using System;
using System.Text;
using System.Threading;
using UnityEngine;
using XUpdater;

namespace XUtliPoolLib
{
	public class XDebug : XSingleton<XDebug>
	{
		private int _OutputChannels;

		private IPlatform _platform;

		private bool _showLog = true;

		private bool _showTimeStick = true;

		private StringBuilder _buffer = new StringBuilder();

		public XDebug()
		{
			this._OutputChannels = 5;
		}

		public void Init(IPlatform platform, XFileLog log)
		{
			this._platform = XSingleton<XUpdater>.singleton.XPlatform;
		}

		public void AddLog(string log1, string log2 = null, string log3 = null, string log4 = null, string log5 = null, string log6 = null, XDebugColor color = XDebugColor.XDebug_None)
		{
			if (this._platform != null && !this._platform.IsPublish())
			{
				this.AddLog(XDebugChannel.XDebug_Default, log1, log2, log3, log4, log5, log6, color);
			}
		}

		public void AddLog(XDebugChannel channel, string log1, string log2 = null, string log3 = null, string log4 = null, string log5 = null, string log6 = null, XDebugColor color = XDebugColor.XDebug_None)
		{
			if (this._showLog && this._platform != null && !this._platform.IsPublish() && (this._OutputChannels & (int)channel) > 0)
			{
				this._buffer.Length = 0;
				this._buffer.Append(log1).Append(log2).Append(log3).Append(log4).Append(log5).Append(log6);
				if (color == XDebugColor.XDebug_Green)
				{
					this._buffer.Insert(0, "<color=green>");
					this._buffer.Append("</color>");
				}
				if (this._showTimeStick)
				{
					if (Thread.CurrentThread.ManagedThreadId == XSingleton<XUpdater>.singleton.ManagedThreadId)
					{
						this._buffer.Append(" (at Frame: ").Append(Time.frameCount).Append(" sec: ").Append(Time.realtimeSinceStartup.ToString("F3")).Append(')');
					}
					else if (string.IsNullOrEmpty(Thread.CurrentThread.Name))
					{
						this._buffer.Append(" (from anonymous thread").Append(" with id ").Append(Thread.CurrentThread.ManagedThreadId).Append(")");
					}
					else
					{
						this._buffer.Append(" (from thread ").Append(Thread.CurrentThread.Name).Append(" with id ").Append(Thread.CurrentThread.ManagedThreadId).Append(")");
					}
				}
				if (color == XDebugColor.XDebug_Red)
				{
					Debug.LogError(this._buffer);
					return;
				}
				if (color == XDebugColor.XDebug_Yellow)
				{
					Debug.LogWarning(this._buffer);
					return;
				}
				Debug.Log(this._buffer);
			}
		}

		public void AddGreenLog(string log1, string log2 = null, string log3 = null, string log4 = null, string log5 = null, string log6 = null)
		{
			if (this._platform != null && !this._platform.IsPublish())
			{
				this.AddLog(XDebugChannel.XDebug_Default, log1, log2, log3, log4, log5, log6, XDebugColor.XDebug_Green);
			}
		}

		public void AddWarningLog(string log1, string log2 = null, string log3 = null, string log4 = null, string log5 = null, string log6 = null)
		{
			if (this._platform != null && !this._platform.IsPublish())
			{
				this.AddLog(XDebugChannel.XDebug_Default, log1, log2, log3, log4, log5, log6, XDebugColor.XDebug_Yellow);
			}
		}

		public void AddWarningLog2(string format, params object[] args)
		{
			if (this._showLog && this._platform != null && !this._platform.IsPublish())
			{
				Debug.LogWarning(string.Format(format, args));
			}
		}

		public void AddErrorLog2(string format, params object[] args)
		{
			if (this._showLog && this._platform != null && !this._platform.IsPublish())
			{
				Debug.LogError(string.Format(format, args));
			}
		}

		public void AddErrorLog(string log1, string log2 = null, string log3 = null, string log4 = null, string log5 = null, string log6 = null)
		{
			this._buffer.Length = 0;
			if (Thread.CurrentThread.ManagedThreadId == XSingleton<XUpdater>.singleton.ManagedThreadId)
			{
				this._buffer.Append(log1).Append(log2).Append(log3).Append(log4).Append(log5).Append(log6).Append(" (at Frame: ").Append(Time.frameCount).Append(" sec: ").Append(Time.realtimeSinceStartup.ToString("F3")).Append(')');
			}
			else
			{
				this._buffer.Append(log1).Append(log2).Append(log3).Append(log4).Append(log5).Append(log6);
			}
			XFileLog.AddCustomLog("AddErrorLog:  " + this._buffer);
			this.AddLog(XDebugChannel.XDebug_Default, log1, log2, log3, log4, log5, log6, XDebugColor.XDebug_Red);
		}

		public override bool Init()
		{
			return true;
		}

		public override void Uninit()
		{
		}

		public void BeginProfile(string title)
		{
		}

		public void RegisterGroupProfile(string title)
		{
		}

		public void BeginGroupProfile(string title)
		{
		}

		public void EndProfile()
		{
		}

		public void EndGroupProfile(string title)
		{
		}

		public void InitProfiler()
		{
		}

		public void PrintProfiler()
		{
		}
	}
}
