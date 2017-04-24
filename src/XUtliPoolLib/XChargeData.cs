using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XChargeData : XBaseData
	{
		[DefaultValue(0f), SerializeField]
		public float At;

		[DefaultValue(0f), SerializeField]
		public float End;

		[DefaultValue(0f), SerializeField]
		public float Offset;

		[DefaultValue(0f), SerializeField]
		public float Height;

		[DefaultValue(0f), SerializeField]
		public float Rotation_Speed;

		[DefaultValue(false), SerializeField]
		public bool Using_Curve;

		[SerializeField]
		public string Curve_Forward;

		[SerializeField]
		public string Curve_Side;

		[DefaultValue(false), SerializeField]
		public bool Using_Up;

		[SerializeField]
		public string Curve_Up;

		[DefaultValue(true), SerializeField]
		public bool StandOnAtEnd;

		[DefaultValue(false), SerializeField]
		public bool AimTarget;

		public XChargeData()
		{
			this.StandOnAtEnd = true;
		}
	}
}
