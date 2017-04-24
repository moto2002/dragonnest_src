using System;
using XUtliPoolLib;

public class FastList<T> : BetterList<T>
{
	public static MemoryPool<T> ms_Pool = new MemoryPool<T>();

	public static bool UseFastList = true;

	protected override void AllocateMore()
	{
		if (FastList<T>.UseFastList)
		{
			int num = this.size + 1;
			if (num >= 65000)
			{
				return;
			}
			T[] buff = FastList<T>.ms_Pool.GetBuff(num);
			if (this.buffer != buff)
			{
				FastList<T>.ms_Pool.ReturnBuff(this.buffer);
				this.Assign(this.buffer, buff);
				this.buffer = buff;
			}
		}
		else
		{
			base.AllocateMore();
		}
	}

	protected void AllocateMore(int alloSize)
	{
		if (FastList<T>.UseFastList)
		{
			int num = this.size + alloSize;
			if (num >= 65000)
			{
				return;
			}
			T[] buff = FastList<T>.ms_Pool.GetBuff(num);
			if (this.buffer != buff)
			{
				FastList<T>.ms_Pool.ReturnBuff(this.buffer);
				this.Assign(this.buffer, buff);
				this.buffer = buff;
			}
		}
		else
		{
			base.AllocateMore();
		}
	}

	protected virtual void Assign(T[] src, T[] des)
	{
		if (src != null && des != null && this.size > 0)
		{
			try
			{
				int length = (this.size <= des.Length) ? this.size : des.Length;
				Array.Copy(src, 0, des, 0, length);
			}
			catch (Exception)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Assign SrcSize:{0} DesSize:{1} DesBuff:{2}", new object[]
				{
					src.Length,
					this.size,
					this.buffer.Length
				});
			}
		}
	}

	protected virtual void TrimNull()
	{
	}

	protected override void Trim()
	{
		if (FastList<T>.UseFastList)
		{
			if (this.size > 0)
			{
				if (this.size <= this.buffer.Length / 2)
				{
					T[] buff = FastList<T>.ms_Pool.GetBuff(this.size);
					if (this.buffer != buff)
					{
						FastList<T>.ms_Pool.ReturnBuff(this.buffer);
						this.Assign(this.buffer, buff);
						this.buffer = buff;
					}
				}
				else
				{
					this.TrimNull();
				}
			}
			else
			{
				FastList<T>.ms_Pool.ReturnBuff(this.buffer);
				this.buffer = null;
			}
		}
		else
		{
			base.Trim();
		}
	}

	public override void Release()
	{
		if (FastList<T>.UseFastList)
		{
			this.size = 0;
			FastList<T>.ms_Pool.ReturnBuff(this.buffer);
			this.buffer = null;
		}
		else
		{
			base.Release();
		}
	}

	public override void Clear()
	{
		base.Clear();
		if (FastList<T>.UseFastList && this.buffer != null)
		{
			FastList<T>.ms_Pool.ReturnBuff(this.buffer);
			this.buffer = null;
		}
	}

	public void CopyFrom(FastList<T> src)
	{
		int num = this.size + src.size;
		if (this.buffer == null || num > this.buffer.Length)
		{
			this.AllocateMore(src.size);
		}
		try
		{
			Array.Copy(src.buffer, 0, this.buffer, this.size, src.size);
		}
		catch (Exception)
		{
			XSingleton<XDebug>.singleton.AddErrorLog2("SrcSize:{0} DesSize:{1} DesBuff:{2}", new object[]
			{
				src.size,
				this.size,
				this.buffer.Length
			});
		}
		this.size += src.size;
	}
}
