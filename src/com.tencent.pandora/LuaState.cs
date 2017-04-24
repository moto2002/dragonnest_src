using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine;

namespace com.tencent.pandora
{
	public class LuaState : IDisposable
	{
		private struct UnrefPair
		{
			public LuaState.UnRefAction act;

			public int r;
		}

		public delegate byte[] LoaderDelegate(string fn);

		public delegate void OutputDelegate(string msg);

		public delegate void UnRefAction(IntPtr l, int r);

		private static readonly char[] DOT = new char[]
		{
			'.'
		};

		private IntPtr l_;

		private int mainThread;

		internal WeakDictionary<int, LuaDelegate> delgateMap = new WeakDictionary<int, LuaDelegate>();

		public static LuaState.LoaderDelegate loaderDelegate;

		public static LuaState.OutputDelegate logDelegate;

		public static LuaState.OutputDelegate errorDelegate;

		private Queue<LuaState.UnrefPair> refQueue;

		public int PCallCSFunctionRef;

		public static LuaState main;

		private static Dictionary<IntPtr, LuaState> statemap = new Dictionary<IntPtr, LuaState>();

		private static IntPtr oldptr = IntPtr.Zero;

		private static LuaState oldstate = null;

		public static LuaCSFunction errorFunc = new LuaCSFunction(LuaState.errorReport);

		public IntPtr L
		{
			get
			{
				if (!this.isMainThread())
				{
					SLogger.LogError("Can't access lua in bg thread");
					throw new Exception("Can't access lua in bg thread");
				}
				if (this.l_ == IntPtr.Zero)
				{
					SLogger.LogError("LuaState had been destroyed, can't used yet");
					throw new Exception("LuaState had been destroyed, can't used yet");
				}
				return this.l_;
			}
			set
			{
				this.l_ = value;
			}
		}

		public IntPtr handle
		{
			get
			{
				return this.L;
			}
		}

		public object this[string path]
		{
			get
			{
				return this.getObject(path);
			}
			set
			{
				this.setObject(path, value);
			}
		}

		public LuaState()
		{
			this.mainThread = Thread.CurrentThread.ManagedThreadId;
			this.L = LuaDLL.puaL_newstate();
			LuaState.statemap[this.L] = this;
			if (LuaState.main == null)
			{
				LuaState.main = this;
			}
			this.refQueue = new Queue<LuaState.UnrefPair>();
			ObjectCache.make(this.L);
			LuaDLL.pua_atpanic(this.L, new LuaCSFunction(LuaState.panicCallback));
			LuaDLL.puaL_openlibs(this.L);
			string chunk = "\r\nlocal assert = assert\r\nlocal function check(ok,...)\r\n\tassert(ok, ...)\r\n\treturn ...\r\nend\r\nreturn function(cs_func)\r\n\treturn function(...)\r\n\t\treturn check(cs_func(...))\r\n\tend\r\nend\r\n";
			LuaDLL.pua_dostring(this.L, chunk);
			this.PCallCSFunctionRef = LuaDLL.puaL_ref(this.L, LuaIndexes.LUA_REGISTRYINDEX);
			LuaState.pcall(this.L, new LuaCSFunction(LuaState.init));
		}

		public bool isMainThread()
		{
			return Thread.CurrentThread.ManagedThreadId == this.mainThread;
		}

