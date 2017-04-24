using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LuaCore
{
	public class Encryption
	{
		public const string Key = "bmc.1001";

		public static string Encrypt(string pToEncrypt)
		{
			return Encryption.Encrypt(pToEncrypt, "bmc.1001");
		}

		public static string Encrypt(string pToEncrypt, string sKey)
		{
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			Encoding encoding = new UTF8Encoding(false);
			byte[] bytes = encoding.GetBytes(pToEncrypt);
			dESCryptoServiceProvider.Key = encoding.GetBytes(sKey);
			dESCryptoServiceProvider.IV = encoding.GetBytes(sKey);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			byte[] array = memoryStream.ToArray();
			return Convert.ToBase64String(array, 0, array.Length);
		}

		public static string Decrypt(string pToDecrypt)
		{
			return Encryption.Decrypt(pToDecrypt, "bmc.1001");
		}

		public static string Decrypt(string pToDecrypt, string sKey)
		{
			Encoding encoding = new UTF8Encoding(false);
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			byte[] array = Convert.FromBase64String(pToDecrypt);
			dESCryptoServiceProvider.Key = encoding.GetBytes(sKey);
			dESCryptoServiceProvider.IV = encoding.GetBytes(sKey);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			return encoding.GetString(memoryStream.ToArray());
		}
	}
}
