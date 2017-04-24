using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XWarningData : XBaseData
	{
		[DefaultValue(0f), SerializeField]
		public float At;

		[DefaultValue(0f), SerializeField]
		public float FxDuration;

		[DefaultValue(0f), SerializeField]
		public float OffsetX;

		[DefaultValue(0f), SerializeField]
		public float OffsetY;

		[DefaultValue(0f), SerializeField]
		public float OffsetZ;

		[SerializeField]
		public string Fx;

		[DefaultValue(1f), SerializeField]
		public float Scale = 1f;

		[DefaultValue(false), SerializeField]
		public bool UnderFeet;

		[DefaultValue(false), SerializeField]
		public bool AttackAll;

		public XWarningData()
		{
			this.Scale = 1f;
		}
	}
}
