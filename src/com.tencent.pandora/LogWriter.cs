using System;
using System.IO;
using System.Text;

namespace com.tencent.pandora
{
	internal class LogWriter : ILogRecorder
	{
		private string _currentLogPath;

		public void Add(Log log)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(log.level.ToString());
			stringBuilder.Append("  ");
			stringBuilder.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
			stringBuilder.Append("\n");
			stringBuilder.Append(log.message);
			stringBuilder.Append("\n");
			stringBuilder.Append(log.stackTrace);
			stringBuilder.Append("\n");
			this.Write(stringBuilder.ToString());
		}

		private void Write(string content)
		{
			try
			{
				string logFilePath = this.GetLogFilePath();
				if (logFilePath != this._currentLogPath)
				{
					this._currentLogPath = logFilePath;
				}
				File.AppendAllText(this._currentLogPath, content);
			}
			catch
			{
			}
		}

		private string GetLogFilePath()
		{
			return LocalDirectoryHelper.GetLogFolderPath() + "/log-" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
		}

		public void Dispose()
		{
		}
	}
}
