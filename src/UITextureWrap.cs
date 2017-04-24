using LuaInterface;
using System;
using UnityEngine;

public class UITextureWrap
{
	private static Type classType = typeof(UITexture);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("RestAlpha", new LuaCSFunction(UITextureWrap.RestAlpha)),
			new LuaMethod("MakePixelPerfect", new LuaCSFunction(UITextureWrap.MakePixelPerfect)),
			new LuaMethod("OnFill", new LuaCSFunction(UITextureWrap.OnFill)),
			new LuaMethod("New", new LuaCSFunction(UITextureWrap._CreateUITexture)),
			new LuaMethod("GetClassType", new LuaCSFunction(UITextureWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UITextureWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("mainTexture", new LuaCSFunction(UITextureWrap.get_mainTexture), new LuaCSFunction(UITextureWrap.set_mainTexture)),
			new LuaField("alphaTexture", new LuaCSFunction(UITextureWrap.get_alphaTexture), null),
			new LuaField("material", new LuaCSFunction(UITextureWrap.get_material), new LuaCSFunction(UITextureWrap.set_material)),
			new LuaField("shader", new LuaCSFunction(UITextureWrap.get_shader), new LuaCSFunction(UITextureWrap.set_shader)),
			new LuaField("flip", new LuaCSFunction(UITextureWrap.get_flip), new LuaCSFunction(UITextureWrap.set_flip)),
			new LuaField("premultipliedAlpha", new LuaCSFunction(UITextureWrap.get_premultipliedAlpha), null),
			new LuaField("uvRect", new LuaCSFunction(UITextureWrap.get_uvRect), new LuaCSFunction(UITextureWrap.set_uvRect)),
			new LuaField("drawingDimensions", new LuaCSFunction(UITextureWrap.get_drawingDimensions), null)
		};
		LuaScriptMgr.RegisterLib(L, "UITexture", typeof(UITexture), regs, fields, typeof(UIWidget));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUITexture(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UITexture class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UITextureWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mainTexture(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITexture uITexture = (UITexture)luaObject;
		if (uITexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTexture on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITexture.mainTexture);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_alphaTexture(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITexture uITexture = (UITexture)luaObject;
		if (uITexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name alphaTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index alphaTexture on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITexture.alphaTexture);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_material(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITexture uITexture = (UITexture)luaObject;
		if (uITexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name material");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index material on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITexture.material);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shader(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITexture uITexture = (UITexture)luaObject;
		if (uITexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shader");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shader on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITexture.shader);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_flip(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITexture uITexture = (UITexture)luaObject;
		if (uITexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flip on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITexture.flip);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_premultipliedAlpha(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITexture uITexture = (UITexture)luaObject;
		if (uITexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name premultipliedAlpha");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index premultipliedAlpha on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITexture.premultipliedAlpha);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_uvRect(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITexture uITexture = (UITexture)luaObject;
		if (uITexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uvRect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uvRect on a nil value");
			}
		}
		LuaScriptMgr.PushValue(L, uITexture.uvRect);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_drawingDimensions(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITexture uITexture = (UITexture)luaObject;
		if (uITexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name drawingDimensions");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index drawingDimensions on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uITexture.drawingDimensions);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mainTexture(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITexture uITexture = (UITexture)luaObject;
		if (uITexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTexture on a nil value");
			}
		}
		uITexture.mainTexture = (Texture)LuaScriptMgr.GetUnityObject(L, 3, typeof(Texture));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_material(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITexture uITexture = (UITexture)luaObject;
		if (uITexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name material");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index material on a nil value");
			}
		}
		uITexture.material = (Material)LuaScriptMgr.GetUnityObject(L, 3, typeof(Material));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shader(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITexture uITexture = (UITexture)luaObject;
		if (uITexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shader");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shader on a nil value");
			}
		}
		uITexture.shader = (Shader)LuaScriptMgr.GetUnityObject(L, 3, typeof(Shader));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_flip(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITexture uITexture = (UITexture)luaObject;
		if (uITexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flip on a nil value");
			}
		}
		uITexture.flip = (UITexture.Flip)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UITexture.Flip)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_uvRect(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UITexture uITexture = (UITexture)luaObject;
		if (uITexture == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uvRect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uvRect on a nil value");
			}
		}
		uITexture.uvRect = (Rect)LuaScriptMgr.GetNetObject(L, 3, typeof(Rect));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RestAlpha(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UITexture uITexture = (UITexture)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITexture");
		uITexture.RestAlpha();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MakePixelPerfect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UITexture uITexture = (UITexture)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITexture");
		uITexture.MakePixelPerfect();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnFill(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		UITexture uITexture = (UITexture)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITexture");
		BetterList<Vector3> verts = (BetterList<Vector3>)LuaScriptMgr.GetNetObject(L, 2, typeof(BetterList<Vector3>));
		BetterList<Vector2> uvs = (BetterList<Vector2>)LuaScriptMgr.GetNetObject(L, 3, typeof(BetterList<Vector2>));
		BetterList<Color32> cols = (BetterList<Color32>)LuaScriptMgr.GetNetObject(L, 4, typeof(BetterList<Color32>));
		uITexture.OnFill(verts, uvs, cols);
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
