using System;
using System.IO;
using System.Security;
using System.Threading;

namespace Unity.IO.Compression
{
	public class DeflateStream : Stream
	{
		internal delegate void AsyncWriteDelegate(byte[] array, int offset, int count, bool isAsync);

		private enum WorkerType : byte
		{
			Managed,
			Unknown
		}

		internal const int DefaultBufferSize = 8192;

		private Stream _stream;

		private CompressionMode _mode;

		private bool _leaveOpen;

		private Inflater inflater;

		private IDeflater deflater;

		private byte[] buffer;

		private int asyncOperations;

		private readonly AsyncCallback m_CallBack;

		private readonly DeflateStream.AsyncWriteDelegate m_AsyncWriterDelegate;

		private IFileFormatWriter formatWriter;

		private bool wroteHeader;

		private bool wroteBytes;

		public Stream BaseStream
		{
			get
			{
				return this._stream;
			}
		}

		public override bool CanRead
		{
			get
			{
				return this._stream != null && this._mode == CompressionMode.Decompress && this._stream.CanRead;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return this._stream != null && this._mode == CompressionMode.Compress && this._stream.CanWrite;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		public override long Length
		{
			get
			{
				throw new NotSupportedException(SR.GetString("Not supported"));
			}
		}

		public override long Position
		{
			get
			{
				throw new NotSupportedException(SR.GetString("Not supported"));
			}
			set
			{
				throw new NotSupportedException(SR.GetString("Not supported"));
			}
		}

		public DeflateStream(Stream stream, CompressionMode mode) : this(stream, mode, false)
		{
		}

		public DeflateStream(Stream stream, CompressionMode mode, bool leaveOpen)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (CompressionMode.Compress != mode && mode != CompressionMode.Decompress)
			{
				throw new ArgumentException(SR.GetString("Argument out of range"), "mode");
			}
			this._stream = stream;
			this._mode = mode;
			this._leaveOpen = leaveOpen;
			CompressionMode mode2 = this._mode;
			if (mode2 != CompressionMode.Decompress)
			{
				if (mode2 == CompressionMode.Compress)
				{
					if (!this._stream.CanWrite)
					{
						throw new ArgumentException(SR.GetString("Not a writeable stream"), "stream");
					}
					this.deflater = DeflateStream.CreateDeflater();
					this.m_AsyncWriterDelegate = new DeflateStream.AsyncWriteDelegate(this.InternalWrite);
					this.m_CallBack = new AsyncCallback(this.WriteCallback);
				}
			}
			else
			{
				if (!this._stream.CanRead)
				{
					throw new ArgumentException(SR.GetString("Not a readable stream"), "stream");
				}
				this.inflater = new Inflater();
				this.m_CallBack = new AsyncCallback(this.ReadCallback);
			}
			this.buffer = new byte[8192];
		}

		private static IDeflater CreateDeflater()
		{
			if (DeflateStream.GetDeflaterType() == DeflateStream.WorkerType.Managed)
			{
				return new DeflaterManaged();
			}
			throw new SystemException("Program entered an unexpected state.");
		}

		[SecuritySafeCritical]
		private static DeflateStream.WorkerType GetDeflaterType()
		{
			return DeflateStream.WorkerType.Managed;
		}

		internal void SetFileFormatReader(IFileFormatReader reader)
		{
			if (reader != null)
			{
				this.inflater.SetFileFormatReader(reader);
			}
		}

		internal void SetFileFormatWriter(IFileFormatWriter writer)
		{
			if (writer != null)
			{
				this.formatWriter = writer;
			}
		}

		public override void Flush()
		{
			this.EnsureNotDisposed();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException(SR.GetString("Not supported"));
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException(SR.GetString("Not supported"));
		}

		public override int Read(byte[] array, int offset, int count)
		{
			this.EnsureDecompressionMode();
			this.ValidateParameters(array, offset, count);
			this.EnsureNotDisposed();
			int num = offset;
			int num2 = count;
			while (true)
			{
				int num3 = this.inflater.Inflate(array, num, num2);
				num += num3;
				num2 -= num3;
				if (num2 == 0 || this.inflater.Finished())
				{
					break;
				}
				int num4 = this._stream.Read(this.buffer, 0, this.buffer.Length);
				if (num4 == 0)
				{
					break;
				}
				this.inflater.SetInput(this.buffer, 0, num4);
			}
			return count - num2;
		}

		private void ValidateParameters(byte[] array, int offset, int count)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (array.Length - offset < count)
			{
				throw new ArgumentException(SR.GetString("Invalid argument offset count"));
			}
		}

		private void EnsureNotDisposed()
		{
			if (this._stream == null)
			{
				throw new ObjectDisposedException(null, SR.GetString("Object disposed"));
			}
		}

