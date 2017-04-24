using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XCastChain
	{
		[DefaultValue(0f), SerializeField]
		public float At;

		[DefaultValue(0), SerializeField]
		public int TemplateID;

		[SerializeField]
		public string Name;
	}
}
