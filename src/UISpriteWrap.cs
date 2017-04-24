using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UISpriteWrap
{
	private static Type classType = typeof(UISprite);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetAtlasSprite", new LuaCSFunction(UISpriteWrap.GetAtlasSprite)),
			new LuaMethod("MakePixelPerfect", new LuaCSFunction(UISpriteWrap.MakePixelPerfect)),
			new LuaMethod("OnFill", new LuaCSFunction(UISpriteWrap.OnFill)),
			new LuaMethod("New", new LuaCSFunction(UISpriteWrap._CreateUISprite)),
			new LuaMethod("GetClassType", new LuaCSFunction(UISpriteWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UISpriteWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("current", new LuaCSFunction(UISpriteWrap.get_current), new LuaCSFunction(UISpriteWrap.set_current)),
			new LuaField("centerType", new LuaCSFunction(UISpriteWrap.get_centerType), new LuaCSFunction(UISpriteWrap.set_centerType)),
			new LuaField("leftType", new LuaCSFunction(UISpriteWrap.get_leftType), new LuaCSFunction(UISpriteWrap.set_leftType)),
			new LuaField("rightType", new LuaCSFunction(UISpriteWrap.get_rightType), new LuaCSFunction(UISpriteWrap.set_rightType)),
			new LuaField("bottomType", new LuaCSFunction(UISpriteWrap.get_bottomType), new LuaCSFunction(UISpriteWrap.set_bottomType)),
			new LuaField("topType", new LuaCSFunction(UISpriteWrap.get_topType), new LuaCSFunction(UISpriteWrap.set_topType)),
			new LuaField("onClick", new LuaCSFunction(UISpriteWrap.get_onClick), new LuaCSFunction(UISpriteWrap.set_onClick)),
			new LuaField("isEnabled", new LuaCSFunction(UISpriteWrap.get_isEnabled), null),
			new LuaField("type", new LuaCSFunction(UISpriteWrap.get_type), new LuaCSFunction(UISpriteWrap.set_type)),
			new LuaField("flip", new LuaCSFunction(UISpriteWrap.get_flip), new LuaCSFunction(UISpriteWrap.set_flip)),
			new LuaField("FillScale", new LuaCSFunction(UISpriteWrap.get_FillScale), null),
			new LuaField("material", new LuaCSFunction(UISpriteWrap.get_material), null),
			new LuaField("atlas", new LuaCSFunction(UISpriteWrap.get_atlas), new LuaCSFunction(UISpriteWrap.set_atlas)),
			new LuaField("spriteName", new LuaCSFunction(UISpriteWrap.get_spriteName), new LuaCSFunction(UISpriteWrap.set_spriteName)),
			new LuaField("isValid", new LuaCSFunction(UISpriteWrap.get_isValid), null),
			new LuaField("fillDirection", new LuaCSFunction(UISpriteWrap.get_fillDirection), new LuaCSFunction(UISpriteWrap.set_fillDirection)),
			new LuaField("fillAmount", new LuaCSFunction(UISpriteWrap.get_fillAmount), new LuaCSFunction(UISpriteWrap.set_fillAmount)),
			new LuaField("invert", new LuaCSFunction(UISpriteWrap.get_invert), new LuaCSFunction(UISpriteWrap.set_invert)),
			new LuaField("border", new LuaCSFunction(UISpriteWrap.get_border), null),
			new LuaField("minWidth", new LuaCSFunction(UISpriteWrap.get_minWidth), null),
			new LuaField("minHeight", new LuaCSFunction(UISpriteWrap.get_minHeight), null),
			new LuaField("drawingDimensions", new LuaCSFunction(UISpriteWrap.get_drawingDimensions), null)
		};
		LuaScriptMgr.RegisterLib(L, "UISprite", typeof(UISprite), regs, fields, typeof(UIWidget));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUISprite(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UISprite class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UISpriteWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_current(IntPtr L)
	{
		LuaScriptMgr.Push(L, UISprite.current);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_centerType(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name centerType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index centerType on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uISprite.centerType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_leftType(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name leftType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index leftType on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uISprite.leftType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rightType(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rightType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rightType on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uISprite.rightType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bottomType(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bottomType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bottomType on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uISprite.bottomType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_topType(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name topType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index topType on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uISprite.topType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onClick(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onClick");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onClick on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, uISprite.onClick);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isEnabled(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isEnabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isEnabled on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uISprite.isEnabled);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_type(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name type");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index type on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uISprite.type);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_flip(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
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
		LuaScriptMgr.Push(L, uISprite.flip);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_FillScale(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name FillScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index FillScale on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uISprite.FillScale);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_material(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
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
		LuaScriptMgr.Push(L, uISprite.material);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_atlas(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name atlas");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index atlas on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uISprite.atlas);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_spriteName(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteName on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uISprite.spriteName);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isValid(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isValid");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isValid on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uISprite.isValid);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fillDirection(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fillDirection");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fillDirection on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uISprite.fillDirection);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fillAmount(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fillAmount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fillAmount on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uISprite.fillAmount);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_invert(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name invert");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index invert on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uISprite.invert);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_border(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name border");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index border on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uISprite.border);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_minWidth(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name minWidth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index minWidth on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uISprite.minWidth);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_minHeight(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name minHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index minHeight on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uISprite.minHeight);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_drawingDimensions(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
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
		LuaScriptMgr.Push(L, uISprite.drawingDimensions);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_current(IntPtr L)
	{
		UISprite.current = (UISprite)LuaScriptMgr.GetUnityObject(L, 3, typeof(UISprite));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_centerType(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name centerType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index centerType on a nil value");
			}
		}
		uISprite.centerType = (UISprite.AdvancedType)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UISprite.AdvancedType)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_leftType(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name leftType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index leftType on a nil value");
			}
		}
		uISprite.leftType = (UISprite.AdvancedType)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UISprite.AdvancedType)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rightType(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rightType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rightType on a nil value");
			}
		}
		uISprite.rightType = (UISprite.AdvancedType)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UISprite.AdvancedType)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bottomType(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bottomType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bottomType on a nil value");
			}
		}
		uISprite.bottomType = (UISprite.AdvancedType)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UISprite.AdvancedType)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_topType(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name topType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index topType on a nil value");
			}
		}
		uISprite.topType = (UISprite.AdvancedType)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UISprite.AdvancedType)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onClick(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onClick");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onClick on a nil value");
			}
		}
		uISprite.onClick = (List<EventDelegate>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<EventDelegate>));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_type(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name type");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index type on a nil value");
			}
		}
		uISprite.type = (UISprite.Type)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UISprite.Type)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_flip(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
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
		uISprite.flip = (UISprite.Flip)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UISprite.Flip)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_atlas(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name atlas");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index atlas on a nil value");
			}
		}
		uISprite.atlas = (UIAtlas)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIAtlas));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_spriteName(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteName on a nil value");
			}
		}
		uISprite.spriteName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fillDirection(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fillDirection");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fillDirection on a nil value");
			}
		}
		uISprite.fillDirection = (UISprite.FillDirection)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UISprite.FillDirection)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fillAmount(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fillAmount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fillAmount on a nil value");
			}
		}
		uISprite.fillAmount = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_invert(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UISprite uISprite = (UISprite)luaObject;
		if (uISprite == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name invert");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index invert on a nil value");
			}
		}
		uISprite.invert = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAtlasSprite(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UISprite uISprite = (UISprite)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UISprite");
		UISpriteData atlasSprite = uISprite.GetAtlasSprite();
		LuaScriptMgr.PushObject(L, atlasSprite);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MakePixelPerfect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UISprite uISprite = (UISprite)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UISprite");
		uISprite.MakePixelPerfect();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnFill(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		UISprite uISprite = (UISprite)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UISprite");
		BetterList<Vector3> verts = (BetterList<Vector3>)LuaScriptMgr.GetNetObject(L, 2, typeof(BetterList<Vector3>));
		BetterList<Vector2> uvs = (BetterList<Vector2>)LuaScriptMgr.GetNetObject(L, 3, typeof(BetterList<Vector2>));
		BetterList<Color32> cols = (BetterList<Color32>)LuaScriptMgr.GetNetObject(L, 4, typeof(BetterList<Color32>));
		uISprite.OnFill(verts, uvs, cols);
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
