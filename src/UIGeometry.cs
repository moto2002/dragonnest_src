using System;
using UnityEngine;

public class UIGeometry
{
	public FastListV3 verts = new FastListV3();

	public FastListV2 uvs = new FastListV2();

	public FastListColor32 cols = new FastListColor32();

	private FastListV3 mRtpVerts = new FastListV3();

	private Vector3 mRtpNormal;

	private Vector4 mRtpTan;

	public bool hasVertices
	{
		get
		{
			return this.verts.size > 0;
		}
	}

	public bool hasTransformed
	{
		get
		{
			return this.mRtpVerts != null && this.mRtpVerts.size > 0 && this.mRtpVerts.size == this.verts.size;
		}
	}

	public void Clear()
	{
		this.verts.Clear();
		this.uvs.Clear();
		this.cols.Clear();
		this.mRtpVerts.Clear();
	}

	public void ApplyTransform(Matrix4x4 widgetToPanel)
	{
		if (this.verts.size > 0)
		{
			this.mRtpVerts.Clear();
			int i = 0;
			int size = this.verts.size;
			while (i < size)
			{
				this.mRtpVerts.Add(widgetToPanel.MultiplyPoint3x4(this.verts[i]));
				i++;
			}
			this.mRtpNormal = widgetToPanel.MultiplyVector(Vector3.back).normalized;
			Vector3 normalized = widgetToPanel.MultiplyVector(Vector3.right).normalized;
			this.mRtpTan.x = normalized.x;
			this.mRtpTan.y = normalized.y;
			this.mRtpTan.z = normalized.z;
			this.mRtpTan.w = -1f;
		}
		else
		{
			this.mRtpVerts.Clear();
		}
	}

	public void WriteToBuffers(FastListV3 v, FastListV2 u, FastListColor32 c, BetterList<Vector3> n, BetterList<Vector4> t)
	{
		if (this.mRtpVerts != null && this.mRtpVerts.size > 0)
		{
			if (n == null)
			{
				if (this.mRtpVerts.size > 0)
				{
					v.CopyFrom(this.mRtpVerts);
					u.CopyFrom(this.uvs);
					c.CopyFrom(this.cols);
				}
			}
			else
			{
				for (int i = 0; i < this.mRtpVerts.size; i++)
				{
					v.Add(this.mRtpVerts.buffer[i].x, this.mRtpVerts.buffer[i].y, this.mRtpVerts.buffer[i].z);
					u.Add(this.uvs.buffer[i].x, this.uvs.buffer[i].y);
					c.Add(this.cols.buffer[i]);
					n.Add(this.mRtpNormal);
					t.Add(this.mRtpTan);
				}
			}
		}
	}
}
