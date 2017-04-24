using System;
using System.IO;
using System.Text;
using Unity.IO.Compression;

namespace com.tencent.pandora
{
	internal class Zlib
	{
		private static byte[] _decompressBuffer = new byte[512];

		public static byte[] Compress(string content)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(content);
			return Zlib.Compress(bytes, 0, bytes.Length);
		}

		public static byte[] Compress(byte[] array, int offset, int count)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (array.Length - offset < count)
			{
				throw new ArgumentException("Invalid argument offset count");
			}
			MemoryStream memoryStream = new MemoryStream();
			using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Compress, true))
			{
				deflateStream.Write(array, offset, count);
			}
			byte[] array2 = new byte[memoryStream.Length];
			memoryStream.Seek(0L, SeekOrigin.Begin);
			memoryStream.Read(array2, 0, array2.Length);
			memoryStream.Dispose();
			ulong num = 1uL;
			num = Zlib.Adler32(num, array);
			byte[] array3 = new byte[]
			{
				120,
				1
			};
			byte[] bytes = BitConverter.GetBytes((uint)num);
			Array.Reverse(bytes);
			byte[] array4 = new byte[array3.Length + array2.Length + bytes.Length];
			array3.CopyTo(array4, 0);
			array2.CopyTo(array4, array3.Length);
			bytes.CopyTo(array4, array3.Length + array2.Length);
			return array4;
		}

		public static string Decompress(byte[] array, int length)
		{
			byte[] bytes = Zlib.Decompress(array, 0, length);
			return Encoding.UTF8.GetString(bytes);
		}

		public static byte[] Decompress(byte[] array, int offset, int count)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (array.Length - offset < count)
			{
				throw new ArgumentException("Invalid argument offset count");
			}
			int num = 2;
			int num2 = 4;
			if (Zlib.CheckZlibHead(array, offset, count) != 0)
			{
				throw new Exception("invalid zlib head");
			}
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(array, offset + num, count - num - num2);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			MemoryStream memoryStream2 = new MemoryStream();
			byte[] result;
			using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress, true))
			{
				while (true)
				{
					int num3 = deflateStream.Read(Zlib._decompressBuffer, 0, Zlib._decompressBuffer.Length);
					if (num3 <= 0)
					{
						break;
					}
					memoryStream2.Write(Zlib._decompressBuffer, 0, num3);
				}
				memoryStream2.Seek(0L, SeekOrigin.Begin);
				byte[] array2 = memoryStream2.ToArray();
				if (Zlib.CheckZlibTail(array, offset, count, array2) != 0)
				{
					throw new Exception("invalid zlib tail");
				}
				result = array2;
			}
			return result;
		}

		private static ulong Adler32(ulong adler, byte[] array)
		{
			ulong num = (ulong)((long)array.Length);
			ulong num2 = adler & 65535uL;
			ulong num3 = adler >> 16;
			ulong num4 = num % 5552uL;
			ulong num5 = 0uL;
			if (array.Length == 0)
			{
				return 1uL;
			}
			while (num != 0uL)
			{
				ulong num6 = 0uL;
				while (num6 + 7uL < num4)
				{
					num2 += (ulong)array[(int)(checked((IntPtr)num5))];
					num3 += num2;
					num2 += (ulong)array[(int)(checked((IntPtr)(unchecked(num5 + 1uL))))];
					num3 += num2;
					num2 += (ulong)array[(int)(checked((IntPtr)(unchecked(num5 + 2uL))))];
					num3 += num2;
					num2 += (ulong)array[(int)(checked((IntPtr)(unchecked(num5 + 3uL))))];
					num3 += num2;
					num2 += (ulong)array[(int)(checked((IntPtr)(unchecked(num5 + 4uL))))];
					num3 += num2;
					num2 += (ulong)array[(int)(checked((IntPtr)(unchecked(num5 + 5uL))))];
					num3 += num2;
					num2 += (ulong)array[(int)(checked((IntPtr)(unchecked(num5 + 6uL))))];
					num3 += num2;
					num2 += (ulong)array[(int)(checked((IntPtr)(unchecked(num5 + 7uL))))];
					num3 += num2;
					num6 += 8uL;
					num5 += 8uL;
				}
				while (num6 < num4)
				{
					num2 += (ulong)array[(int)(checked((IntPtr)num5))];
					num5 += 1uL;
					num3 += num2;
					num6 += 1uL;
				}
				num2 %= 65521uL;
				num3 %= 65521uL;
				num -= num4;
				num4 = 5552uL;
			}
			return (num3 << 16) + num2;
		}

		private static int CheckZlibHead(byte[] array, int offset, int count)
		{
			if (array[offset] != 120 || array[offset + 1] != 1)
			{
				return -1;
			}
			return 0;
		}

		private static int CheckZlibTail(byte[] array, int offset, int count, byte[] uncompressData)
		{
			ulong num = 1uL;
			num = Zlib.Adler32(num, uncompressData);
			byte[] bytes = BitConverter.GetBytes((uint)num);
			Array.Reverse(bytes);
			for (int i = 0; i < 4; i++)
			{
				if (array[offset + count - 1 - i] != bytes[3 - i])
				{
					return -1;
				}
			}
			return 0;
		}
	}
}
