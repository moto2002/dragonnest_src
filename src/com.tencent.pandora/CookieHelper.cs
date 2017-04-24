using System;
using System.IO;

namespace com.tencent.pandora
{
	internal class CookieHelper
	{
		public static bool Write(string fileName, string content)
		{
			try
			{
				string path = Path.Combine(LocalDirectoryHelper.GetCookieFolderPath(), fileName);
				File.WriteAllText(path, content);
				return true;
			}
			catch (Exception ex)
			{
				string text = string.Concat(new string[]
				{
					"写入Cookie失败， ",
					fileName,
					" ",
					content,
					ex.Message
				});
				Pandora.Instance.ReportError(text, 0);
				Logger.LogError(text);
			}
			return false;
		}

		public static string Read(string fileName)
		{
			try
			{
				string path = Path.Combine(LocalDirectoryHelper.GetCookieFolderPath(), fileName);
				if (File.Exists(path))
				{
					return File.ReadAllText(path);
				}
			}
			catch (Exception ex)
			{
				string text = "读取Cookie失败， " + fileName + ex.Message;
				Pandora.Instance.ReportError(text, 0);
				Logger.LogError(text);
			}
			return string.Empty;
		}
	}
}
