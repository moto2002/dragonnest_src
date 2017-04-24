using System;

namespace Unity.IO.Compression
{
	internal class DeflateInput
	{
		internal struct InputState
		{
			internal int count;

			internal int startIndex;
		}

		private byte[] buffer;

		private int count;

		private int startIndex;

		internal byte[] Buffer
		{
			get
			{
				return this.buffer;
			}
			set
			{
				this.buffer = value;
			}
		}

		internal int Count
		{
			get
			{
				return this.count;
			}
			set
			{
				this.count = value;
			}
		}

		internal int StartIndex
		{
			get
			{
				return this.startIndex;
			}
			set
			{
				this.startIndex = value;
			}
		}

		internal void ConsumeBytes(int n)
		{
			this.startIndex += n;
			this.count -= n;
		}

		internal DeflateInput.InputState DumpState()
		{
			DeflateInput.InputState result;
			result.count = this.count;
			result.startIndex = this.startIndex;
			return result;
		}

		internal void RestoreState(DeflateInput.InputState state)
		{
			this.count = state.count;
			this.startIndex = state.startIndex;
		}
	}
}