		private void EnsureDecompressionMode()
		{
			if (this._mode != CompressionMode.Decompress)
			{
				throw new InvalidOperationException(SR.GetString("Cannot read from deflate stream"));
			}
		}

		private void EnsureCompressionMode()
		{
			if (this._mode != CompressionMode.Compress)
			{
				throw new InvalidOperationException(SR.GetString("Cannot write to deflate stream"));
			}
		}

		public override IAsyncResult BeginRead(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState)
		{
			this.EnsureDecompressionMode();
			if (this.asyncOperations != 0)
			{
				throw new InvalidOperationException(SR.GetString("Invalid begin call"));
			}
			this.ValidateParameters(array, offset, count);
			this.EnsureNotDisposed();
			Interlocked.Increment(ref this.asyncOperations);
			IAsyncResult result;
			try
			{
				DeflateStreamAsyncResult deflateStreamAsyncResult = new DeflateStreamAsyncResult(this, asyncState, asyncCallback, array, offset, count);
				deflateStreamAsyncResult.isWrite = false;
				int num = this.inflater.Inflate(array, offset, count);
				if (num != 0)
				{
					deflateStreamAsyncResult.InvokeCallback(true, num);
					result = deflateStreamAsyncResult;
				}
				else if (this.inflater.Finished())
				{
					deflateStreamAsyncResult.InvokeCallback(true, 0);
					result = deflateStreamAsyncResult;
				}
				else
				{
					this._stream.BeginRead(this.buffer, 0, this.buffer.Length, this.m_CallBack, deflateStreamAsyncResult);
					deflateStreamAsyncResult.m_CompletedSynchronously &= deflateStreamAsyncResult.IsCompleted;
					result = deflateStreamAsyncResult;
				}
			}
			catch
			{
				Interlocked.Decrement(ref this.asyncOperations);
				throw;
			}
			return result;
		}

		private void ReadCallback(IAsyncResult baseStreamResult)
		{
			DeflateStreamAsyncResult deflateStreamAsyncResult = (DeflateStreamAsyncResult)baseStreamResult.AsyncState;
			deflateStreamAsyncResult.m_CompletedSynchronously &= baseStreamResult.CompletedSynchronously;
			try
			{
				this.EnsureNotDisposed();
				int num = this._stream.EndRead(baseStreamResult);
				if (num <= 0)
				{
					deflateStreamAsyncResult.InvokeCallback(0);
				}
				else
				{
					this.inflater.SetInput(this.buffer, 0, num);
					num = this.inflater.Inflate(deflateStreamAsyncResult.buffer, deflateStreamAsyncResult.offset, deflateStreamAsyncResult.count);
					if (num == 0 && !this.inflater.Finished())
					{
						this._stream.BeginRead(this.buffer, 0, this.buffer.Length, this.m_CallBack, deflateStreamAsyncResult);
					}
					else
					{
						deflateStreamAsyncResult.InvokeCallback(num);
					}
				}
			}
			catch (Exception result)
			{
				deflateStreamAsyncResult.InvokeCallback(result);
			}
		}

		public override int EndRead(IAsyncResult asyncResult)
		{
			this.EnsureDecompressionMode();
			this.CheckEndXxxxLegalStateAndParams(asyncResult);
			DeflateStreamAsyncResult deflateStreamAsyncResult = (DeflateStreamAsyncResult)asyncResult;
			this.AwaitAsyncResultCompletion(deflateStreamAsyncResult);
			Exception ex = deflateStreamAsyncResult.Result as Exception;
			if (ex != null)
			{
				throw ex;
			}
			return (int)deflateStreamAsyncResult.Result;
		}

		public override void Write(byte[] array, int offset, int count)
		{
			this.EnsureCompressionMode();
			this.ValidateParameters(array, offset, count);
			this.EnsureNotDisposed();
			this.InternalWrite(array, offset, count, false);
		}

		internal void InternalWrite(byte[] array, int offset, int count, bool isAsync)
		{
			this.DoMaintenance(array, offset, count);
			this.WriteDeflaterOutput(isAsync);
			this.deflater.SetInput(array, offset, count);
			this.WriteDeflaterOutput(isAsync);
		}

		private void WriteDeflaterOutput(bool isAsync)
		{
			while (!this.deflater.NeedsInput())
			{
				int deflateOutput = this.deflater.GetDeflateOutput(this.buffer);
				if (deflateOutput > 0)
				{
					this.DoWrite(this.buffer, 0, deflateOutput, isAsync);
				}
			}
		}

		private void DoWrite(byte[] array, int offset, int count, bool isAsync)
		{
			if (isAsync)
			{
				IAsyncResult asyncResult = this._stream.BeginWrite(array, offset, count, null, null);
				this._stream.EndWrite(asyncResult);
				return;
			}
			this._stream.Write(array, offset, count);
		}

