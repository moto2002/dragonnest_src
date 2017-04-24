using System;
using System.Runtime.InteropServices;

namespace com.tencent.pandora
{
	public class LuaDLL
	{
		private const string LUADLL = "slua";

		public static int LUA_MULTRET = -1;

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void luaS_openextlibs(IntPtr L);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_tothread(IntPtr L, int index);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_xmove(IntPtr from, IntPtr to, int n);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr pua_newthread(IntPtr L);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_status(IntPtr L);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_pushthread(IntPtr L);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_gc(IntPtr luaState, LuaGCOptions what, int data);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr pua_typename(IntPtr luaState, int type);

		public static string pua_typenamestr(IntPtr luaState, LuaTypes type)
		{
			IntPtr ptr = LuaDLL.pua_typename(luaState, (int)type);
			return Marshal.PtrToStringAnsi(ptr);
		}

		public static string puaL_typename(IntPtr luaState, int stackPos)
		{
			return LuaDLL.pua_typenamestr(luaState, LuaDLL.pua_type(luaState, stackPos));
		}

		public static bool pua_isfunction(IntPtr luaState, int stackPos)
		{
			return LuaDLL.pua_type(luaState, stackPos) == LuaTypes.LUA_TFUNCTION;
		}

		public static bool pua_islightuserdata(IntPtr luaState, int stackPos)
		{
			return LuaDLL.pua_type(luaState, stackPos) == LuaTypes.LUA_TLIGHTUSERDATA;
		}

		public static bool pua_istable(IntPtr luaState, int stackPos)
		{
			return LuaDLL.pua_type(luaState, stackPos) == LuaTypes.LUA_TTABLE;
		}

		public static bool pua_isthread(IntPtr luaState, int stackPos)
		{
			return LuaDLL.pua_type(luaState, stackPos) == LuaTypes.LUA_TTHREAD;
		}

		[Obsolete]
		public static void puaL_error(IntPtr luaState, string message)
		{
		}

