using System;
using System.Runtime.InteropServices;

namespace com.tencent.pandora
{
	public class LuaDLLWrapper
	{
		private const string LUADLL = "slua";

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int luaS_objlen(IntPtr luaState, int stackPos);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_isnumber(IntPtr luaState, int index);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_isstring(IntPtr luaState, int index);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_iscfunction(IntPtr luaState, int index);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_toboolean(IntPtr luaState, int index);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void pua_pushboolean(IntPtr luaState, int value);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern void luaS_pushlstring(IntPtr luaState, byte[] str, int size);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int puaL_getmetafield(IntPtr luaState, int stackPos, string field);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int luaLS_loadbuffer(IntPtr luaState, byte[] buff, int size, string name);

		[DllImport("slua", CallingConvention = CallingConvention.Cdecl)]
		public static extern int pua_checkstack(IntPtr luaState, int extra);
	}
}
