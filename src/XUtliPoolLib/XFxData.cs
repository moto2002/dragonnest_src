using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XFxData : XBaseData
	{
		[SerializeField]
		public SkillFxType Type;

		[DefaultValue(0f), SerializeField]
		public float At;

		[DefaultValue(0f), SerializeField]
		public float End;

		[SerializeField]
		public string Fx;

		[SerializeField]
		public string Bone;

		[DefaultValue(1f), SerializeField]
		public float ScaleX;

		[DefaultValue(1f), SerializeField]
		public float ScaleY;

		[DefaultValue(1f), SerializeField]
		public float ScaleZ;

		[DefaultValue(0f), SerializeField]
		public float OffsetX;

		[DefaultValue(0f), SerializeField]
		public float OffsetY;

		[DefaultValue(0f), SerializeField]
		public float OffsetZ;

		[DefaultValue(0f), SerializeField]
		public float Target_OffsetX;

		[DefaultValue(0f), SerializeField]
		public float Target_OffsetY;

		[DefaultValue(0f), SerializeField]
		public float Target_OffsetZ;

		[DefaultValue(true), SerializeField]
		public bool Follow;

		[DefaultValue(false), SerializeField]
		public bool StickToGround;

		[DefaultValue(0f), SerializeField]
		public float Destroy_Delay;

		[DefaultValue(false), SerializeField]
		public bool Combined;

		public XFxData()
		{
			this.Follow = true;
			this.ScaleX = 1f;
			this.ScaleY = 1f;
			this.ScaleZ = 1f;
		}
	}
}
