using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XMobUnitData : XBaseData
	{
		[DefaultValue(0f), SerializeField]
		public float At;

		[DefaultValue(0), SerializeField]
		public int TemplateID;

		[DefaultValue(false), SerializeField]
		public bool LifewithinSkill;

		[DefaultValue(0f), SerializeField]
		public float Offset_At_X;

		[DefaultValue(0f), SerializeField]
		public float Offset_At_Y;

		[DefaultValue(0f), SerializeField]
		public float Offset_At_Z;
	}
}
