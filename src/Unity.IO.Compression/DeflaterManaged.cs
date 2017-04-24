using System;

namespace Unity.IO.Compression
{
	internal class DeflaterManaged : IDeflater, IDisposable
	{
		private enum DeflaterState
		{
			NotStarted,
			SlowDownForIncompressible1,
			SlowDownForIncompressible2,
			StartingSmallData,
			CompressThenCheck,
			CheckingForIncompressible,
			HandlingSmallData
		}

		private const int MinBlockSize = 256;

		private const int MaxHeaderFooterGoo = 120;

		private const int CleanCopySize = 8072;

		private const double BadCompressionThreshold = 1.0;

		private FastEncoder deflateEncoder;

		private CopyEncoder copyEncoder;

		private DeflateInput input;

		private OutputBuffer output;

		private DeflaterManaged.DeflaterState processingState;

		private DeflateInput inputFromHistory;

		internal DeflaterManaged()
		{
			this.deflateEncoder = new FastEncoder();
			this.copyEncoder = new CopyEncoder();
			this.input = new DeflateInput();
			this.output = new OutputBuffer();
			this.processingState = DeflaterManaged.DeflaterState.NotStarted;
		}

		private bool NeedsInput()
		{
			return ((IDeflater)this).NeedsInput();
		}

		bool IDeflater.NeedsInput()
		{
			return this.input.Count == 0 && this.deflateEncoder.BytesInHistory == 0;
		}

		void IDeflater.SetInput(byte[] inputBuffer, int startIndex, int count)
		{
			this.input.Buffer = inputBuffer;
			this.input.Count = count;
			this.input.StartIndex = startIndex;
			if (count > 0 && count < 256)
			{
				DeflaterManaged.DeflaterState deflaterState = this.processingState;
				if (deflaterState != DeflaterManaged.DeflaterState.NotStarted)
				{
					if (deflaterState == DeflaterManaged.DeflaterState.CompressThenCheck)
					{
						this.processingState = DeflaterManaged.DeflaterState.HandlingSmallData;
						return;
					}
					if (deflaterState != DeflaterManaged.DeflaterState.CheckingForIncompressible)
					{
						return;
					}
				}
				this.processingState = DeflaterManaged.DeflaterState.StartingSmallData;
				return;
			}
		}

		int IDeflater.GetDeflateOutput(byte[] outputBuffer)
		{
			this.output.UpdateBuffer(outputBuffer);
			switch (this.processingState)
			{
			case DeflaterManaged.DeflaterState.NotStarted:
			{
				DeflateInput.InputState state = this.input.DumpState();
				OutputBuffer.BufferState state2 = this.output.DumpState();
				this.deflateEncoder.GetBlockHeader(this.output);
				this.deflateEncoder.GetCompressedData(this.input, this.output);
				if (!this.UseCompressed(this.deflateEncoder.LastCompressionRatio))
				{
					this.input.RestoreState(state);
					this.output.RestoreState(state2);
					this.copyEncoder.GetBlock(this.input, this.output, false);
					this.FlushInputWindows();
					this.processingState = DeflaterManaged.DeflaterState.CheckingForIncompressible;
					goto IL_23A;
				}
				this.processingState = DeflaterManaged.DeflaterState.CompressThenCheck;
				goto IL_23A;
			}
			case DeflaterManaged.DeflaterState.SlowDownForIncompressible1:
				this.deflateEncoder.GetBlockFooter(this.output);
				this.processingState = DeflaterManaged.DeflaterState.SlowDownForIncompressible2;
				break;
			case DeflaterManaged.DeflaterState.SlowDownForIncompressible2:
				break;
			case DeflaterManaged.DeflaterState.StartingSmallData:
				this.deflateEncoder.GetBlockHeader(this.output);
				this.processingState = DeflaterManaged.DeflaterState.HandlingSmallData;
				goto IL_223;
			case DeflaterManaged.DeflaterState.CompressThenCheck:
				this.deflateEncoder.GetCompressedData(this.input, this.output);
				if (!this.UseCompressed(this.deflateEncoder.LastCompressionRatio))
				{
					this.processingState = DeflaterManaged.DeflaterState.SlowDownForIncompressible1;
					this.inputFromHistory = this.deflateEncoder.UnprocessedInput;
					goto IL_23A;
				}
				goto IL_23A;
			case DeflaterManaged.DeflaterState.CheckingForIncompressible:
			{
				DeflateInput.InputState state3 = this.input.DumpState();
				OutputBuffer.BufferState state4 = this.output.DumpState();
				this.deflateEncoder.GetBlock(this.input, this.output, 8072);
				if (!this.UseCompressed(this.deflateEncoder.LastCompressionRatio))
				{
					this.input.RestoreState(state3);
					this.output.RestoreState(state4);
					this.copyEncoder.GetBlock(this.input, this.output, false);
					this.FlushInputWindows();
					goto IL_23A;
				}
				goto IL_23A;
			}
			case DeflaterManaged.DeflaterState.HandlingSmallData:
				goto IL_223;
			default:
				goto IL_23A;
			}
			if (this.inputFromHistory.Count > 0)
			{
				this.copyEncoder.GetBlock(this.inputFromHistory, this.output, false);
			}
			if (this.inputFromHistory.Count == 0)
			{
				this.deflateEncoder.FlushInput();
				this.processingState = DeflaterManaged.DeflaterState.CheckingForIncompressible;
				goto IL_23A;
			}
			goto IL_23A;
			IL_223:
			this.deflateEncoder.GetCompressedData(this.input, this.output);
			IL_23A:
			return this.output.BytesWritten;
		}

		bool IDeflater.Finish(byte[] outputBuffer, out int bytesRead)
		{
			if (this.processingState == DeflaterManaged.DeflaterState.NotStarted)
			{
				bytesRead = 0;
				return true;
			}
			this.output.UpdateBuffer(outputBuffer);
			if (this.processingState == DeflaterManaged.DeflaterState.CompressThenCheck || this.processingState == DeflaterManaged.DeflaterState.HandlingSmallData || this.processingState == DeflaterManaged.DeflaterState.SlowDownForIncompressible1)
			{
				this.deflateEncoder.GetBlockFooter(this.output);
			}
			this.WriteFinal();
			bytesRead = this.output.BytesWritten;
			return true;
		}

		void IDisposable.Dispose()
		{
		}

		protected void Dispose(bool disposing)
		{
		}

		private bool UseCompressed(double ratio)
		{
			return ratio <= 1.0;
		}

		private void FlushInputWindows()
		{
			this.deflateEncoder.FlushInput();
		}

		private void WriteFinal()
		{
			this.copyEncoder.GetBlock(null, this.output, true);
		}
	}
}
