using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class TableMap
	{
		[SerializeField]
		public List<string> tableDir = new List<string>();

		[SerializeField]
		public List<TableScriptMap> tableScriptMap = new List<TableScriptMap>();
	}
}
