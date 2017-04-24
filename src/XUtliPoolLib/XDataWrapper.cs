using System;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XDataWrapper : ScriptableObject
	{
		public object Data
		{
			get;
			set;
		}
	}
}
