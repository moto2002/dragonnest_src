using System;
using System.IO;

namespace XUtliPoolLib
{
	public class XDirectory
	{
		public static DirectoryInfo CreateDirectory(string path)
		{
			return Directory.CreateDirectory(path);
		}

		public static void Delete(string path)
		{
			Directory.Delete(path);
		}

		public static bool Exists(string path)
		{
			return Directory.Exists(path);
		}

		public static DateTime GetCreationTime(string path)
		{
			return Directory.GetCreationTime(path);
		}

		public static string GetCurrentDirectory()
		{
			return Directory.GetCurrentDirectory();
		}

		public static string[] GetDirectories(string path)
		{
			return Directory.GetDirectories(path);
		}

		public static string[] GetDirectories(string path, string searchPattern)
		{
			return Directory.GetDirectories(path, searchPattern);
		}

		public static string[] GetDirectories(string path, string searchPattern, SearchOption searchOption)
		{
			return Directory.GetDirectories(path, searchPattern, searchOption);
		}

		public static string GetDirectoryRoot(string path)
		{
			return Directory.GetDirectoryRoot(path);
		}

		public static string[] GetFiles(string path)
		{
			return Directory.GetFiles(path);
		}

		public static string[] GetFiles(string path, string searchPattern)
		{
			return Directory.GetFiles(path, searchPattern);
		}

		public static string[] GetFileSystemEntries(string path)
		{
			return Directory.GetFileSystemEntries(path);
		}

		public static string[] GetFileSystemEntries(string path, string searchPattern)
		{
			return Directory.GetFileSystemEntries(path, searchPattern);
		}

		public static DirectoryInfo GetParent(string path)
		{
			return Directory.GetParent(path);
		}

		public static void Move(string sourceDirName, string destDirName)
		{
			Directory.Move(sourceDirName, destDirName);
		}
	}
}
