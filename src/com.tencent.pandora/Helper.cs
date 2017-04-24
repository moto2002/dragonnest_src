using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

namespace com.tencent.pandora
{
	internal class Helper : LuaObject
	{
		private static string classfunc = "\r\nlocal getmetatable = getmetatable\r\nlocal function Class(base,static,instance)\r\n\r\n    local mt = getmetatable(base)\r\n\r\n    local class = static or {}\r\n    setmetatable(class, \r\n        {\r\n            __index = base,\r\n            __call = function(...)\r\n                local r = mt.__call(...)\r\n                local ret = instance or {}\r\n\r\n                local ins_ret = setmetatable(\r\n                    {\r\n                        __base = r,\r\n                    },\r\n\r\n                    {\r\n                        __index = function(t, k)\r\n                            local ret_field\r\n                            ret_field = ret[k]\r\n                            if nil == ret_field then\r\n                                ret_field = r[k]\r\n                            end\r\n\r\n                            return ret_field\r\n                        end,\r\n\r\n                        __newindex = function(t,k,v)\r\n                            if not pcall(function() r[k]=v end) then\r\n                                rawset(t,k,v)\r\n                            end\r\n                        end,\r\n                    })\r\n\r\n                if ret.ctor then\r\n                    ret.ctor(ins_ret, ...)\r\n                end\r\n\r\n                return ins_ret\r\n            end,\r\n        }\r\n    )\r\n    return class\r\nend\r\nreturn Class\r\n";

