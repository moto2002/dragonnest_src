using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using XUpdater;

namespace XUtliPoolLib
{
	public sealed class XTableAsyncLoader
	{
		private bool _executing;

		private List<XFileReadAsync> _task_list = new List<XFileReadAsync>();

		private OnLoadedCallback _call_back;

		private XFileReadAsync currentXfra;

		public static int currentThreadCount = 0;

		public static readonly int AsyncPerTime = 8;

		public static Dictionary<string, string> tableScriptMap;

		public bool IsDone
		{
			get
			{
				bool flag = false;
				if (this.currentXfra == null)
				{
					if (XTableAsyncLoader.currentThreadCount < XTableAsyncLoader.AsyncPerTime)
					{
						XTableAsyncLoader.currentThreadCount++;
					}
					flag = this.InnerExecute();
				}
				if (flag)
				{
					if (this._call_back != null)
					{
						this._call_back();
						this._call_back = null;
					}
					this._executing = false;
				}
				return flag;
			}
		}

		public void AddTask(string location, CVSReader reader)
		{
			XFileReadAsync xFileReadAsync = new XFileReadAsync();
			xFileReadAsync.Location = location;
			xFileReadAsync.Reader = reader;
			this._task_list.Add(xFileReadAsync);
		}

		private bool InnerExecute()
		{
			if (this._task_list.Count <= 0)
			{
				return true;
			}
			if (XTableAsyncLoader.currentThreadCount <= 0)
			{
				return false;
			}
			XTableAsyncLoader.currentThreadCount--;
			this.currentXfra = this._task_list[this._task_list.Count - 1];
			this._task_list.RemoveAt(this._task_list.Count - 1);
			this.ReadFileAsync(this.currentXfra);
			return false;
		}

		public bool Execute(OnLoadedCallback callback = null)
		{
			if (this._executing)
			{
				return false;
			}
			this._call_back = callback;
			this._executing = true;
			this.InnerExecute();
			return true;
		}

		public static void DumpTableScriptMap()
		{
			TableMap tableMap = null;
			string path = "Assets/Editor/ResImporter/ImporterData/Table/Table.xml";
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(TableMap));
				using (FileStream fileStream = new FileStream(path, FileMode.Open))
				{
					tableMap = (xmlSerializer.Deserialize(fileStream) as TableMap);
				}
				if (tableMap != null)
				{
					tableMap.tableScriptMap.Clear();
					foreach (KeyValuePair<string, string> current in XTableAsyncLoader.tableScriptMap)
					{
						TableScriptMap tableScriptMap = new TableScriptMap();
						tableScriptMap.table = current.Key;
						tableScriptMap.script = current.Value;
						tableMap.tableScriptMap.Add(tableScriptMap);
					}
					using (FileStream fileStream2 = new FileStream(path, FileMode.Create))
					{
						StreamWriter textWriter = new StreamWriter(fileStream2, Encoding.UTF8);
						XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
						xmlSerializerNamespaces.Add(string.Empty, string.Empty);
						xmlSerializer.Serialize(textWriter, tableMap, xmlSerializerNamespaces);
					}
				}
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddWarningLog(ex.Message, null, null, null, null, null);
			}
		}

		public static void AddTableScript(string location, Type reader)
		{
			IPlatform xPlatform = XSingleton<XUpdater>.singleton.XPlatform;
			if (xPlatform != null && xPlatform.IsEdior())
			{
				if (XTableAsyncLoader.tableScriptMap == null)
				{
					XTableAsyncLoader.tableScriptMap = new Dictionary<string, string>();
				}
				string key = location.Replace("Table/", "");
				XTableAsyncLoader.tableScriptMap[key] = reader.Name;
			}
		}

		private void ReadFileAsync(XFileReadAsync xfra)
		{
			XTableAsyncLoader.AddTableScript(xfra.Location, xfra.Reader.GetType());
			xfra.Data = new MemoryStream();
			if (!XSingleton<XResourceLoaderMgr>.singleton.ReadText(xfra.Location, xfra.Data as MemoryStream, false))
			{
				XResourceLoaderMgr.LoadErrorLog(xfra.Location);
				xfra.Data.Close();
				xfra.Data = null;
				xfra.IsDone = true;
				this.currentXfra = null;
				return;
			}
			ThreadPool.QueueUserWorkItem(delegate(object state)
			{
				try
				{
					if (!xfra.Reader.ReadFile(xfra.Data))
					{
						XSingleton<XDebug>.singleton.AddErrorLog("in File: ", xfra.Location, xfra.Reader.error, null, null, null);
					}
					else
					{
						xfra.IsDone = true;
					}
				}
				catch (Exception ex)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(ex.Message, " in File: ", xfra.Location, xfra.Reader.error, null, null);
				}
				if (xfra.Data != null)
				{
					xfra.Data.Close();
					xfra.Data = null;
				}
				this.currentXfra = null;
			});
		}
	}
}
