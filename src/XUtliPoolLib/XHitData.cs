using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XHitData : XBaseData
	{
		[DefaultValue(0f), SerializeField]
		public float Time_Present_Straight;

		[DefaultValue(0f), SerializeField]
		public float Time_Hard_Straight;

		[DefaultValue(0f), SerializeField]
		public float Offset;

		[DefaultValue(0f), SerializeField]
		public float Height;

		[SerializeField]
		public XBeHitState State;

		[SerializeField]
		public XBeHitState_Animation State_Animation;

		[DefaultValue(0f), SerializeField]
		public float Random_Range;

		[SerializeField]
		public string Fx;

		[DefaultValue(true), SerializeField]
		public bool Fx_Follow;

		[DefaultValue(false), SerializeField]
		public bool Fx_StickToGround;

		[DefaultValue(false), SerializeField]
		public bool CurveUsing;

		[DefaultValue(false), SerializeField]
		public bool FreezePresent;

		[DefaultValue(0f), SerializeField]
		public float FreezeDuration;

		[DefaultValue(true), SerializeField]
		public bool Additional_Using_Default;

		[DefaultValue(0f), SerializeField]
		public float Additional_Hit_Time_Present_Straight;

		[DefaultValue(0f), SerializeField]
		public float Additional_Hit_Time_Hard_Straight;

		[DefaultValue(0f), SerializeField]
		public float Additional_Hit_Offset;

		[DefaultValue(0f), SerializeField]
		public float Additional_Hit_Height;

		public XHitData()
		{
			this.Fx_Follow = true;
			this.Additional_Using_Default = true;
		}
	}
}
