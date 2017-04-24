using System;
using System.Runtime.InteropServices;

public class LuaStringBuffer
{
	public byte[] buffer;

	public LuaStringBuffer(IntPtr source, int len)
	{
		this.buffer = new byte[len];
		Marshal.Copy(source, this.buffer, 0, len);
	}

	public LuaStringBuffer(byte[] buf)
	{
		this.Set(buf);
	}

	public LuaStringBuffer()
	{
	}

	public void Set(byte[] buf)
	{
		this.buffer = buf;
	}

	public void Copy(byte[] buf, int length)
	{
		this.buffer = new byte[length];
		Array.Copy(buf, this.buffer, length);
	}
}
