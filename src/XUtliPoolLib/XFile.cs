using System;
using System.IO;
using System.Text;

namespace XUtliPoolLib
{
	public class XFile
	{
		public static void AppendAllText(string path, string contents)
		{
			File.AppendAllText(path, contents);
		}

		public static void AppendAllText(string path, string contents, Encoding encoding)
		{
			File.AppendAllText(path, contents, encoding);
		}

		public static StreamWriter AppendText(string path)
		{
			return File.AppendText(path);
		}

		public static void Copy(string sourceFileName, string destFileName)
		{
			File.Copy(sourceFileName, destFileName);
		}

		public static void Copy(string sourceFileName, string destFileName, bool overwrite)
		{
			File.Copy(sourceFileName, destFileName, overwrite);
		}

		public static FileStream Create(string path)
		{
			return File.Create(path);
		}

		public static FileStream Create(string path, int bufferSize)
		{
			return File.Create(path, bufferSize);
		}

		public static StreamWriter CreateText(string path)
		{
			return File.CreateText(path);
		}

		public static void Decrypt(string path)
		{
			File.Decrypt(path);
		}

		public static void Delete(string path)
		{
			File.Delete(path);
		}

		public static void Encrypt(string path)
		{
			File.Encrypt(path);
		}

		public static bool Exists(string path)
		{
			return File.Exists(path);
		}

		public static FileAttributes GetAttributes(string path)
		{
			return File.GetAttributes(path);
		}

		public static DateTime GetCreationTime(string path)
		{
			return File.GetCreationTime(path);
		}

		public static DateTime GetCreationTimeUtc(string path)
		{
			return File.GetCreationTimeUtc(path);
		}

		public static DateTime GetLastAccessTime(string path)
		{
			return File.GetLastAccessTime(path);
		}

		public static DateTime GetLastWriteTime(string path)
		{
			return File.GetLastWriteTime(path);
		}

		public static DateTime GetLastWriteTimeUtc(string path)
		{
			return File.GetLastWriteTimeUtc(path);
		}

		public static void Move(string sourceFileName, string destFileName)
		{
			File.Move(sourceFileName, destFileName);
		}

		public static FileStream Open(string path, FileMode mode)
		{
			return File.Open(path, mode);
		}

		public static FileStream OpenRead(string path)
		{
			return File.OpenRead(path);
		}

		public static StreamReader OpenText(string path)
		{
			return File.OpenText(path);
		}

		public static FileStream OpenWrite(string path)
		{
			return File.OpenWrite(path);
		}

		public static byte[] ReadAllBytes(string path)
		{
			return File.ReadAllBytes(path);
		}

		public static string[] ReadAllLines(string path)
		{
			return File.ReadAllLines(path);
		}

		public static string[] ReadAllLines(string path, Encoding encoding)
		{
			return File.ReadAllLines(path, encoding);
		}

		public static string ReadAllText(string path)
		{
			return File.ReadAllText(path);
		}

		public static string ReadAllText(string path, Encoding encoding)
		{
			return File.ReadAllText(path, encoding);
		}

		public static void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName)
		{
			File.Replace(sourceFileName, destinationFileName, destinationBackupFileName);
		}

		public static void WriteAllBytes(string path, byte[] bytes)
		{
			File.WriteAllBytes(path, bytes);
		}

		public static void WriteAllLines(string path, string[] contents)
		{
			File.WriteAllLines(path, contents);
		}

		public static void WriteAllLines(string path, string[] contents, Encoding encoding)
		{
			File.WriteAllLines(path, contents, encoding);
		}

		public static void WriteAllText(string path, string contents)
		{
			File.WriteAllText(path, contents);
		}

		public static void WriteAllText(string path, string contents, Encoding encoding)
		{
			File.WriteAllText(path, contents, encoding);
		}
	}
}
