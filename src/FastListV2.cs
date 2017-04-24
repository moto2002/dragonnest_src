using System;
using UnityEngine;

public sealed class FastListV2 : FastList<Vector2>
{
	private static Vector2 vec2 = default(Vector2);

	protected override void TrimNull()
	{
		for (int i = this.size; i < this.buffer.Length; i++)
		{
			this.buffer[i].x = -10f;
			this.buffer[i].y = -10f;
		}
	}

	public void Add(float x, float y)
	{
		if (FastList<Vector2>.UseFastList)
		{
			if (this.buffer == null || this.size == this.buffer.Length)
			{
				this.AllocateMore();
			}
			int num = this.size++;
			if (num < this.buffer.Length)
			{
				this.buffer[num].x = x;
				this.buffer[num].y = y;
			}
		}
		else
		{
			FastListV2.vec2.x = x;
			FastListV2.vec2.y = y;
			this.Add(FastListV2.vec2);
		}
	}
}
