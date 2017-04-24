using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
	public class XInterpolate
	{
		public enum EaseType
		{
			Linear,
			EaseInQuad,
			EaseOutQuad,
			EaseInOutQuad,
			EaseInCubic,
			EaseOutCubic,
			EaseInOutCubic,
			EaseInQuart,
			EaseOutQuart,
			EaseInOutQuart,
			EaseInQuint,
			EaseOutQuint,
			EaseInOutQuint,
			EaseInSine,
			EaseOutSine,
			EaseInOutSine,
			EaseInExpo,
			EaseOutExpo,
			EaseInOutExpo,
			EaseInCirc,
			EaseOutCirc,
			EaseInOutCirc
		}

		public delegate Vector3 ToVector3<T>(T v);

		public delegate float Function(float a, float b, float c, float d);

		private static Vector3 Identity(Vector3 v)
		{
			return v;
		}

		private static Vector3 TransformDotPosition(Transform t)
		{
			return t.position;
		}

		private static IEnumerable<float> NewTimer(float duration)
		{
			float num = 0f;
			while (num < duration)
			{
				yield return num;
				num += Time.deltaTime;
				if (num >= duration)
				{
					yield return num;
				}
			}
			yield break;
		}

		private static IEnumerable<float> NewCounter(int start, int end, int step)
		{
			for (int i = start; i <= end; i += step)
			{
				yield return (float)i;
			}
			yield break;
		}

		public static IEnumerator NewEase(XInterpolate.Function ease, Vector3 start, Vector3 end, float duration)
		{
			IEnumerable<float> driver = XInterpolate.NewTimer(duration);
			return XInterpolate.NewEase(ease, start, end, duration, driver);
		}

		public static IEnumerator NewEase(XInterpolate.Function ease, Vector3 start, Vector3 end, int slices)
		{
			IEnumerable<float> driver = XInterpolate.NewCounter(0, slices + 1, 1);
			return XInterpolate.NewEase(ease, start, end, (float)(slices + 1), driver);
		}

		private static IEnumerator NewEase(XInterpolate.Function ease, Vector3 start, Vector3 end, float total, IEnumerable<float> driver)
		{
			Vector3 distance = end - start;
			foreach (float elapsedTime in driver)
			{
				yield return XInterpolate.Ease(ease, start, distance, elapsedTime, total);
			}
			yield break;
		}

		private static Vector3 Ease(XInterpolate.Function ease, Vector3 start, Vector3 distance, float elapsedTime, float duration)
		{
			start.x = ease(start.x, distance.x, elapsedTime, duration);
			start.y = ease(start.y, distance.y, elapsedTime, duration);
			start.z = ease(start.z, distance.z, elapsedTime, duration);
			return start;
		}

		public static XInterpolate.Function Ease(XInterpolate.EaseType type)
		{
			XInterpolate.Function result = null;
			switch (type)
			{
			case XInterpolate.EaseType.Linear:
				result = new XInterpolate.Function(XInterpolate.Linear);
				break;
			case XInterpolate.EaseType.EaseInQuad:
				result = new XInterpolate.Function(XInterpolate.EaseInQuad);
				break;
			case XInterpolate.EaseType.EaseOutQuad:
				result = new XInterpolate.Function(XInterpolate.EaseOutQuad);
				break;
			case XInterpolate.EaseType.EaseInOutQuad:
				result = new XInterpolate.Function(XInterpolate.EaseInOutQuad);
				break;
			case XInterpolate.EaseType.EaseInCubic:
				result = new XInterpolate.Function(XInterpolate.EaseInCubic);
				break;
			case XInterpolate.EaseType.EaseOutCubic:
				result = new XInterpolate.Function(XInterpolate.EaseOutCubic);
				break;
			case XInterpolate.EaseType.EaseInOutCubic:
				result = new XInterpolate.Function(XInterpolate.EaseInOutCubic);
				break;
			case XInterpolate.EaseType.EaseInQuart:
				result = new XInterpolate.Function(XInterpolate.EaseInQuart);
				break;
			case XInterpolate.EaseType.EaseOutQuart:
				result = new XInterpolate.Function(XInterpolate.EaseOutQuart);
				break;
			case XInterpolate.EaseType.EaseInOutQuart:
				result = new XInterpolate.Function(XInterpolate.EaseInOutQuart);
				break;
			case XInterpolate.EaseType.EaseInQuint:
				result = new XInterpolate.Function(XInterpolate.EaseInQuint);
				break;
			case XInterpolate.EaseType.EaseOutQuint:
				result = new XInterpolate.Function(XInterpolate.EaseOutQuint);
				break;
			case XInterpolate.EaseType.EaseInOutQuint:
				result = new XInterpolate.Function(XInterpolate.EaseInOutQuint);
				break;
			case XInterpolate.EaseType.EaseInSine:
				result = new XInterpolate.Function(XInterpolate.EaseInSine);
				break;
			case XInterpolate.EaseType.EaseOutSine:
				result = new XInterpolate.Function(XInterpolate.EaseOutSine);
				break;
			case XInterpolate.EaseType.EaseInOutSine:
				result = new XInterpolate.Function(XInterpolate.EaseInOutSine);
				break;
			case XInterpolate.EaseType.EaseInExpo:
				result = new XInterpolate.Function(XInterpolate.EaseInExpo);
				break;
			case XInterpolate.EaseType.EaseOutExpo:
				result = new XInterpolate.Function(XInterpolate.EaseOutExpo);
				break;
			case XInterpolate.EaseType.EaseInOutExpo:
				result = new XInterpolate.Function(XInterpolate.EaseInOutExpo);
				break;
			case XInterpolate.EaseType.EaseInCirc:
				result = new XInterpolate.Function(XInterpolate.EaseInCirc);
				break;
			case XInterpolate.EaseType.EaseOutCirc:
				result = new XInterpolate.Function(XInterpolate.EaseOutCirc);
				break;
			case XInterpolate.EaseType.EaseInOutCirc:
				result = new XInterpolate.Function(XInterpolate.EaseInOutCirc);
				break;
			}
			return result;
		}

		public static IEnumerable<Vector3> NewBezier(XInterpolate.Function ease, Transform[] nodes, float duration)
		{
			IEnumerable<float> steps = XInterpolate.NewTimer(duration);
			return XInterpolate.NewBezier<Transform>(ease, nodes, new XInterpolate.ToVector3<Transform>(XInterpolate.TransformDotPosition), duration, steps);
		}

		public static IEnumerable<Vector3> NewBezier(XInterpolate.Function ease, Transform[] nodes, int slices)
		{
			IEnumerable<float> steps = XInterpolate.NewCounter(0, slices + 1, 1);
			return XInterpolate.NewBezier<Transform>(ease, nodes, new XInterpolate.ToVector3<Transform>(XInterpolate.TransformDotPosition), (float)(slices + 1), steps);
		}

		public static IEnumerable<Vector3> NewBezier(XInterpolate.Function ease, Vector3[] points, float duration)
		{
			IEnumerable<float> steps = XInterpolate.NewTimer(duration);
			return XInterpolate.NewBezier<Vector3>(ease, points, new XInterpolate.ToVector3<Vector3>(XInterpolate.Identity), duration, steps);
		}

		public static IEnumerable<Vector3> NewBezier(XInterpolate.Function ease, Vector3[] points, int slices)
		{
			IEnumerable<float> steps = XInterpolate.NewCounter(0, slices + 1, 1);
			return XInterpolate.NewBezier<Vector3>(ease, points, new XInterpolate.ToVector3<Vector3>(XInterpolate.Identity), (float)(slices + 1), steps);
		}

		private static IEnumerable<Vector3> NewBezier<T>(XInterpolate.Function ease, IList nodes, XInterpolate.ToVector3<T> toVector3, float maxStep, IEnumerable<float> steps)
		{
			if (nodes.Count >= 2)
			{
				Vector3[] array = new Vector3[nodes.Count];
				foreach (float elapsedTime in steps)
				{
					for (int i = 0; i < nodes.Count; i++)
					{
						array[i] = toVector3((T)((object)nodes[i]));
					}
					yield return XInterpolate.Bezier(ease, array, elapsedTime, maxStep);
				}
			}
			yield break;
		}

		private static Vector3 Bezier(XInterpolate.Function ease, Vector3[] points, float elapsedTime, float duration)
		{
			for (int i = points.Length - 1; i > 0; i--)
			{
				for (int j = 0; j < i; j++)
				{
					points[j].x = ease(points[j].x, points[j + 1].x - points[j].x, elapsedTime, duration);
					points[j].y = ease(points[j].y, points[j + 1].y - points[j].y, elapsedTime, duration);
					points[j].z = ease(points[j].z, points[j + 1].z - points[j].z, elapsedTime, duration);
				}
			}
			return points[0];
		}

		public static IEnumerable<Vector3> NewCatmullRom(Transform[] nodes, int slices, bool loop)
		{
			return XInterpolate.NewCatmullRom<Transform>(nodes, new XInterpolate.ToVector3<Transform>(XInterpolate.TransformDotPosition), slices, loop);
		}

		public static IEnumerable<Vector3> NewCatmullRom(Vector3[] points, int slices, bool loop)
		{
			return XInterpolate.NewCatmullRom<Vector3>(points, new XInterpolate.ToVector3<Vector3>(XInterpolate.Identity), slices, loop);
		}

		private static IEnumerable<Vector3> NewCatmullRom<T>(IList nodes, XInterpolate.ToVector3<T> toVector3, int slices, bool loop)
		{
			if (nodes.Count >= 2)
			{
				yield return toVector3((T)((object)nodes[0]));
				int num = nodes.Count - 1;
				int num2 = 0;
				while (loop || num2 < num)
				{
					if (loop && num2 > num)
					{
						num2 = 0;
					}
					int index = (num2 == 0) ? (loop ? num : num2) : (num2 - 1);
					int index2 = num2;
					int num3 = (num2 == num) ? (loop ? 0 : num2) : (num2 + 1);
					int index3 = (num3 == num) ? (loop ? 0 : num3) : (num3 + 1);
					int num4 = slices + 1;
					for (int i = 1; i <= num4; i++)
					{
						yield return XInterpolate.CatmullRom(toVector3((T)((object)nodes[index])), toVector3((T)((object)nodes[index2])), toVector3((T)((object)nodes[num3])), toVector3((T)((object)nodes[index3])), (float)i, (float)num4);
					}
					num2++;
				}
			}
			yield break;
		}

		private static Vector3 CatmullRom(Vector3 previous, Vector3 start, Vector3 end, Vector3 next, float elapsedTime, float duration)
		{
			float num = elapsedTime / duration;
			float num2 = num * num;
			float num3 = num2 * num;
			return previous * (-0.5f * num3 + num2 - 0.5f * num) + start * (1.5f * num3 + -2.5f * num2 + 1f) + end * (-1.5f * num3 + 2f * num2 + 0.5f * num) + next * (0.5f * num3 - 0.5f * num2);
		}

		private static float Linear(float start, float distance, float elapsedTime, float duration)
		{
			if (elapsedTime > duration)
			{
				elapsedTime = duration;
			}
			return distance * (elapsedTime / duration) + start;
		}

		private static float EaseInQuad(float start, float distance, float elapsedTime, float duration)
		{
			elapsedTime = ((elapsedTime > duration) ? 1f : (elapsedTime / duration));
			return distance * elapsedTime * elapsedTime + start;
		}

		private static float EaseOutQuad(float start, float distance, float elapsedTime, float duration)
		{
			elapsedTime = ((elapsedTime > duration) ? 1f : (elapsedTime / duration));
			return -distance * elapsedTime * (elapsedTime - 2f) + start;
		}

		private static float EaseInOutQuad(float start, float distance, float elapsedTime, float duration)
		{
			elapsedTime = ((elapsedTime > duration) ? 2f : (elapsedTime / (duration / 2f)));
			if (elapsedTime < 1f)
			{
				return distance / 2f * elapsedTime * elapsedTime + start;
			}
			elapsedTime -= 1f;
			return -distance / 2f * (elapsedTime * (elapsedTime - 2f) - 1f) + start;
		}

		private static float EaseInCubic(float start, float distance, float elapsedTime, float duration)
		{
			elapsedTime = ((elapsedTime > duration) ? 1f : (elapsedTime / duration));
			return distance * elapsedTime * elapsedTime * elapsedTime + start;
		}

		private static float EaseOutCubic(float start, float distance, float elapsedTime, float duration)
		{
			elapsedTime = ((elapsedTime > duration) ? 1f : (elapsedTime / duration));
			elapsedTime -= 1f;
			return distance * (elapsedTime * elapsedTime * elapsedTime + 1f) + start;
		}

		private static float EaseInOutCubic(float start, float distance, float elapsedTime, float duration)
		{
			elapsedTime = ((elapsedTime > duration) ? 2f : (elapsedTime / (duration / 2f)));
			if (elapsedTime < 1f)
			{
				return distance / 2f * elapsedTime * elapsedTime * elapsedTime + start;
			}
			elapsedTime -= 2f;
			return distance / 2f * (elapsedTime * elapsedTime * elapsedTime + 2f) + start;
		}

		private static float EaseInQuart(float start, float distance, float elapsedTime, float duration)
		{
			elapsedTime = ((elapsedTime > duration) ? 1f : (elapsedTime / duration));
			return distance * elapsedTime * elapsedTime * elapsedTime * elapsedTime + start;
		}

		private static float EaseOutQuart(float start, float distance, float elapsedTime, float duration)
		{
			elapsedTime = ((elapsedTime > duration) ? 1f : (elapsedTime / duration));
			elapsedTime -= 1f;
			return -distance * (elapsedTime * elapsedTime * elapsedTime * elapsedTime - 1f) + start;
		}

		private static float EaseInOutQuart(float start, float distance, float elapsedTime, float duration)
		{
			elapsedTime = ((elapsedTime > duration) ? 2f : (elapsedTime / (duration / 2f)));
			if (elapsedTime < 1f)
			{
				return distance / 2f * elapsedTime * elapsedTime * elapsedTime * elapsedTime + start;
			}
			elapsedTime -= 2f;
			return -distance / 2f * (elapsedTime * elapsedTime * elapsedTime * elapsedTime - 2f) + start;
		}

		private static float EaseInQuint(float start, float distance, float elapsedTime, float duration)
		{
			elapsedTime = ((elapsedTime > duration) ? 1f : (elapsedTime / duration));
			return distance * elapsedTime * elapsedTime * elapsedTime * elapsedTime * elapsedTime + start;
		}

		private static float EaseOutQuint(float start, float distance, float elapsedTime, float duration)
		{
			elapsedTime = ((elapsedTime > duration) ? 1f : (elapsedTime / duration));
			elapsedTime -= 1f;
			return distance * (elapsedTime * elapsedTime * elapsedTime * elapsedTime * elapsedTime + 1f) + start;
		}

		private static float EaseInOutQuint(float start, float distance, float elapsedTime, float duration)
		{
			elapsedTime = ((elapsedTime > duration) ? 2f : (elapsedTime / (duration / 2f)));
			if (elapsedTime < 1f)
			{
				return distance / 2f * elapsedTime * elapsedTime * elapsedTime * elapsedTime * elapsedTime + start;
			}
			elapsedTime -= 2f;
			return distance / 2f * (elapsedTime * elapsedTime * elapsedTime * elapsedTime * elapsedTime + 2f) + start;
		}

		private static float EaseInSine(float start, float distance, float elapsedTime, float duration)
		{
			if (elapsedTime > duration)
			{
				elapsedTime = duration;
			}
			return -distance * Mathf.Cos(elapsedTime / duration * 1.57079637f) + distance + start;
		}

		private static float EaseOutSine(float start, float distance, float elapsedTime, float duration)
		{
			if (elapsedTime > duration)
			{
				elapsedTime = duration;
			}
			return distance * Mathf.Sin(elapsedTime / duration * 1.57079637f) + start;
		}

		private static float EaseInOutSine(float start, float distance, float elapsedTime, float duration)
		{
			if (elapsedTime > duration)
			{
				elapsedTime = duration;
			}
			return -distance / 2f * (Mathf.Cos(3.14159274f * elapsedTime / duration) - 1f) + start;
		}

		private static float EaseInExpo(float start, float distance, float elapsedTime, float duration)
		{
			if (elapsedTime > duration)
			{
				elapsedTime = duration;
			}
			return distance * Mathf.Pow(2f, 10f * (elapsedTime / duration - 1f)) + start;
		}

		private static float EaseOutExpo(float start, float distance, float elapsedTime, float duration)
		{
			if (elapsedTime > duration)
			{
				elapsedTime = duration;
			}
			return distance * (-Mathf.Pow(2f, -10f * elapsedTime / duration) + 1f) + start;
		}

		private static float EaseInOutExpo(float start, float distance, float elapsedTime, float duration)
		{
			elapsedTime = ((elapsedTime > duration) ? 2f : (elapsedTime / (duration / 2f)));
			if (elapsedTime < 1f)
			{
				return distance / 2f * Mathf.Pow(2f, 10f * (elapsedTime - 1f)) + start;
			}
			elapsedTime -= 1f;
			return distance / 2f * (-Mathf.Pow(2f, -10f * elapsedTime) + 2f) + start;
		}

		private static float EaseInCirc(float start, float distance, float elapsedTime, float duration)
		{
			elapsedTime = ((elapsedTime > duration) ? 1f : (elapsedTime / duration));
			return -distance * (Mathf.Sqrt(1f - elapsedTime * elapsedTime) - 1f) + start;
		}

		private static float EaseOutCirc(float start, float distance, float elapsedTime, float duration)
		{
			elapsedTime = ((elapsedTime > duration) ? 1f : (elapsedTime / duration));
			elapsedTime -= 1f;
			return distance * Mathf.Sqrt(1f - elapsedTime * elapsedTime) + start;
		}

		private static float EaseInOutCirc(float start, float distance, float elapsedTime, float duration)
		{
			elapsedTime = ((elapsedTime > duration) ? 2f : (elapsedTime / (duration / 2f)));
			if (elapsedTime < 1f)
			{
				return -distance / 2f * (Mathf.Sqrt(1f - elapsedTime * elapsedTime) - 1f) + start;
			}
			elapsedTime -= 2f;
			return distance / 2f * (Mathf.Sqrt(1f - elapsedTime * elapsedTime) + 1f) + start;
		}
	}
}
