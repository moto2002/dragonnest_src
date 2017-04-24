using System;

namespace Unity.IO.Compression
{
	internal interface IFileFormatReader
	{
		bool ReadHeader(InputBuffer input);

		bool ReadFooter(InputBuffer input);

		void UpdateWithBytesRead(byte[] buffer, int offset, int bytesToCopy);

		void Validate();
	}
}
