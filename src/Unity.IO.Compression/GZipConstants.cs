using System;

namespace Unity.IO.Compression
{
	internal static class GZipConstants
	{
		internal const int CompressionLevel_3 = 3;

		internal const int CompressionLevel_10 = 10;

		internal const long FileLengthModulo = 4294967296L;

		internal const byte ID1 = 31;

		internal const byte ID2 = 139;

		internal const byte Deflate = 8;

		internal const int Xfl_HeaderPos = 8;

		internal const byte Xfl_FastestAlgorithm = 4;

		internal const byte Xfl_MaxCompressionSlowestAlgorithm = 2;
	}
}
