using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using XUpdater;

namespace XUtliPoolLib
{
	public class XFileLog : MonoBehaviour
	{
		private const int QUEUE_SIZE = 20;

		private static Queue<string> CustomLogQueue = new Queue<string>();

		public static string RoleName = "";

		public static string ServerID = "";

		public static string OpenID = "";

		private static Application.LogCallback callBack = null;

		private string _outpath;

		public bool _logOpen = true;

		private bool _firstWrite = true;

		private void Start()
		{
			this._outpath = Application.persistentDataPath + string.Format("/{0}{1}{2}_{3}{4}{5}.log", new object[]
			{
				DateTime.Now.Year.ToString().PadLeft(2, '0'),
				DateTime.Now.Month.ToString().PadLeft(2, '0'),
				DateTime.Now.Day.ToString().PadLeft(2, '0'),
				DateTime.Now.Hour.ToString().PadLeft(2, '0'),
				DateTime.Now.Minute.ToString().PadLeft(2, '0'),
				DateTime.Now.Second.ToString().PadLeft(2, '0')
			});
			string path = (Application.platform == RuntimePlatform.IPhonePlayer) ? ("/private" + Application.persistentDataPath) : Application.persistentDataPath;
			if (Directory.Exists(path))
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(path);
				FileInfo[] files = directoryInfo.GetFiles();
				if (files != null)
				{
					for (int i = 0; i < files.Length; i++)
					{
						string a = files[i].Name.Substring(files[i].Name.LastIndexOf(".") + 1);
						if (!(a != "log") && DateTime.Now.Subtract(files[i].CreationTime).TotalDays > 1.0)
						{
							try
							{
								files[i].Delete();
							}
							catch
							{
								XSingleton<XDebug>.singleton.AddErrorLog("Del Log File Error!!!", null, null, null, null, null);
							}
						}
					}
				}
			}
			XFileLog.callBack = new Application.LogCallback(this.HandleLog);
			XSingleton<XDebug>.singleton.AddLog(this._outpath, null, null, null, null, null, XDebugColor.XDebug_None);
		}

		public void HandleLog(string logString, string stackTrace, LogType type)
		{
			if (!this._firstWrite)
			{
				return;
			}
			if (this._logOpen)
			{
				this.WriterLog(logString);
			}
			if (type == LogType.Error || type == LogType.Exception)
			{
				this._firstWrite = false;
				this.Log(new object[]
				{
					logString
				});
				this.Log(new object[]
				{
					stackTrace
				});
				string text = string.Format("{0}\n{1}\n", logString, stackTrace);
				while (XFileLog.CustomLogQueue.Count > 0)
				{
					text = string.Format("{0}\n{1}", text, XFileLog.CustomLogQueue.Dequeue());
				}
				this.SendBuglyReport(text);
			}
		}

		public void WriterLog(string logString)
		{
			using (StreamWriter streamWriter = new StreamWriter(this._outpath, true, Encoding.UTF8))
			{
				streamWriter.WriteLine(string.Format("[{0}]{1}", string.Format("{0}/{1}/{2} {3}:{4}:{5}.{6}", new object[]
				{
					DateTime.Now.Year,
					DateTime.Now.Month.ToString().PadLeft(2, '0'),
					DateTime.Now.Day.ToString().PadLeft(2, '0'),
					DateTime.Now.Hour.ToString().PadLeft(2, '0'),
					DateTime.Now.Minute.ToString().PadLeft(2, '0'),
					DateTime.Now.Second.ToString().PadLeft(2, '0'),
					DateTime.Now.Millisecond.ToString().PadLeft(3, '0')
				}), logString));
				XSingleton<XUpdater>.singleton.XPlatform.SetNoBackupFlag(this._outpath);
			}
		}

		private void Update()
		{
			Application.RegisterLogCallback(XFileLog.callBack);
		}

		public void Log(params object[] objs)
		{
			string text = "";
			for (int i = 0; i < objs.Length; i++)
			{
				if (i == 0)
				{
					text += objs[i].ToString();
				}
				else
				{
					text = text + ", " + objs[i].ToString();
				}
			}
			this.WriterLog(text);
		}

		public void SendBuglyReport(string logstring)
		{
			if (Application.platform != RuntimePlatform.WindowsEditor && Application.platform != RuntimePlatform.OSXEditor)
			{
				IXBuglyMgr iXBuglyMgr = XUpdater.XGameRoot.GetComponent("XBuglyMgr") as IXBuglyMgr;
				iXBuglyMgr.ReportCrashToBugly(XFileLog.ServerID, XFileLog.RoleName, XFileLog.OpenID, XSingleton<XUpdater>.singleton.Version, Time.realtimeSinceStartup.ToString(), logstring);
			}
		}

		public static void AddCustomLog(string customLog)
		{
			XFileLog.CustomLogQueue.Enqueue(customLog);
			while (XFileLog.CustomLogQueue.Count > 20)
			{
				XFileLog.CustomLogQueue.Dequeue();
			}
		}
	}
}
