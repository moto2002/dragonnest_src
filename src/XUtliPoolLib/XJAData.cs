using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XJAData : XBaseData
	{
		[SerializeField]
		public string Next_Name;

		[SerializeField]
		public string Name;

		[DefaultValue(0f), SerializeField]
		public float At;

		[DefaultValue(0f), SerializeField]
		public float End;

		[DefaultValue(0f), SerializeField]
		public float Point;
	}
}
