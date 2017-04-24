using com.tencent.pandora.MiniJSON;
using System;
using System.Collections.Generic;
using System.IO;

namespace com.tencent.pandora
{
	public class RemoteConfig
	{
		public class AssetInfo
		{
			public string name;

			public string url;

			public string md5;

			public int size;

			public override string ToString()
			{
				return this.name + " " + this.url;
			}
		}

		public int ruleId;

		public bool totalSwitch;

		public bool isDebug;

		public bool isNetLog;

		public int netLogLevel;

		public string brokerHost;

		public int brokerPort;

		public string brokerAlternateIp1;

		public string brokerAlternateIp2;

		public Dictionary<string, bool> functionSwitchDict;

		public Dictionary<string, List<RemoteConfig.AssetInfo>> assetInfoListDict;

		public Dictionary<string, RemoteConfig.AssetInfo> assetInfoDict;

		public bool IsEmpty
		{
			get;
			private set;
		}

		public bool IsError
		{
			get;
			private set;
		}

		public RemoteConfig(string response)
		{
			this.Parse(response);
		}

		public bool GetFunctionSwitch(string functionName)
		{
			return this.functionSwitchDict.ContainsKey(functionName) && this.functionSwitchDict[functionName];
		}

		public string GetAssetPath(string assetName)
		{
			if (this.assetInfoDict.ContainsKey(assetName))
			{
				return this.assetInfoDict[assetName].url;
			}
			return string.Empty;
		}

		public RemoteConfig.AssetInfo GetAssetInfo(string name)
		{
			if (this.assetInfoDict.ContainsKey(name))
			{
				return this.assetInfoDict[name];
			}
			return null;
		}

