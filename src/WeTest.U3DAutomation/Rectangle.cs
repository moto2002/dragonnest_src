using System;
using System.Text;
using UnityEngine;

namespace WeTest.U3DAutomation
{
	public class Rectangle
	{
		public float _x;

		public float _y;

		public float _width;

		public float _height;

		public float x
		{
			get
			{
				return this._x;
			}
			set
			{
				this._x = value;
			}
		}

		public float y
		{
			get
			{
				return this._y;
			}
			set
			{
				this._y = value;
			}
		}

		public float width
		{
			get
			{
				return this._width;
			}
			set
			{
				this._width = value;
			}
		}

		public float height
		{
			get
			{
				return this._height;
			}
			set
			{
				this._height = value;
			}
		}

		public Rectangle()
		{
			this.x = 0f;
			this.y = 0f;
			this.width = 0f;
			this.height = 0f;
		}

		public Rectangle(float x, float y, float width, float height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}

		public Rect ToRect()
		{
			return new Rect(this.x, this.y, this.width, this.height);
		}

		public bool ContainPt(Point pt)
		{
			return pt.X > this._x && pt.X < this._x + this._width && pt.Y > this._y && pt.Y < this._y + this._height;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("x=");
			stringBuilder.Append(this._x.ToString());
			stringBuilder.Append("; y=");
			stringBuilder.Append(this._y.ToString());
			stringBuilder.Append("; width=");
			stringBuilder.Append(this._width.ToString());
			stringBuilder.Append("; height=");
			stringBuilder.Append(this._height.ToString());
			return stringBuilder.ToString();
		}
	}
}
