using com.tencent.pandora;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Lua_System_Collections_Generic_List_1_int : LuaObject
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
				List<int> o = new List<int>();
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(IEnumerable<int>)))
			{
				IEnumerable<int> collection;
				LuaObject.checkType<IEnumerable<int>>(l, 2, out collection);
				List<int> o = new List<int>(collection);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(int)))
			{
				int capacity;
				LuaObject.checkType(l, 2, out capacity);
				List<int> o = new List<int>(capacity);
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
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			int item;
			LuaObject.checkType(l, 2, out item);
			list.Add(item);
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
	public static int AddRange(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			IEnumerable<int> collection;
			LuaObject.checkType<IEnumerable<int>>(l, 2, out collection);
			list.AddRange(collection);
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
	public static int AsReadOnly(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			ReadOnlyCollection<int> o = list.AsReadOnly();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, o);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int BinarySearch(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				List<int> list = (List<int>)LuaObject.checkSelf(l);
				int item;
				LuaObject.checkType(l, 2, out item);
				int i = list.BinarySearch(item);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, i);
				result = 2;
			}
			else if (num == 3)
			{
				List<int> list2 = (List<int>)LuaObject.checkSelf(l);
				int item2;
				LuaObject.checkType(l, 2, out item2);
				IComparer<int> comparer;
				LuaObject.checkType<IComparer<int>>(l, 3, out comparer);
				int i2 = list2.BinarySearch(item2, comparer);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, i2);
				result = 2;
			}
			else if (num == 5)
			{
				List<int> list3 = (List<int>)LuaObject.checkSelf(l);
				int index;
				LuaObject.checkType(l, 2, out index);
				int count;
				LuaObject.checkType(l, 3, out count);
				int item3;
				LuaObject.checkType(l, 4, out item3);
				IComparer<int> comparer2;
				LuaObject.checkType<IComparer<int>>(l, 5, out comparer2);
				int i3 = list3.BinarySearch(index, count, item3, comparer2);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, i3);
				result = 2;
			}
			else
			{
				LuaObject.pushValue(l, false);
				LuaDLL.pua_pushstring(l, "No matched override function to call");
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
	public static int Clear(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			list.Clear();
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
	public static int Contains(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			int item;
			LuaObject.checkType(l, 2, out item);
			bool b = list.Contains(item);
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
	public static int Exists(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			Predicate<int> match;
			LuaDelegation.checkDelegate(l, 2, out match);
			bool b = list.Exists(match);
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
	public static int Find(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			Predicate<int> match;
			LuaDelegation.checkDelegate(l, 2, out match);
			int i = list.Find(match);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, i);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int FindAll(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			Predicate<int> match;
			LuaDelegation.checkDelegate(l, 2, out match);
			List<int> o = list.FindAll(match);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, o);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int FindIndex(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				List<int> list = (List<int>)LuaObject.checkSelf(l);
				Predicate<int> match;
				LuaDelegation.checkDelegate(l, 2, out match);
				int i = list.FindIndex(match);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, i);
				result = 2;
			}
			else if (num == 3)
			{
				List<int> list2 = (List<int>)LuaObject.checkSelf(l);
				int startIndex;
				LuaObject.checkType(l, 2, out startIndex);
				Predicate<int> match2;
				LuaDelegation.checkDelegate(l, 3, out match2);
				int i2 = list2.FindIndex(startIndex, match2);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, i2);
				result = 2;
			}
			else if (num == 4)
			{
				List<int> list3 = (List<int>)LuaObject.checkSelf(l);
				int startIndex2;
				LuaObject.checkType(l, 2, out startIndex2);
				int count;
				LuaObject.checkType(l, 3, out count);
				Predicate<int> match3;
				LuaDelegation.checkDelegate(l, 4, out match3);
				int i3 = list3.FindIndex(startIndex2, count, match3);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, i3);
				result = 2;
			}
			else
			{
				LuaObject.pushValue(l, false);
				LuaDLL.pua_pushstring(l, "No matched override function to call");
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
	public static int FindLast(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			Predicate<int> match;
			LuaDelegation.checkDelegate(l, 2, out match);
			int i = list.FindLast(match);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, i);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int FindLastIndex(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				List<int> list = (List<int>)LuaObject.checkSelf(l);
				Predicate<int> match;
				LuaDelegation.checkDelegate(l, 2, out match);
				int i = list.FindLastIndex(match);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, i);
				result = 2;
			}
			else if (num == 3)
			{
				List<int> list2 = (List<int>)LuaObject.checkSelf(l);
				int startIndex;
				LuaObject.checkType(l, 2, out startIndex);
				Predicate<int> match2;
				LuaDelegation.checkDelegate(l, 3, out match2);
				int i2 = list2.FindLastIndex(startIndex, match2);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, i2);
				result = 2;
			}
			else if (num == 4)
			{
				List<int> list3 = (List<int>)LuaObject.checkSelf(l);
				int startIndex2;
				LuaObject.checkType(l, 2, out startIndex2);
				int count;
				LuaObject.checkType(l, 3, out count);
				Predicate<int> match3;
				LuaDelegation.checkDelegate(l, 4, out match3);
				int i3 = list3.FindLastIndex(startIndex2, count, match3);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, i3);
				result = 2;
			}
			else
			{
				LuaObject.pushValue(l, false);
				LuaDLL.pua_pushstring(l, "No matched override function to call");
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
	public static int ForEach(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			Action<int> action;
			LuaDelegation.checkDelegate(l, 2, out action);
			list.ForEach(action);
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
	public static int GetRange(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			int index;
			LuaObject.checkType(l, 2, out index);
			int count;
			LuaObject.checkType(l, 3, out count);
			List<int> range = list.GetRange(index, count);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, range);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int IndexOf(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				List<int> list = (List<int>)LuaObject.checkSelf(l);
				int item;
				LuaObject.checkType(l, 2, out item);
				int i = list.IndexOf(item);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, i);
				result = 2;
			}
			else if (num == 3)
			{
				List<int> list2 = (List<int>)LuaObject.checkSelf(l);
				int item2;
				LuaObject.checkType(l, 2, out item2);
				int index;
				LuaObject.checkType(l, 3, out index);
				int i2 = list2.IndexOf(item2, index);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, i2);
				result = 2;
			}
			else if (num == 4)
			{
				List<int> list3 = (List<int>)LuaObject.checkSelf(l);
				int item3;
				LuaObject.checkType(l, 2, out item3);
				int index2;
				LuaObject.checkType(l, 3, out index2);
				int count;
				LuaObject.checkType(l, 4, out count);
				int i3 = list3.IndexOf(item3, index2, count);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, i3);
				result = 2;
			}
			else
			{
				LuaObject.pushValue(l, false);
				LuaDLL.pua_pushstring(l, "No matched override function to call");
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
	public static int Insert(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			int index;
			LuaObject.checkType(l, 2, out index);
			int item;
			LuaObject.checkType(l, 3, out item);
			list.Insert(index, item);
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
	public static int InsertRange(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			int index;
			LuaObject.checkType(l, 2, out index);
			IEnumerable<int> collection;
			LuaObject.checkType<IEnumerable<int>>(l, 3, out collection);
			list.InsertRange(index, collection);
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
	public static int LastIndexOf(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 2)
			{
				List<int> list = (List<int>)LuaObject.checkSelf(l);
				int item;
				LuaObject.checkType(l, 2, out item);
				int i = list.LastIndexOf(item);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, i);
				result = 2;
			}
			else if (num == 3)
			{
				List<int> list2 = (List<int>)LuaObject.checkSelf(l);
				int item2;
				LuaObject.checkType(l, 2, out item2);
				int index;
				LuaObject.checkType(l, 3, out index);
				int i2 = list2.LastIndexOf(item2, index);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, i2);
				result = 2;
			}
			else if (num == 4)
			{
				List<int> list3 = (List<int>)LuaObject.checkSelf(l);
				int item3;
				LuaObject.checkType(l, 2, out item3);
				int index2;
				LuaObject.checkType(l, 3, out index2);
				int count;
				LuaObject.checkType(l, 4, out count);
				int i3 = list3.LastIndexOf(item3, index2, count);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, i3);
				result = 2;
			}
			else
			{
				LuaObject.pushValue(l, false);
				LuaDLL.pua_pushstring(l, "No matched override function to call");
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
	public static int Remove(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			int item;
			LuaObject.checkType(l, 2, out item);
			bool b = list.Remove(item);
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
	public static int RemoveAll(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			Predicate<int> match;
			LuaDelegation.checkDelegate(l, 2, out match);
			int i = list.RemoveAll(match);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, i);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int RemoveAt(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			int index;
			LuaObject.checkType(l, 2, out index);
			list.RemoveAt(index);
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
	public static int RemoveRange(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			int index;
			LuaObject.checkType(l, 2, out index);
			int count;
			LuaObject.checkType(l, 3, out count);
			list.RemoveRange(index, count);
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
	public static int Reverse(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				List<int> list = (List<int>)LuaObject.checkSelf(l);
				list.Reverse();
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 3)
			{
				List<int> list2 = (List<int>)LuaObject.checkSelf(l);
				int index;
				LuaObject.checkType(l, 2, out index);
				int count;
				LuaObject.checkType(l, 3, out count);
				list2.Reverse(index, count);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else
			{
				LuaObject.pushValue(l, false);
				LuaDLL.pua_pushstring(l, "No matched override function to call");
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
	public static int Sort(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				List<int> list = (List<int>)LuaObject.checkSelf(l);
				list.Sort();
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(Comparison<int>)))
			{
				List<int> list2 = (List<int>)LuaObject.checkSelf(l);
				Comparison<int> comparison;
				LuaDelegation.checkDelegate(l, 2, out comparison);
				list2.Sort(comparison);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (LuaObject.matchType(l, num, 2, typeof(IComparer<int>)))
			{
				List<int> list3 = (List<int>)LuaObject.checkSelf(l);
				IComparer<int> comparer;
				LuaObject.checkType<IComparer<int>>(l, 2, out comparer);
				list3.Sort(comparer);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 4)
			{
				List<int> list4 = (List<int>)LuaObject.checkSelf(l);
				int index;
				LuaObject.checkType(l, 2, out index);
				int count;
				LuaObject.checkType(l, 3, out count);
				IComparer<int> comparer2;
				LuaObject.checkType<IComparer<int>>(l, 4, out comparer2);
				list4.Sort(index, count, comparer2);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else
			{
				LuaObject.pushValue(l, false);
				LuaDLL.pua_pushstring(l, "No matched override function to call");
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
	public static int ToArray(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			int[] a = list.ToArray();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, a);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int TrimExcess(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			list.TrimExcess();
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
	public static int TrueForAll(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			Predicate<int> match;
			LuaDelegation.checkDelegate(l, 2, out match);
			bool b = list.TrueForAll(match);
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
	public static int get_Capacity(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, list.Capacity);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_Capacity(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			int capacity;
			LuaObject.checkType(l, 2, out capacity);
			list.Capacity = capacity;
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
	public static int get_Count(IntPtr l)
	{
		int result;
		try
		{
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, list.Count);
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
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			int index;
			LuaObject.checkType(l, 2, out index);
			int i = list[index];
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, i);
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
			List<int> list = (List<int>)LuaObject.checkSelf(l);
			int index;
			LuaObject.checkType(l, 2, out index);
			int value;
			LuaObject.checkType(l, 3, out value);
			list[index] = value;
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
		LuaObject.getTypeTable(l, "ListInt");
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.Add));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.AddRange));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.AsReadOnly));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.BinarySearch));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.Clear));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.Contains));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.Exists));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.Find));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.FindAll));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.FindIndex));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.FindLast));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.FindLastIndex));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.ForEach));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.GetRange));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.IndexOf));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.Insert));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.InsertRange));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.LastIndexOf));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.Remove));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.RemoveAll));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.RemoveAt));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.RemoveRange));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.Reverse));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.Sort));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.ToArray));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.TrimExcess));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.TrueForAll));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.getItem));
		LuaObject.addMember(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.setItem));
		LuaObject.addMember(l, "Capacity", new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.get_Capacity), new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.set_Capacity), true);
		LuaObject.addMember(l, "Count", new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.get_Count), null, true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_System_Collections_Generic_List_1_int.constructor), typeof(List<int>));
	}
}
