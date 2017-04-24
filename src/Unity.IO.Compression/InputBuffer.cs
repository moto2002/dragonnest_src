using System;

namespace Unity.IO.Compression
{
	internal class InputBuffer
	{
		private byte[] buffer;

		private int start;

		private int end;

		private uint bitBuffer;

		private int bitsInBuffer;

		public int AvailableBits
		{
			get
			{
				return this.bitsInBuffer;
			}
		}

		public int AvailableBytes
		{
			get
			{
				return this.end - this.start + this.bitsInBuffer / 8;
			}
		}

		public bool EnsureBitsAvailable(int count)
		{
			if (this.bitsInBuffer < count)
			{
				if (this.NeedsInput())
				{
					return false;
				}
				uint arg_3F_0 = this.bitBuffer;
				byte[] arg_34_0 = this.buffer;
				int num = this.start;
				this.start = num + 1;
				this.bitBuffer = (arg_3F_0 | arg_34_0[num] << (this.bitsInBuffer & 31));
				this.bitsInBuffer += 8;
				if (this.bitsInBuffer < count)
				{
					if (this.NeedsInput())
					{
						return false;
					}
					uint arg_8F_0 = this.bitBuffer;
					byte[] arg_84_0 = this.buffer;
					num = this.start;
					this.start = num + 1;
					this.bitBuffer = (arg_8F_0 | arg_84_0[num] << (this.bitsInBuffer & 31));
					this.bitsInBuffer += 8;
				}
			}
			return true;
		}

		public uint TryLoad16Bits()
		{
			if (this.bitsInBuffer < 8)
			{
				if (this.start < this.end)
				{
					uint arg_43_0 = this.bitBuffer;
					byte[] arg_38_0 = this.buffer;
					int num = this.start;
					this.start = num + 1;
					this.bitBuffer = (arg_43_0 | arg_38_0[num] << (this.bitsInBuffer & 31));
					this.bitsInBuffer += 8;
				}
				if (this.start < this.end)
				{
					uint arg_91_0 = this.bitBuffer;
					byte[] arg_86_0 = this.buffer;
					int num = this.start;
					this.start = num + 1;
					this.bitBuffer = (arg_91_0 | arg_86_0[num] << (this.bitsInBuffer & 31));
					this.bitsInBuffer += 8;
				}
			}
			else if (this.bitsInBuffer < 16 && this.start < this.end)
			{
				uint arg_E8_0 = this.bitBuffer;
				byte[] arg_DD_0 = this.buffer;
				int num = this.start;
				this.start = num + 1;
				this.bitBuffer = (arg_E8_0 | arg_DD_0[num] << (this.bitsInBuffer & 31));
				this.bitsInBuffer += 8;
			}
			return this.bitBuffer;
		}

		private uint GetBitMask(int count)
		{
			return (1u << count) - 1u;
		}

		public int GetBits(int count)
		{
			if (!this.EnsureBitsAvailable(count))
			{
				return -1;
			}
			int arg_38_0 = (int)(this.bitBuffer & this.GetBitMask(count));
			this.bitBuffer >>= count;
			this.bitsInBuffer -= count;
			return arg_38_0;
		}

		public int CopyTo(byte[] output, int offset, int length)
		{
			int num = 0;
			while (this.bitsInBuffer > 0 && length > 0)
			{
				output[offset++] = (byte)this.bitBuffer;
				this.bitBuffer >>= 8;
				this.bitsInBuffer -= 8;
				length--;
				num++;
			}
			if (length == 0)
			{
				return num;
			}
			int num2 = this.end - this.start;
			if (length > num2)
			{
				length = num2;
			}
			Array.Copy(this.buffer, this.start, output, offset, length);
			this.start += length;
			return num + length;
		}

		public bool NeedsInput()
		{
			return this.start == this.end;
		}

		public void SetInput(byte[] buffer, int offset, int length)
		{
			this.buffer = buffer;
			this.start = offset;
			this.end = offset + length;
		}

		public void SkipBits(int n)
		{
			this.bitBuffer >>= n;
			this.bitsInBuffer -= n;
		}

		public void SkipToByteBoundary()
		{
			this.bitBuffer >>= this.bitsInBuffer % 8;
			this.bitsInBuffer -= this.bitsInBuffer % 8;
		}
	}
}