		[Obsolete]
		public static void puaL_error(IntPtr luaState, string fmt, params object[] args)
		{
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern string puaL_gsub(IntPtr luaState, string str, string pattern, string replacement);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_isuserdata(IntPtr luaState, int stackPos);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_rawequal(IntPtr luaState, int stackPos1, int stackPos2);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_setfield(IntPtr luaState, int stackPos, string name);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int puaL_callmeta(IntPtr luaState, int stackPos, string name);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr puaL_newstate();

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_close(IntPtr luaState);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void puaL_openlibs(IntPtr luaState);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int puaL_loadstring(IntPtr luaState, string chunk);

		public static int puaL_dostring(IntPtr luaState, string chunk)
		{
			int num = LuaDLL.puaL_loadstring(luaState, chunk);
			if (num != 0)
			{
				return num;
			}
			return LuaDLL.pua_pcall(luaState, 0, -1, 0);
		}

		public static int pua_dostring(IntPtr luaState, string chunk)
		{
			return LuaDLL.puaL_dostring(luaState, chunk);
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_createtable(IntPtr luaState, int narr, int nrec);

		public static void pua_newtable(IntPtr luaState)
		{
			LuaDLL.pua_createtable(luaState, 0, 0);
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_resume(IntPtr L, int narg);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_lessthan(IntPtr luaState, int stackPos1, int stackPos2);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_getfenv(IntPtr luaState, int stackPos);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_yield(IntPtr L, int nresults);

		public static void pua_getglobal(IntPtr luaState, string name)
		{
			LuaDLL.pua_pushstring(luaState, name);
			LuaDLL.pua_gettable(luaState, LuaIndexes.LUA_GLOBALSINDEX);
		}

		public static void pua_setglobal(IntPtr luaState, string name)
		{
			LuaDLL.pua_pushstring(luaState, name);
			LuaDLL.pua_insert(luaState, -2);
			LuaDLL.pua_settable(luaState, LuaIndexes.LUA_GLOBALSINDEX);
		}

		public static void pua_pushglobaltable(IntPtr l)
		{
			LuaDLL.pua_pushvalue(l, LuaIndexes.LUA_GLOBALSINDEX);
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_insert(IntPtr luaState, int newTop);

		public static int pua_rawlen(IntPtr luaState, int stackPos)
		{
			return LuaDLLWrapper.luaS_objlen(luaState, stackPos);
		}

		public static int pua_strlen(IntPtr luaState, int stackPos)
		{
			return LuaDLL.pua_rawlen(luaState, stackPos);
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_call(IntPtr luaState, int nArgs, int nResults);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_pcall(IntPtr luaState, int nArgs, int nResults, int errfunc);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern double pua_tonumber(IntPtr luaState, int index);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_tointeger(IntPtr luaState, int index);

		public static int puaL_loadbuffer(IntPtr luaState, byte[] buff, int size, string name)
		{
			return LuaDLLWrapper.luaLS_loadbuffer(luaState, buff, size, name);
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_remove(IntPtr luaState, int index);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_rawgeti(IntPtr luaState, int tableIndex, int index);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_rawseti(IntPtr luaState, int tableIndex, int index);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_pushinteger(IntPtr luaState, IntPtr i);

		public static void pua_pushinteger(IntPtr luaState, int i)
		{
			LuaDLL.pua_pushinteger(luaState, (IntPtr)i);
		}

		public static int puaL_checkinteger(IntPtr luaState, int stackPos)
		{
			LuaDLL.puaL_checktype(luaState, stackPos, LuaTypes.LUA_TNUMBER);
			return LuaDLL.pua_tointeger(luaState, stackPos);
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_replace(IntPtr luaState, int index);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_setfenv(IntPtr luaState, int stackPos);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_equal(IntPtr luaState, int index1, int index2);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int puaL_loadfile(IntPtr luaState, string filename);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_settop(IntPtr luaState, int newTop);

		public static void pua_pop(IntPtr luaState, int amount)
		{
			LuaDLL.pua_settop(luaState, -amount - 1);
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_gettable(IntPtr luaState, int index);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_rawget(IntPtr luaState, int index);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_settable(IntPtr luaState, int index);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_rawset(IntPtr luaState, int index);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_setmetatable(IntPtr luaState, int objIndex);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_getmetatable(IntPtr luaState, int objIndex);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_pushvalue(IntPtr luaState, int index);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_gettop(IntPtr luaState);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern LuaTypes pua_type(IntPtr luaState, int index);

		public static bool pua_isnil(IntPtr luaState, int index)
		{
			return LuaDLL.pua_type(luaState, index) == LuaTypes.LUA_TNIL;
		}

		public static bool pua_isnumber(IntPtr luaState, int index)
		{
			return LuaDLLWrapper.pua_isnumber(luaState, index) > 0;
		}

		public static bool pua_isboolean(IntPtr luaState, int index)
		{
			return LuaDLL.pua_type(luaState, index) == LuaTypes.LUA_TBOOLEAN;
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int puaL_ref(IntPtr luaState, int registryIndex);

		public static void pua_getref(IntPtr luaState, int reference)
		{
			LuaDLL.pua_rawgeti(luaState, LuaIndexes.LUA_REGISTRYINDEX, reference);
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void puaL_unref(IntPtr luaState, int registryIndex, int reference);

		public static void pua_unref(IntPtr luaState, int reference)
		{
			LuaDLL.puaL_unref(luaState, LuaIndexes.LUA_REGISTRYINDEX, reference);
		}

		public static bool pua_isstring(IntPtr luaState, int index)
		{
			return LuaDLLWrapper.pua_isstring(luaState, index) > 0;
		}

		public static bool pua_iscfunction(IntPtr luaState, int index)
		{
			return LuaDLLWrapper.pua_iscfunction(luaState, index) > 0;
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_pushnil(IntPtr luaState);

		public static void puaL_checktype(IntPtr luaState, int p, LuaTypes t)
		{
			LuaTypes luaTypes = LuaDLL.pua_type(luaState, p);
			if (luaTypes != t)
			{
				throw new Exception(string.Format("arg {0} expect {1}, got {2}", p, LuaDLL.pua_typenamestr(luaState, t), LuaDLL.pua_typenamestr(luaState, luaTypes)));
			}
		}

		public static void pua_pushcfunction(IntPtr luaState, LuaCSFunction function)
		{
			IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(function);
			LuaDLL.pua_pushcclosure(luaState, functionPointerForDelegate, 0);
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr pua_tocfunction(IntPtr luaState, int index);

		public static bool pua_toboolean(IntPtr luaState, int index)
		{
			return LuaDLLWrapper.pua_toboolean(luaState, index) > 0;
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr luaS_tolstring32(IntPtr luaState, int index, out int strLen);

		public static string pua_tostring(IntPtr luaState, int index)
		{
			int len;
			IntPtr intPtr = LuaDLL.luaS_tolstring32(luaState, index, out len);
			if (intPtr != IntPtr.Zero)
			{
				return Marshal.PtrToStringAnsi(intPtr, len);
			}
			return null;
		}

		public static byte[] pua_tobytes(IntPtr luaState, int index)
		{
			int num;
			IntPtr intPtr = LuaDLL.luaS_tolstring32(luaState, index, out num);
			if (intPtr != IntPtr.Zero)
			{
				byte[] array = new byte[num];
				Marshal.Copy(intPtr, array, 0, num);
				return array;
			}
			return null;
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr pua_atpanic(IntPtr luaState, LuaCSFunction panicf);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_pushnumber(IntPtr luaState, double number);

		public static void pua_pushboolean(IntPtr luaState, bool value)
		{
			LuaDLLWrapper.pua_pushboolean(luaState, (!value) ? 0 : 1);
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_pushstring(IntPtr luaState, string str);

		public static void pua_pushlstring(IntPtr luaState, byte[] str, int size)
		{
			LuaDLLWrapper.luaS_pushlstring(luaState, str, size);
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int puaL_newmetatable(IntPtr luaState, string meta);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_getfield(IntPtr luaState, int stackPos, string meta);

		public static void puaL_getmetatable(IntPtr luaState, string meta)
		{
			LuaDLL.pua_getfield(luaState, LuaIndexes.LUA_REGISTRYINDEX, meta);
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr puaL_checkudata(IntPtr luaState, int stackPos, string meta);

		public static bool puaL_getmetafield(IntPtr luaState, int stackPos, string field)
		{
			return LuaDLLWrapper.puaL_getmetafield(luaState, stackPos, field) > 0;
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_load(IntPtr luaState, LuaChunkReader chunkReader, ref ReaderInfo data, string chunkName);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_error(IntPtr luaState);

		public static bool pua_checkstack(IntPtr luaState, int extra)
		{
			return LuaDLLWrapper.pua_checkstack(luaState, extra) > 0;
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_next(IntPtr luaState, int index);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_pushlightuserdata(IntPtr luaState, IntPtr udata);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void puaL_where(IntPtr luaState, int level);

		public static double puaL_checknumber(IntPtr luaState, int stackPos)
		{
			LuaDLL.puaL_checktype(luaState, stackPos, LuaTypes.LUA_TNUMBER);
			return LuaDLL.pua_tonumber(luaState, stackPos);
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_concat(IntPtr luaState, int n);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void luaS_newuserdata(IntPtr luaState, int val);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int luaS_rawnetobj(IntPtr luaState, int obj);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr pua_touserdata(IntPtr luaState, int index);

		public static int pua_absindex(IntPtr luaState, int index)
		{
			return (index <= 0) ? (LuaDLL.pua_gettop(luaState) + index + 1) : index;
		}

		public static int pua_upvalueindex(int i)
		{
			return LuaIndexes.LUA_GLOBALSINDEX - i;
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_pushcclosure(IntPtr l, IntPtr f, int nup);

		public static void pua_pushcclosure(IntPtr l, LuaCSFunction f, int nup)
		{
			IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(f);
			LuaDLL.pua_pushcclosure(l, functionPointerForDelegate, nup);
		}

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int luaS_checkVector2(IntPtr l, int p, out float x, out float y);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int luaS_checkVector3(IntPtr l, int p, out float x, out float y, out float z);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int luaS_checkVector4(IntPtr l, int p, out float x, out float y, out float z, out float w);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int luaS_checkQuaternion(IntPtr l, int p, out float x, out float y, out float z, out float w);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int luaS_checkColor(IntPtr l, int p, out float x, out float y, out float z, out float w);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void luaS_pushVector2(IntPtr l, float x, float y);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void luaS_pushVector3(IntPtr l, float x, float y, float z);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void luaS_pushVector4(IntPtr l, float x, float y, float z, float w);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void luaS_pushQuaternion(IntPtr l, float x, float y, float z, float w);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void luaS_pushColor(IntPtr l, float x, float y, float z, float w);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void luaS_setDataVec(IntPtr l, int p, float x, float y, float z, float w);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int luaS_checkluatype(IntPtr l, int p, string t);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int luaS_pushobject(IntPtr l, int index, string t, bool gco, int cref);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int luaS_getcacheud(IntPtr l, int index, int cref);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int luaS_subclassof(IntPtr l, int index, string t);
	}
}
