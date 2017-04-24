using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XAudioData : XBaseData
	{
		[DefaultValue(0f), SerializeField]
		public float At;

		[SerializeField]
		public string Clip;

		[SerializeField]
		public AudioChannel Channel = AudioChannel.Skill;
	}
}