		private static LuaOut luaOut = new LuaOut();

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int _iter(IntPtr l)
		{
			object obj = LuaObject.checkObj(l, LuaDLL.pua_upvalueindex(1));
			IEnumerator enumerator = (IEnumerator)obj;
			if (enumerator.MoveNext())
			{
				LuaObject.pushVar(l, enumerator.Current);
				return 1;
			}
			if (obj is IDisposable)
			{
				(obj as IDisposable).Dispose();
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int iter(IntPtr l)
		{
			object obj = LuaObject.checkObj(l, 1);
			if (obj is IEnumerable)
			{
				IEnumerable enumerable = obj as IEnumerable;
				IEnumerator enumerator = enumerable.GetEnumerator();
				LuaObject.pushValue(l, true);
				LuaObject.pushLightObject(l, enumerator);
				LuaDLL.pua_pushcclosure(l, new LuaCSFunction(Helper._iter), 1);
				return 2;
			}
			return LuaObject.error(l, "passed in object isn't enumerable");
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int CreateAction(IntPtr l)
		{
			int result;
			try
			{
				LuaFunction func;
				LuaObject.checkType(l, 1, out func);
				Action o = delegate
				{
					func.call();
				};
				LuaObject.pushValue(l, true);
				LuaObject.pushVar(l, o);
				result = 2;
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int CreateClass(IntPtr l)
		{
			int result;
			try
			{
				string text;
				LuaObject.checkType(l, 1, out text);
				Type type = LuaObject.FindType(text);
				if (type == null)
				{
					result = LuaObject.error(l, string.Format("Can't find {0} to create", text));
				}
				else
				{
					ConstructorInfo[] constructors = type.GetConstructors();
					ConstructorInfo constructorInfo = null;
					for (int i = 0; i < constructors.Length; i++)
					{
						ConstructorInfo constructorInfo2 = constructors[i];
						if (LuaObject.matchType(l, LuaDLL.pua_gettop(l), 2, constructorInfo2.GetParameters()))
						{
							constructorInfo = constructorInfo2;
							break;
						}
					}
					if (constructorInfo != null)
					{
						ParameterInfo[] parameters = constructorInfo.GetParameters();
						object[] array = new object[parameters.Length];
						for (int j = 0; j < parameters.Length; j++)
						{
							array[j] = LuaObject.changeType(LuaObject.checkVar(l, j + 2), parameters[j].ParameterType);
						}
						object o = constructorInfo.Invoke(array);
						LuaObject.pushValue(l, true);
						LuaObject.pushVar(l, o);
						result = 2;
					}
					else
					{
						LuaObject.pushValue(l, true);
						result = 1;
					}
				}
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int GetClass(IntPtr l)
		{
			int result;
			try
			{
				string text;
				LuaObject.checkType(l, 1, out text);
				Type type = LuaObject.FindType(text);
				if (type == null)
				{
					result = LuaObject.error(l, "Can't find {0} to create", new object[]
					{
						text
					});
				}
				else
				{
					LuaClassObject o = new LuaClassObject(type);
					LuaObject.pushValue(l, true);
					LuaObject.pushObject(l, o);
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
		public static int ToBytes(IntPtr l)
		{
			int result;
			try
			{
				byte[] o = null;
				LuaObject.checkBinaryString(l, 1, out o);
				LuaObject.pushValue(l, true);
				LuaObject.pushObject(l, o);
				result = 2;
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public new static int ToString(IntPtr l)
		{
			int result;
			try
			{
				object obj = LuaObject.checkObj(l, 1);
				if (obj == null)
				{
					LuaObject.pushValue(l, true);
					LuaDLL.pua_pushnil(l);
					result = 2;
				}
				else
				{
					LuaObject.pushValue(l, true);
					if (obj is byte[])
					{
						byte[] array = (byte[])obj;
						LuaDLL.pua_pushlstring(l, array, array.Length);
					}
					else
					{
						LuaObject.pushValue(l, obj.ToString());
					}
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
		public static int MakeArray(IntPtr l)
		{
			int result;
			try
			{
				Type type;
				LuaObject.checkType(l, 1, out type);
				LuaDLL.puaL_checktype(l, 2, LuaTypes.LUA_TTABLE);
				int num = LuaDLL.pua_rawlen(l, 2);
				Array array = Array.CreateInstance(type, num);
				for (int i = 0; i < num; i++)
				{
					LuaDLL.pua_rawgeti(l, 2, i + 1);
					object obj = LuaObject.checkVar(l, -1);
					array.SetValue(LuaObject.changeType(obj, type), i);
					LuaDLL.pua_pop(l, 1);
				}
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, array);
				result = 2;
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int As(IntPtr l)
		{
			int result;
			try
			{
				if (!LuaObject.isTypeTable(l, 2))
				{
					result = LuaObject.error(l, "No matched type of param 2");
				}
				else
				{
					string meta = LuaDLL.pua_tostring(l, -1);
					LuaDLL.puaL_getmetatable(l, meta);
					LuaDLL.pua_setmetatable(l, 1);
					LuaObject.pushValue(l, true);
					LuaDLL.pua_pushvalue(l, 1);
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
		public static int IsNull(IntPtr l)
		{
			int result;
			try
			{
				LuaTypes luaTypes = LuaDLL.pua_type(l, 1);
				LuaObject.pushValue(l, true);
				if (luaTypes == LuaTypes.LUA_TNIL)
				{
					LuaObject.pushValue(l, true);
				}
				else if (luaTypes == LuaTypes.LUA_TUSERDATA || LuaObject.isLuaClass(l, 1))
				{
					object obj = LuaObject.checkObj(l, 1);
					if (obj is UnityEngine.Object)
					{
						LuaObject.pushValue(l, (UnityEngine.Object)obj == null);
					}
					else
					{
						LuaObject.pushValue(l, obj.Equals(null));
					}
				}
				else
				{
					LuaObject.pushValue(l, false);
				}
				result = 2;
			}
			catch (Exception e)
			{
				result = LuaObject.error(l, e);
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int get_out(IntPtr l)
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushLightObject(l, Helper.luaOut);
			return 2;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int get_version(IntPtr l)
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, 4113);
			return 2;
		}

		public static void reg(IntPtr l)
		{
			LuaObject.getTypeTable(l, "Slua");
			LuaObject.addMember(l, new LuaCSFunction(Helper.CreateAction), false);
			LuaObject.addMember(l, new LuaCSFunction(Helper.CreateClass), false);
			LuaObject.addMember(l, new LuaCSFunction(Helper.GetClass), false);
			LuaObject.addMember(l, new LuaCSFunction(Helper.iter), false);
			LuaObject.addMember(l, new LuaCSFunction(Helper.ToString), false);
			LuaObject.addMember(l, new LuaCSFunction(Helper.As), false);
			LuaObject.addMember(l, new LuaCSFunction(Helper.IsNull), false);
			LuaObject.addMember(l, new LuaCSFunction(Helper.MakeArray), false);
			LuaObject.addMember(l, new LuaCSFunction(Helper.ToBytes), false);
			LuaObject.addMember(l, "out", new LuaCSFunction(Helper.get_out), null, false);
			LuaObject.addMember(l, "version", new LuaCSFunction(Helper.get_version), null, false);
			LuaFunction luaFunction = LuaState.get(l).doString(Helper.classfunc) as LuaFunction;
			luaFunction.push(l);
			LuaDLL.pua_setfield(l, -3, "Class");
			LuaObject.createTypeMetatable(l, null, typeof(Helper));
		}
	}
}
