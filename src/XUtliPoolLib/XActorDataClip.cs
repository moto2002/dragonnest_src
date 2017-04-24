using System;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XActorDataClip : XCutSceneClip
	{
		[SerializeField]
		public string Prefab;

		[SerializeField]
		public string Clip;

		[SerializeField]
		public float AppearX;

		[SerializeField]
		public float AppearY;

		[SerializeField]
		public float AppearZ;

		[SerializeField]
		public int StatisticsID;

		[SerializeField]
		public bool bUsingID;

		[SerializeField]
		public bool bToCommonPool;

		[SerializeField]
		public string Tag;
	}
}
