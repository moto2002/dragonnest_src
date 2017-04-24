using System;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public abstract class XCutSceneClip
	{
		[SerializeField]
		public XClipType Type;

		[SerializeField]
		public float TimeLineAt;
	}
}
