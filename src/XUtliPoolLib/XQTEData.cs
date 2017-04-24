using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XQTEData
	{
		[SerializeField]
		public int QTE;

		[DefaultValue(0f), SerializeField]
		public float At;

		[DefaultValue(0f), SerializeField]
		public float End;
	}
}
