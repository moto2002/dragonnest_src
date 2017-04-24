using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace com.tencent.pandora
{
	public class ObjectCache
	{
		private class ObjSlot
		{
			public int freeslot;

			public object v;

			public ObjSlot(int slot, object o)
			{
				this.freeslot = slot;
				this.v = o;
			}
		}

		private class FreeList : Dictionary<int, object>
		{
			private int id = 1;

			public int add(object o)
			{
				this.Add(this.id, o);
				return this.id++;
			}

			public void del(int i)
			{
				this.Remove(i);
			}

			public bool get(int i, out object o)
			{
				return this.TryGetValue(i, out o);
			}

			public object get(int i)
			{
				object result;
				if (this.TryGetValue(i, out result))
				{
					return result;
				}
				return null;
			}

			public void set(int i, object o)
			{
				this[i] = o;
			}
		}

		public class ObjEqualityComparer : IEqualityComparer<object>
		{
			public new bool Equals(object x, object y)
			{
				return object.ReferenceEquals(x, y);
			}

			public int GetHashCode(object obj)
			{
				return RuntimeHelpers.GetHashCode(obj);
			}
		}

		private static Dictionary<IntPtr, ObjectCache> multiState = new Dictionary<IntPtr, ObjectCache>();

		private static IntPtr oldl = IntPtr.Zero;

		internal static ObjectCache oldoc = null;

		private ObjectCache.FreeList cache = new ObjectCache.FreeList();

		private Dictionary<object, int> objMap = new Dictionary<object, int>(new ObjectCache.ObjEqualityComparer());

		private int udCacheRef;

		private static Dictionary<Type, string> aqnameMap = new Dictionary<Type, string>();

		public ObjectCache(IntPtr l)
		{
			LuaDLL.pua_newtable(l);
			LuaDLL.pua_newtable(l);
			LuaDLL.pua_pushstring(l, "v");
			LuaDLL.pua_setfield(l, -2, "__mode");
			LuaDLL.pua_setmetatable(l, -2);
			this.udCacheRef = LuaDLL.puaL_ref(l, LuaIndexes.LUA_REGISTRYINDEX);
		}

		public static ObjectCache get(IntPtr l)
		{
			if (ObjectCache.oldl == l)
			{
				return ObjectCache.oldoc;
			}
			ObjectCache result;
			if (ObjectCache.multiState.TryGetValue(l, out result))
			{
				ObjectCache.oldl = l;
				ObjectCache.oldoc = result;
				return result;
			}
			LuaDLL.pua_getglobal(l, "__main_state");
			if (LuaDLL.pua_isnil(l, -1))
			{
				LuaDLL.pua_pop(l, 1);
				return null;
			}
			IntPtr intPtr = LuaDLL.pua_touserdata(l, -1);
			LuaDLL.pua_pop(l, 1);
			if (intPtr != l)
			{
				return ObjectCache.get(intPtr);
			}
			return null;
		}

		public static void clear()
		{
			ObjectCache.oldl = IntPtr.Zero;
			ObjectCache.oldoc = null;
		}

		internal static void del(IntPtr l)
		{
			ObjectCache.multiState.Remove(l);
		}

		internal static void make(IntPtr l)
		{
			ObjectCache value = new ObjectCache(l);
			ObjectCache.multiState[l] = value;
			ObjectCache.oldl = l;
			ObjectCache.oldoc = value;
		}

		internal void gc(int index)
		{
			object obj;
			if (this.cache.get(index, out obj))
			{
				int num;
				if (this.isGcObject(obj) && this.objMap.TryGetValue(obj, out num) && num == index)
				{
					this.objMap.Remove(obj);
				}
				this.cache.del(index);
			}
		}

		internal void gc(UnityEngine.Object o)
		{
			int i;
			if (this.objMap.TryGetValue(o, out i))
			{
				this.objMap.Remove(o);
				this.cache.del(i);
			}
		}

		internal int add(object o)
		{
			int num = this.cache.add(o);
			if (this.isGcObject(o))
			{
				this.objMap[o] = num;
			}
			return num;
		}

		internal object get(IntPtr l, int p)
		{
			int num = LuaDLL.luaS_rawnetobj(l, p);
			object result;
			if (num != -1 && this.cache.get(num, out result))
			{
				return result;
			}
			return null;
		}

		internal void setBack(IntPtr l, int p, object o)
		{
			int num = LuaDLL.luaS_rawnetobj(l, p);
			if (num != -1)
			{
				this.cache.set(num, o);
			}
		}

		internal void push(IntPtr l, object o)
		{
			this.push(l, o, true, false);
		}

		internal void push(IntPtr l, Array o)
		{
			this.push(l, o, true, true);
		}

		internal void push(IntPtr l, object o, bool checkReflect, bool isArray = false)
		{
			if (o == null)
			{
				LuaDLL.pua_pushnil(l);
				return;
			}
			int index = -1;
			bool flag = this.isGcObject(o);
			bool flag2 = flag && this.objMap.TryGetValue(o, out index);
			if (flag2 && LuaDLL.luaS_getcacheud(l, index, this.udCacheRef) == 1)
			{
				return;
			}
			index = this.add(o);
			LuaDLL.luaS_pushobject(l, index, (!isArray) ? ObjectCache.getAQName(o) : "LuaArray", flag, this.udCacheRef);
		}

		private static string getAQName(object o)
		{
			Type type = o.GetType();
			return ObjectCache.getAQName(type);
		}

		internal static string getAQName(Type t)
		{
			string assemblyQualifiedName;
			if (ObjectCache.aqnameMap.TryGetValue(t, out assemblyQualifiedName))
			{
				return assemblyQualifiedName;
			}
			assemblyQualifiedName = t.AssemblyQualifiedName;
			ObjectCache.aqnameMap[t] = assemblyQualifiedName;
			return assemblyQualifiedName;
		}

		private bool isGcObject(object obj)
		{
			return !obj.GetType().IsValueType;
		}
	}
}
