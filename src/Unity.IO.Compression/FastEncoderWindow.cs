using System;
using System.Diagnostics;

namespace Unity.IO.Compression
{
	internal class FastEncoderWindow
	{
		private byte[] window;

		private int bufPos;

		private int bufEnd;

		private const int FastEncoderHashShift = 4;

		private const int FastEncoderHashtableSize = 2048;

		private const int FastEncoderHashMask = 2047;

		private const int FastEncoderWindowSize = 8192;

		private const int FastEncoderWindowMask = 8191;

		private const int FastEncoderMatch3DistThreshold = 16384;

		internal const int MaxMatch = 258;

		internal const int MinMatch = 3;

		private const int SearchDepth = 32;

		private const int GoodLength = 4;

		private const int NiceLength = 32;

		private const int LazyMatchThreshold = 6;

		private ushort[] prev;

		private ushort[] lookup;

		public int BytesAvailable
		{
			get
			{
				return this.bufEnd - this.bufPos;
			}
		}

		public DeflateInput UnprocessedInput
		{
			get
			{
				return new DeflateInput
				{
					Buffer = this.window,
					StartIndex = this.bufPos,
					Count = this.bufEnd - this.bufPos
				};
			}
		}

		public int FreeWindowSpace
		{
			get
			{
				return 16384 - this.bufEnd;
			}
		}

		public FastEncoderWindow()
		{
			this.ResetWindow();
		}

		public void FlushWindow()
		{
			this.ResetWindow();
		}

		private void ResetWindow()
		{
			this.window = new byte[16646];
			this.prev = new ushort[8450];
			this.lookup = new ushort[2048];
			this.bufPos = 8192;
			this.bufEnd = this.bufPos;
		}

		public void CopyBytes(byte[] inputBuffer, int startIndex, int count)
		{
			Array.Copy(inputBuffer, startIndex, this.window, this.bufEnd, count);
			this.bufEnd += count;
		}

		public void MoveWindows()
		{
			Array.Copy(this.window, this.bufPos - 8192, this.window, 0, 8192);
			for (int i = 0; i < 2048; i++)
			{
				int num = (int)(this.lookup[i] - 8192);
				if (num <= 0)
				{
					this.lookup[i] = 0;
				}
				else
				{
					this.lookup[i] = (ushort)num;
				}
			}
			for (int i = 0; i < 8192; i++)
			{
				long num2 = (long)((ulong)this.prev[i] - 8192uL);
				if (num2 <= 0L)
				{
					this.prev[i] = 0;
				}
				else
				{
					this.prev[i] = (ushort)num2;
				}
			}
			this.bufPos = 8192;
			this.bufEnd = this.bufPos;
		}

		private uint HashValue(uint hash, byte b)
		{
			return hash << 4 ^ (uint)b;
		}

		private uint InsertString(ref uint hash)
		{
			hash = this.HashValue(hash, this.window[this.bufPos + 2]);
			uint num = (uint)this.lookup[(int)(hash & 2047u)];
			this.lookup[(int)(hash & 2047u)] = (ushort)this.bufPos;
			this.prev[this.bufPos & 8191] = (ushort)num;
			return num;
		}

		private void InsertStrings(ref uint hash, int matchLen)
		{
			if (this.bufEnd - this.bufPos <= matchLen)
			{
				this.bufPos += matchLen - 1;
				return;
			}
			while (--matchLen > 0)
			{
				this.InsertString(ref hash);
				this.bufPos++;
			}
		}

		internal bool GetNextSymbolOrMatch(Match match)
		{
			uint hash = this.HashValue(0u, this.window[this.bufPos]);
			hash = this.HashValue(hash, this.window[this.bufPos + 1]);
			int position = 0;
			int num;
			if (this.bufEnd - this.bufPos <= 3)
			{
				num = 0;
			}
			else
			{
				int num2 = (int)this.InsertString(ref hash);
				if (num2 != 0)
				{
					num = this.FindMatch(num2, out position, 32, 32);
					if (this.bufPos + num > this.bufEnd)
					{
						num = this.bufEnd - this.bufPos;
					}
				}
				else
				{
					num = 0;
				}
			}
			if (num < 3)
			{
				match.State = MatchState.HasSymbol;
				match.Symbol = this.window[this.bufPos];
				this.bufPos++;
			}
			else
			{
				this.bufPos++;
				if (num <= 6)
				{
					int position2 = 0;
					int num3 = (int)this.InsertString(ref hash);
					int num4;
					if (num3 != 0)
					{
						num4 = this.FindMatch(num3, out position2, (num < 4) ? 32 : 8, 32);
						if (this.bufPos + num4 > this.bufEnd)
						{
							num4 = this.bufEnd - this.bufPos;
						}
					}
					else
					{
						num4 = 0;
					}
					if (num4 > num)
					{
						match.State = MatchState.HasSymbolAndMatch;
						match.Symbol = this.window[this.bufPos - 1];
						match.Position = position2;
						match.Length = num4;
						this.bufPos++;
						num = num4;
						this.InsertStrings(ref hash, num);
					}
					else
					{
						match.State = MatchState.HasMatch;
						match.Position = position;
						match.Length = num;
						num--;
						this.bufPos++;
						this.InsertStrings(ref hash, num);
					}
				}
				else
				{
					match.State = MatchState.HasMatch;
					match.Position = position;
					match.Length = num;
					this.InsertStrings(ref hash, num);
				}
			}
			if (this.bufPos == 16384)
			{
				this.MoveWindows();
			}
			return true;
		}

		private int FindMatch(int search, out int matchPos, int searchDepth, int niceLength)
		{
			int num = 0;
			int num2 = 0;
			int num3 = this.bufPos - 8192;
			byte b = this.window[this.bufPos];
			while (search > num3)
			{
				if (this.window[search + num] == b)
				{
					int num4 = 0;
					while (num4 < 258 && this.window[this.bufPos + num4] == this.window[search + num4])
					{
						num4++;
					}
					if (num4 > num)
					{
						num = num4;
						num2 = search;
						if (num4 > 32)
						{
							break;
						}
						b = this.window[this.bufPos + num4];
					}
				}
				if (--searchDepth == 0)
				{
					break;
				}
				search = (int)this.prev[search & 8191];
			}
			matchPos = this.bufPos - num2 - 1;
			if (num == 3 && matchPos >= 16384)
			{
				return 0;
			}
			return num;
		}

		[Conditional("DEBUG")]
		private void VerifyHashes()
		{
			for (int i = 0; i < 2048; i++)
			{
				ushort num = this.lookup[i];
				while (num != 0 && this.bufPos - (int)num < 8192)
				{
					ushort num2 = this.prev[(int)(num & 8191)];
					if (this.bufPos - (int)num2 >= 8192)
					{
						break;
					}
					num = num2;
				}
			}
		}

		private uint RecalculateHash(int position)
		{
			return (uint)(((int)this.window[position] << 8 ^ (int)this.window[position + 1] << 4 ^ (int)this.window[position + 2]) & 2047);
		}
	}
}
