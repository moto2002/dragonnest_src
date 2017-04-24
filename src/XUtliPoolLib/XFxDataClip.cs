using System;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XFxDataClip : XCutSceneClip
	{
		[SerializeField]
		public string Fx;

		[SerializeField]
		public int BindIdx;

		[SerializeField]
		public string Bone;

		[SerializeField]
		public float Scale = 1f;

		[SerializeField]
		public bool Follow = true;

		[SerializeField]
		public float Destroy_Delay;

		[SerializeField]
		public float AppearX;

		[SerializeField]
		public float AppearY;

		[SerializeField]
		public float AppearZ;

		[SerializeField]
		public float Face;
	}
}
