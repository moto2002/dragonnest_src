using System;

namespace Unity.IO.Compression
{
	internal class Match
	{
		private MatchState state;

		private int pos;

		private int len;

		private byte symbol;

		internal MatchState State
		{
			get
			{
				return this.state;
			}
			set
			{
				this.state = value;
			}
		}

		internal int Position
		{
			get
			{
				return this.pos;
			}
			set
			{
				this.pos = value;
			}
		}

		internal int Length
		{
			get
			{
				return this.len;
			}
			set
			{
				this.len = value;
			}
		}

		internal byte Symbol
		{
			get
			{
				return this.symbol;
			}
			set
			{
				this.symbol = value;
			}
		}
	}
}
