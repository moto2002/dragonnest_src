using System;

namespace Unity.IO.Compression
{
	internal interface IFileFormatWriter
	{
		byte[] GetHeader();

		void UpdateWithBytesRead(byte[] buffer, int offset, int bytesToCopy);

		byte[] GetFooter();
	}
}
