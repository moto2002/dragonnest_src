using System;

namespace Unity.IO.Compression
{
	internal class GZipFormatter : IFileFormatWriter
	{
		private byte[] headerBytes = new byte[]
		{
			31,
			139,
			8,
			0,
			0,
			0,
			0,
			0,
			4,
			0
		};

		private uint _crc32;

		private long _inputStreamSizeModulo;

		internal GZipFormatter() : this(3)
		{
		}

		internal GZipFormatter(int compressionLevel)
		{
			if (compressionLevel == 10)
			{
				this.headerBytes[8] = 2;
			}
		}

		public byte[] GetHeader()
		{
			return this.headerBytes;
		}

		public void UpdateWithBytesRead(byte[] buffer, int offset, int bytesToCopy)
		{
			this._crc32 = Crc32Helper.UpdateCrc32(this._crc32, buffer, offset, bytesToCopy);
			long num = this._inputStreamSizeModulo + (long)((ulong)bytesToCopy);
			if (num >= 4294967296L)
			{
				num %= 4294967296L;
			}
			this._inputStreamSizeModulo = num;
		}

		public byte[] GetFooter()
		{
			byte[] array = new byte[8];
			this.WriteUInt32(array, this._crc32, 0);
			this.WriteUInt32(array, (uint)this._inputStreamSizeModulo, 4);
			return array;
		}

		internal void WriteUInt32(byte[] b, uint value, int startIndex)
		{
			b[startIndex] = (byte)value;
			b[startIndex + 1] = (byte)(value >> 8);
			b[startIndex + 2] = (byte)(value >> 16);
			b[startIndex + 3] = (byte)(value >> 24);
		}
	}
}