		private void DoMaintenance(byte[] array, int offset, int count)
		{
			if (count <= 0)
			{
				return;
			}
			this.wroteBytes = true;
			if (this.formatWriter == null)
			{
				return;
			}
			if (!this.wroteHeader)
			{
				byte[] header = this.formatWriter.GetHeader();
				this._stream.Write(header, 0, header.Length);
				this.wroteHeader = true;
			}
			this.formatWriter.UpdateWithBytesRead(array, offset, count);
		}

		private void PurgeBuffers(bool disposing)
		{
			if (!disposing)
			{
				return;
			}
			if (this._stream == null)
			{
				return;
			}
			this.Flush();
			if (this._mode != CompressionMode.Compress)
			{
				return;
			}
			if (this.wroteBytes)
			{
				this.WriteDeflaterOutput(false);
				bool flag;
				do
				{
					int num;
					flag = this.deflater.Finish(this.buffer, out num);
					if (num > 0)
					{
						this.DoWrite(this.buffer, 0, num, false);
					}
				}
				while (!flag);
			}
			if (this.formatWriter != null && this.wroteHeader)
			{
				byte[] footer = this.formatWriter.GetFooter();
				this._stream.Write(footer, 0, footer.Length);
			}
		}

		protected override void Dispose(bool disposing)
		{
			try
			{
				this.PurgeBuffers(disposing);
			}
			finally
			{
				try
				{
					if (disposing && !this._leaveOpen && this._stream != null)
					{
						this._stream.Dispose();
					}
				}
				finally
				{
					this._stream = null;
					try
					{
						if (this.deflater != null)
						{
							this.deflater.Dispose();
						}
					}
					finally
					{
						this.deflater = null;
						base.Dispose(disposing);
					}
				}
			}
		}

		public override IAsyncResult BeginWrite(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState)
		{
			this.EnsureCompressionMode();
			if (this.asyncOperations != 0)
			{
				throw new InvalidOperationException(SR.GetString("Invalid begin call"));
			}
			this.ValidateParameters(array, offset, count);
			this.EnsureNotDisposed();
			Interlocked.Increment(ref this.asyncOperations);
			IAsyncResult result;
			try
			{
				DeflateStreamAsyncResult deflateStreamAsyncResult = new DeflateStreamAsyncResult(this, asyncState, asyncCallback, array, offset, count);
				deflateStreamAsyncResult.isWrite = true;
				this.m_AsyncWriterDelegate.BeginInvoke(array, offset, count, true, this.m_CallBack, deflateStreamAsyncResult);
				deflateStreamAsyncResult.m_CompletedSynchronously &= deflateStreamAsyncResult.IsCompleted;
				result = deflateStreamAsyncResult;
			}
			catch
			{
				Interlocked.Decrement(ref this.asyncOperations);
				throw;
			}
			return result;
		}

		private void WriteCallback(IAsyncResult asyncResult)
		{
			DeflateStreamAsyncResult deflateStreamAsyncResult = (DeflateStreamAsyncResult)asyncResult.AsyncState;
			deflateStreamAsyncResult.m_CompletedSynchronously &= asyncResult.CompletedSynchronously;
			try
			{
				this.m_AsyncWriterDelegate.EndInvoke(asyncResult);
			}
			catch (Exception result)
			{
				deflateStreamAsyncResult.InvokeCallback(result);
				return;
			}
			deflateStreamAsyncResult.InvokeCallback(null);
		}

		public override void EndWrite(IAsyncResult asyncResult)
		{
			this.EnsureCompressionMode();
			this.CheckEndXxxxLegalStateAndParams(asyncResult);
			DeflateStreamAsyncResult deflateStreamAsyncResult = (DeflateStreamAsyncResult)asyncResult;
			this.AwaitAsyncResultCompletion(deflateStreamAsyncResult);
			Exception ex = deflateStreamAsyncResult.Result as Exception;
			if (ex != null)
			{
				throw ex;
			}
		}

		private void CheckEndXxxxLegalStateAndParams(IAsyncResult asyncResult)
		{
			if (this.asyncOperations != 1)
			{
				throw new InvalidOperationException(SR.GetString("Invalid end call"));
			}
			if (asyncResult == null)
			{
				throw new ArgumentNullException("asyncResult");
			}
			this.EnsureNotDisposed();
			if (!(asyncResult is DeflateStreamAsyncResult))
			{
				throw new ArgumentNullException("asyncResult");
			}
		}

		private void AwaitAsyncResultCompletion(DeflateStreamAsyncResult asyncResult)
		{
			try
			{
				if (!asyncResult.IsCompleted)
				{
					asyncResult.AsyncWaitHandle.WaitOne();
				}
			}
			finally
			{
				Interlocked.Decrement(ref this.asyncOperations);
				asyncResult.Close();
			}
		}
	}
}
