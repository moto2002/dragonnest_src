using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace XUtliPoolLib
{
	public class XCommon : XSingleton<XCommon>
	{
		public readonly float FrameStep = 0.0333333351f;

		private static readonly float _eps = 0.0001f;

		private System.Random _random = new System.Random(DateTime.Now.Millisecond);

		private int _idx;

		private uint[] _seeds = new uint[]
		{
			17u,
			33u,
			65u,
			129u
		};

		private int _new_id;

		public StringBuilder shareSB = new StringBuilder();

		public static List<Renderer> tmpRender = new List<Renderer>();

		public static List<ParticleSystem> tmpParticle = new List<ParticleSystem>();

		public static float XEps
		{
			get
			{
				return XCommon._eps;
			}
		}

		public int New_id
		{
			get
			{
				return ++this._new_id;
			}
		}

		public long UniqueToken
		{
			get
			{
				return DateTime.Now.Ticks + (long)this.New_id;
			}
		}

		public XCommon()
		{
			this._idx = 5;
		}

		public uint XHash(string str)
		{
			if (str == null)
			{
				return 0u;
			}
			uint num = 0u;
			for (int i = 0; i < str.Length; i++)
			{
				num = (num << this._idx) + num + (uint)str[i];
			}
			return num;
		}

		public uint XHashLower(string str)
		{
			if (str == null)
			{
				return 0u;
			}
			uint num = 0u;
			for (int i = 0; i < str.Length; i++)
			{
				char c = char.ToLower(str[i]);
				num = (num << this._idx) + num + (uint)c;
			}
			return num;
		}

		public uint XHash(StringBuilder str)
		{
			if (str == null)
			{
				return 0u;
			}
			uint num = 0u;
			for (int i = 0; i < str.Length; i++)
			{
				num = (num << this._idx) + num + (uint)str[i];
			}
			return num;
		}

		public bool IsEqual(float a, float b)
		{
			return a == b;
		}

		public bool IsLess(float a, float b)
		{
			return a < b;
		}

		public int Range(int value, int min, int max)
		{
			value = Math.Max(value, min);
			return Math.Min(value, max);
		}

		public bool IsGreater(float a, float b)
		{
			return a > b;
		}

		public bool IsEqualLess(float a, float b)
		{
			return a <= b;
		}

		public bool IsEqualGreater(float a, float b)
		{
			return a >= b;
		}

		public uint GetToken()
		{
			return (uint)DateTime.Now.Millisecond;
		}

		public void ProcessValueDamp(ref float values, float target, ref float factor, float deltaT)
		{
			if (XSingleton<XCommon>.singleton.IsEqual(values, target))
			{
				values = target;
				factor = 0f;
				return;
			}
			values += (target - values) * Mathf.Min(1f, deltaT * factor);
		}

		public void ProcessValueEvenPace(ref float value, float target, float speed, float deltaT)
		{
			float num = target - value;
			float num2 = target - (num - speed * deltaT);
			if (XSingleton<XCommon>.singleton.IsGreater((target - num2) * num, 0f))
			{
				value = num2;
				return;
			}
			value = target;
		}

		public bool IsRectCycleCross(float rectw, float recth, Vector3 c, float r)
		{
			Vector3 vector = new Vector3(Mathf.Max(Mathf.Abs(c.x) - rectw, 0f), 0f, Mathf.Max(Mathf.Abs(c.z) - recth, 0f));
			return vector.sqrMagnitude < r * r;
		}

		public bool Intersection(Vector2 begin, Vector2 end, Vector2 center, float radius, out float t)
		{
			t = 0f;
			float num = radius * radius;
			Vector2 from = center - begin;
			float sqrMagnitude = from.sqrMagnitude;
			if (sqrMagnitude < num)
			{
				return true;
			}
			Vector2 to = end - begin;
			if (to.sqrMagnitude > 0f)
			{
				float num2 = Mathf.Sqrt(sqrMagnitude) * Mathf.Cos(Vector2.Angle(from, to));
				if (num2 >= 0f)
				{
					float num3 = sqrMagnitude - num2 * num2;
					if (num3 < num)
					{
						float f = num - num3;
						t = num2 - Mathf.Sqrt(f);
						return true;
					}
				}
			}
			return false;
		}

		private float CrossProduct(float x1, float z1, float x2, float z2)
		{
			return x1 * z2 - x2 * z1;
		}

		public bool IsLineSegmentCross(Vector3 p1, Vector3 p2, Vector3 q1, Vector3 q2)
		{
			if (Mathf.Min(p1.x, p2.x) <= Mathf.Max(q1.x, q2.x) && Mathf.Min(q1.x, q2.x) <= Mathf.Max(p1.x, p2.x) && Mathf.Min(p1.z, p2.z) <= Mathf.Max(q1.z, q2.z) && Mathf.Min(q1.z, q2.z) <= Mathf.Max(p1.z, p2.z))
			{
				float num = this.CrossProduct(p1.x - q1.x, p1.z - q1.z, q2.x - q1.x, q2.z - q1.z);
				float num2 = this.CrossProduct(p2.x - q1.x, p2.z - q1.z, q2.x - q1.x, q2.z - q1.z);
				float num3 = this.CrossProduct(q1.x - p1.x, q1.z - p1.z, p2.x - p1.x, p2.z - p1.z);
				float num4 = this.CrossProduct(q2.x - p1.x, q2.z - p1.z, p2.x - p1.x, p2.z - p1.z);
				return num * num2 <= 0f && num3 * num4 <= 0f;
			}
			return false;
		}

		public Vector3 Horizontal(Vector3 v)
		{
			v.y = 0f;
			return v.normalized;
		}

		public void Horizontal(ref Vector3 v)
		{
			v.y = 0f;
			v.Normalize();
		}

		public float AngleNormalize(float basic, float degree)
		{
			Vector3 vector = this.FloatToAngle(basic);
			Vector3 vector2 = this.FloatToAngle(degree);
			float num = Vector3.Angle(vector, vector2);
			if (!this.Clockwise(vector, vector2))
			{
				return basic - num;
			}
			return basic + num;
		}

		public Vector2 HorizontalRotateVetor2(Vector2 v, float degree, bool normalized = true)
		{
			degree = -degree;
			float f = degree * 0.0174532924f;
			float num = Mathf.Sin(f);
			float num2 = Mathf.Cos(f);
			float x = v.x * num2 - v.y * num;
			float y = v.x * num + v.y * num2;
			v.x = x;
			v.y = y;
			if (!normalized)
			{
				return v;
			}
			return v.normalized;
		}

		public Vector3 HorizontalRotateVetor3(Vector3 v, float degree, bool normalized = true)
		{
			degree = -degree;
			float f = degree * 0.0174532924f;
			float num = Mathf.Sin(f);
			float num2 = Mathf.Cos(f);
			float x = v.x * num2 - v.z * num;
			float z = v.x * num + v.z * num2;
			v.x = x;
			v.z = z;
			if (!normalized)
			{
				return v;
			}
			return v.normalized;
		}

		public float TicksToSeconds(long tick)
		{
			long num = tick / 10000L;
			return (float)num / 1000f;
		}

		public long SecondsToTicks(float time)
		{
			long num = (long)(time * 1000f);
			return num * 10000L;
		}

		public float AngleToFloat(Vector3 dir)
		{
			float num = Vector3.Angle(Vector3.forward, dir);
			if (!XSingleton<XCommon>.singleton.Clockwise(Vector3.forward, dir))
			{
				return -num;
			}
			return num;
		}

		public float AngleWithSign(Vector3 from, Vector3 to)
		{
			float num = Vector3.Angle(from, to);
			if (!this.Clockwise(from, to))
			{
				return -num;
			}
			return num;
		}

		public Vector3 FloatToAngle(float angle)
		{
			return Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
		}

		public Quaternion VectorToQuaternion(Vector3 v)
		{
			return XSingleton<XCommon>.singleton.FloatToQuaternion(XSingleton<XCommon>.singleton.AngleWithSign(Vector3.forward, v));
		}

		public Quaternion FloatToQuaternion(float angle)
		{
			return Quaternion.Euler(0f, angle, 0f);
		}

		public Quaternion RotateToGround(Vector3 pos, Vector3 forward)
		{
			RaycastHit raycastHit;
			if (Physics.Raycast(new Ray(pos + Vector3.up, Vector3.down), out raycastHit, 5f, 513))
			{
				Vector3 normal = raycastHit.normal;
				Vector3 forward2 = forward;
				Vector3.OrthoNormalize(ref normal, ref forward2);
				return Quaternion.LookRotation(forward2, normal);
			}
			return Quaternion.identity;
		}

		public bool Clockwise(Vector3 fiduciary, Vector3 relativity)
		{
			float num = fiduciary.z * relativity.x - fiduciary.x * relativity.z;
			return num > 0f;
		}

		public bool Clockwise(Vector2 fiduciary, Vector2 relativity)
		{
			float num = fiduciary.y * relativity.x - fiduciary.x * relativity.y;
			return num > 0f;
		}

		public bool IsInRect(Vector3 point, Rect rect, Vector3 center, Quaternion rotation)
		{
			float num = -(rotation.eulerAngles.y % 360f) / 180f * 3.14159274f;
			Quaternion identity = Quaternion.identity;
			identity.w = Mathf.Cos(num / 2f);
			identity.x = 0f;
			identity.y = Mathf.Sin(num / 2f);
			identity.z = 0f;
			point = identity * (point - center);
			return point.x > rect.xMin && point.x < rect.xMax && point.z > rect.yMin && point.z < rect.yMax;
		}

		public float RandomPercentage()
		{
			return (float)this._random.NextDouble();
		}

		public float RandomPercentage(float min)
		{
			if (this.IsEqualGreater(min, 1f))
			{
				return 1f;
			}
			float num = (float)this._random.NextDouble();
			if (this.IsGreater(num, min))
			{
				return num;
			}
			return num / min * (1f - min) + min;
		}

		public float RandomFloat(float max)
		{
			return this.RandomPercentage() * max;
		}

		public float RandomFloat(float min, float max)
		{
			return min + this.RandomFloat(max - min);
		}

		public int RandomInt(int min, int max)
		{
			return this._random.Next(min, max);
		}

		public int RandomInt(int max)
		{
			return this._random.Next(max);
		}

		public int RandomInt()
		{
			return this._random.Next();
		}

		public bool IsInteger(float n)
		{
			return Mathf.Abs(n - (float)((int)n)) < XCommon._eps || Mathf.Abs(n - (float)((int)n)) > 1f - XCommon._eps;
		}

		public float GetFloatingValue(float value, float floating)
		{
			if (this.IsEqualLess(floating, 0f) || this.IsEqualGreater(floating, 1f))
			{
				return value;
			}
			float num = this.IsLess(this.RandomPercentage(), 0.5f) ? (1f - floating) : (1f + floating);
			return value * num;
		}

		public float GetSmoothFactor(float distance, float timespan, float nearenough)
		{
			float result = 0f;
			distance = Mathf.Abs(distance);
			if (distance > XCommon.XEps)
			{
				float smoothDeltaTime = Time.smoothDeltaTime;
				float f = nearenough / distance;
				float num = timespan / smoothDeltaTime;
				if (num > 1f)
				{
					float num2 = Mathf.Pow(f, 1f / num);
					result = (1f - num2) / smoothDeltaTime;
				}
				else
				{
					result = float.PositiveInfinity;
				}
			}
			return result;
		}

		public float GetJumpForce(float airTime, float g)
		{
			return 0f;
		}

		public string SecondsToString(int time)
		{
			int num = time / 60;
			int num2 = time % 60;
			return string.Format("{0:D2}:{1}", num, num2);
		}

		public double Clamp(double value, double min, double max)
		{
			return Math.Min(Math.Max(min, value), max);
		}

		public Transform FindChildRecursively(Transform t, string name)
		{
			if (t.name == name)
			{
				return t;
			}
			for (int i = 0; i < t.childCount; i++)
			{
				Transform transform = this.FindChildRecursively(t.GetChild(i), name);
				if (transform != null)
				{
					return transform;
				}
			}
			return null;
		}

		public void CleanStringCombine()
		{
			this.shareSB.Length = 0;
		}

		public StringBuilder GetSharedStringBuilder()
		{
			return this.shareSB;
		}

		public string GetString()
		{
			return this.shareSB.ToString();
		}

		public XCommon AppendString(string s)
		{
			this.shareSB.Append(s);
			return this;
		}

		public XCommon AppendString(string s0, string s1)
		{
			this.shareSB.Append(s0);
			this.shareSB.Append(s1);
			return this;
		}

		public XCommon AppendString(string s0, string s1, string s2)
		{
			this.shareSB.Append(s0);
			this.shareSB.Append(s1);
			this.shareSB.Append(s2);
			return this;
		}

		public string StringCombine(string s0, string s1)
		{
			this.shareSB.Length = 0;
			this.shareSB.Append(s0);
			this.shareSB.Append(s1);
			return this.shareSB.ToString();
		}

		public string StringCombine(string s0, string s1, string s2)
		{
			this.shareSB.Length = 0;
			this.shareSB.Append(s0);
			this.shareSB.Append(s1);
			this.shareSB.Append(s2);
			return this.shareSB.ToString();
		}

		public string StringCombine(string s0, string s1, string s2, string s3)
		{
			this.shareSB.Length = 0;
			this.shareSB.Append(s0);
			this.shareSB.Append(s1);
			this.shareSB.Append(s2);
			this.shareSB.Append(s3);
			return this.shareSB.ToString();
		}

		public uint CombineAdd(uint value, int heigh, int low)
		{
			int num = (int)((value >> 16) + (uint)heigh);
			int num2 = (int)((value & 65535u) + (uint)low);
			return (uint)(num << 16 | num2);
		}

		public void CombineSetHeigh(ref uint value, uint heigh)
		{
			value = (heigh << 16 | (value & 65535u));
		}

		public ushort CombineGetHeigh(uint value)
		{
			return (ushort)(value >> 16);
		}

		public void CombineSetLow(ref uint value, uint low)
		{
			value = ((value & 4294901760u) | (low & 65535u));
		}

		public ushort CombineGetLow(uint value)
		{
			return (ushort)(value & 65535u);
		}

		public void EnableParticleRenderer(GameObject go, bool enable)
		{
			Animator componentInChildren = go.GetComponentInChildren<Animator>();
			if (componentInChildren != null)
			{
				componentInChildren.enabled = enable;
			}
			this.EnableParticle(go, enable);
		}

		public void EnableParticle(GameObject go, bool enable)
		{
			go.GetComponentsInChildren<ParticleSystem>(XCommon.tmpParticle);
			int i = 0;
			int count = XCommon.tmpParticle.Count;
			while (i < count)
			{
				ParticleSystem particleSystem = XCommon.tmpParticle[i];
				if (enable)
				{
					particleSystem.Play();
				}
				else
				{
					particleSystem.Stop();
				}
				i++;
			}
			XCommon.tmpParticle.Clear();
		}

		public override bool Init()
		{
			return true;
		}

		public override void Uninit()
		{
		}
	}
}
