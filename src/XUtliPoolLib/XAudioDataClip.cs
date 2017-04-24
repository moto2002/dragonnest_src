using System;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XAudioDataClip : XCutSceneClip
	{
		[SerializeField]
		public string Clip;

		[SerializeField]
		public int BindIdx;

		[SerializeField]
		public AudioChannel Channel = AudioChannel.Skill;
	}
}
