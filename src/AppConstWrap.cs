using LuaInterface;
using System;

public class AppConstWrap
{
	private static Type classType = typeof(AppConst);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", new LuaCSFunction(AppConstWrap._CreateAppConst)),
			new LuaMethod("GetClassType", new LuaCSFunction(AppConstWrap.GetClassType))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("UsePbc", new LuaCSFunction(AppConstWrap.get_UsePbc), null),
			new LuaField("UseLpeg", new LuaCSFunction(AppConstWrap.get_UseLpeg), null),
			new LuaField("UsePbLua", new LuaCSFunction(AppConstWrap.get_UsePbLua), null),
			new LuaField("UseCJson", new LuaCSFunction(AppConstWrap.get_UseCJson), null),
			new LuaField("UseSproto", new LuaCSFunction(AppConstWrap.get_UseSproto), null),
			new LuaField("AutoWrapMode", new LuaCSFunction(AppConstWrap.get_AutoWrapMode), null),
			new LuaField("uLuaPath", new LuaCSFunction(AppConstWrap.get_uLuaPath), null)
		};
		LuaScriptMgr.RegisterLib(L, "AppConst", typeof(AppConst), regs, fields, typeof(object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateAppConst(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			AppConst o = new AppConst();
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: AppConst.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConstWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_UsePbc(IntPtr L)
	{
		LuaScriptMgr.Push(L, true);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_UseLpeg(IntPtr L)
	{
		LuaScriptMgr.Push(L, true);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_UsePbLua(IntPtr L)
	{
		LuaScriptMgr.Push(L, true);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_UseCJson(IntPtr L)
	{
		LuaScriptMgr.Push(L, true);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_UseSproto(IntPtr L)
	{
		LuaScriptMgr.Push(L, true);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_AutoWrapMode(IntPtr L)
	{
		LuaScriptMgr.Push(L, true);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_uLuaPath(IntPtr L)
	{
		LuaScriptMgr.Push(L, AppConst.uLuaPath);
		return 1;
	}
}
