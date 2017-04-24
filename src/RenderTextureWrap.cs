using LuaInterface;
using System;
using UnityEngine;

public class RenderTextureWrap
{
	private static Type classType = typeof(RenderTexture);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetTemporary", new LuaCSFunction(RenderTextureWrap.GetTemporary)),
			new LuaMethod("ReleaseTemporary", new LuaCSFunction(RenderTextureWrap.ReleaseTemporary)),
			new LuaMethod("Create", new LuaCSFunction(RenderTextureWrap.Create)),
			new LuaMethod("Release", new LuaCSFunction(RenderTextureWrap.Release)),
			new LuaMethod("IsCreated", new LuaCSFunction(RenderTextureWrap.IsCreated)),
			new LuaMethod("DiscardContents", new LuaCSFunction(RenderTextureWrap.DiscardContents)),
			new LuaMethod("MarkRestoreExpected", new LuaCSFunction(RenderTextureWrap.MarkRestoreExpected)),
			new LuaMethod("SetGlobalShaderProperty", new LuaCSFunction(RenderTextureWrap.SetGlobalShaderProperty)),
			new LuaMethod("GetTexelOffset", new LuaCSFunction(RenderTextureWrap.GetTexelOffset)),
			new LuaMethod("SupportsStencil", new LuaCSFunction(RenderTextureWrap.SupportsStencil)),
			new LuaMethod("New", new LuaCSFunction(RenderTextureWrap._CreateRenderTexture)),
			new LuaMethod("GetClassType", new LuaCSFunction(RenderTextureWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(RenderTextureWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("width", new LuaCSFunction(RenderTextureWrap.get_width), new LuaCSFunction(RenderTextureWrap.set_width)),
			new LuaField("height", new LuaCSFunction(RenderTextureWrap.get_height), new LuaCSFunction(RenderTextureWrap.set_height)),
			new LuaField("depth", new LuaCSFunction(RenderTextureWrap.get_depth), new LuaCSFunction(RenderTextureWrap.set_depth)),
			new LuaField("isPowerOfTwo", new LuaCSFunction(RenderTextureWrap.get_isPowerOfTwo), new LuaCSFunction(RenderTextureWrap.set_isPowerOfTwo)),
			new LuaField("sRGB", new LuaCSFunction(RenderTextureWrap.get_sRGB), null),
			new LuaField("format", new LuaCSFunction(RenderTextureWrap.get_format), new LuaCSFunction(RenderTextureWrap.set_format)),
			new LuaField("useMipMap", new LuaCSFunction(RenderTextureWrap.get_useMipMap), new LuaCSFunction(RenderTextureWrap.set_useMipMap)),
			new LuaField("generateMips", new LuaCSFunction(RenderTextureWrap.get_generateMips), new LuaCSFunction(RenderTextureWrap.set_generateMips)),
			new LuaField("isCubemap", new LuaCSFunction(RenderTextureWrap.get_isCubemap), new LuaCSFunction(RenderTextureWrap.set_isCubemap)),
			new LuaField("isVolume", new LuaCSFunction(RenderTextureWrap.get_isVolume), new LuaCSFunction(RenderTextureWrap.set_isVolume)),
			new LuaField("volumeDepth", new LuaCSFunction(RenderTextureWrap.get_volumeDepth), new LuaCSFunction(RenderTextureWrap.set_volumeDepth)),
			new LuaField("antiAliasing", new LuaCSFunction(RenderTextureWrap.get_antiAliasing), new LuaCSFunction(RenderTextureWrap.set_antiAliasing)),
			new LuaField("enableRandomWrite", new LuaCSFunction(RenderTextureWrap.get_enableRandomWrite), new LuaCSFunction(RenderTextureWrap.set_enableRandomWrite)),
			new LuaField("colorBuffer", new LuaCSFunction(RenderTextureWrap.get_colorBuffer), null),
			new LuaField("depthBuffer", new LuaCSFunction(RenderTextureWrap.get_depthBuffer), null),
			new LuaField("active", new LuaCSFunction(RenderTextureWrap.get_active), new LuaCSFunction(RenderTextureWrap.set_active))
		};
		LuaScriptMgr.RegisterLib(L, "UnityEngine.RenderTexture", typeof(RenderTexture), regs, fields, typeof(Texture));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateRenderTexture(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 3)
		{
			int width = (int)LuaScriptMgr.GetNumber(L, 1);
			int height = (int)LuaScriptMgr.GetNumber(L, 2);
			int depth = (int)LuaScriptMgr.GetNumber(L, 3);
			RenderTexture obj = new RenderTexture(width, height, depth);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		if (num == 4)
		{
			int width2 = (int)LuaScriptMgr.GetNumber(L, 1);
			int height2 = (int)LuaScriptMgr.GetNumber(L, 2);
			int depth2 = (int)LuaScriptMgr.GetNumber(L, 3);
			RenderTextureFormat format = (RenderTextureFormat)((int)LuaScriptMgr.GetNetObject(L, 4, typeof(RenderTextureFormat)));
			RenderTexture obj2 = new RenderTexture(width2, height2, depth2, format);
			LuaScriptMgr.Push(L, obj2);
			return 1;
		}
		if (num == 5)
		{
			int width3 = (int)LuaScriptMgr.GetNumber(L, 1);
			int height3 = (int)LuaScriptMgr.GetNumber(L, 2);
			int depth3 = (int)LuaScriptMgr.GetNumber(L, 3);
			RenderTextureFormat format2 = (RenderTextureFormat)((int)LuaScriptMgr.GetNetObject(L, 4, typeof(RenderTextureFormat)));
			RenderTextureReadWrite readWrite = (RenderTextureReadWrite)((int)LuaScriptMgr.GetNetObject(L, 5, typeof(RenderTextureReadWrite)));
			RenderTexture obj3 = new RenderTexture(width3, height3, depth3, format2, readWrite);
			LuaScriptMgr.Push(L, obj3);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: RenderTexture.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderTextureWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_width(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name width");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index width on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderTexture.width);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_height(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name height");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index height on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderTexture.height);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_depth(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depth on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderTexture.depth);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isPowerOfTwo(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isPowerOfTwo");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isPowerOfTwo on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderTexture.isPowerOfTwo);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sRGB(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sRGB");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sRGB on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderTexture.sRGB);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_format(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name format");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index format on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderTexture.format);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useMipMap(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useMipMap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useMipMap on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderTexture.useMipMap);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_generateMips(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name generateMips");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index generateMips on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderTexture.generateMips);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isCubemap(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isCubemap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isCubemap on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderTexture.isCubemap);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isVolume(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isVolume");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isVolume on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderTexture.isVolume);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_volumeDepth(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name volumeDepth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index volumeDepth on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderTexture.volumeDepth);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_antiAliasing(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name antiAliasing");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index antiAliasing on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderTexture.antiAliasing);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_enableRandomWrite(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enableRandomWrite");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enableRandomWrite on a nil value");
			}
		}
		LuaScriptMgr.Push(L, renderTexture.enableRandomWrite);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_colorBuffer(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name colorBuffer");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index colorBuffer on a nil value");
			}
		}
		LuaScriptMgr.PushValue(L, renderTexture.colorBuffer);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_depthBuffer(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depthBuffer");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depthBuffer on a nil value");
			}
		}
		LuaScriptMgr.PushValue(L, renderTexture.depthBuffer);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_active(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderTexture.active);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_width(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name width");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index width on a nil value");
			}
		}
		renderTexture.width = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_height(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name height");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index height on a nil value");
			}
		}
		renderTexture.height = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_depth(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depth on a nil value");
			}
		}
		renderTexture.depth = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isPowerOfTwo(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isPowerOfTwo");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isPowerOfTwo on a nil value");
			}
		}
		renderTexture.isPowerOfTwo = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_format(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name format");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index format on a nil value");
			}
		}
		renderTexture.format = (RenderTextureFormat)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(RenderTextureFormat)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useMipMap(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useMipMap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useMipMap on a nil value");
			}
		}
		renderTexture.useMipMap = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_generateMips(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name generateMips");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index generateMips on a nil value");
			}
		}
		renderTexture.generateMips = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isCubemap(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isCubemap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isCubemap on a nil value");
			}
		}
		renderTexture.isCubemap = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isVolume(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isVolume");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isVolume on a nil value");
			}
		}
		renderTexture.isVolume = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_volumeDepth(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name volumeDepth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index volumeDepth on a nil value");
			}
		}
		renderTexture.volumeDepth = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_antiAliasing(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name antiAliasing");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index antiAliasing on a nil value");
			}
		}
		renderTexture.antiAliasing = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_enableRandomWrite(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		RenderTexture renderTexture = (RenderTexture)luaObject;
		if (renderTexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enableRandomWrite");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enableRandomWrite on a nil value");
			}
		}
		renderTexture.enableRandomWrite = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_active(IntPtr L)
	{
		RenderTexture.active = (RenderTexture)LuaScriptMgr.GetUnityObject(L, 3, typeof(RenderTexture));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTemporary(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			int width = (int)LuaScriptMgr.GetNumber(L, 1);
			int height = (int)LuaScriptMgr.GetNumber(L, 2);
			RenderTexture temporary = RenderTexture.GetTemporary(width, height);
			LuaScriptMgr.Push(L, temporary);
			return 1;
		}
		if (num == 3)
		{
			int width2 = (int)LuaScriptMgr.GetNumber(L, 1);
			int height2 = (int)LuaScriptMgr.GetNumber(L, 2);
			int depthBuffer = (int)LuaScriptMgr.GetNumber(L, 3);
			RenderTexture temporary2 = RenderTexture.GetTemporary(width2, height2, depthBuffer);
			LuaScriptMgr.Push(L, temporary2);
			return 1;
		}
		if (num == 4)
		{
			int width3 = (int)LuaScriptMgr.GetNumber(L, 1);
			int height3 = (int)LuaScriptMgr.GetNumber(L, 2);
			int depthBuffer2 = (int)LuaScriptMgr.GetNumber(L, 3);
			RenderTextureFormat format = (RenderTextureFormat)((int)LuaScriptMgr.GetNetObject(L, 4, typeof(RenderTextureFormat)));
			RenderTexture temporary3 = RenderTexture.GetTemporary(width3, height3, depthBuffer2, format);
			LuaScriptMgr.Push(L, temporary3);
			return 1;
		}
		if (num == 5)
		{
			int width4 = (int)LuaScriptMgr.GetNumber(L, 1);
			int height4 = (int)LuaScriptMgr.GetNumber(L, 2);
			int depthBuffer3 = (int)LuaScriptMgr.GetNumber(L, 3);
			RenderTextureFormat format2 = (RenderTextureFormat)((int)LuaScriptMgr.GetNetObject(L, 4, typeof(RenderTextureFormat)));
			RenderTextureReadWrite readWrite = (RenderTextureReadWrite)((int)LuaScriptMgr.GetNetObject(L, 5, typeof(RenderTextureReadWrite)));
			RenderTexture temporary4 = RenderTexture.GetTemporary(width4, height4, depthBuffer3, format2, readWrite);
			LuaScriptMgr.Push(L, temporary4);
			return 1;
		}
		if (num == 6)
		{
			int width5 = (int)LuaScriptMgr.GetNumber(L, 1);
			int height5 = (int)LuaScriptMgr.GetNumber(L, 2);
			int depthBuffer4 = (int)LuaScriptMgr.GetNumber(L, 3);
			RenderTextureFormat format3 = (RenderTextureFormat)((int)LuaScriptMgr.GetNetObject(L, 4, typeof(RenderTextureFormat)));
			RenderTextureReadWrite readWrite2 = (RenderTextureReadWrite)((int)LuaScriptMgr.GetNetObject(L, 5, typeof(RenderTextureReadWrite)));
			int antiAliasing = (int)LuaScriptMgr.GetNumber(L, 6);
			RenderTexture temporary5 = RenderTexture.GetTemporary(width5, height5, depthBuffer4, format3, readWrite2, antiAliasing);
			LuaScriptMgr.Push(L, temporary5);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: RenderTexture.GetTemporary");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReleaseTemporary(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		RenderTexture temp = (RenderTexture)LuaScriptMgr.GetUnityObject(L, 1, typeof(RenderTexture));
		RenderTexture.ReleaseTemporary(temp);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Create(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		RenderTexture renderTexture = (RenderTexture)LuaScriptMgr.GetUnityObjectSelf(L, 1, "RenderTexture");
		bool b = renderTexture.Create();
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Release(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		RenderTexture renderTexture = (RenderTexture)LuaScriptMgr.GetUnityObjectSelf(L, 1, "RenderTexture");
		renderTexture.Release();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsCreated(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		RenderTexture renderTexture = (RenderTexture)LuaScriptMgr.GetUnityObjectSelf(L, 1, "RenderTexture");
		bool b = renderTexture.IsCreated();
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DiscardContents(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			RenderTexture renderTexture = (RenderTexture)LuaScriptMgr.GetUnityObjectSelf(L, 1, "RenderTexture");
			renderTexture.DiscardContents();
			return 0;
		}
		if (num == 3)
		{
			RenderTexture renderTexture2 = (RenderTexture)LuaScriptMgr.GetUnityObjectSelf(L, 1, "RenderTexture");
			bool boolean = LuaScriptMgr.GetBoolean(L, 2);
			bool boolean2 = LuaScriptMgr.GetBoolean(L, 3);
			renderTexture2.DiscardContents(boolean, boolean2);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: RenderTexture.DiscardContents");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MarkRestoreExpected(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		RenderTexture renderTexture = (RenderTexture)LuaScriptMgr.GetUnityObjectSelf(L, 1, "RenderTexture");
		renderTexture.MarkRestoreExpected();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetGlobalShaderProperty(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		RenderTexture renderTexture = (RenderTexture)LuaScriptMgr.GetUnityObjectSelf(L, 1, "RenderTexture");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		renderTexture.SetGlobalShaderProperty(luaString);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTexelOffset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		RenderTexture renderTexture = (RenderTexture)LuaScriptMgr.GetUnityObjectSelf(L, 1, "RenderTexture");
		Vector2 texelOffset = renderTexture.GetTexelOffset();
		LuaScriptMgr.Push(L, texelOffset);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SupportsStencil(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		RenderTexture rt = (RenderTexture)LuaScriptMgr.GetUnityObject(L, 1, typeof(RenderTexture));
		bool b = RenderTexture.SupportsStencil(rt);
		LuaScriptMgr.Push(L, b);
		return 1;
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