		private void Parse(string response)
		{
			try
			{
				if (response == "{}")
				{
					this.IsError = true;
				}
				else
				{
					Dictionary<string, object> content = Json.Deserialize(response) as Dictionary<string, object>;
					Pandora.Instance.IsDebug = (this.ParseIntField(content, "isDebug", 0) == 1);
					this.ruleId = this.ParseIntField(content, "id", 0);
					if (this.ruleId == 0)
					{
						Logger.Log("<color=#ff0000>没有匹配到任何规则</color>");
						this.IsEmpty = true;
					}
					else
					{
						this.totalSwitch = (this.ParseIntField(content, "totalSwitch", -1) == 1);
						if (!this.totalSwitch)
						{
							Logger.Log("<color=#ff0000>总量开关关闭，规则Id： " + this.ruleId.ToString() + "</color>");
							this.IsEmpty = true;
						}
						else
						{
							this.functionSwitchDict = this.ParseFuntionSwitch(content);
							this.isNetLog = (this.ParseIntField(content, "isNetLog", 1) == 1);
							this.netLogLevel = this.ParseIntField(content, "log_level", 0);
							this.brokerHost = this.ParseStringField(content, "ip");
							this.brokerPort = this.ParseIntField(content, "port", 0);
							if (string.IsNullOrEmpty(this.brokerHost) || this.brokerPort == 0)
							{
								string text = "Broker域名或端口配置错误，规则Id： " + this.ruleId.ToString();
								Logger.LogError(text);
								Pandora.Instance.ReportError(text, 0);
								this.IsError = true;
							}
							else
							{
								this.brokerAlternateIp1 = this.ParseStringField(content, "cap_ip1");
								this.brokerAlternateIp2 = this.ParseStringField(content, "cap_ip2");
								if (string.IsNullOrEmpty(this.brokerAlternateIp1) || string.IsNullOrEmpty(this.brokerAlternateIp2))
								{
									Logger.LogWarning("Broker的备选IP1或IP2没有配置");
								}
								bool flag;
								this.assetInfoDict = this.ParseAssetInfoDict(content, out flag);
								if (flag)
								{
									this.IsError = true;
								}
								else
								{
									this.assetInfoListDict = this.ParseAssetInfoListDict(content, this.assetInfoDict, out flag);
									if (flag)
									{
										this.IsError = true;
									}
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				string text2 = "解析RemoteConfig发生错误： " + ex.Message;
				Logger.LogError(text2);
				Pandora.Instance.ReportError(text2, 0);
				this.IsError = true;
			}
		}

		private int ParseIntField(Dictionary<string, object> content, string fieldName, int defaultValue = -1)
		{
			int result = defaultValue;
			if (content.ContainsKey(fieldName))
			{
				result = Convert.ToInt32(content[fieldName]);
			}
			return result;
		}

		public ushort ParseUShortField(Dictionary<string, object> content, string fieldName, ushort defaultValue = 0)
		{
			ushort result = defaultValue;
			if (content.ContainsKey(fieldName))
			{
				result = Convert.ToUInt16(content[fieldName]);
			}
			return result;
		}

		private string ParseStringField(Dictionary<string, object> content, string fieldName)
		{
			string result = string.Empty;
			if (content.ContainsKey(fieldName))
			{
				result = (content[fieldName] as string);
			}
			return result;
		}

		private Dictionary<string, bool> ParseFuntionSwitch(Dictionary<string, object> content)
		{
			Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
			string text = this.ParseStringField(content, "function_switch");
			if (!string.IsNullOrEmpty(text))
			{
				string[] array = text.Split(new char[]
				{
					','
				});
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text2 = array2[i];
					string[] array3 = text2.Split(new char[]
					{
						':'
					});
					if (array3.Length == 2)
					{
						string key = array3[0];
						int num = Convert.ToInt32(array3[1]);
						dictionary[key] = (num == 1);
					}
				}
			}
			return dictionary;
		}

		private Dictionary<string, RemoteConfig.AssetInfo> ParseAssetInfoDict(Dictionary<string, object> content, out bool hasError)
		{
			hasError = false;
			Dictionary<string, RemoteConfig.AssetInfo> dictionary = new Dictionary<string, RemoteConfig.AssetInfo>();
			if (!content.ContainsKey("sourcelist"))
			{
				Logger.LogError("文件列表配置错误，未发现sourcelist字段");
				hasError = true;
				return dictionary;
			}
			Dictionary<string, object> dictionary2 = content["sourcelist"] as Dictionary<string, object>;
			if (dictionary2 == null || !dictionary2.ContainsKey("count") || !dictionary2.ContainsKey("list"))
			{
				Logger.LogError("文件列表配置错误，sourcelist字段中count或list不存在");
				hasError = true;
				return dictionary;
			}
			int num = Convert.ToInt32(dictionary2["count"]);
			List<object> list = dictionary2["list"] as List<object>;
			if (num != list.Count)
			{
				Logger.LogError("文件列表配置错误，sourcelist字段中count值或list内容长度值不一致");
				hasError = true;
				return dictionary;
			}
			foreach (object current in list)
			{
				Dictionary<string, object> dictionary3 = current as Dictionary<string, object>;
				if (!dictionary3.ContainsKey("url") || !dictionary3.ContainsKey("luacmd5") || !dictionary3.ContainsKey("size"))
				{
					string text = "文件列表配置错误，sourcelist.list某一个文件的url，luacmd5，size字段不存在";
					Logger.LogError(text);
					Pandora.Instance.ReportError(text, 0);
					hasError = true;
					Dictionary<string, RemoteConfig.AssetInfo> result = dictionary;
					return result;
				}
				RemoteConfig.AssetInfo assetInfo = new RemoteConfig.AssetInfo();
				assetInfo.url = (dictionary3["url"] as string);
				assetInfo.url = assetInfo.url.ToLower().Replace("http://", "https://");
				assetInfo.size = (int)((long)dictionary3["size"]);
				assetInfo.md5 = (dictionary3["luacmd5"] as string);
				assetInfo.name = Path.GetFileName(assetInfo.url);
				if (string.IsNullOrEmpty(assetInfo.name) || string.IsNullOrEmpty(assetInfo.md5) || assetInfo.size <= 0 || string.IsNullOrEmpty(assetInfo.url))
				{
					string text2 = "文件列表配置错误，sourcelist.list某一个文件的url，luacmd5，size字段内容不正确";
					Logger.LogError(text2);
					Pandora.Instance.ReportError(text2, 0);
					hasError = true;
					Dictionary<string, RemoteConfig.AssetInfo> result = dictionary;
					return result;
				}
				if (dictionary.ContainsKey(assetInfo.name))
				{
					Logger.LogError("文件列表配置错误，sourcelist.list存在同名的资源配置信息");
					hasError = true;
					Dictionary<string, RemoteConfig.AssetInfo> result = dictionary;
					return result;
				}
				dictionary.Add(assetInfo.name, assetInfo);
			}
			return dictionary;
		}

		private Dictionary<string, List<RemoteConfig.AssetInfo>> ParseAssetInfoListDict(Dictionary<string, object> content, Dictionary<string, RemoteConfig.AssetInfo> fileInfoDict, out bool hasError)
		{
			hasError = false;
			Dictionary<string, List<RemoteConfig.AssetInfo>> dictionary = new Dictionary<string, List<RemoteConfig.AssetInfo>>();
			string text = this.ParseStringField(content, "dependency");
			if (string.IsNullOrEmpty(text))
			{
				string text2 = "依赖文件列表字段dependecy内容不存在或内容为空";
				Logger.LogError(text2);
				Pandora.Instance.ReportError(text2, 0);
				hasError = true;
				return dictionary;
			}
			string[] array = text.Split(new char[]
			{
				'|'
			});
			for (int i = 0; i < array.Length; i++)
			{
				string text3 = array[i];
				string[] array2 = text3.Split(new char[]
				{
					':'
				});
				if (array2.Length != 2)
				{
					string text4 = "依赖文件列表字段dependecy内容中Group的内容格式配置错误";
					Logger.LogError(text4);
					Pandora.Instance.ReportError(text4, 0);
					hasError = true;
					return dictionary;
				}
				string key = array2[0];
				string text5 = array2[1];
				string[] array3 = text5.Split(new char[]
				{
					','
				});
				List<RemoteConfig.AssetInfo> list = new List<RemoteConfig.AssetInfo>();
				for (int j = 0; j < array3.Length; j++)
				{
					string text6 = array3[j];
					if (text6.StartsWith("@"))
					{
						string key2 = text6.Substring(1);
						if (!dictionary.ContainsKey(key2))
						{
							string text7 = "依赖文件列表字段dependecy内容中关于其他Group的依赖配置错误，被依赖的Group需要配置在右边";
							Logger.LogError(text7);
							Pandora.Instance.ReportError(text7, 0);
							hasError = true;
							return dictionary;
						}
						list.AddRange(dictionary[key2]);
					}
					else
					{
						if (!fileInfoDict.ContainsKey(text6))
						{
							string text8 = "依赖文件列表字段dependecy内容中的文件名在sourcelist中不存在";
							Logger.LogError(text8);
							Pandora.Instance.ReportError(text8, 0);
							hasError = true;
							return dictionary;
						}
						list.Add(fileInfoDict[text6]);
					}
				}
				if (dictionary.ContainsKey(key))
				{
					string text9 = "依赖文件列表字段dependecy内容中存在重复的GroupName";
					Logger.LogError(text9);
					Pandora.Instance.ReportError(text9, 0);
					hasError = true;
					return dictionary;
				}
				dictionary.Add(key, list);
			}
			return dictionary;
		}
	}
}
