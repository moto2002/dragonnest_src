using System;
using System.IO;
using UnityEngine;

namespace com.tencent.pandora
{
	internal class LocalDirectoryHelper
	{
		private const int EXPIRE_DAYS = 7;

		private static string _root;

		public static void Initialize()
		{
			LocalDirectoryHelper.CreateIfNotExists();
			LocalDirectoryHelper.DeleteExpiredAsset();
			LocalDirectoryHelper.DeleteExpiredCookie();
			LocalDirectoryHelper.DeleteExpiredLog();
		}

		public static void CreateIfNotExists()
		{
			Directory.CreateDirectory(LocalDirectoryHelper.GetProgramAssetFolderPath());
			Directory.CreateDirectory(LocalDirectoryHelper.GetAssetFolderPath());
			Directory.CreateDirectory(LocalDirectoryHelper.GetCookieFolderPath());
			Directory.CreateDirectory(LocalDirectoryHelper.GetLogFolderPath());
			Directory.CreateDirectory(LocalDirectoryHelper.GetSettingsFolderPath());
		}

		private static string GetPandoraRoot()
		{
			if (string.IsNullOrEmpty(LocalDirectoryHelper._root))
			{
				LocalDirectoryHelper._root = Path.Combine(PandoraSettings.GetTemporaryCachePath(), "Pandora");
			}
			return LocalDirectoryHelper._root;
		}

		public static string GetLogFolderPath()
		{
			return Path.Combine(LocalDirectoryHelper.GetPandoraRoot(), "logs");
		}

		public static string GetSettingsFolderPath()
		{
			return Path.Combine(LocalDirectoryHelper.GetPandoraRoot(), "settings");
		}

		public static string GetProgramAssetFolderPath()
		{
			return Path.Combine(LocalDirectoryHelper.GetPandoraRoot(), "program");
		}

		public static string GetCookieFolderPath()
		{
			return Path.Combine(LocalDirectoryHelper.GetPandoraRoot(), "cookies");
		}

		public static string GetProgramAssetMetaPath()
		{
			return Path.Combine(LocalDirectoryHelper.GetProgramAssetFolderPath(), "meta.txt");
		}

		public static string GetAssetFolderPath()
		{
			return Path.Combine(LocalDirectoryHelper.GetPandoraRoot(), "assets");
		}

		public static string GetStreamingAssetsUrl()
		{
			return PandoraSettings.GetFileProtocolToken() + Application.streamingAssetsPath + "/Pandora";
		}

		public static bool IsStreamingAssetsExists(string name)
		{
			return File.Exists(Application.streamingAssetsPath + "/Pandora/" + name);
		}

		public static void DeleteExpiredCookie()
		{
			LocalDirectoryHelper.DeleteExpiredAsset(LocalDirectoryHelper.GetCookieFolderPath());
		}

		public static void DeleteExpiredAsset()
		{
			LocalDirectoryHelper.DeleteExpiredAsset(LocalDirectoryHelper.GetAssetFolderPath());
		}

		public static void DeleteExpiredLog()
		{
			LocalDirectoryHelper.DeleteExpiredAsset(LocalDirectoryHelper.GetLogFolderPath());
		}

		private static void DeleteExpiredAsset(string directory)
		{
			try
			{
				string[] files = Directory.GetFiles(directory);
				for (int i = 0; i < files.Length; i++)
				{
					string text = files[i];
					DateTime lastWriteTimeUtc = File.GetLastWriteTimeUtc(text);
					double totalDays = DateTime.UtcNow.Subtract(lastWriteTimeUtc).TotalDays;
					if (totalDays >= 7.0)
					{
						File.Delete(text);
						Logger.Log("删除过期文件： " + text);
					}
				}
			}
			catch (Exception ex)
			{
				string text2 = "删除文件发生异常，directory: " + directory + "\n" + ex.Message;
				Logger.LogError(text2);
				Pandora.Instance.ReportError(text2, 0);
			}
		}

		public static void Clean()
		{
			LocalDirectoryHelper.DeleteDirectoryAssets(LocalDirectoryHelper.GetCookieFolderPath());
			LocalDirectoryHelper.DeleteDirectoryAssets(LocalDirectoryHelper.GetLogFolderPath());
		}

		public static void DeleteCookies()
		{
			LocalDirectoryHelper.DeleteDirectoryAssets(LocalDirectoryHelper.GetCookieFolderPath());
		}

		private static void DeleteDirectoryAssets(string directory)
		{
			try
			{
				string[] files = Directory.GetFiles(directory);
				for (int i = 0; i < files.Length; i++)
				{
					File.Delete(files[i]);
				}
			}
			catch (Exception ex)
			{
				string text = "删除文件发生异常，directory: " + directory + "\n" + ex.Message;
				Logger.LogError(text);
				Pandora.Instance.ReportError(text, 0);
			}
		}

		public static void DeleteAssetByUrl(string url)
		{
			try
			{
				string path = url.Replace(PandoraSettings.GetFileProtocolToken(), string.Empty);
				if (File.Exists(path))
				{
					File.Delete(path);
				}
			}
			catch (Exception ex)
			{
				string text = "删除文件发生异常，Url: " + url + "\n" + ex.Message;
				Logger.LogError(text);
				Pandora.Instance.ReportError(text, 0);
			}
		}
	}
}
