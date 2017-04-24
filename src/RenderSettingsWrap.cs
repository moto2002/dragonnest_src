using LuaInterface;
using System;
using UnityEngine;

public class RenderSettingsWrap
{
	private static Type classType = typeof(RenderSettings);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", new LuaCSFunction(RenderSettingsWrap._CreateRenderSettings)),
			new LuaMethod("GetClassType", new LuaCSFunction(RenderSettingsWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(RenderSettingsWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("fog", new LuaCSFunction(RenderSettingsWrap.get_fog), new LuaCSFunction(RenderSettingsWrap.set_fog)),
			new LuaField("fogMode", new LuaCSFunction(RenderSettingsWrap.get_fogMode), new LuaCSFunction(RenderSettingsWrap.set_fogMode)),
			new LuaField("fogColor", new LuaCSFunction(RenderSettingsWrap.get_fogColor), new LuaCSFunction(RenderSettingsWrap.set_fogColor)),
			new LuaField("fogDensity", new LuaCSFunction(RenderSettingsWrap.get_fogDensity), new LuaCSFunction(RenderSettingsWrap.set_fogDensity)),
			new LuaField("fogStartDistance", new LuaCSFunction(RenderSettingsWrap.get_fogStartDistance), new LuaCSFunction(RenderSettingsWrap.set_fogStartDistance)),
			new LuaField("fogEndDistance", new LuaCSFunction(RenderSettingsWrap.get_fogEndDistance), new LuaCSFunction(RenderSettingsWrap.set_fogEndDistance)),
			new LuaField("ambientLight", new LuaCSFunction(RenderSettingsWrap.get_ambientLight), new LuaCSFunction(RenderSettingsWrap.set_ambientLight)),
			new LuaField("haloStrength", new LuaCSFunction(RenderSettingsWrap.get_haloStrength), new LuaCSFunction(RenderSettingsWrap.set_haloStrength)),
			new LuaField("flareStrength", new LuaCSFunction(RenderSettingsWrap.get_flareStrength), new LuaCSFunction(RenderSettingsWrap.set_flareStrength)),
			new LuaField("flareFadeSpeed", new LuaCSFunction(RenderSettingsWrap.get_flareFadeSpeed), new LuaCSFunction(RenderSettingsWrap.set_flareFadeSpeed)),
			new LuaField("skybox", new LuaCSFunction(RenderSettingsWrap.get_skybox), new LuaCSFunction(RenderSettingsWrap.set_skybox))
		};
		LuaScriptMgr.RegisterLib(L, "UnityEngine.RenderSettings", typeof(RenderSettings), regs, fields, typeof(UnityEngine.Object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateRenderSettings(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			RenderSettings obj = new RenderSettings();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: RenderSettings.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettingsWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fog(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.fog);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fogMode(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.fogMode);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fogColor(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.fogColor);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fogDensity(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.fogDensity);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fogStartDistance(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.fogStartDistance);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fogEndDistance(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.fogEndDistance);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ambientLight(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.ambientLight);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_haloStrength(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.haloStrength);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_flareStrength(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.flareStrength);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_flareFadeSpeed(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.flareFadeSpeed);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_skybox(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.skybox);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fog(IntPtr L)
	{
		RenderSettings.fog = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fogMode(IntPtr L)
	{
		RenderSettings.fogMode = (FogMode)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(FogMode)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fogColor(IntPtr L)
	{
		RenderSettings.fogColor = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fogDensity(IntPtr L)
	{
		RenderSettings.fogDensity = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fogStartDistance(IntPtr L)
	{
		RenderSettings.fogStartDistance = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fogEndDistance(IntPtr L)
	{
		RenderSettings.fogEndDistance = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ambientLight(IntPtr L)
	{
		RenderSettings.ambientLight = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_haloStrength(IntPtr L)
	{
		RenderSettings.haloStrength = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_flareStrength(IntPtr L)
	{
		RenderSettings.flareStrength = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_flareFadeSpeed(IntPtr L)
	{
		RenderSettings.flareFadeSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_skybox(IntPtr L)
	{
		RenderSettings.skybox = (Material)LuaScriptMgr.GetUnityObject(L, 3, typeof(Material));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UnityEngine.Object x = LuaScriptMgr.GetLuaObject(L, 1) as UnityEngine.Object;
		UnityEngine.Object y = LuaScriptMgr.GetLuaObject(L, 2) as UnityEngine.Object;
		bool b = x == y;
		LuaScriptMgr.Push(L, b);
		return 1;
	}
}
