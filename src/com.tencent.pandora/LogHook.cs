using com.tencent.pandora.MiniJSON;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace com.tencent.pandora
{
	public class LogHook : MonoBehaviour
	{
		private const string PANDORA_NAMESPACE = "com.tencent.pandora";

		private List<ILogRecorder> _recorderList = new List<ILogRecorder>();

		private bool _localLogSetting;

		private bool _isWriterAdded;

		private bool _isConsoleAdded;

		protected void Awake()
		{
			this.ReadSettings();
		}

		private void ReadSettings()
		{
			try
			{
				string path = LocalDirectoryHelper.GetSettingsFolderPath() + "/settings.txt";
				if (File.Exists(path))
				{
					string json = File.ReadAllText(path);
					Dictionary<string, object> dictionary = Json.Deserialize(json) as Dictionary<string, object>;
					if (dictionary.ContainsKey("log"))
					{
						this._localLogSetting = (dictionary["log"] as string == "1");
					}
				}
			}
			catch
			{
			}
		}

		private void Update()
		{
			if (Logger.Enable && (Application.platform == RuntimePlatform.WindowsEditor || !PandoraSettings.IsProductEnvironment || (PandoraSettings.IsProductEnvironment && Pandora.Instance.IsDebug) || this._localLogSetting))
			{
				if (Logger.HandleLog == null)
				{
					Logger.HandleLog = new Action<string, string, Logger.Level>(this.HandleLog);
				}
				if (!this._isWriterAdded)
				{
					this._isWriterAdded = true;
					this._recorderList.Add(new LogWriter());
				}
				if (!this._isConsoleAdded && Pandora.Instance.IsDebug && Pandora.Instance.GetRemoteConfig() != null && Pandora.Instance.GetRemoteConfig().GetFunctionSwitch("console"))
				{
					this._isConsoleAdded = true;
					this._recorderList.Add(base.gameObject.AddComponent<LogConsole>());
				}
			}
			else
			{
				Logger.HandleLog = null;
			}
		}

		public void HandleLog(string message, string stackTrace, Logger.Level level)
		{
			if (this._recorderList.Count == 0)
			{
				return;
			}
			Log log = new Log
			{
				message = message,
				stackTrace = stackTrace,
				level = level
			};
			for (int i = 0; i < this._recorderList.Count; i++)
			{
				this._recorderList[i].Add(log);
			}
		}
	}
}
