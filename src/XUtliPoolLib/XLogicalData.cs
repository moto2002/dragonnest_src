using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XLogicalData
	{
		[SerializeField]
		public XStrickenResponse StrickenMask = XStrickenResponse.Cease;

		[DefaultValue(0), SerializeField]
		public int CanReplacedby;

		[DefaultValue(0f), SerializeField]
		public float Not_Move_At;

		[DefaultValue(0f), SerializeField]
		public float Not_Move_End;

		[DefaultValue(0f), SerializeField]
		public float Rotate_At;

		[DefaultValue(0f), SerializeField]
		public float Rotate_End;

		[DefaultValue(0f), SerializeField]
		public float Rotate_Speed;

		[DefaultValue(false), SerializeField]
		public bool Rotate_Server_Sync;

		[DefaultValue(0), SerializeField]
		public int CanCastAt_QTE;

		[DefaultValue(0), SerializeField]
		public int QTE_Key;

		[SerializeField]
		public List<XQTEData> QTEData;

		[DefaultValue(0f), SerializeField]
		public float CanCancelAt;

		[DefaultValue(false), SerializeField]
		public bool SuppressPlayer;

		[DefaultValue(true), SerializeField]
		public bool AttackOnHitDown;

		[DefaultValue(false), SerializeField]
		public bool Association;

		[DefaultValue(false), SerializeField]
		public bool MoveType;

		[SerializeField]
		public string Association_Skill;

		[DefaultValue(0), SerializeField]
		public int PreservedStrength;

		[DefaultValue(0f), SerializeField]
		public float PreservedEndAt;

		[SerializeField]
		public string Exstring;

		[DefaultValue(0f), SerializeField]
		public float Exstring_At;

		[DefaultValue(0f), SerializeField]
		public float Not_Selected_At;

		[DefaultValue(0f), SerializeField]
		public float Not_Selected_End;

		public XLogicalData()
		{
			this.AttackOnHitDown = true;
		}
	}
}
