using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XResultData : XBaseData
	{
		[DefaultValue(false), SerializeField]
		public bool LongAttackEffect;

		[DefaultValue(false), SerializeField]
		public bool Attack_Only_Target;

		[DefaultValue(false), SerializeField]
		public bool Attack_All;

		[DefaultValue(true), SerializeField]
		public bool Sector_Type;

		[DefaultValue(false), SerializeField]
		public bool Rect_HalfEffect;

		[DefaultValue(0), SerializeField]
		public int None_Sector_Angle_Shift;

		[DefaultValue(0f), SerializeField]
		public float At;

		[DefaultValue(0f), SerializeField]
		public float Low_Range;

		[DefaultValue(0f), SerializeField]
		public float Range;

		[DefaultValue(0f), SerializeField]
		public float Scope;

		[DefaultValue(0f), SerializeField]
		public float Offset_X;

		[DefaultValue(0f), SerializeField]
		public float Offset_Z;

		[DefaultValue(false), SerializeField]
		public bool Loop;

		[DefaultValue(false), SerializeField]
		public bool Group;

		[DefaultValue(0f), SerializeField]
		public float Cycle;

		[DefaultValue(0), SerializeField]
		public int Loop_Count;

		[DefaultValue(0), SerializeField]
		public int Deviation_Angle;

		[DefaultValue(0), SerializeField]
		public int Angle_Step;

		[DefaultValue(0f), SerializeField]
		public float Time_Step;

		[DefaultValue(0), SerializeField]
		public int Group_Count;

		[DefaultValue(0), SerializeField]
		public int Token;

		[DefaultValue(false), SerializeField]
		public bool Clockwise;

		[SerializeField]
		public XLongAttackResultData LongAttackData;

		[DefaultValue(false), SerializeField]
		public bool Warning;

		[DefaultValue(0), SerializeField]
		public int Warning_Idx;

		[SerializeField]
		public XResultAffectDirection Affect_Direction;

		public XResultData()
		{
			this.Sector_Type = true;
		}
	}
}
