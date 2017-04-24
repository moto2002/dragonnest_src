using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XBaseData
	{
		[DefaultValue(0), SerializeField]
		public int Index;
	}
}
