using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace com.tencent.pandora
{
	public class CachedFileMd5Helper
	{
		private static MD5CryptoServiceProvider MD5_SERVICE = new MD5CryptoServiceProvider();

		public static string GetFileMd5(byte[] fileBytes)
		{
			if (fileBytes.Length == 0)
			{
				return string.Empty;
			}
			byte[] array = CachedFileMd5Helper.MD5_SERVICE.ComputeHash(fileBytes);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString("X2"));
			}
			string str = stringBuilder.ToString();
			string str2 = "pandora20151019";
			byte[] bytes = Encoding.UTF8.GetBytes(str2 + str);
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(bytes, 0, bytes.Length);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			byte[] array2 = CachedFileMd5Helper.MD5_SERVICE.ComputeHash(memoryStream);
			memoryStream.Dispose();
			stringBuilder = new StringBuilder();
			for (int j = 0; j < array2.Length; j++)
			{
				stringBuilder.Append(array2[j].ToString("X2"));
			}
			return stringBuilder.ToString();
		}
	}
}
