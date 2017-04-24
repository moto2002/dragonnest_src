using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace com.tencent.pandora
{
	internal class LuaVarObject : LuaObject
	{
		private class MethodWrapper
		{
			private object self;

			private IList<MemberInfo> mis;

			public MethodWrapper(object self, IList<MemberInfo> mi)
			{
				this.self = self;
				this.mis = mi;
			}

			private bool matchType(IntPtr l, int p, LuaTypes lt, Type t)
			{
				if (t.IsPrimitive && t != typeof(bool))
				{
					return lt == LuaTypes.LUA_TNUMBER;
				}
				if (t == typeof(bool))
				{
					return lt == LuaTypes.LUA_TBOOLEAN;
				}
				if (t == typeof(string))
				{
					return lt == LuaTypes.LUA_TSTRING;
				}
				if (lt == LuaTypes.LUA_TTABLE)
				{
					return t == typeof(LuaTable) || LuaObject.luaTypeCheck(l, p, t.Name);
				}
				if (lt != LuaTypes.LUA_TFUNCTION)
				{
					return lt == LuaTypes.LUA_TUSERDATA || t == typeof(object);
				}
				return t == typeof(LuaFunction) || t.BaseType == typeof(MulticastDelegate);
			}

			private object checkVar(IntPtr l, int p, Type t)
			{
				string name = t.Name;
				string text = name;
				switch (text)
				{
				case "String":
				{
					string result;
					if (LuaObject.checkType(l, p, out result))
					{
						return result;
					}
					return null;
				}
				case "Decimal":
					return (decimal)LuaDLL.pua_tonumber(l, p);
				case "Int64":
					return (long)LuaDLL.pua_tonumber(l, p);
				case "UInt64":
					return (ulong)LuaDLL.pua_tonumber(l, p);
				case "Int32":
					return LuaDLL.pua_tointeger(l, p);
				case "UInt32":
					return (uint)LuaDLL.pua_tointeger(l, p);
				case "Single":
					return (float)LuaDLL.pua_tonumber(l, p);
				case "Double":
					return LuaDLL.pua_tonumber(l, p);
				case "Boolean":
					return LuaDLL.pua_toboolean(l, p);
				case "Byte":
					return (byte)LuaDLL.pua_tointeger(l, p);
				case "UInt16":
					return (ushort)LuaDLL.pua_tointeger(l, p);
				case "Int16":
					return (short)LuaDLL.pua_tointeger(l, p);
				}
				if (t.IsEnum)
				{
					int value = LuaDLL.pua_tointeger(l, p);
					return Enum.ToObject(t, value);
				}
				return LuaObject.checkVar(l, p);
			}

			internal bool matchType(IntPtr l, int from, ParameterInfo[] pis, bool isstatic)
			{
				int num = LuaDLL.pua_gettop(l);
				from = ((!isstatic) ? (from + 1) : from);
				if (num - from + 1 != pis.Length)
				{
					return false;
				}
				for (int i = 0; i < pis.Length; i++)
				{
					int num2 = i + from;
					LuaTypes lt = LuaDLL.pua_type(l, num2);
					if (!this.matchType(l, num2, lt, pis[i].ParameterType))
					{
						return false;
					}
				}
				return true;
			}

			public int invoke(IntPtr l)
			{
				for (int i = 0; i < this.mis.Count; i++)
				{
					MethodInfo methodInfo = (MethodInfo)this.mis[i];
					if (this.matchType(l, 2, methodInfo.GetParameters(), methodInfo.IsStatic))
					{
						return this.forceInvoke(l, methodInfo);
					}
				}
				return this.forceInvoke(l, this.mis[0] as MethodInfo);
			}

			private int forceInvoke(IntPtr l, MethodInfo m)
			{
				object[] parameters;
				this.checkArgs(l, 1, m, out parameters);
				object obj = m.Invoke((!m.IsStatic) ? this.self : null, parameters);
				LuaObject.pushValue(l, true);
				if (obj != null)
				{
					LuaObject.pushVar(l, obj);
					return 2;
				}
				return 1;
			}

			public void checkArgs(IntPtr l, int from, MethodInfo m, out object[] args)
			{
				ParameterInfo[] parameters = m.GetParameters();
				args = new object[parameters.Length];
				int num = 0;
				from = ((!m.IsStatic) ? (from + 2) : (from + 1));
				int i = from;
				while (i <= LuaDLL.pua_gettop(l))
				{
					if (num + 1 > parameters.Length)
					{
						break;
					}
					args[num] = this.checkVar(l, i, parameters[num].ParameterType);
					i++;
					num++;
				}
			}
		}

		private static Dictionary<Type, Dictionary<string, List<MemberInfo>>> cachedMemberInfos = new Dictionary<Type, Dictionary<string, List<MemberInfo>>>();

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int luaIndex(IntPtr l)
		{
			int result;
			try
			{
				ObjectCache objectCache = ObjectCache.get(l);
				object self = objectCache.get(l, 1);
				LuaTypes luaTypes = LuaDLL.pua_type(l, 2);
				LuaTypes luaTypes2 = luaTypes;
				if (luaTypes2 != LuaTypes.LUA_TNUMBER)
				{
					if (luaTypes2 != LuaTypes.LUA_TSTRING)
					{
						result = LuaVarObject.indexObject(l, self, LuaObject.checkObj(l, 2));
					}
					else
					{
						result = LuaVarObject.indexString(l, self, LuaDLL.pua_tostring(l, 2));
					}
				}
				else
				{
					result = LuaVarObject.indexInt(l, self, LuaDLL.pua_tointeger(l, 2));
				}
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		private static int indexObject(IntPtr l, object self, object key)
		{
			if (self is IDictionary)
			{
				IDictionary dictionary = self as IDictionary;
				object o = dictionary[key];
				LuaObject.pushValue(l, true);
				LuaObject.pushVar(l, o);
				return 2;
			}
			return 0;
		}

		private static Type getType(object o)
		{
			if (o is LuaClassObject)
			{
				return (o as LuaClassObject).GetClsType();
			}
			return o.GetType();
		}

		private static int indexString(IntPtr l, object self, string key)
		{
			Type type = LuaVarObject.getType(self);
			if (self is IDictionary)
			{
				if (!type.IsGenericType || type.GetGenericArguments()[0] == typeof(string))
				{
					object obj = (self as IDictionary)[key];
					if (obj != null)
					{
						LuaObject.pushValue(l, true);
						LuaObject.pushVar(l, obj);
						return 2;
					}
				}
			}
			IList<MemberInfo> cacheMembers = LuaVarObject.GetCacheMembers(type, key);
			if (cacheMembers == null || cacheMembers.Count == 0)
			{
				return LuaObject.error(l, "Can't find " + key);
			}
			LuaObject.pushValue(l, true);
			MemberInfo memberInfo = cacheMembers[0];
			MemberTypes memberType = memberInfo.MemberType;
			switch (memberType)
			{
			case MemberTypes.Event:
				return 2;
			case MemberTypes.Constructor | MemberTypes.Event:
			{
				IL_B3:
				if (memberType == MemberTypes.Method)
				{
					LuaCSFunction o = new LuaCSFunction(new LuaVarObject.MethodWrapper(self, cacheMembers).invoke);
					LuaObject.pushObject(l, o);
					return 2;
				}
				if (memberType != MemberTypes.Property)
				{
					return 1;
				}
				PropertyInfo propertyInfo = (PropertyInfo)memberInfo;
				MethodInfo getMethod = propertyInfo.GetGetMethod(true);
				LuaObject.pushVar(l, getMethod.Invoke(self, null));
				return 2;
			}
			case MemberTypes.Field:
			{
				FieldInfo fieldInfo = (FieldInfo)memberInfo;
				LuaObject.pushVar(l, fieldInfo.GetValue(self));
				return 2;
			}
			}
			goto IL_B3;
		}

		private static void CollectTypeMembers(Type type, ref Dictionary<string, List<MemberInfo>> membersMap)
		{
			MemberInfo[] members = type.GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			for (int i = 0; i < members.Length; i++)
			{
				MemberInfo memberInfo = members[i];
				List<MemberInfo> list;
				if (!membersMap.TryGetValue(memberInfo.Name, out list))
				{
					List<MemberInfo> list2 = new List<MemberInfo>();
					membersMap[memberInfo.Name] = list2;
					list = list2;
				}
				list.Add(memberInfo);
			}
			if (type.BaseType != null)
			{
				LuaVarObject.CollectTypeMembers(type.BaseType, ref membersMap);
			}
		}

		private static IList<MemberInfo> GetCacheMembers(Type type, string key)
		{
			Dictionary<string, List<MemberInfo>> dictionary;
			if (!LuaVarObject.cachedMemberInfos.TryGetValue(type, out dictionary))
			{
				dictionary = (LuaVarObject.cachedMemberInfos[type] = new Dictionary<string, List<MemberInfo>>());
				LuaVarObject.CollectTypeMembers(type, ref dictionary);
			}
			return dictionary[key];
		}

		private static int newindexString(IntPtr l, object self, string key)
		{
			if (self is IDictionary)
			{
				Type type = LuaVarObject.getType(self);
				Type t = type.GetGenericArguments()[1];
				(self as IDictionary)[key] = LuaObject.checkVar(l, 3, t);
				return LuaObject.ok(l);
			}
			Type type2 = LuaVarObject.getType(self);
			IList<MemberInfo> cacheMembers = LuaVarObject.GetCacheMembers(type2, key);
			if (cacheMembers == null || cacheMembers.Count == 0)
			{
				return LuaObject.error(l, "Can't find " + key);
			}
			MemberInfo memberInfo = cacheMembers[0];
			MemberTypes memberType = memberInfo.MemberType;
			switch (memberType)
			{
			case MemberTypes.Event:
				return LuaObject.error(l, "Event can't set");
			case MemberTypes.Constructor | MemberTypes.Event:
			{
				IL_8F:
				if (memberType == MemberTypes.Method)
				{
					return LuaObject.error(l, "Method can't set");
				}
				if (memberType != MemberTypes.Property)
				{
					goto IL_121;
				}
				PropertyInfo propertyInfo = (PropertyInfo)memberInfo;
				MethodInfo setMethod = propertyInfo.GetSetMethod(true);
				object obj = LuaObject.checkVar(l, 3, propertyInfo.PropertyType);
				setMethod.Invoke(self, new object[]
				{
					obj
				});
				goto IL_121;
			}
			case MemberTypes.Field:
			{
				FieldInfo fieldInfo = (FieldInfo)memberInfo;
				object value = LuaObject.checkVar(l, 3, fieldInfo.FieldType);
				fieldInfo.SetValue(self, value);
				goto IL_121;
			}
			}
			goto IL_8F;
			IL_121:
			return LuaObject.ok(l);
		}

		private static int indexInt(IntPtr l, object self, int index)
		{
			Type type = LuaVarObject.getType(self);
			if (self is IList)
			{
				LuaObject.pushValue(l, true);
				LuaObject.pushVar(l, (self as IList)[index]);
				return 2;
			}
			if (self is IDictionary)
			{
				IDictionary dictionary = (IDictionary)self;
				object obj = index;
				if (type.IsGenericType)
				{
					Type type2 = type.GetGenericArguments()[0];
					if (type2.IsEnum)
					{
						LuaObject.pushValue(l, true);
						LuaObject.pushVar(l, dictionary[Enum.Parse(type2, obj.ToString())]);
						return 2;
					}
					obj = LuaObject.changeType(obj, type2);
				}
				LuaObject.pushValue(l, true);
				LuaObject.pushVar(l, dictionary[obj]);
				return 2;
			}
			return 0;
		}

		private static int newindexInt(IntPtr l, object self, int index)
		{
			Type type = LuaVarObject.getType(self);
			if (self is IList)
			{
				if (type.IsGenericType)
				{
					Type t = type.GetGenericArguments()[0];
					(self as IList)[index] = LuaObject.changeType(LuaObject.checkVar(l, 3), t);
				}
				else
				{
					(self as IList)[index] = LuaObject.checkVar(l, 3);
				}
			}
			else if (self is IDictionary)
			{
				Type t2 = type.GetGenericArguments()[0];
				object obj = index;
				obj = LuaObject.changeType(obj, t2);
				if (type.IsGenericType)
				{
					Type t3 = type.GetGenericArguments()[1];
					(self as IDictionary)[obj] = LuaObject.changeType(LuaObject.checkVar(l, 3), t3);
				}
				else
				{
					(self as IDictionary)[obj] = LuaObject.checkVar(l, 3);
				}
			}
			LuaObject.pushValue(l, true);
			return 1;
		}

		private static int newindexObject(IntPtr l, object self, object k, object v)
		{
			if (self is IDictionary)
			{
				IDictionary dictionary = self as IDictionary;
				Type type = LuaVarObject.getType(self);
				Type t = type.GetGenericArguments()[1];
				object value = LuaObject.changeType(v, t);
				dictionary[k] = value;
			}
			return LuaObject.ok(l);
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int luaNewIndex(IntPtr l)
		{
			int result;
			try
			{
				ObjectCache objectCache = ObjectCache.get(l);
				object self = objectCache.get(l, 1);
				LuaTypes luaTypes = LuaDLL.pua_type(l, 2);
				LuaTypes luaTypes2 = luaTypes;
				if (luaTypes2 != LuaTypes.LUA_TNUMBER)
				{
					if (luaTypes2 != LuaTypes.LUA_TSTRING)
					{
						result = LuaVarObject.newindexObject(l, self, LuaObject.checkVar(l, 2), LuaObject.checkVar(l, 3));
					}
					else
					{
						result = LuaVarObject.newindexString(l, self, LuaDLL.pua_tostring(l, 2));
					}
				}
				else
				{
					result = LuaVarObject.newindexInt(l, self, LuaDLL.pua_tointeger(l, 2));
				}
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int methodWrapper(IntPtr l)
		{
			int result;
			try
			{
				ObjectCache objectCache = ObjectCache.get(l);
				LuaCSFunction luaCSFunction = (LuaCSFunction)objectCache.get(l, 1);
				result = luaCSFunction(l);
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		public new static void init(IntPtr l)
		{
			LuaDLL.pua_createtable(l, 0, 3);
			LuaObject.pushValue(l, new LuaCSFunction(LuaVarObject.luaIndex));
			LuaDLL.pua_setfield(l, -2, "__index");
			LuaObject.pushValue(l, new LuaCSFunction(LuaVarObject.luaNewIndex));
			LuaDLL.pua_setfield(l, -2, "__newindex");
			LuaDLL.pua_pushcfunction(l, LuaObject.lua_gc);
			LuaDLL.pua_setfield(l, -2, "__gc");
			LuaDLL.pua_setfield(l, LuaIndexes.LUA_REGISTRYINDEX, "LuaVarObject");
			LuaDLL.pua_createtable(l, 0, 1);
			LuaObject.pushValue(l, new LuaCSFunction(LuaVarObject.methodWrapper));
			LuaDLL.pua_setfield(l, -2, "__call");
			LuaDLL.pua_setfield(l, LuaIndexes.LUA_REGISTRYINDEX, ObjectCache.getAQName(typeof(LuaCSFunction)));
		}
	}
}
