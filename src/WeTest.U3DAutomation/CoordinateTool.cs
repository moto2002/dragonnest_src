using System;
using UnityEngine;

namespace WeTest.U3DAutomation
{
	public class CoordinateTool
	{
		private static i a;

		public static bool GetCurrenScreenScale(ref float scalex, ref float scaley)
		{
			if (CoordinateTool.a == null)
			{
				CoordinateTool.a = r.a();
				u.c(string.Concat(new object[]
				{
					"Screen.width=",
					Screen.width,
					", Screen.height=",
					Screen.height
				}));
				if (CoordinateTool.a != null)
				{
					u.c(string.Concat(new object[]
					{
						"physicalscreen.width=",
						CoordinateTool.a.b(),
						" , physicalscreen.height=",
						CoordinateTool.a.a()
					}));
				}
			}
			if (CoordinateTool.a == null)
			{
				u.c("get physical screen failed.");
				return false;
			}
			int num = CoordinateTool.a.b();
			int num2 = CoordinateTool.a.a();
			if (Screen.width > Screen.height)
			{
				if (num < num2)
				{
					num = CoordinateTool.a.a();
					num2 = CoordinateTool.a.b();
				}
			}
			else if (Screen.width < Screen.height && num > num2)
			{
				num = CoordinateTool.a.a();
				num2 = CoordinateTool.a.b();
			}
			float num3 = (float)((double)num / ((double)Screen.width * 1.0));
			float num4 = (float)((double)num2 / ((double)Screen.height * 1.0));
			u.d(string.Concat(new object[]
			{
				"realphysicalwidth=",
				num,
				", realphysicalheight=",
				num2
			}));
			u.d(string.Concat(new object[]
			{
				"Screen.width=",
				Screen.width,
				", Screen.height=",
				Screen.height
			}));
			u.d(string.Concat(new object[]
			{
				"sx=",
				num3,
				", sy=",
				num4
			}));
			scalex = num3;
			scaley = num4;
			return true;
		}

		public static Point ConvertMobile2Unity(Point pt)
		{
			if (pt == null)
			{
				return null;
			}
			float num = 0f;
			float num2 = 0f;
			Point point = new Point(CoordinateType.UnityScreen);
			if (CoordinateTool.GetCurrenScreenScale(ref num, ref num2))
			{
				point.X = pt.X / num;
				point.Y = (float)Screen.height - pt.Y / num2;
				u.c(string.Concat(new object[]
				{
					"point(",
					pt.X,
					",",
					pt.Y,
					") => (",
					point.X,
					",",
					point.Y,
					")"
				}));
			}
			return point;
		}

		public static Point ConvertUnity2Mobile(Vector2 pt)
		{
			Point point = new Point();
			float num = (float)Screen.height - pt.y;
			float num2 = 0f;
			float num3 = 0f;
			if (CoordinateTool.GetCurrenScreenScale(ref num2, ref num3))
			{
				point.X = pt.x * num2;
				point.Y = num * num3;
				u.d(string.Concat(new object[]
				{
					"ConvertUnity2Mobile from point =(",
					pt.x,
					", ",
					pt.y,
					") ==> ( ",
					point.X,
					", ",
					point.Y,
					")"
				}));
			}
			else
			{
				point.X = pt.x;
				point.Y = num;
			}
			return point;
		}

		public static Rectangle ConvertUnity2Mobile(Rectangle rect)
		{
			Rectangle rectangle = new Rectangle();
			float num = (float)Screen.height - rect.y;
			float num2 = 0f;
			float num3 = 0f;
			if (CoordinateTool.GetCurrenScreenScale(ref num2, ref num3))
			{
				rectangle.x = rect.x * num2;
				rectangle.y = num * num3;
				rectangle.width = rect.width * num2;
				rectangle.height = rect.height * num3;
			}
			else
			{
				rectangle = rect;
			}
			return rectangle;
		}

		public static Vector2 ConvertPoint2Vector(Point pt)
		{
			Vector2 result = new Vector2(pt.X, pt.Y);
			return result;
		}

		private static Point a(Camera A_0, Vector3 A_1)
		{
			Vector3 vector = A_0.WorldToScreenPoint(A_1);
			return new Point(vector.x, (float)Screen.height - vector.y);
		}

		private static Rectangle a(Point[] A_0)
		{
			float x = A_0[0].X;
			float x2 = A_0[0].X;
			float y = A_0[0].Y;
			float y2 = A_0[0].Y;
			for (int i = 0; i < A_0.Length; i++)
			{
				Point point = A_0[i];
				if (point.X > x2)
				{
					x2 = point.X;
				}
				if (point.X < x)
				{
					x = point.X;
				}
				if (point.Y > y2)
				{
					y2 = point.Y;
				}
				if (point.Y < y)
				{
					y = point.Y;
				}
			}
			return new Rectangle(x, y, x2 - x, y2 - y);
		}

		public static Rectangle WorldBoundsToScreenRect(Camera cm, Bounds bounds)
		{
			Vector3[] array = new Vector3[]
			{
				new Vector3(bounds.center.x + bounds.extents.x, bounds.center.y + bounds.extents.y, bounds.center.z + bounds.extents.z),
				new Vector3(bounds.center.x + bounds.extents.x, bounds.center.y + bounds.extents.y, bounds.center.z - bounds.extents.z),
				new Vector3(bounds.center.x + bounds.extents.x, bounds.center.y - bounds.extents.y, bounds.center.z + bounds.extents.z),
				new Vector3(bounds.center.x - bounds.extents.x, bounds.center.y + bounds.extents.y, bounds.center.z + bounds.extents.z),
				new Vector3(bounds.center.x + bounds.extents.x, bounds.center.y - bounds.extents.y, bounds.center.z - bounds.extents.z),
				new Vector3(bounds.center.x - bounds.extents.x, bounds.center.y + bounds.extents.y, bounds.center.z - bounds.extents.z),
				new Vector3(bounds.center.x - bounds.extents.x, bounds.center.y - bounds.extents.y, bounds.center.z + bounds.extents.z),
				new Vector3(bounds.center.x - bounds.extents.x, bounds.center.y - bounds.extents.y, bounds.center.z - bounds.extents.z)
			};
			return CoordinateTool.a(new Point[]
			{
				CoordinateTool.a(cm, array[0]),
				CoordinateTool.a(cm, array[1]),
				CoordinateTool.a(cm, array[2]),
				CoordinateTool.a(cm, array[3]),
				CoordinateTool.a(cm, array[4]),
				CoordinateTool.a(cm, array[5]),
				CoordinateTool.a(cm, array[6]),
				CoordinateTool.a(cm, array[7])
			});
		}
	}
}
