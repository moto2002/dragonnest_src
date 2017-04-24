using System;
using UnityEngine;

public sealed class FastListV3 : FastList<Vector3>
{
	private static Vector3 vec3 = default(Vector3);

	protected override void TrimNull()
	{
		for (int i = this.size; i < this.buffer.Length; i++)
		{
			this.buffer[i].x = 10000f;
			this.buffer[i].y = 10000f;
			this.buffer[i].z = 10000f;
		}
	}

	public void Add(float x, float y, float z)
	{
		if (FastList<Vector3>.UseFastList)
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
				this.buffer[num].z = z;
			}
		}
		else
		{
			FastListV3.vec3.x = x;
			FastListV3.vec3.y = y;
			FastListV3.vec3.z = z;
			this.Add(FastListV3.vec3);
		}
	}

	public override void Add(Vector3 v)
	{
		if (FastList<Vector3>.UseFastList)
		{
			if (this.buffer == null || this.size == this.buffer.Length)
			{
				this.AllocateMore();
			}
			int num = this.size++;
			if (num < this.buffer.Length)
			{
				this.buffer[num] = v;
			}
		}
		else
		{
			this.Add(v);
		}
	}
}
