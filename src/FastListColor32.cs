using System;
using UnityEngine;

public sealed class FastListColor32 : FastList<Color32>
{
	private static Color32 color32 = default(Color32);

	public void Add(byte r, byte g, byte b, byte a)
	{
		if (FastList<Color32>.UseFastList)
		{
			if (this.buffer == null || this.size == this.buffer.Length)
			{
				this.AllocateMore();
			}
			int num = this.size++;
			this.buffer[num].r = r;
			this.buffer[num].g = g;
			this.buffer[num].b = b;
			this.buffer[num].a = a;
		}
		else
		{
			FastListColor32.color32.r = r;
			FastListColor32.color32.g = g;
			FastListColor32.color32.b = b;
			FastListColor32.color32.a = a;
			this.Add(FastListColor32.color32);
		}
	}
}
