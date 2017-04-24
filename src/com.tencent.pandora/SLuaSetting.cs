using System;
using UnityEngine;

namespace com.tencent.pandora
{
	public class SLuaSetting : ScriptableObject
	{
		public EOL eol;

		public bool exportExtensionMethod = true;

		public string UnityEngineGeneratePath = "Assets/Pandora/Slua/LuaObject/";

		public int debugPort = 10240;

		public string debugIP = "0.0.0.0";

		private static SLuaSetting _instance;

		public static SLuaSetting Instance
		{
			get
			{
				if (SLuaSetting._instance == null)
				{
					SLuaSetting._instance = Resources.Load<SLuaSetting>("setting");
				}
				return SLuaSetting._instance;
			}
		}
	}
}
