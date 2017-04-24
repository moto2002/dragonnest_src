using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XCombinedData : XBaseData
	{
		[SerializeField]
		public string Name;

		[DefaultValue(0f), SerializeField]
		public float At;

		[DefaultValue(0f), SerializeField]
		public float End;

		[DefaultValue(false), SerializeField]
		public bool Override_Presentation;
	}
}
