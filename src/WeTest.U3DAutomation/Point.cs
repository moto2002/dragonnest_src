using System;
using System.Text;

namespace WeTest.U3DAutomation
{
	public class Point
	{
		private float a;

		private float b;

		private CoordinateType c;

		public float X
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		public float Y
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		public CoordinateType Type
		{
			get
			{
				return this.c;
			}
		}

		public Point(CoordinateType type)
		{
			this.c = type;
		}

		public Point(float x, float y)
		{
			this.a = x;
			this.b = y;
		}

		public Point(float x, float y, CoordinateType type)
		{
			this.a = x;
			this.b = y;
			this.c = type;
		}

		public Point()
		{
			this.a = 0f;
			this.b = 0f;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("x=");
			stringBuilder.Append(this.a.ToString());
			stringBuilder.Append("; y=");
			stringBuilder.Append(this.b.ToString());
			return stringBuilder.ToString();
		}
	}
}
