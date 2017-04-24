using System;

namespace Unity.IO.Compression
{
	internal class OutputBuffer
	{
		internal struct BufferState
		{
			internal int pos;

			internal uint bitBuf;

			internal int bitCount;
		}

		private byte[] byteBuffer;

		private int pos;

		private uint bitBuf;

		private int bitCount;

		internal int BytesWritten
		{
			get
			{
				return this.pos;
			}
		}

		internal int FreeBytes
		{
			get
			{
				return this.byteBuffer.Length - this.pos;
			}
		}

		internal int BitsInBuffer
		{
			get
			{
				return this.bitCount / 8 + 1;
			}
		}

		internal void UpdateBuffer(byte[] output)
		{
			this.byteBuffer = output;
			this.pos = 0;
		}

		internal void WriteUInt16(ushort value)
		{
			byte[] arg_19_0 = this.byteBuffer;
			int num = this.pos;
			this.pos = num + 1;
			arg_19_0[num] = (byte)value;
			byte[] arg_35_0 = this.byteBuffer;
			num = this.pos;
			this.pos = num + 1;
			arg_35_0[num] = (byte)(value >> 8);
		}

		internal void WriteBits(int n, uint bits)
		{
			this.bitBuf |= bits << this.bitCount;
			this.bitCount += n;
			if (this.bitCount >= 16)
			{
				byte[] arg_4E_0 = this.byteBuffer;
				int num = this.pos;
				this.pos = num + 1;
				arg_4E_0[num] = (byte)this.bitBuf;
				byte[] arg_6F_0 = this.byteBuffer;
				num = this.pos;
				this.pos = num + 1;
				arg_6F_0[num] = (byte)(this.bitBuf >> 8);
				this.bitCount -= 16;
				this.bitBuf >>= 16;
			}
		}

		internal void FlushBits()
		{
			while (this.bitCount >= 8)
			{
				byte[] arg_20_0 = this.byteBuffer;
				int num = this.pos;
				this.pos = num + 1;
				arg_20_0[num] = (byte)this.bitBuf;
				this.bitCount -= 8;
				this.bitBuf >>= 8;
			}
			if (this.bitCount > 0)
			{
				byte[] arg_6D_0 = this.byteBuffer;
				int num = this.pos;
				this.pos = num + 1;
				arg_6D_0[num] = (byte)this.bitBuf;
				this.bitBuf = 0u;
				this.bitCount = 0;
			}
		}

		internal void WriteBytes(byte[] byteArray, int offset, int count)
		{
			if (this.bitCount == 0)
			{
				Array.Copy(byteArray, offset, this.byteBuffer, this.pos, count);
				this.pos += count;
				return;
			}
			this.WriteBytesUnaligned(byteArray, offset, count);
		}

		private void WriteBytesUnaligned(byte[] byteArray, int offset, int count)
		{
			for (int i = 0; i < count; i++)
			{
				byte b = byteArray[offset + i];
				this.WriteByteUnaligned(b);
			}
		}

		private void WriteByteUnaligned(byte b)
		{
			this.WriteBits(8, (uint)b);
		}

		internal OutputBuffer.BufferState DumpState()
		{
			OutputBuffer.BufferState result;
			result.pos = this.pos;
			result.bitBuf = this.bitBuf;
			result.bitCount = this.bitCount;
			return result;
		}

		internal void RestoreState(OutputBuffer.BufferState state)
		{
			this.pos = state.pos;
			this.bitBuf = state.bitBuf;
			this.bitCount = state.bitCount;
		}
	}
}
