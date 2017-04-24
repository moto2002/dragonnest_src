using System;
using System.Collections.Generic;
using System.Reflection;

namespace com.tencent.pandora
{
	public static class Lua3rdDLL
	{
		[AttributeUsage(AttributeTargets.Method)]
		public class LualibRegAttribute : Attribute
		{
			public string luaName;

			public LualibRegAttribute(string luaName)
			{
				this.luaName = luaName;
			}
		}

		private static Dictionary<string, LuaCSFunction> DLLRegFuncs;

		static Lua3rdDLL()
		{
			Lua3rdDLL.DLLRegFuncs = new Dictionary<string, LuaCSFunction>();
		}

		public static void open(IntPtr L)
		{
			List<string> typesWithAttribtues = Lua3rdMeta.Instance.typesWithAttribtues;
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			Assembly assembly = null;
			Assembly[] array = assemblies;
			for (int i = 0; i < array.Length; i++)
			{
				Assembly assembly2 = array[i];
				if (assembly2.GetName().Name == "Assembly-CSharp")
				{
					assembly = assembly2;
					break;
				}
			}
			if (assembly != null)
			{
				foreach (string current in typesWithAttribtues)
				{
					Type type = assembly.GetType(current);
					MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public);
					MethodInfo[] array2 = methods;
					for (int j = 0; j < array2.Length; j++)
					{
						MethodInfo methodInfo = array2[j];
						Lua3rdDLL.LualibRegAttribute lualibRegAttribute = Attribute.GetCustomAttribute(methodInfo, typeof(Lua3rdDLL.LualibRegAttribute)) as Lua3rdDLL.LualibRegAttribute;
						if (lualibRegAttribute != null)
						{
							LuaCSFunction value = Delegate.CreateDelegate(typeof(LuaCSFunction), methodInfo) as LuaCSFunction;
							Lua3rdDLL.DLLRegFuncs.Add(lualibRegAttribute.luaName, value);
						}
					}
				}
			}
			if (Lua3rdDLL.DLLRegFuncs.Count == 0)
			{
				return;
			}
			LuaDLL.pua_getglobal(L, "package");
			LuaDLL.pua_getfield(L, -1, "preload");
			foreach (KeyValuePair<string, LuaCSFunction> current2 in Lua3rdDLL.DLLRegFuncs)
			{
				LuaDLL.pua_pushcfunction(L, current2.Value);
				LuaDLL.pua_setfield(L, -2, current2.Key);
			}
			LuaDLL.pua_settop(L, 0);
		}
	}
}
