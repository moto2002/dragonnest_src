using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.tencent.pandora
{
	public class Lua3rdMeta : ScriptableObject
	{
		public List<string> typesWithAttribtues = new List<string>();

		private static Lua3rdMeta _instance;

		public static Lua3rdMeta Instance
		{
			get
			{
				if (Lua3rdMeta._instance == null)
				{
					Lua3rdMeta._instance = Resources.Load<Lua3rdMeta>("lua3rdmeta");
				}
				return Lua3rdMeta._instance;
			}
		}

		private void OnEnable()
		{
			base.hideFlags = HideFlags.NotEditable;
		}
	}
}
