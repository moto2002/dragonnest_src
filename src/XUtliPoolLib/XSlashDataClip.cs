using System;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XSlashDataClip : XCutSceneClip
	{
		[SerializeField]
		public float Duration = 1f;

		[SerializeField]
		public string Name;

		[SerializeField]
		public string Discription;

		[SerializeField]
		public float AnchorX;

		[SerializeField]
		public float AnchorY;
	}
}
