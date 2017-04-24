using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIAtlasWrap
{
	private static Type classType = typeof(UIAtlas);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetSprite", new LuaCSFunction(UIAtlasWrap.GetSprite)),
			new LuaMethod("SortAlphabetically", new LuaCSFunction(UIAtlasWrap.SortAlphabetically)),
			new LuaMethod("GetListOfSprites", new LuaCSFunction(UIAtlasWrap.GetListOfSprites)),
			new LuaMethod("CheckIfRelated", new LuaCSFunction(UIAtlasWrap.CheckIfRelated)),
			new LuaMethod("MarkAsChanged", new LuaCSFunction(UIAtlasWrap.MarkAsChanged)),
			new LuaMethod("New", new LuaCSFunction(UIAtlasWrap._CreateUIAtlas)),
			new LuaMethod("GetClassType", new LuaCSFunction(UIAtlasWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UIAtlasWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("spriteMaterial", new LuaCSFunction(UIAtlasWrap.get_spriteMaterial), new LuaCSFunction(UIAtlasWrap.set_spriteMaterial)),
			new LuaField("premultipliedAlpha", new LuaCSFunction(UIAtlasWrap.get_premultipliedAlpha), null),
			new LuaField("spriteList", new LuaCSFunction(UIAtlasWrap.get_spriteList), new LuaCSFunction(UIAtlasWrap.set_spriteList)),
			new LuaField("texture", new LuaCSFunction(UIAtlasWrap.get_texture), null),
			new LuaField("pixelSize", new LuaCSFunction(UIAtlasWrap.get_pixelSize), new LuaCSFunction(UIAtlasWrap.set_pixelSize)),
			new LuaField("replacement", new LuaCSFunction(UIAtlasWrap.get_replacement), new LuaCSFunction(UIAtlasWrap.set_replacement))
		};
		LuaScriptMgr.RegisterLib(L, "UIAtlas", typeof(UIAtlas), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUIAtlas(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIAtlas class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIAtlasWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_spriteMaterial(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas uIAtlas = (UIAtlas)luaObject;
		if (uIAtlas == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteMaterial");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteMaterial on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIAtlas.spriteMaterial);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_premultipliedAlpha(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas uIAtlas = (UIAtlas)luaObject;
		if (uIAtlas == null)
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
		LuaScriptMgr.Push(L, uIAtlas.premultipliedAlpha);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_spriteList(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas uIAtlas = (UIAtlas)luaObject;
		if (uIAtlas == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteList");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteList on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, uIAtlas.spriteList);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_texture(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas uIAtlas = (UIAtlas)luaObject;
		if (uIAtlas == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name texture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index texture on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIAtlas.texture);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pixelSize(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas uIAtlas = (UIAtlas)luaObject;
		if (uIAtlas == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pixelSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pixelSize on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIAtlas.pixelSize);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_replacement(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas uIAtlas = (UIAtlas)luaObject;
		if (uIAtlas == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name replacement");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index replacement on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIAtlas.replacement);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_spriteMaterial(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas uIAtlas = (UIAtlas)luaObject;
		if (uIAtlas == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteMaterial");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteMaterial on a nil value");
			}
		}
		uIAtlas.spriteMaterial = (Material)LuaScriptMgr.GetUnityObject(L, 3, typeof(Material));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_spriteList(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas uIAtlas = (UIAtlas)luaObject;
		if (uIAtlas == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteList");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteList on a nil value");
			}
		}
		uIAtlas.spriteList = (List<UISpriteData>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<UISpriteData>));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pixelSize(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas uIAtlas = (UIAtlas)luaObject;
		if (uIAtlas == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pixelSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pixelSize on a nil value");
			}
		}
		uIAtlas.pixelSize = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_replacement(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas uIAtlas = (UIAtlas)luaObject;
		if (uIAtlas == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name replacement");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index replacement on a nil value");
			}
		}
		uIAtlas.replacement = (UIAtlas)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIAtlas));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSprite(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIAtlas uIAtlas = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		UISpriteData sprite = uIAtlas.GetSprite(luaString);
		LuaScriptMgr.PushObject(L, sprite);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SortAlphabetically(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIAtlas uIAtlas = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
		uIAtlas.SortAlphabetically();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetListOfSprites(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			UIAtlas uIAtlas = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
			BetterList<string> listOfSprites = uIAtlas.GetListOfSprites();
			LuaScriptMgr.PushObject(L, listOfSprites);
			return 1;
		}
		if (num == 2)
		{
			UIAtlas uIAtlas2 = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
			string luaString = LuaScriptMgr.GetLuaString(L, 2);
			BetterList<string> listOfSprites2 = uIAtlas2.GetListOfSprites(luaString);
			LuaScriptMgr.PushObject(L, listOfSprites2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: UIAtlas.GetListOfSprites");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CheckIfRelated(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIAtlas a = (UIAtlas)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIAtlas));
		UIAtlas b = (UIAtlas)LuaScriptMgr.GetUnityObject(L, 2, typeof(UIAtlas));
		bool b2 = UIAtlas.CheckIfRelated(a, b);
		LuaScriptMgr.Push(L, b2);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MarkAsChanged(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIAtlas uIAtlas = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
		uIAtlas.MarkAsChanged();
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
