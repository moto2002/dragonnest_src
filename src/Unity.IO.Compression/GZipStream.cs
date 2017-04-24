using System;
using System.IO;

namespace Unity.IO.Compression
{
	public class GZipStream : Stream
	{
		private DeflateStream deflateStream;

		public override bool CanRead
		{
			get
			{
				return this.deflateStream != null && this.deflateStream.CanRead;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return this.deflateStream != null && this.deflateStream.CanWrite;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return this.deflateStream != null && this.deflateStream.CanSeek;
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

		public Stream BaseStream
		{
			get
			{
				if (this.deflateStream != null)
				{
					return this.deflateStream.BaseStream;
				}
				return null;
			}
		}

		public GZipStream(Stream stream, CompressionMode mode) : this(stream, mode, false)
		{
		}

		public GZipStream(Stream stream, CompressionMode mode, bool leaveOpen)
		{
			this.deflateStream = new DeflateStream(stream, mode, leaveOpen);
			this.SetDeflateStreamFileFormatter(mode);
		}

		private void SetDeflateStreamFileFormatter(CompressionMode mode)
		{
			if (mode == CompressionMode.Compress)
			{
				IFileFormatWriter fileFormatWriter = new GZipFormatter();
				this.deflateStream.SetFileFormatWriter(fileFormatWriter);
				return;
			}
			IFileFormatReader fileFormatReader = new GZipDecoder();
			this.deflateStream.SetFileFormatReader(fileFormatReader);
		}

		public override void Flush()
		{
			if (this.deflateStream == null)
			{
				throw new ObjectDisposedException(null, SR.GetString("Object disposed"));
			}
			this.deflateStream.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException(SR.GetString("Not supported"));
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException(SR.GetString("Not supported"));
		}

		public override IAsyncResult BeginRead(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState)
		{
			if (this.deflateStream == null)
			{
				throw new InvalidOperationException(SR.GetString("Object disposed"));
			}
			return this.deflateStream.BeginRead(array, offset, count, asyncCallback, asyncState);
		}

		public override int EndRead(IAsyncResult asyncResult)
		{
			if (this.deflateStream == null)
			{
				throw new InvalidOperationException(SR.GetString("Object disposed"));
			}
			return this.deflateStream.EndRead(asyncResult);
		}

		public override IAsyncResult BeginWrite(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState)
		{
			if (this.deflateStream == null)
			{
				throw new InvalidOperationException(SR.GetString("Object disposed"));
			}
			return this.deflateStream.BeginWrite(array, offset, count, asyncCallback, asyncState);
		}

		public override void EndWrite(IAsyncResult asyncResult)
		{
			if (this.deflateStream == null)
			{
				throw new InvalidOperationException(SR.GetString("Object disposed"));
			}
			this.deflateStream.EndWrite(asyncResult);
		}

		public override int Read(byte[] array, int offset, int count)
		{
			if (this.deflateStream == null)
			{
				throw new ObjectDisposedException(null, SR.GetString("Object disposed"));
			}
			return this.deflateStream.Read(array, offset, count);
		}

		public override void Write(byte[] array, int offset, int count)
		{
			if (this.deflateStream == null)
			{
				throw new ObjectDisposedException(null, SR.GetString("Object disposed"));
			}
			this.deflateStream.Write(array, offset, count);
		}

		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && this.deflateStream != null)
				{
					this.deflateStream.Dispose();
				}
				this.deflateStream = null;
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
	}
}
