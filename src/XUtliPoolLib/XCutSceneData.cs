using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XCutSceneData
	{
		[SerializeField]
		public float TotalFrame;

		[SerializeField]
		public string CameraClip;

		[SerializeField]
		public string Name;

		[SerializeField]
		public string Script;

		[SerializeField]
		public string Scene;

		[SerializeField]
		public int TypeMask = -1;

		[SerializeField]
		public bool OverrideBGM = true;

		[SerializeField]
		public bool Mourningborder = true;

		[SerializeField]
		public bool AutoEnd = true;

		[SerializeField]
		public float Length;

		[SerializeField]
		public float FieldOfView = 45f;

		[SerializeField]
		public string Trigger = "ToEffect";

		[SerializeField]
		public bool GeneralShow;

		[SerializeField]
		public bool GeneralBigGuy;

		[SerializeField]
		public List<XActorDataClip> Actors = new List<XActorDataClip>();

		[SerializeField]
		public List<XPlayerDataClip> Player = new List<XPlayerDataClip>();

		[SerializeField]
		public List<XFxDataClip> Fxs = new List<XFxDataClip>();

		[SerializeField]
		public List<XAudioDataClip> Audios = new List<XAudioDataClip>();

		[SerializeField]
		public List<XSubTitleDataClip> SubTitle = new List<XSubTitleDataClip>();

		[SerializeField]
		public List<XSlashDataClip> Slash = new List<XSlashDataClip>();
	}
}