		public static LuaState get(IntPtr l)
		{
			if (l == LuaState.oldptr)
			{
				return LuaState.oldstate;
			}
			LuaState result;
			if (LuaState.statemap.TryGetValue(l, out result))
			{
				LuaState.oldptr = l;
				LuaState.oldstate = result;
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
				return LuaState.get(intPtr);
			}
			return null;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int init(IntPtr L)
		{
			LuaDLL.pua_pushlightuserdata(L, L);
			LuaDLL.pua_setglobal(L, "__main_state");
			LuaDLL.pua_pushcfunction(L, new LuaCSFunction(LuaState.print));
			LuaDLL.pua_setglobal(L, "print");
			LuaDLL.pua_pushcfunction(L, new LuaCSFunction(LuaState.pcall));
			LuaDLL.pua_setglobal(L, "pcall");
			LuaState.pushcsfunction(L, new LuaCSFunction(LuaState.include));
			LuaDLL.pua_setglobal(L, "include");
			LuaState.pushcsfunction(L, new LuaCSFunction(LuaState.import));
			LuaDLL.pua_setglobal(L, "import");
			string str = "\r\nlocal resume = coroutine.resume\r\nlocal function check(co, ok, err, ...)\r\n\tif not ok then UnityEngine.Debug.LogError(debug.traceback(co,err)) end\r\n\treturn ok, err, ...\r\nend\r\ncoroutine.resume=function(co,...)\r\n\treturn check(co, resume(co,...))\r\nend\r\n";
			LuaState.get(L).doString(str);
			LuaState.get(L).doString("if jit then require('jit.opt').start('sizemcode=256','maxmcode=256') for i=1,1000 do end end");
			LuaState.pushcsfunction(L, new LuaCSFunction(LuaState.dofile));
			LuaDLL.pua_setglobal(L, "dofile");
			LuaState.pushcsfunction(L, new LuaCSFunction(LuaState.loadfile));
			LuaDLL.pua_setglobal(L, "loadfile");
			LuaState.pushcsfunction(L, new LuaCSFunction(LuaState.loader));
			int index = LuaDLL.pua_gettop(L);
			LuaDLL.pua_getglobal(L, "package");
			LuaDLL.pua_getfield(L, -1, "loaders");
			int num = LuaDLL.pua_gettop(L);
			for (int i = LuaDLL.pua_rawlen(L, num) + 1; i > 2; i--)
			{
				LuaDLL.pua_rawgeti(L, num, i - 1);
				LuaDLL.pua_rawseti(L, num, i);
			}
			LuaDLL.pua_pushvalue(L, index);
			LuaDLL.pua_rawseti(L, num, 2);
			LuaDLL.pua_settop(L, 0);
			return 0;
		}

		public void Close()
		{
			if (this.L != IntPtr.Zero && LuaState.main == this)
			{
				SLogger.Log("Finalizing Lua State.");
				LuaDLL.pua_close(this.L);
				ObjectCache.del(this.L);
				ObjectCache.clear();
				LuaState.statemap.Clear();
				LuaState.oldptr = IntPtr.Zero;
				LuaState.oldstate = null;
				this.L = IntPtr.Zero;
				LuaState.main = null;
			}
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}

		public virtual void Dispose(bool dispose)
		{
			if (dispose)
			{
				this.Close();
			}
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int errorReport(IntPtr L)
		{
			LuaDLL.pua_getglobal(L, "debug");
			LuaDLL.pua_getfield(L, -1, "traceback");
			LuaDLL.pua_pushvalue(L, 1);
			LuaDLL.pua_pushnumber(L, 2.0);
			LuaDLL.pua_call(L, 2, 1);
			LuaDLL.pua_remove(L, -2);
			SLogger.LogError(LuaDLL.pua_tostring(L, -1));
			if (LuaState.errorDelegate != null)
			{
				LuaState.errorDelegate(LuaDLL.pua_tostring(L, -1));
			}
			LuaDLL.pua_pop(L, 1);
			return 0;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		internal static int import(IntPtr l)
		{
			LuaObject.pushValue(l, true);
			return 1;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		internal static int include(IntPtr l)
		{
			int result;
			try
			{
				LuaDLL.puaL_checktype(l, 1, LuaTypes.LUA_TSTRING);
				string text = LuaDLL.pua_tostring(l, 1);
				string[] array = text.Split(LuaState.DOT);
				LuaDLL.pua_pushglobaltable(l);
				for (int i = 0; i < array.Length; i++)
				{
					LuaDLL.pua_getfield(l, -1, array[i]);
					if (!LuaDLL.pua_istable(l, -1))
					{
						result = LuaObject.error(l, "expect {0} is type table", array);
						return result;
					}
					LuaDLL.pua_remove(l, -2);
				}
				LuaDLL.pua_pushnil(l);
				while (LuaDLL.pua_next(l, -2) != 0)
				{
					string text2 = LuaDLL.pua_tostring(l, -2);
					LuaDLL.pua_getglobal(l, text2);
					if (!LuaDLL.pua_isnil(l, -1))
					{
						LuaDLL.pua_pop(l, 1);
						result = LuaObject.error(l, "{0} had existed, import can't overload it.", new object[]
						{
							text2
						});
						return result;
					}
					LuaDLL.pua_pop(l, 1);
					LuaDLL.pua_setglobal(l, text2);
				}
				LuaDLL.pua_pop(l, 1);
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
		internal static int pcall(IntPtr L)
		{
			if (LuaDLL.pua_type(L, 1) != LuaTypes.LUA_TFUNCTION)
			{
				return LuaObject.error(L, "arg 1 expect function");
			}
			LuaDLL.puaL_checktype(L, 1, LuaTypes.LUA_TFUNCTION);
			int num = LuaDLL.pua_pcall(L, LuaDLL.pua_gettop(L) - 1, LuaDLL.LUA_MULTRET, 0);
			LuaDLL.pua_pushboolean(L, num == 0);
			LuaDLL.pua_insert(L, 1);
			return LuaDLL.pua_gettop(L);
		}

		internal static void pcall(IntPtr l, LuaCSFunction f)
		{
			int num = LuaObject.pushTry(l);
			LuaDLL.pua_pushcfunction(l, f);
			if (LuaDLL.pua_pcall(l, 0, 0, num) != 0)
			{
				LuaDLL.pua_pop(l, 1);
			}
			LuaDLL.pua_remove(l, num);
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		internal static int print(IntPtr L)
		{
			int num = LuaDLL.pua_gettop(L);
			string text = string.Empty;
			LuaDLL.pua_getglobal(L, "tostring");
			for (int i = 1; i <= num; i++)
			{
				if (i > 1)
				{
					text += "    ";
				}
				LuaDLL.pua_pushvalue(L, -1);
				LuaDLL.pua_pushvalue(L, i);
				LuaDLL.pua_call(L, 1, 1);
				text += LuaDLL.pua_tostring(L, -1);
				LuaDLL.pua_pop(L, 1);
			}
			LuaDLL.pua_settop(L, num);
			SLogger.Log(text);
			if (LuaState.logDelegate != null)
			{
				LuaState.logDelegate(text);
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		internal static int loadfile(IntPtr L)
		{
			LuaState.loader(L);
			if (LuaDLL.pua_isnil(L, -1))
			{
				string text = LuaDLL.pua_tostring(L, 1);
				return LuaObject.error(L, "Can't find {0}", new object[]
				{
					text
				});
			}
			return 2;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		internal static int dofile(IntPtr L)
		{
			int num = LuaDLL.pua_gettop(L);
			LuaState.loader(L);
			if (!LuaDLL.pua_toboolean(L, -2))
			{
				return 2;
			}
			if (LuaDLL.pua_isnil(L, -1))
			{
				string text = LuaDLL.pua_tostring(L, 1);
				return LuaObject.error(L, "Can't find {0}", new object[]
				{
					text
				});
			}
			int num2 = LuaDLL.pua_gettop(L);
			LuaDLL.pua_call(L, 0, LuaDLL.LUA_MULTRET);
			num2 = LuaDLL.pua_gettop(L);
			return num2 - num;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int panicCallback(IntPtr l)
		{
			string message = string.Format("unprotected error in call to Lua API ({0})", LuaDLL.pua_tostring(l, -1));
			throw new Exception(message);
		}

		public static void pushcsfunction(IntPtr L, LuaCSFunction function)
		{
			LuaDLL.pua_getref(L, LuaState.get(L).PCallCSFunctionRef);
			LuaDLL.pua_pushcclosure(L, function, 0);
			LuaDLL.pua_call(L, 1, 1);
		}

		public object doString(string str)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(str);
			object result;
			if (this.doBuffer(bytes, "temp buffer", out result))
			{
				return result;
			}
			return null;
		}

		public object doString(string str, string chunkname)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(str);
			object result;
			if (this.doBuffer(bytes, chunkname, out result))
			{
				return result;
			}
			return null;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		internal static int loader(IntPtr L)
		{
			string text = LuaDLL.pua_tostring(L, 1);
			byte[] array = LuaState.loadFile(text);
			if (array == null)
			{
				LuaObject.pushValue(L, true);
				LuaDLL.pua_pushnil(L);
				return 2;
			}
			if (LuaDLL.puaL_loadbuffer(L, array, array.Length, "@" + text) == 0)
			{
				LuaObject.pushValue(L, true);
				LuaDLL.pua_insert(L, -2);
				return 2;
			}
			string err = LuaDLL.pua_tostring(L, -1);
			return LuaObject.error(L, err);
		}

		public object doFile(string fn)
		{
			byte[] array = LuaState.loadFile(fn);
			if (array == null)
			{
				SLogger.LogError(string.Format("Can't find {0}", fn));
				return null;
			}
			object result;
			if (this.doBuffer(array, "@" + fn, out result))
			{
				return result;
			}
			return null;
		}

		public static byte[] CleanUTF8Bom(byte[] bytes)
		{
			if (bytes.Length > 3 && bytes[0] == 239 && bytes[1] == 187 && bytes[2] == 191)
			{
				byte[] sourceArray = bytes;
				bytes = new byte[bytes.Length - 3];
				Array.Copy(sourceArray, 3, bytes, 0, bytes.Length);
			}
			return bytes;
		}

		public bool doBuffer(byte[] bytes, string fn, out object ret)
		{
			bytes = LuaState.CleanUTF8Bom(bytes);
			ret = null;
			int num = LuaObject.pushTry(this.L);
			if (LuaDLL.puaL_loadbuffer(this.L, bytes, bytes.Length, fn) != 0)
			{
				string message = LuaDLL.pua_tostring(this.L, -1);
				LuaDLL.pua_pop(this.L, 2);
				throw new Exception(message);
			}
			if (LuaDLL.pua_pcall(this.L, 0, LuaDLL.LUA_MULTRET, num) != 0)
			{
				LuaDLL.pua_pop(this.L, 2);
				return false;
			}
			LuaDLL.pua_remove(this.L, num);
			ret = this.topObjects(num - 1);
			return true;
		}

		internal static byte[] loadFile(string fn)
		{
			byte[] result;
			try
			{
				byte[] array;
				if (LuaState.loaderDelegate != null)
				{
					array = LuaState.loaderDelegate(fn);
				}
				else
				{
					fn = fn.Replace(".", "/");
					TextAsset textAsset = (TextAsset)Resources.Load(fn);
					if (textAsset == null)
					{
						result = null;
						return result;
					}
					array = textAsset.bytes;
				}
				result = array;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return result;
		}

		internal object getObject(string key)
		{
			LuaDLL.pua_pushglobaltable(this.L);
			object @object = this.getObject(key.Split(LuaState.DOT));
			LuaDLL.pua_pop(this.L, 1);
			return @object;
		}

		internal void setObject(string key, object v)
		{
			LuaDLL.pua_pushglobaltable(this.L);
			this.setObject(key.Split(LuaState.DOT), v);
			LuaDLL.pua_pop(this.L, 1);
		}

		internal object getObject(string[] remainingPath)
		{
			object obj = null;
			for (int i = 0; i < remainingPath.Length; i++)
			{
				LuaDLL.pua_pushstring(this.L, remainingPath[i]);
				LuaDLL.pua_gettable(this.L, -2);
				obj = this.getObject(this.L, -1);
				LuaDLL.pua_remove(this.L, -2);
				if (obj == null)
				{
					break;
				}
			}
			return obj;
		}

		internal object getObject(int reference, string field)
		{
			int newTop = LuaDLL.pua_gettop(this.L);
			LuaDLL.pua_getref(this.L, reference);
			object @object = this.getObject(field.Split(LuaState.DOT));
			LuaDLL.pua_settop(this.L, newTop);
			return @object;
		}

		internal object getObject(int reference, int index)
		{
			if (index >= 1)
			{
				int newTop = LuaDLL.pua_gettop(this.L);
				LuaDLL.pua_getref(this.L, reference);
				LuaDLL.pua_rawgeti(this.L, -1, index);
				object @object = this.getObject(this.L, -1);
				LuaDLL.pua_settop(this.L, newTop);
				return @object;
			}
			throw new IndexOutOfRangeException();
		}

		internal object getObject(int reference, object field)
		{
			int newTop = LuaDLL.pua_gettop(this.L);
			LuaDLL.pua_getref(this.L, reference);
			LuaObject.pushObject(this.L, field);
			LuaDLL.pua_gettable(this.L, -2);
			object @object = this.getObject(this.L, -1);
			LuaDLL.pua_settop(this.L, newTop);
			return @object;
		}

		internal void setObject(string[] remainingPath, object o)
		{
			int newTop = LuaDLL.pua_gettop(this.L);
			for (int i = 0; i < remainingPath.Length - 1; i++)
			{
				LuaDLL.pua_pushstring(this.L, remainingPath[i]);
				LuaDLL.pua_gettable(this.L, -2);
			}
			LuaDLL.pua_pushstring(this.L, remainingPath[remainingPath.Length - 1]);
			LuaObject.pushVar(this.L, o);
			LuaDLL.pua_settable(this.L, -3);
			LuaDLL.pua_settop(this.L, newTop);
		}

		internal void setObject(int reference, string field, object o)
		{
			int newTop = LuaDLL.pua_gettop(this.L);
			LuaDLL.pua_getref(this.L, reference);
			this.setObject(field.Split(LuaState.DOT), o);
			LuaDLL.pua_settop(this.L, newTop);
		}

		internal void setObject(int reference, int index, object o)
		{
			if (index >= 1)
			{
				int newTop = LuaDLL.pua_gettop(this.L);
				LuaDLL.pua_getref(this.L, reference);
				LuaObject.pushVar(this.L, o);
				LuaDLL.pua_rawseti(this.L, -2, index);
				LuaDLL.pua_settop(this.L, newTop);
				return;
			}
			throw new IndexOutOfRangeException();
		}

		internal void setObject(int reference, object field, object o)
		{
			int newTop = LuaDLL.pua_gettop(this.L);
			LuaDLL.pua_getref(this.L, reference);
			LuaObject.pushObject(this.L, field);
			LuaObject.pushObject(this.L, o);
			LuaDLL.pua_settable(this.L, -3);
			LuaDLL.pua_settop(this.L, newTop);
		}

		internal object topObjects(int from)
		{
			int num = LuaDLL.pua_gettop(this.L);
			int num2 = num - from;
			if (num2 == 0)
			{
				return null;
			}
			if (num2 == 1)
			{
				object result = LuaObject.checkVar(this.L, num);
				LuaDLL.pua_pop(this.L, 1);
				return result;
			}
			object[] array = new object[num2];
			for (int i = 1; i <= num2; i++)
			{
				array[i - 1] = LuaObject.checkVar(this.L, from + i);
			}
			LuaDLL.pua_settop(this.L, from);
			return array;
		}

		private object getObject(IntPtr l, int p)
		{
			p = LuaDLL.pua_absindex(l, p);
			return LuaObject.checkVar(l, p);
		}

		public LuaFunction getFunction(string key)
		{
			return (LuaFunction)this[key];
		}

		public LuaTable getTable(string key)
		{
			return (LuaTable)this[key];
		}

		public void gcRef(LuaState.UnRefAction act, int r)
		{
			LuaState.UnrefPair item = default(LuaState.UnrefPair);
			item.act = act;
			item.r = r;
			Queue<LuaState.UnrefPair> obj = this.refQueue;
			lock (obj)
			{
				this.refQueue.Enqueue(item);
			}
		}

		public void checkRef()
		{
			int num = 0;
			Queue<LuaState.UnrefPair> obj = this.refQueue;
			lock (obj)
			{
				num = this.refQueue.Count;
			}
			IntPtr l = this.L;
			for (int i = 0; i < num; i++)
			{
				Queue<LuaState.UnrefPair> obj2 = this.refQueue;
				LuaState.UnrefPair unrefPair;
				lock (obj2)
				{
					unrefPair = this.refQueue.Dequeue();
				}
				unrefPair.act(l, unrefPair.r);
			}
		}
	}
}
