using System;
using System.Collections.Generic;

namespace com.tencent.pandora
{
	internal class LuaArray : LuaObject
	{
		private delegate int ArrayPropFunction(IntPtr l, Array a);

		private static Dictionary<string, LuaArray.ArrayPropFunction> propMethod = new Dictionary<string, LuaArray.ArrayPropFunction>();

		private static int toTable(IntPtr l, Array o)
		{
			if (o == null)
			{
				LuaDLL.pua_pushnil(l);
				return 1;
			}
			LuaDLL.pua_createtable(l, o.Length, 0);
			for (int i = 0; i < o.Length; i++)
			{
				LuaObject.pushVar(l, o.GetValue(i));
				LuaDLL.pua_rawseti(l, -2, i + 1);
			}
			return 1;
		}

		private static int length(IntPtr l, Array a)
		{
			LuaObject.pushValue(l, a.Length);
			return 1;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int len(IntPtr l)
		{
			Array array = (Array)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, array.Length);
			return 1;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int luaIndex(IntPtr l)
		{
			int result;
			try
			{
				Array array = (Array)LuaObject.checkSelf(l);
				if (LuaDLL.pua_type(l, 2) == LuaTypes.LUA_TSTRING)
				{
					string text;
					LuaObject.checkType(l, 2, out text);
					LuaArray.ArrayPropFunction arrayPropFunction;
					if (!LuaArray.propMethod.TryGetValue(text, out arrayPropFunction))
					{
						throw new Exception("Can't find property named " + text);
					}
					LuaObject.pushValue(l, true);
					result = arrayPropFunction(l, array) + 1;
				}
				else
				{
					int num;
					LuaObject.checkType(l, 2, out num);
					LuaObject.assert(num > 0, "index base 1");
					LuaObject.pushValue(l, true);
					LuaObject.pushVar(l, array.GetValue(num - 1));
					result = 2;
				}
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int luaNewIndex(IntPtr l)
		{
			int result;
			try
			{
				Array array = (Array)LuaObject.checkSelf(l);
				int num;
				LuaObject.checkType(l, 2, out num);
				LuaObject.assert(num > 0, "index base 1");
				object obj = LuaObject.checkVar(l, 3);
				Type elementType = array.GetType().GetElementType();
				array.SetValue(LuaObject.changeType(obj, elementType), num - 1);
				result = LuaObject.ok(l);
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int tostring(IntPtr l)
		{
			Array array = (Array)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, string.Format("Array<{0}>", array.GetType().GetElementType().Name));
			return 1;
		}

		public new static void init(IntPtr l)
		{
			LuaArray.propMethod["Table"] = new LuaArray.ArrayPropFunction(LuaArray.toTable);
			LuaArray.propMethod["Length"] = new LuaArray.ArrayPropFunction(LuaArray.length);
			LuaDLL.pua_createtable(l, 0, 5);
			LuaObject.pushValue(l, new LuaCSFunction(LuaArray.luaIndex));
			LuaDLL.pua_setfield(l, -2, "__index");
			LuaObject.pushValue(l, new LuaCSFunction(LuaArray.luaNewIndex));
			LuaDLL.pua_setfield(l, -2, "__newindex");
			LuaDLL.pua_pushcfunction(l, LuaObject.lua_gc);
			LuaDLL.pua_setfield(l, -2, "__gc");
			LuaDLL.pua_pushcfunction(l, new LuaCSFunction(LuaArray.tostring));
			LuaDLL.pua_setfield(l, -2, "__tostring");
			LuaDLL.pua_pushcfunction(l, new LuaCSFunction(LuaArray.len));
			LuaDLL.pua_setfield(l, -2, "__len");
			LuaDLL.pua_setfield(l, LuaIndexes.LUA_REGISTRYINDEX, "LuaArray");
		}
	}
}
