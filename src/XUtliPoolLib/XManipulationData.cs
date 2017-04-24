using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XManipulationData : XBaseData
	{
		[DefaultValue(0f), SerializeField]
		public float At;

		[DefaultValue(0f), SerializeField]
		public float End;

		[DefaultValue(0f), SerializeField]
		public float OffsetX;

		[DefaultValue(0f), SerializeField]
		public float OffsetZ;

		[DefaultValue(0f), SerializeField]
		public float Degree;

		[DefaultValue(0f), SerializeField]
		public float Radius;

		[DefaultValue(0f), SerializeField]
		public float Force;
	}
}
