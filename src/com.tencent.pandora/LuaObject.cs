using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace com.tencent.pandora
{
	public class LuaObject
	{
		private delegate void PushVarDelegate(IntPtr l, object o);

		private const string DelgateTable = "__LuaDelegate";

		internal const int VersionNumber = 4113;

		protected static LuaCSFunction lua_gc = new LuaCSFunction(LuaObject.luaGC);

		protected static LuaCSFunction lua_add = new LuaCSFunction(LuaObject.luaAdd);

		protected static LuaCSFunction lua_sub = new LuaCSFunction(LuaObject.luaSub);

		protected static LuaCSFunction lua_mul = new LuaCSFunction(LuaObject.luaMul);

		protected static LuaCSFunction lua_div = new LuaCSFunction(LuaObject.luaDiv);

		protected static LuaCSFunction lua_unm = new LuaCSFunction(LuaObject.luaUnm);

		protected static LuaCSFunction lua_eq = new LuaCSFunction(LuaObject.luaEq);

		protected static LuaCSFunction lua_lt = new LuaCSFunction(LuaObject.luaLt);

		protected static LuaCSFunction lua_le = new LuaCSFunction(LuaObject.luaLe);

		protected static LuaCSFunction lua_tostring = new LuaCSFunction(LuaObject.ToString);

		protected static LuaFunction newindex_func;

		protected static LuaFunction index_func;

		private static Dictionary<Type, LuaObject.PushVarDelegate> typePushMap = new Dictionary<Type, LuaObject.PushVarDelegate>();

		private static Type MonoType = typeof(Type).GetType();

		public static void init(IntPtr l)
		{
			string str = "\r\n\r\nlocal getmetatable=getmetatable\r\nlocal rawget=rawget\r\nlocal error=error\r\nlocal type=type\r\nlocal function newindex(ud,k,v)\r\n    local t=getmetatable(ud)\r\n    repeat\r\n        local h=rawget(t,k)\r\n        if h then\r\n\t\t\tif h[2] then\r\n\t\t\t\th[2](ud,v)\r\n\t            return\r\n\t\t\telse\r\n\t\t\t\terror('property '..k..' is read only')\r\n\t\t\tend\r\n        end\r\n        t=rawget(t,'__parent')\r\n    until t==nil\r\n    error('can not find '..k)\r\nend\r\n\r\nreturn newindex\r\n";
			string str2 = "\r\nlocal type=type\r\nlocal error=error\r\nlocal rawget=rawget\r\nlocal getmetatable=getmetatable\r\nlocal function index(ud,k)\r\n    local t=getmetatable(ud)\r\n    repeat\r\n        local fun=rawget(t,k)\r\n        local tp=type(fun)\t\r\n        if tp=='function' then \r\n            return fun \r\n        elseif tp=='table' then\r\n\t\t\tlocal f=fun[1]\r\n\t\t\tif f then\r\n\t\t\t\treturn f(ud)\r\n\t\t\telse\r\n\t\t\t\terror('property '..k..' is write only')\r\n\t\t\tend\r\n        end\r\n        t = rawget(t,'__parent')\r\n    until t==nil\r\n    error('Can not find '..k)\r\nend\r\n\r\nreturn index\r\n";
			LuaState luaState = LuaState.get(l);
			LuaObject.newindex_func = (LuaFunction)luaState.doString(str);
			LuaObject.index_func = (LuaFunction)luaState.doString(str2);
			LuaDLL.pua_createtable(l, 0, 4);
			LuaObject.addMember(l, new LuaCSFunction(LuaObject.ToString));
			LuaObject.addMember(l, new LuaCSFunction(LuaObject.GetHashCode));
			LuaObject.addMember(l, new LuaCSFunction(LuaObject.Equals));
			LuaObject.addMember(l, new LuaCSFunction(LuaObject.GetType));
			LuaDLL.pua_setfield(l, LuaIndexes.LUA_REGISTRYINDEX, "__luabaseobject");
			LuaArray.init(l);
			LuaVarObject.init(l);
			LuaDLL.pua_newtable(l);
			LuaDLL.pua_setglobal(l, "__LuaDelegate");
			LuaObject.setupPushVar();
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int ToString(IntPtr l)
		{
			int result;
			try
			{
				object obj = LuaObject.checkVar(l, 1);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, obj.ToString());
				result = 2;
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int GetHashCode(IntPtr l)
		{
			int result;
			try
			{
				object obj = LuaObject.checkVar(l, 1);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, obj.GetHashCode());
				result = 2;
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int Equals(IntPtr l)
		{
			int result;
			try
			{
				object obj = LuaObject.checkVar(l, 1);
				object obj2 = LuaObject.checkVar(l, 2);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, obj.Equals(obj2));
				result = 2;
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int GetType(IntPtr l)
		{
			int result;
			try
			{
				object obj = LuaObject.checkVar(l, 1);
				LuaObject.pushValue(l, true);
				LuaObject.pushObject(l, obj.GetType());
				result = 2;
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		private static void setupPushVar()
		{
			LuaObject.typePushMap[typeof(float)] = delegate(IntPtr L, object o)
			{
				LuaDLL.pua_pushnumber(L, (double)((float)o));
			};
			LuaObject.typePushMap[typeof(double)] = delegate(IntPtr L, object o)
			{
				LuaDLL.pua_pushnumber(L, (double)o);
			};
			LuaObject.typePushMap[typeof(int)] = delegate(IntPtr L, object o)
			{
				LuaDLL.pua_pushinteger(L, (int)o);
			};
			LuaObject.typePushMap[typeof(uint)] = delegate(IntPtr L, object o)
			{
				LuaDLL.pua_pushnumber(L, Convert.ToUInt32(o));
			};
			LuaObject.typePushMap[typeof(short)] = delegate(IntPtr L, object o)
			{
				LuaDLL.pua_pushinteger(L, (int)((short)o));
			};
			LuaObject.typePushMap[typeof(ushort)] = delegate(IntPtr L, object o)
			{
				LuaDLL.pua_pushinteger(L, (int)((ushort)o));
			};
			LuaObject.typePushMap[typeof(sbyte)] = delegate(IntPtr L, object o)
			{
				LuaDLL.pua_pushinteger(L, (int)((sbyte)o));
			};
			LuaObject.typePushMap[typeof(byte)] = delegate(IntPtr L, object o)
			{
				LuaDLL.pua_pushinteger(L, (int)((byte)o));
			};
			Dictionary<Type, LuaObject.PushVarDelegate> arg_1CB_0 = LuaObject.typePushMap;
			Type arg_1CB_1 = typeof(long);
			LuaObject.PushVarDelegate pushVarDelegate = delegate(IntPtr L, object o)
			{
				LuaDLL.pua_pushnumber(L, Convert.ToDouble(o));
			};
			LuaObject.typePushMap[typeof(ulong)] = pushVarDelegate;
			arg_1CB_0[arg_1CB_1] = pushVarDelegate;
			LuaObject.typePushMap[typeof(string)] = delegate(IntPtr L, object o)
			{
				LuaDLL.pua_pushstring(L, (string)o);
			};
			LuaObject.typePushMap[typeof(bool)] = delegate(IntPtr L, object o)
			{
				LuaDLL.pua_pushboolean(L, (bool)o);
			};
			Dictionary<Type, LuaObject.PushVarDelegate> arg_28C_0 = LuaObject.typePushMap;
			Type arg_28C_1 = typeof(LuaTable);
			pushVarDelegate = delegate(IntPtr L, object o)
			{
				((LuaVar)o).push(L);
			};
			LuaObject.typePushMap[typeof(LuaThread)] = pushVarDelegate;
			pushVarDelegate = pushVarDelegate;
			LuaObject.typePushMap[typeof(LuaFunction)] = pushVarDelegate;
			arg_28C_0[arg_28C_1] = pushVarDelegate;
			LuaObject.typePushMap[typeof(Vector3)] = delegate(IntPtr L, object o)
			{
				LuaObject.pushValue(L, (Vector3)o);
			};
			LuaObject.typePushMap[typeof(Vector2)] = delegate(IntPtr L, object o)
			{
				LuaObject.pushValue(L, (Vector2)o);
			};
			LuaObject.typePushMap[typeof(Vector4)] = delegate(IntPtr L, object o)
			{
				LuaObject.pushValue(L, (Vector4)o);
			};
			LuaObject.typePushMap[typeof(Quaternion)] = delegate(IntPtr L, object o)
			{
				LuaObject.pushValue(L, (Quaternion)o);
			};
			LuaObject.typePushMap[typeof(Color)] = delegate(IntPtr L, object o)
			{
				LuaObject.pushValue(L, (Color)o);
			};
			LuaObject.typePushMap[typeof(LuaCSFunction)] = delegate(IntPtr L, object o)
			{
				LuaObject.pushValue(L, (LuaCSFunction)o);
			};
		}

		private static int getOpFunction(IntPtr l, string f, string tip)
		{
			int result = LuaObject.pushTry(l);
			LuaObject.checkLuaObject(l, 1);
			while (!LuaDLL.pua_isnil(l, -1))
			{
				LuaDLL.pua_getfield(l, -1, f);
				if (!LuaDLL.pua_isnil(l, -1))
				{
					LuaDLL.pua_remove(l, -2);
					break;
				}
				LuaDLL.pua_pop(l, 1);
				LuaDLL.pua_getfield(l, -1, "__parent");
				LuaDLL.pua_remove(l, -2);
			}
			if (LuaDLL.pua_isnil(l, -1))
			{
				LuaDLL.pua_pop(l, 1);
				throw new Exception(string.Format("No {0} operator", tip));
			}
			return result;
		}

		private static int luaOp(IntPtr l, string f, string tip)
		{
			int opFunction = LuaObject.getOpFunction(l, f, tip);
			LuaDLL.pua_pushvalue(l, 1);
			LuaDLL.pua_pushvalue(l, 2);
			if (LuaDLL.pua_pcall(l, 2, 1, opFunction) != 0)
			{
				LuaDLL.pua_pop(l, 1);
			}
			LuaDLL.pua_remove(l, opFunction);
			LuaObject.pushValue(l, true);
			LuaDLL.pua_insert(l, -2);
			return 2;
		}

		private static int luaUnaryOp(IntPtr l, string f, string tip)
		{
			int opFunction = LuaObject.getOpFunction(l, f, tip);
			LuaDLL.pua_pushvalue(l, 1);
			if (LuaDLL.pua_pcall(l, 1, 1, opFunction) != 0)
			{
				LuaDLL.pua_pop(l, 1);
			}
			LuaDLL.pua_remove(l, opFunction);
			LuaObject.pushValue(l, true);
			LuaDLL.pua_insert(l, -2);
			return 2;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int luaAdd(IntPtr l)
		{
			int result;
			try
			{
				result = LuaObject.luaOp(l, "op_Addition", "add");
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int luaSub(IntPtr l)
		{
			int result;
			try
			{
				result = LuaObject.luaOp(l, "op_Subtraction", "sub");
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int luaMul(IntPtr l)
		{
			int result;
			try
			{
				result = LuaObject.luaOp(l, "op_Multiply", "mul");
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int luaDiv(IntPtr l)
		{
			int result;
			try
			{
				result = LuaObject.luaOp(l, "op_Division", "div");
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int luaUnm(IntPtr l)
		{
			int result;
			try
			{
				result = LuaObject.luaUnaryOp(l, "op_UnaryNegation", "unm");
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int luaEq(IntPtr l)
		{
			int result;
			try
			{
				result = LuaObject.luaOp(l, "op_Equality", "eq");
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int luaLt(IntPtr l)
		{
			int result;
			try
			{
				result = LuaObject.luaOp(l, "op_LessThan", "lt");
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int luaLe(IntPtr l)
		{
			int result;
			try
			{
				result = LuaObject.luaOp(l, "op_LessThanOrEqual", "le");
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		public static void getEnumTable(IntPtr l, string t)
		{
			LuaObject.newTypeTable(l, t);
		}

		public static void getTypeTable(IntPtr l, string t)
		{
			LuaObject.newTypeTable(l, t);
			LuaDLL.pua_newtable(l);
			LuaDLL.pua_newtable(l);
		}

		public static void newTypeTable(IntPtr l, string name)
		{
			string[] array = name.Split(new char[]
			{
				'.'
			});
			LuaDLL.pua_pushglobaltable(l);
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string str = array2[i];
				LuaDLL.pua_pushstring(l, str);
				LuaDLL.pua_rawget(l, -2);
				if (LuaDLL.pua_isnil(l, -1))
				{
					LuaDLL.pua_pop(l, 1);
					LuaDLL.pua_createtable(l, 0, 0);
					LuaDLL.pua_pushstring(l, str);
					LuaDLL.pua_pushvalue(l, -2);
					LuaDLL.pua_rawset(l, -4);
				}
				LuaDLL.pua_remove(l, -2);
			}
		}

		public static void createTypeMetatable(IntPtr l, Type self)
		{
			LuaObject.createTypeMetatable(l, null, self, null);
		}

		public static void createTypeMetatable(IntPtr l, LuaCSFunction con, Type self)
		{
			LuaObject.createTypeMetatable(l, con, self, null);
		}

		private static void checkMethodValid(LuaCSFunction f)
		{
		}

		public static void createTypeMetatable(IntPtr l, LuaCSFunction con, Type self, Type parent)
		{
			LuaObject.checkMethodValid(con);
			if (parent != null && parent != typeof(object) && parent != typeof(ValueType))
			{
				LuaDLL.pua_pushstring(l, "__parent");
				LuaDLL.puaL_getmetatable(l, ObjectCache.getAQName(parent));
				LuaDLL.pua_rawset(l, -3);
				LuaDLL.pua_pushstring(l, "__parent");
				LuaDLL.puaL_getmetatable(l, parent.FullName);
				LuaDLL.pua_rawset(l, -4);
			}
			else
			{
				LuaDLL.pua_pushstring(l, "__parent");
				LuaDLL.puaL_getmetatable(l, "__luabaseobject");
				LuaDLL.pua_rawset(l, -3);
			}
			LuaObject.completeInstanceMeta(l, self);
			LuaObject.completeTypeMeta(l, con, self);
			LuaDLL.pua_pop(l, 1);
		}

		private static void completeTypeMeta(IntPtr l, LuaCSFunction con, Type self)
		{
			LuaDLL.pua_pushstring(l, ObjectCache.getAQName(self));
			LuaDLL.pua_setfield(l, -3, "__fullname");
			LuaObject.index_func.push(l);
			LuaDLL.pua_setfield(l, -2, "__index");
			LuaObject.newindex_func.push(l);
			LuaDLL.pua_setfield(l, -2, "__newindex");
			if (con == null)
			{
				con = new LuaCSFunction(LuaObject.noConstructor);
			}
			LuaObject.pushValue(l, con);
			LuaDLL.pua_setfield(l, -2, "__call");
			LuaDLL.pua_pushcfunction(l, new LuaCSFunction(LuaObject.typeToString));
			LuaDLL.pua_setfield(l, -2, "__tostring");
			LuaDLL.pua_pushvalue(l, -1);
			LuaDLL.pua_setmetatable(l, -3);
			LuaDLL.pua_setfield(l, LuaIndexes.LUA_REGISTRYINDEX, self.FullName);
		}

		private static void completeInstanceMeta(IntPtr l, Type self)
		{
			LuaDLL.pua_pushstring(l, "__typename");
			LuaDLL.pua_pushstring(l, self.Name);
			LuaDLL.pua_rawset(l, -3);
			LuaObject.index_func.push(l);
			LuaDLL.pua_setfield(l, -2, "__index");
			LuaObject.newindex_func.push(l);
			LuaDLL.pua_setfield(l, -2, "__newindex");
			LuaObject.pushValue(l, LuaObject.lua_add);
			LuaDLL.pua_setfield(l, -2, "__add");
			LuaObject.pushValue(l, LuaObject.lua_sub);
			LuaDLL.pua_setfield(l, -2, "__sub");
			LuaObject.pushValue(l, LuaObject.lua_mul);
			LuaDLL.pua_setfield(l, -2, "__mul");
			LuaObject.pushValue(l, LuaObject.lua_div);
			LuaDLL.pua_setfield(l, -2, "__div");
			LuaObject.pushValue(l, LuaObject.lua_unm);
			LuaDLL.pua_setfield(l, -2, "__unm");
			LuaObject.pushValue(l, LuaObject.lua_eq);
			LuaDLL.pua_setfield(l, -2, "__eq");
			LuaObject.pushValue(l, LuaObject.lua_le);
			LuaDLL.pua_setfield(l, -2, "__le");
			LuaObject.pushValue(l, LuaObject.lua_lt);
			LuaDLL.pua_setfield(l, -2, "__lt");
			LuaObject.pushValue(l, LuaObject.lua_tostring);
			LuaDLL.pua_setfield(l, -2, "__tostring");
			LuaDLL.pua_pushcfunction(l, LuaObject.lua_gc);
			LuaDLL.pua_setfield(l, -2, "__gc");
			if (self.IsValueType && LuaObject.isImplByLua(self))
			{
				LuaDLL.pua_pushvalue(l, -1);
				LuaDLL.pua_setglobal(l, self.FullName + ".Instance");
			}
			LuaDLL.pua_setfield(l, LuaIndexes.LUA_REGISTRYINDEX, ObjectCache.getAQName(self));
		}

		public static bool isImplByLua(Type t)
		{
			return t == typeof(Color) || t == typeof(Vector2) || t == typeof(Vector3) || t == typeof(Vector4) || t == typeof(Quaternion);
		}

		public static void reg(IntPtr l, LuaCSFunction func, string ns)
		{
			LuaObject.checkMethodValid(func);
			LuaObject.newTypeTable(l, ns);
			LuaObject.pushValue(l, func);
			LuaDLL.pua_setfield(l, -2, func.Method.Name);
			LuaDLL.pua_pop(l, 1);
		}

		protected static void addMember(IntPtr l, LuaCSFunction func)
		{
			LuaObject.checkMethodValid(func);
			LuaObject.pushValue(l, func);
			string text = func.Method.Name;
			if (text.EndsWith("_s"))
			{
				text = text.Substring(0, text.Length - 2);
				LuaDLL.pua_setfield(l, -3, text);
			}
			else
			{
				LuaDLL.pua_setfield(l, -2, text);
			}
		}

		protected static void addMember(IntPtr l, LuaCSFunction func, bool instance)
		{
			LuaObject.checkMethodValid(func);
			LuaObject.pushValue(l, func);
			string name = func.Method.Name;
			LuaDLL.pua_setfield(l, (!instance) ? -3 : -2, name);
		}

		protected static void addMember(IntPtr l, string name, LuaCSFunction get, LuaCSFunction set, bool instance)
		{
			LuaObject.checkMethodValid(get);
			LuaObject.checkMethodValid(set);
			int stackPos = (!instance) ? -3 : -2;
			LuaDLL.pua_createtable(l, 2, 0);
			if (get == null)
			{
				LuaDLL.pua_pushnil(l);
			}
			else
			{
				LuaObject.pushValue(l, get);
			}
			LuaDLL.pua_rawseti(l, -2, 1);
			if (set == null)
			{
				LuaDLL.pua_pushnil(l);
			}
			else
			{
				LuaObject.pushValue(l, set);
			}
			LuaDLL.pua_rawseti(l, -2, 2);
			LuaDLL.pua_setfield(l, stackPos, name);
		}

		protected static void addMember(IntPtr l, int v, string name)
		{
			LuaDLL.pua_pushinteger(l, v);
			LuaDLL.pua_setfield(l, -2, name);
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int luaGC(IntPtr l)
		{
			int num = LuaDLL.luaS_rawnetobj(l, 1);
			if (num > 0)
			{
				ObjectCache objectCache = ObjectCache.get(l);
				objectCache.gc(num);
			}
			return 0;
		}

		internal static void gc(IntPtr l, int p, UnityEngine.Object o)
		{
			LuaDLL.pua_pushnil(l);
			LuaDLL.pua_setmetatable(l, p);
			ObjectCache objectCache = ObjectCache.get(l);
			objectCache.gc(o);
		}

		public static void checkLuaObject(IntPtr l, int p)
		{
			LuaDLL.pua_getmetatable(l, p);
			if (LuaDLL.pua_isnil(l, -1))
			{
				LuaDLL.pua_pop(l, 1);
				throw new Exception("expect luaobject as first argument");
			}
		}

		public static void pushObject(IntPtr l, object o)
		{
			ObjectCache objectCache = ObjectCache.get(l);
			objectCache.push(l, o);
		}

		public static void pushObject(IntPtr l, Array o)
		{
			ObjectCache objectCache = ObjectCache.get(l);
			objectCache.push(l, o);
		}

		public static void pushLightObject(IntPtr l, object t)
		{
			ObjectCache objectCache = ObjectCache.get(l);
			objectCache.push(l, t, false, false);
		}

		public static int pushTry(IntPtr l)
		{
			if (!LuaState.get(l).isMainThread())
			{
				SLogger.LogError("Can't call lua function in bg thread");
				return 0;
			}
			LuaDLL.pua_pushcfunction(l, LuaState.errorFunc);
			return LuaDLL.pua_gettop(l);
		}

		public static bool matchType(IntPtr l, int p, LuaTypes lt, Type t)
		{
			if (t == typeof(object))
			{
				return true;
			}
			if (t == typeof(Type) && LuaObject.isTypeTable(l, p))
			{
				return true;
			}
			if (t == typeof(char[]) || t == typeof(byte[]))
			{
				return lt == LuaTypes.LUA_TSTRING;
			}
			switch (lt)
			{
			case LuaTypes.LUA_TNIL:
				return !t.IsValueType && !t.IsPrimitive;
			case LuaTypes.LUA_TBOOLEAN:
				return t == typeof(bool);
			case LuaTypes.LUA_TNUMBER:
				return t.IsPrimitive || t.IsEnum;
			case LuaTypes.LUA_TSTRING:
				return t == typeof(string);
			case LuaTypes.LUA_TTABLE:
				return t == typeof(LuaTable) || t.IsArray || t.IsValueType || LuaDLL.luaS_subclassof(l, p, t.Name) == 1;
			case LuaTypes.LUA_TFUNCTION:
				return t == typeof(LuaFunction) || t.BaseType == typeof(MulticastDelegate);
			case LuaTypes.LUA_TUSERDATA:
			{
				object obj = LuaObject.checkObj(l, p);
				Type type = obj.GetType();
				return type == t || type.IsSubclassOf(t);
			}
			case LuaTypes.LUA_TTHREAD:
				return t == typeof(LuaThread);
			}
			return false;
		}

		public static bool isTypeTable(IntPtr l, int p)
		{
			if (LuaDLL.pua_type(l, p) != LuaTypes.LUA_TTABLE)
			{
				return false;
			}
			LuaDLL.pua_pushstring(l, "__fullname");
			LuaDLL.pua_rawget(l, p);
			if (LuaDLL.pua_isnil(l, -1))
			{
				LuaDLL.pua_pop(l, 1);
				return false;
			}
			return true;
		}

		public static bool isLuaClass(IntPtr l, int p)
		{
			return LuaDLL.luaS_subclassof(l, p, null) == 1;
		}

		private static bool isLuaValueType(IntPtr l, int p)
		{
			return LuaDLL.luaS_checkluatype(l, p, null) == 1;
		}

		public static bool matchType(IntPtr l, int p, Type t1)
		{
			LuaTypes lt = LuaDLL.pua_type(l, p);
			return LuaObject.matchType(l, p, lt, t1);
		}

		public static bool matchType(IntPtr l, int total, int from, Type t1)
		{
			return total - from + 1 == 1 && LuaObject.matchType(l, from, t1);
		}

		public static bool matchType(IntPtr l, int total, int from, Type t1, Type t2)
		{
			return total - from + 1 == 2 && LuaObject.matchType(l, from, t1) && LuaObject.matchType(l, from + 1, t2);
		}

		public static bool matchType(IntPtr l, int total, int from, Type t1, Type t2, Type t3)
		{
			return total - from + 1 == 3 && (LuaObject.matchType(l, from, t1) && LuaObject.matchType(l, from + 1, t2)) && LuaObject.matchType(l, from + 2, t3);
		}

		public static bool matchType(IntPtr l, int total, int from, Type t1, Type t2, Type t3, Type t4)
		{
			return total - from + 1 == 4 && (LuaObject.matchType(l, from, t1) && LuaObject.matchType(l, from + 1, t2) && LuaObject.matchType(l, from + 2, t3)) && LuaObject.matchType(l, from + 3, t4);
		}

		public static bool matchType(IntPtr l, int total, int from, Type t1, Type t2, Type t3, Type t4, Type t5)
		{
			return total - from + 1 == 5 && (LuaObject.matchType(l, from, t1) && LuaObject.matchType(l, from + 1, t2) && LuaObject.matchType(l, from + 2, t3) && LuaObject.matchType(l, from + 3, t4)) && LuaObject.matchType(l, from + 4, t5);
		}

		public static bool matchType(IntPtr l, int total, int from, Type t1, Type t2, Type t3, Type t4, Type t5, Type t6)
		{
			return total - from + 1 == 6 && (LuaObject.matchType(l, from, t1) && LuaObject.matchType(l, from + 1, t2) && LuaObject.matchType(l, from + 2, t3) && LuaObject.matchType(l, from + 3, t4) && LuaObject.matchType(l, from + 4, t5)) && LuaObject.matchType(l, from + 5, t6);
		}

		public static bool matchType(IntPtr l, int total, int from, Type t1, Type t2, Type t3, Type t4, Type t5, Type t6, Type t7)
		{
			return total - from + 1 == 7 && (LuaObject.matchType(l, from, t1) && LuaObject.matchType(l, from + 1, t2) && LuaObject.matchType(l, from + 2, t3) && LuaObject.matchType(l, from + 3, t4) && LuaObject.matchType(l, from + 4, t5) && LuaObject.matchType(l, from + 5, t6)) && LuaObject.matchType(l, from + 6, t7);
		}

		public static bool matchType(IntPtr l, int total, int from, Type t1, Type t2, Type t3, Type t4, Type t5, Type t6, Type t7, Type t8)
		{
			return total - from + 1 == 8 && (LuaObject.matchType(l, from, t1) && LuaObject.matchType(l, from + 1, t2) && LuaObject.matchType(l, from + 2, t3) && LuaObject.matchType(l, from + 3, t4) && LuaObject.matchType(l, from + 4, t5) && LuaObject.matchType(l, from + 5, t6) && LuaObject.matchType(l, from + 6, t7)) && LuaObject.matchType(l, from + 7, t8);
		}

		public static bool matchType(IntPtr l, int total, int from, Type t1, Type t2, Type t3, Type t4, Type t5, Type t6, Type t7, Type t8, Type t9)
		{
			return total - from + 1 == 9 && (LuaObject.matchType(l, from, t1) && LuaObject.matchType(l, from + 1, t2) && LuaObject.matchType(l, from + 2, t3) && LuaObject.matchType(l, from + 3, t4) && LuaObject.matchType(l, from + 4, t5) && LuaObject.matchType(l, from + 5, t6) && LuaObject.matchType(l, from + 6, t7) && LuaObject.matchType(l, from + 7, t8)) && LuaObject.matchType(l, from + 8, t9);
		}

		public static bool matchType(IntPtr l, int total, int from, Type t1, Type t2, Type t3, Type t4, Type t5, Type t6, Type t7, Type t8, Type t9, Type t10)
		{
			return total - from + 1 == 10 && (LuaObject.matchType(l, from, t1) && LuaObject.matchType(l, from + 1, t2) && LuaObject.matchType(l, from + 2, t3) && LuaObject.matchType(l, from + 3, t4) && LuaObject.matchType(l, from + 4, t5) && LuaObject.matchType(l, from + 5, t6) && LuaObject.matchType(l, from + 6, t7) && LuaObject.matchType(l, from + 7, t8) && LuaObject.matchType(l, from + 8, t9)) && LuaObject.matchType(l, from + 9, t10);
		}

		public static bool matchType(IntPtr l, int total, int from, params Type[] t)
		{
			if (total - from + 1 != t.Length)
			{
				return false;
			}
			for (int i = 0; i < t.Length; i++)
			{
				if (!LuaObject.matchType(l, from + i, t[i]))
				{
					return false;
				}
			}
			return true;
		}

		public static bool matchType(IntPtr l, int total, int from, ParameterInfo[] pars)
		{
			if (total - from + 1 != pars.Length)
			{
				return false;
			}
			for (int i = 0; i < pars.Length; i++)
			{
				int num = i + from;
				LuaTypes lt = LuaDLL.pua_type(l, num);
				if (!LuaObject.matchType(l, num, lt, pars[i].ParameterType))
				{
					return false;
				}
			}
			return true;
		}

		public static bool luaTypeCheck(IntPtr l, int p, string t)
		{
			return LuaDLL.luaS_checkluatype(l, p, t) != 0;
		}

		private static LuaDelegate newDelegate(IntPtr l, int p)
		{
			LuaState luaState = LuaState.get(l);
			LuaDLL.pua_pushvalue(l, p);
			int num = LuaDLL.puaL_ref(l, LuaIndexes.LUA_REGISTRYINDEX);
			LuaDelegate luaDelegate = new LuaDelegate(l, num);
			LuaDLL.pua_pushvalue(l, p);
			LuaDLL.pua_pushinteger(l, num);
			LuaDLL.pua_settable(l, -3);
			luaState.delgateMap[num] = luaDelegate;
			return luaDelegate;
		}

		public static void removeDelgate(IntPtr l, int r)
		{
			LuaDLL.pua_getglobal(l, "__LuaDelegate");
			LuaDLL.pua_getref(l, r);
			LuaDLL.pua_pushnil(l);
			LuaDLL.pua_settable(l, -3);
			LuaDLL.pua_pop(l, 1);
		}

		public static object checkObj(IntPtr l, int p)
		{
			ObjectCache objectCache = ObjectCache.get(l);
			return objectCache.get(l, p);
		}

		public static bool checkArray<T>(IntPtr l, int p, out T[] ta)
		{
			if (LuaDLL.pua_type(l, p) == LuaTypes.LUA_TTABLE)
			{
				int num = LuaDLL.pua_rawlen(l, p);
				ta = new T[num];
				for (int i = 0; i < num; i++)
				{
					LuaDLL.pua_rawgeti(l, p, i + 1);
					ta[i] = (T)((object)Convert.ChangeType(LuaObject.checkVar(l, -1), typeof(T)));
					LuaDLL.pua_pop(l, 1);
				}
				return true;
			}
			Array array = LuaObject.checkObj(l, p) as Array;
			ta = (array as T[]);
			return ta != null;
		}

		public static bool checkParams<T>(IntPtr l, int p, out T[] pars) where T : class
		{
			int num = LuaDLL.pua_gettop(l);
			if (num - p >= 0)
			{
				pars = new T[num - p + 1];
				int i = p;
				int num2 = 0;
				while (i <= num)
				{
					LuaObject.checkType<T>(l, i, out pars[num2]);
					i++;
					num2++;
				}
				return true;
			}
			pars = new T[0];
			return true;
		}

		public static bool checkValueParams<T>(IntPtr l, int p, out T[] pars) where T : struct
		{
			int num = LuaDLL.pua_gettop(l);
			if (num - p >= 0)
			{
				pars = new T[num - p + 1];
				int i = p;
				int num2 = 0;
				while (i <= num)
				{
					LuaObject.checkValueType<T>(l, i, out pars[num2]);
					i++;
					num2++;
				}
				return true;
			}
			pars = new T[0];
			return true;
		}

		public static bool checkParams(IntPtr l, int p, out float[] pars)
		{
			int num = LuaDLL.pua_gettop(l);
			if (num - p >= 0)
			{
				pars = new float[num - p + 1];
				int i = p;
				int num2 = 0;
				while (i <= num)
				{
					LuaObject.checkType(l, i, out pars[num2]);
					i++;
					num2++;
				}
				return true;
			}
			pars = new float[0];
			return true;
		}

		public static bool checkParams(IntPtr l, int p, out int[] pars)
		{
			int num = LuaDLL.pua_gettop(l);
			if (num - p >= 0)
			{
				pars = new int[num - p + 1];
				int i = p;
				int num2 = 0;
				while (i <= num)
				{
					LuaObject.checkType(l, i, out pars[num2]);
					i++;
					num2++;
				}
				return true;
			}
			pars = new int[0];
			return true;
		}

		public static bool checkParams(IntPtr l, int p, out string[] pars)
		{
			int num = LuaDLL.pua_gettop(l);
			if (num - p >= 0)
			{
				pars = new string[num - p + 1];
				int i = p;
				int num2 = 0;
				while (i <= num)
				{
					LuaObject.checkType(l, i, out pars[num2]);
					i++;
					num2++;
				}
				return true;
			}
			pars = new string[0];
			return true;
		}

		public static bool checkParams(IntPtr l, int p, out char[] pars)
		{
			LuaDLL.puaL_checktype(l, p, LuaTypes.LUA_TSTRING);
			string text;
			LuaObject.checkType(l, p, out text);
			pars = text.ToCharArray();
			return true;
		}

		public static object checkVar(IntPtr l, int p, Type t)
		{
			object obj = LuaObject.checkVar(l, p);
			object result;
			try
			{
				if (t.IsEnum)
				{
					object value = Convert.ChangeType(obj, typeof(int));
					result = Enum.ToObject(t, value);
				}
				else
				{
					result = ((obj != null) ? Convert.ChangeType(obj, t) : null);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(string.Format("parameter {0} expected {1}, got {2}, exception: {3}", new object[]
				{
					p,
					t.Name,
					(obj != null) ? obj.GetType().Name : "null",
					ex.Message
				}));
			}
			return result;
		}

		public static object checkVar(IntPtr l, int p)
		{
			switch (LuaDLL.pua_type(l, p))
			{
			case LuaTypes.LUA_TBOOLEAN:
				return LuaDLL.pua_toboolean(l, p);
			case LuaTypes.LUA_TNUMBER:
				return LuaDLL.pua_tonumber(l, p);
			case LuaTypes.LUA_TSTRING:
				return LuaDLL.pua_tostring(l, p);
			case LuaTypes.LUA_TTABLE:
				if (LuaObject.isLuaValueType(l, p))
				{
					if (LuaObject.luaTypeCheck(l, p, "Vector2"))
					{
						Vector2 vector;
						LuaObject.checkType(l, p, out vector);
						return vector;
					}
					if (LuaObject.luaTypeCheck(l, p, "Vector3"))
					{
						Vector3 vector2;
						LuaObject.checkType(l, p, out vector2);
						return vector2;
					}
					if (LuaObject.luaTypeCheck(l, p, "Vector4"))
					{
						Vector4 vector3;
						LuaObject.checkType(l, p, out vector3);
						return vector3;
					}
					if (LuaObject.luaTypeCheck(l, p, "Quaternion"))
					{
						Quaternion quaternion;
						LuaObject.checkType(l, p, out quaternion);
						return quaternion;
					}
					if (LuaObject.luaTypeCheck(l, p, "Color"))
					{
						Color color;
						LuaObject.checkType(l, p, out color);
						return color;
					}
					SLogger.LogError("unknown lua value type");
					return null;
				}
				else
				{
					if (LuaObject.isLuaClass(l, p))
					{
						return LuaObject.checkObj(l, p);
					}
					LuaTable result;
					LuaObject.checkType(l, p, out result);
					return result;
				}
				break;
			case LuaTypes.LUA_TFUNCTION:
			{
				LuaFunction result2;
				LuaObject.checkType(l, p, out result2);
				return result2;
			}
			case LuaTypes.LUA_TUSERDATA:
				return LuaObject.checkObj(l, p);
			case LuaTypes.LUA_TTHREAD:
			{
				LuaThread result3;
				LuaObject.checkType(l, p, out result3);
				return result3;
			}
			}
			return null;
		}

		public static void pushValue(IntPtr l, object o)
		{
			LuaObject.pushVar(l, o);
		}

		public static void pushValue(IntPtr l, Array a)
		{
			LuaObject.pushObject(l, a);
		}

		public static void pushVar(IntPtr l, object o)
		{
			if (o == null)
			{
				LuaDLL.pua_pushnil(l);
				return;
			}
			Type type = o.GetType();
			LuaObject.PushVarDelegate pushVarDelegate;
			if (LuaObject.typePushMap.TryGetValue(type, out pushVarDelegate))
			{
				pushVarDelegate(l, o);
			}
			else if (type.IsEnum)
			{
				LuaObject.pushEnum(l, Convert.ToInt32(o));
			}
			else if (type.IsArray)
			{
				LuaObject.pushObject(l, (Array)o);
			}
			else
			{
				LuaObject.pushObject(l, o);
			}
		}

		public static T checkSelf<T>(IntPtr l)
		{
			object obj = LuaObject.checkObj(l, 1);
			if (obj != null)
			{
				return (T)((object)obj);
			}
			throw new Exception("arg 1 expect self, but get null");
		}

		public static object checkSelf(IntPtr l)
		{
			object obj = LuaObject.checkObj(l, 1);
			if (obj == null)
			{
				throw new Exception("expect self, but get null");
			}
			return obj;
		}

		public static void setBack(IntPtr l, object o)
		{
			ObjectCache objectCache = ObjectCache.get(l);
			objectCache.setBack(l, 1, o);
		}

		public static void setBack(IntPtr l, Vector3 v)
		{
			LuaDLL.luaS_setDataVec(l, 1, v.x, v.y, v.z, float.NaN);
		}

		public static void setBack(IntPtr l, Vector2 v)
		{
			LuaDLL.luaS_setDataVec(l, 1, v.x, v.y, float.NaN, float.NaN);
		}

		public static void setBack(IntPtr l, Vector4 v)
		{
			LuaDLL.luaS_setDataVec(l, 1, v.x, v.y, v.z, v.w);
		}

		public static void setBack(IntPtr l, Quaternion v)
		{
			LuaDLL.luaS_setDataVec(l, 1, v.x, v.y, v.z, v.w);
		}

		public static void setBack(IntPtr l, Color v)
		{
			LuaDLL.luaS_setDataVec(l, 1, v.r, v.g, v.b, v.a);
		}

		public static int extractFunction(IntPtr l, int p)
		{
			int result = 0;
			switch (LuaDLL.pua_type(l, p))
			{
			case LuaTypes.LUA_TNIL:
			case LuaTypes.LUA_TUSERDATA:
				result = 0;
				return result;
			case LuaTypes.LUA_TTABLE:
				LuaDLL.pua_rawgeti(l, p, 1);
				LuaDLL.pua_pushstring(l, "+=");
				if (LuaDLL.pua_rawequal(l, -1, -2) == 1)
				{
					result = 1;
				}
				else
				{
					result = 2;
				}
				LuaDLL.pua_pop(l, 2);
				LuaDLL.pua_rawgeti(l, p, 2);
				return result;
			case LuaTypes.LUA_TFUNCTION:
				LuaDLL.pua_pushvalue(l, p);
				return result;
			}
			throw new Exception("expect valid Delegate");
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int noConstructor(IntPtr l)
		{
			return LuaObject.error(l, "Can't new this object");
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int typeToString(IntPtr l)
		{
			LuaDLL.pua_pushstring(l, "__fullname");
			LuaDLL.pua_rawget(l, -2);
			return 1;
		}

		public static int error(IntPtr l, Exception e)
		{
			LuaDLL.pua_pushboolean(l, false);
			LuaDLL.pua_pushstring(l, e.ToString());
			return 2;
		}

		public static int error(IntPtr l, string err)
		{
			LuaDLL.pua_pushboolean(l, false);
			LuaDLL.pua_pushstring(l, err);
			return 2;
		}

		public static int error(IntPtr l, string err, params object[] args)
		{
			err = string.Format(err, args);
			LuaDLL.pua_pushboolean(l, false);
			LuaDLL.pua_pushstring(l, err);
			return 2;
		}

		public static int ok(IntPtr l)
		{
			LuaDLL.pua_pushboolean(l, true);
			return 1;
		}

		public static int ok(IntPtr l, int retCount)
		{
			LuaDLL.pua_pushboolean(l, true);
			LuaDLL.pua_insert(l, -(retCount + 1));
			return retCount + 1;
		}

		public static void assert(bool cond, string err)
		{
			if (!cond)
			{
				throw new Exception(err);
			}
		}

		public static object changeType(object obj, Type t)
		{
			if (t == typeof(object))
			{
				return obj;
			}
			if (obj.GetType() == t)
			{
				return obj;
			}
			object result;
			try
			{
				result = Convert.ChangeType(obj, t);
			}
			catch
			{
				result = obj;
			}
			return result;
		}

		public static bool checkEnum<T>(IntPtr l, int p, out T o) where T : struct
		{
			int value = LuaDLL.puaL_checkinteger(l, p);
			o = (T)((object)Enum.ToObject(typeof(T), value));
			return true;
		}

		public static void pushEnum(IntPtr l, int e)
		{
			LuaObject.pushValue(l, e);
		}

		public static bool checkType(IntPtr l, int p, out sbyte v)
		{
			v = (sbyte)LuaDLL.puaL_checkinteger(l, p);
			return true;
		}

		public static void pushValue(IntPtr l, sbyte v)
		{
			LuaDLL.pua_pushinteger(l, (int)v);
		}

		public static bool checkType(IntPtr l, int p, out byte v)
		{
			v = (byte)LuaDLL.puaL_checkinteger(l, p);
			return true;
		}

		public static void pushValue(IntPtr l, byte i)
		{
			LuaDLL.pua_pushinteger(l, (int)i);
		}

		public static bool checkType(IntPtr l, int p, out char c)
		{
			c = (char)LuaDLL.puaL_checkinteger(l, p);
			return true;
		}

		public static void pushValue(IntPtr l, char v)
		{
			LuaDLL.pua_pushinteger(l, (int)v);
		}

		public static bool checkArray(IntPtr l, int p, out char[] pars)
		{
			LuaDLL.puaL_checktype(l, p, LuaTypes.LUA_TSTRING);
			string text;
			LuaObject.checkType(l, p, out text);
			pars = text.ToCharArray();
			return true;
		}

		public static bool checkType(IntPtr l, int p, out short v)
		{
			v = (short)LuaDLL.puaL_checkinteger(l, p);
			return true;
		}

		public static void pushValue(IntPtr l, short i)
		{
			LuaDLL.pua_pushinteger(l, (int)i);
		}

		public static bool checkType(IntPtr l, int p, out ushort v)
		{
			v = (ushort)LuaDLL.puaL_checkinteger(l, p);
			return true;
		}

		public static void pushValue(IntPtr l, ushort v)
		{
			LuaDLL.pua_pushinteger(l, (int)v);
		}

		public static bool checkType(IntPtr l, int p, out int v)
		{
			v = LuaDLL.puaL_checkinteger(l, p);
			return true;
		}

		public static void pushValue(IntPtr l, int i)
		{
			LuaDLL.pua_pushinteger(l, i);
		}

		public static bool checkType(IntPtr l, int p, out uint v)
		{
			v = (uint)LuaDLL.puaL_checkinteger(l, p);
			return true;
		}

		public static void pushValue(IntPtr l, uint o)
		{
			LuaDLL.pua_pushnumber(l, o);
		}

		public static bool checkType(IntPtr l, int p, out long v)
		{
			v = (long)LuaDLL.puaL_checknumber(l, p);
			return true;
		}

		public static void pushValue(IntPtr l, long i)
		{
			LuaDLL.pua_pushnumber(l, (double)i);
		}

		public static bool checkType(IntPtr l, int p, out ulong v)
		{
			v = (ulong)LuaDLL.puaL_checknumber(l, p);
			return true;
		}

		public static void pushValue(IntPtr l, ulong o)
		{
			LuaDLL.pua_pushnumber(l, o);
		}

		public static bool checkType(IntPtr l, int p, out float v)
		{
			v = (float)LuaDLL.puaL_checknumber(l, p);
			return true;
		}

		public static void pushValue(IntPtr l, float o)
		{
			LuaDLL.pua_pushnumber(l, (double)o);
		}

		public static bool checkType(IntPtr l, int p, out double v)
		{
			v = LuaDLL.puaL_checknumber(l, p);
			return true;
		}

		public static void pushValue(IntPtr l, double d)
		{
			LuaDLL.pua_pushnumber(l, d);
		}

		public static bool checkType(IntPtr l, int p, out bool v)
		{
			LuaDLL.puaL_checktype(l, p, LuaTypes.LUA_TBOOLEAN);
			v = LuaDLL.pua_toboolean(l, p);
			return true;
		}

		public static void pushValue(IntPtr l, bool b)
		{
			LuaDLL.pua_pushboolean(l, b);
		}

		public static bool checkType(IntPtr l, int p, out string v)
		{
			if (LuaDLL.pua_isuserdata(l, p) > 0)
			{
				object obj = LuaObject.checkObj(l, p);
				if (obj is string)
				{
					v = (obj as string);
					return true;
				}
			}
			else if (LuaDLL.pua_isstring(l, p))
			{
				v = LuaDLL.pua_tostring(l, p);
				return true;
			}
			v = null;
			return false;
		}

		public static bool checkBinaryString(IntPtr l, int p, out byte[] bytes)
		{
			if (LuaDLL.pua_isstring(l, p))
			{
				bytes = LuaDLL.pua_tobytes(l, p);
				return true;
			}
			bytes = null;
			return false;
		}

		public static void pushValue(IntPtr l, string s)
		{
			LuaDLL.pua_pushstring(l, s);
		}

		public static bool checkType(IntPtr l, int p, out IntPtr v)
		{
			v = LuaDLL.pua_touserdata(l, p);
			return true;
		}

		public static bool checkType(IntPtr l, int p, out LuaDelegate f)
		{
			LuaState luaState = LuaState.get(l);
			p = LuaDLL.pua_absindex(l, p);
			LuaDLL.puaL_checktype(l, p, LuaTypes.LUA_TFUNCTION);
			LuaDLL.pua_getglobal(l, "__LuaDelegate");
			LuaDLL.pua_pushvalue(l, p);
			LuaDLL.pua_gettable(l, -2);
			if (LuaDLL.pua_isnil(l, -1))
			{
				LuaDLL.pua_pop(l, 1);
				f = LuaObject.newDelegate(l, p);
			}
			else
			{
				int key = LuaDLL.pua_tointeger(l, -1);
				LuaDLL.pua_pop(l, 1);
				f = luaState.delgateMap[key];
				if (f == null)
				{
					f = LuaObject.newDelegate(l, p);
				}
			}
			LuaDLL.pua_pop(l, 1);
			return true;
		}

		public static bool checkType(IntPtr l, int p, out LuaThread lt)
		{
			if (LuaDLL.pua_isnil(l, p))
			{
				lt = null;
				return true;
			}
			LuaDLL.puaL_checktype(l, p, LuaTypes.LUA_TTHREAD);
			LuaDLL.pua_pushvalue(l, p);
			int r = LuaDLL.puaL_ref(l, LuaIndexes.LUA_REGISTRYINDEX);
			lt = new LuaThread(l, r);
			return true;
		}

		public static bool checkType(IntPtr l, int p, out LuaFunction f)
		{
			if (LuaDLL.pua_isnil(l, p))
			{
				f = null;
				return true;
			}
			LuaDLL.puaL_checktype(l, p, LuaTypes.LUA_TFUNCTION);
			LuaDLL.pua_pushvalue(l, p);
			int r = LuaDLL.puaL_ref(l, LuaIndexes.LUA_REGISTRYINDEX);
			f = new LuaFunction(l, r);
			return true;
		}

		public static bool checkType(IntPtr l, int p, out LuaTable t)
		{
			if (LuaDLL.pua_isnil(l, p))
			{
				t = null;
				return true;
			}
			LuaDLL.puaL_checktype(l, p, LuaTypes.LUA_TTABLE);
			LuaDLL.pua_pushvalue(l, p);
			int r = LuaDLL.puaL_ref(l, LuaIndexes.LUA_REGISTRYINDEX);
			t = new LuaTable(l, r);
			return true;
		}

		public static void pushValue(IntPtr l, LuaCSFunction f)
		{
			LuaState.pushcsfunction(l, f);
		}

		public static void pushValue(IntPtr l, LuaTable t)
		{
			if (t == null)
			{
				LuaDLL.pua_pushnil(l);
			}
			else
			{
				t.push(l);
			}
		}

		public static Type FindType(string qualifiedTypeName)
		{
			Type type = Type.GetType(qualifiedTypeName);
			if (type != null)
			{
				return type;
			}
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				Assembly assembly = assemblies[i];
				type = assembly.GetType(qualifiedTypeName);
				if (type != null)
				{
					return type;
				}
			}
			return null;
		}

		public static bool checkType(IntPtr l, int p, out Type t)
		{
			string text = null;
			LuaTypes luaTypes = LuaDLL.pua_type(l, p);
			switch (luaTypes)
			{
			case LuaTypes.LUA_TSTRING:
				LuaObject.checkType(l, p, out text);
				break;
			case LuaTypes.LUA_TTABLE:
				LuaDLL.pua_pushstring(l, "__type");
				LuaDLL.pua_rawget(l, p);
				if (!LuaDLL.pua_isnil(l, -1))
				{
					t = (Type)LuaObject.checkObj(l, -1);
					LuaDLL.pua_pop(l, 1);
					return true;
				}
				LuaDLL.pua_pushstring(l, "__fullname");
				LuaDLL.pua_rawget(l, p);
				text = LuaDLL.pua_tostring(l, -1);
				LuaDLL.pua_pop(l, 2);
				break;
			case LuaTypes.LUA_TUSERDATA:
			{
				object obj = LuaObject.checkObj(l, p);
				if (obj.GetType() != LuaObject.MonoType)
				{
					throw new Exception(string.Format("{0} expect Type, got {1}", p, obj.GetType().Name));
				}
				t = (Type)obj;
				return true;
			}
			}
			if (text == null)
			{
				throw new Exception("expect string or type table");
			}
			t = LuaObject.FindType(text);
			if (t != null && luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.pua_pushstring(l, "__type");
				LuaObject.pushLightObject(l, t);
				LuaDLL.pua_rawset(l, p);
			}
			return t != null;
		}

		public static bool checkValueType<T>(IntPtr l, int p, out T v) where T : struct
		{
			v = (T)((object)LuaObject.checkObj(l, p));
			return true;
		}

		public static bool checkNullable<T>(IntPtr l, int p, out T? v) where T : struct
		{
			if (LuaDLL.pua_isnil(l, p))
			{
				v = null;
			}
			else
			{
				object obj = LuaObject.checkVar(l, p, typeof(T));
				if (obj == null)
				{
					v = null;
				}
				else
				{
					v = new T?((T)((object)obj));
				}
			}
			return true;
		}

		public static bool checkType<T>(IntPtr l, int p, out T o) where T : class
		{
			object obj = LuaObject.checkVar(l, p);
			if (obj == null)
			{
				o = (T)((object)null);
				return true;
			}
			o = (obj as T);
			if (o == null)
			{
				throw new Exception(string.Format("arg {0} is not type of {1}", p, typeof(T).Name));
			}
			return true;
		}

		public static bool checkType(IntPtr l, int p, out Vector4 v)
		{
			float x;
			float y;
			float z;
			float w;
			if (LuaDLL.luaS_checkVector4(l, p, out x, out y, out z, out w) != 0)
			{
				throw new Exception(string.Format("Invalid vector4 argument at {0}", p));
			}
			v = new Vector4(x, y, z, w);
			return true;
		}

		public static bool checkType(IntPtr l, int p, out Vector3 v)
		{
			float x;
			float y;
			float z;
			if (LuaDLL.luaS_checkVector3(l, p, out x, out y, out z) != 0)
			{
				throw new Exception(string.Format("Invalid vector3 argument at {0}", p));
			}
			v = new Vector3(x, y, z);
			return true;
		}

		public static bool checkType(IntPtr l, int p, out Vector2 v)
		{
			float x;
			float y;
			if (LuaDLL.luaS_checkVector2(l, p, out x, out y) != 0)
			{
				throw new Exception(string.Format("Invalid vector2 argument at {0}", p));
			}
			v = new Vector2(x, y);
			return true;
		}

		public static bool checkType(IntPtr l, int p, out Quaternion q)
		{
			float x;
			float y;
			float z;
			float w;
			if (LuaDLL.luaS_checkQuaternion(l, p, out x, out y, out z, out w) != 0)
			{
				throw new Exception(string.Format("Invalid quaternion argument at {0}", p));
			}
			q = new Quaternion(x, y, z, w);
			return true;
		}

		public static bool checkType(IntPtr l, int p, out Color c)
		{
			float r;
			float g;
			float b;
			float a;
			if (LuaDLL.luaS_checkColor(l, p, out r, out g, out b, out a) != 0)
			{
				throw new Exception(string.Format("Invalid color argument at {0}", p));
			}
			c = new Color(r, g, b, a);
			return true;
		}

		public static bool checkType(IntPtr l, int p, out LayerMask lm)
		{
			int intVal;
			LuaObject.checkType(l, p, out intVal);
			lm = intVal;
			return true;
		}

		public static bool checkParams(IntPtr l, int p, out Vector2[] pars)
		{
			int num = LuaDLL.pua_gettop(l);
			if (num - p >= 0)
			{
				pars = new Vector2[num - p + 1];
				int i = p;
				int num2 = 0;
				while (i <= num)
				{
					LuaObject.checkType(l, i, out pars[num2]);
					i++;
					num2++;
				}
				return true;
			}
			pars = new Vector2[0];
			return true;
		}

		public static void pushValue(IntPtr l, RaycastHit2D r)
		{
			LuaObject.pushObject(l, r);
		}

		public static void pushValue(IntPtr l, RaycastHit r)
		{
			LuaObject.pushObject(l, r);
		}

		public static void pushValue(IntPtr l, AnimationState o)
		{
			if (o == null)
			{
				LuaDLL.pua_pushnil(l);
			}
			else
			{
				LuaObject.pushObject(l, o);
			}
		}

		public static void pushValue(IntPtr l, UnityEngine.Object o)
		{
			if (o == null)
			{
				LuaDLL.pua_pushnil(l);
			}
			else
			{
				LuaObject.pushObject(l, o);
			}
		}

		public static void pushValue(IntPtr l, Quaternion o)
		{
			LuaDLL.luaS_pushQuaternion(l, o.x, o.y, o.z, o.w);
		}

		public static void pushValue(IntPtr l, Vector2 o)
		{
			LuaDLL.luaS_pushVector2(l, o.x, o.y);
		}

		public static void pushValue(IntPtr l, Vector3 o)
		{
			LuaDLL.luaS_pushVector3(l, o.x, o.y, o.z);
		}

		public static void pushValue(IntPtr l, Vector4 o)
		{
			LuaDLL.luaS_pushVector4(l, o.x, o.y, o.z, o.w);
		}

		public static void pushValue(IntPtr l, Color o)
		{
			LuaDLL.luaS_pushColor(l, o.r, o.g, o.b, o.a);
		}

		public static void pushValue(IntPtr l, Color32 c32)
		{
			LuaObject.pushObject(l, c32);
		}
	}
}
