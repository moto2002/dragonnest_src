using com.tencent.pandora;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

public class Lua_System_Collections_Generic_Dictionary_2_int_string : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				Dictionary<int, string> o = new Dictionary<int, string>();
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(IEqualityComparer<int>)))
			{
				IEqualityComparer<int> comparer;
				LuaObject.checkType<IEqualityComparer<int>>(l, 2, out comparer);
				Dictionary<int, string> o = new Dictionary<int, string>(comparer);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(IDictionary<int, string>)))
			{
				IDictionary<int, string> dictionary;
				LuaObject.checkType<IDictionary<int, string>>(l, 2, out dictionary);
				Dictionary<int, string> o = new Dictionary<int, string>(dictionary);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(int)))
			{
				int capacity;
				LuaObject.checkType(l, 2, out capacity);
				Dictionary<int, string> o = new Dictionary<int, string>(capacity);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(IDictionary<int, string>), typeof(IEqualityComparer<int>)))
			{
				IDictionary<int, string> dictionary2;
				LuaObject.checkType<IDictionary<int, string>>(l, 2, out dictionary2);
				IEqualityComparer<int> comparer2;
				LuaObject.checkType<IEqualityComparer<int>>(l, 3, out comparer2);
				Dictionary<int, string> o = new Dictionary<int, string>(dictionary2, comparer2);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(int), typeof(IEqualityComparer<int>)))
			{
				int capacity2;
				LuaObject.checkType(l, 2, out capacity2);
				IEqualityComparer<int> comparer3;
				LuaObject.checkType<IEqualityComparer<int>>(l, 3, out comparer3);
				Dictionary<int, string> o = new Dictionary<int, string>(capacity2, comparer3);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else
			{
				result = LuaObject.error(l, "New object failed.");
			}
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Add(IntPtr l)
	{
		int result;
		try
		{
			Dictionary<int, string> dictionary = (Dictionary<int, string>)LuaObject.checkSelf(l);
			int key;
			LuaObject.checkType(l, 2, out key);
			string value;
			LuaObject.checkType(l, 3, out value);
			dictionary.Add(key, value);
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Clear(IntPtr l)
	{
		int result;
		try
		{
			Dictionary<int, string> dictionary = (Dictionary<int, string>)LuaObject.checkSelf(l);
			dictionary.Clear();
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int ContainsKey(IntPtr l)
	{
		int result;
		try
		{
			Dictionary<int, string> dictionary = (Dictionary<int, string>)LuaObject.checkSelf(l);
			int key;
			LuaObject.checkType(l, 2, out key);
			bool b = dictionary.ContainsKey(key);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, b);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int ContainsValue(IntPtr l)
	{
		int result;
		try
		{
			Dictionary<int, string> dictionary = (Dictionary<int, string>)LuaObject.checkSelf(l);
			string value;
			LuaObject.checkType(l, 2, out value);
			bool b = dictionary.ContainsValue(value);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, b);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetObjectData(IntPtr l)
	{
		int result;
		try
		{
			Dictionary<int, string> dictionary = (Dictionary<int, string>)LuaObject.checkSelf(l);
			SerializationInfo info;
			LuaObject.checkType<SerializationInfo>(l, 2, out info);
			StreamingContext context;
			LuaObject.checkValueType<StreamingContext>(l, 3, out context);
			dictionary.GetObjectData(info, context);
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int OnDeserialization(IntPtr l)
	{
		int result;
		try
		{
			Dictionary<int, string> dictionary = (Dictionary<int, string>)LuaObject.checkSelf(l);
			object sender;
			LuaObject.checkType<object>(l, 2, out sender);
			dictionary.OnDeserialization(sender);
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Remove(IntPtr l)
	{
		int result;
		try
		{
			Dictionary<int, string> dictionary = (Dictionary<int, string>)LuaObject.checkSelf(l);
			int key;
			LuaObject.checkType(l, 2, out key);
			bool b = dictionary.Remove(key);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, b);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int TryGetValue(IntPtr l)
	{
		int result;
		try
		{
			Dictionary<int, string> dictionary = (Dictionary<int, string>)LuaObject.checkSelf(l);
			int key;
			LuaObject.checkType(l, 2, out key);
			string s;
			bool b = dictionary.TryGetValue(key, out s);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, b);
			LuaObject.pushValue(l, s);
			result = 3;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_Count(IntPtr l)
	{
		int result;
		try
		{
			Dictionary<int, string> dictionary = (Dictionary<int, string>)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, dictionary.Count);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_Comparer(IntPtr l)
	{
		int result;
		try
		{
			Dictionary<int, string> dictionary = (Dictionary<int, string>)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, dictionary.Comparer);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_Keys(IntPtr l)
	{
		int result;
		try
		{
			Dictionary<int, string> dictionary = (Dictionary<int, string>)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, dictionary.Keys);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_Values(IntPtr l)
	{
		int result;
		try
		{
			Dictionary<int, string> dictionary = (Dictionary<int, string>)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, dictionary.Values);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int getItem(IntPtr l)
	{
		int result;
		try
		{
			Dictionary<int, string> dictionary = (Dictionary<int, string>)LuaObject.checkSelf(l);
			int key;
			LuaObject.checkType(l, 2, out key);
			string s = dictionary[key];
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, s);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int setItem(IntPtr l)
	{
		int result;
		try
		{
			Dictionary<int, string> dictionary = (Dictionary<int, string>)LuaObject.checkSelf(l);
			int key;
			LuaObject.checkType(l, 2, out key);
			string value;
			LuaObject.checkType(l, 3, out value);
			dictionary[key] = value;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	public static void reg(IntPtr l)
	{
		LuaObject.getTypeTable(l, "DictIntStr");
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_Dictionary_2_int_string.Add));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_Dictionary_2_int_string.Clear));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_Dictionary_2_int_string.ContainsKey));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_Dictionary_2_int_string.ContainsValue));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_Dictionary_2_int_string.GetObjectData));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_Dictionary_2_int_string.OnDeserialization));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_Dictionary_2_int_string.Remove));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_Dictionary_2_int_string.TryGetValue));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_Dictionary_2_int_string.getItem));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_Dictionary_2_int_string.setItem));
		LuaObject.addMember(l, "Count", new LuaCSFunction(Lua_System_Collections_Generic_Dictionary_2_int_string.get_Count), null, true);
		LuaObject.addMember(l, "Comparer", new LuaCSFunction(Lua_System_Collections_Generic_Dictionary_2_int_string.get_Comparer), null, true);
		LuaObject.addMember(l, "Keys", new LuaCSFunction(Lua_System_Collections_Generic_Dictionary_2_int_string.get_Keys), null, true);
		LuaObject.addMember(l, "Values", new LuaCSFunction(Lua_System_Collections_Generic_Dictionary_2_int_string.get_Values), null, true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_System_Collections_Generic_Dictionary_2_int_string.constructor), typeof(Dictionary<int, string>));
	}
}
