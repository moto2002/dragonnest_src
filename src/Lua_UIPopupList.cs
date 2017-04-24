using com.tencent.pandora;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Lua_UIPopupList : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList o = new UIPopupList();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, o);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Close(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			uIPopupList.Close();
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
	public static int get_current(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, UIPopupList.current);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_current(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList current;
			LuaObject.checkType<UIPopupList>(l, 2, out current);
			UIPopupList.current = current;
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
	public static int get_atlas(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPopupList.atlas);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_atlas(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			UIAtlas atlas;
			LuaObject.checkType<UIAtlas>(l, 2, out atlas);
			uIPopupList.atlas = atlas;
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
	public static int get_bitmapFont(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPopupList.bitmapFont);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_bitmapFont(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			UIFont bitmapFont;
			LuaObject.checkType<UIFont>(l, 2, out bitmapFont);
			uIPopupList.bitmapFont = bitmapFont;
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
	public static int get_trueTypeFont(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPopupList.trueTypeFont);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_trueTypeFont(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			Font trueTypeFont;
			LuaObject.checkType<Font>(l, 2, out trueTypeFont);
			uIPopupList.trueTypeFont = trueTypeFont;
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
	public static int get_fontSize(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPopupList.fontSize);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_fontSize(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			int fontSize;
			LuaObject.checkType(l, 2, out fontSize);
			uIPopupList.fontSize = fontSize;
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
	public static int get_fontStyle(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIPopupList.fontStyle);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_fontStyle(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			FontStyle fontStyle;
			LuaObject.checkEnum<FontStyle>(l, 2, out fontStyle);
			uIPopupList.fontStyle = fontStyle;
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
	public static int get_backgroundSprite(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPopupList.backgroundSprite);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_backgroundSprite(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			string backgroundSprite;
			LuaObject.checkType(l, 2, out backgroundSprite);
			uIPopupList.backgroundSprite = backgroundSprite;
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
	public static int get_highlightSprite(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPopupList.highlightSprite);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_highlightSprite(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			string highlightSprite;
			LuaObject.checkType(l, 2, out highlightSprite);
			uIPopupList.highlightSprite = highlightSprite;
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
	public static int get_position(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIPopupList.position);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_position(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			UIPopupList.Position position;
			LuaObject.checkEnum<UIPopupList.Position>(l, 2, out position);
			uIPopupList.position = position;
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
	public static int get_items(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPopupList.items);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_items(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			List<string> items;
			LuaObject.checkType<List<string>>(l, 2, out items);
			uIPopupList.items = items;
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
	public static int get_padding(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPopupList.padding);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_padding(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			Vector2 padding;
			LuaObject.checkType(l, 2, out padding);
			uIPopupList.padding = padding;
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
	public static int get_textColor(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPopupList.textColor);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_textColor(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			Color textColor;
			LuaObject.checkType(l, 2, out textColor);
			uIPopupList.textColor = textColor;
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
	public static int get_backgroundColor(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPopupList.backgroundColor);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_backgroundColor(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			Color backgroundColor;
			LuaObject.checkType(l, 2, out backgroundColor);
			uIPopupList.backgroundColor = backgroundColor;
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
	public static int get_highlightColor(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPopupList.highlightColor);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_highlightColor(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			Color highlightColor;
			LuaObject.checkType(l, 2, out highlightColor);
			uIPopupList.highlightColor = highlightColor;
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
	public static int get_isAnimated(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPopupList.isAnimated);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_isAnimated(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			bool isAnimated;
			LuaObject.checkType(l, 2, out isAnimated);
			uIPopupList.isAnimated = isAnimated;
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
	public static int get_isLocalized(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPopupList.isLocalized);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_isLocalized(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			bool isLocalized;
			LuaObject.checkType(l, 2, out isLocalized);
			uIPopupList.isLocalized = isLocalized;
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
	public static int get_onChange(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPopupList.onChange);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_onChange(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			List<EventDelegate> onChange;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onChange);
			uIPopupList.onChange = onChange;
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
	public static int get_ambigiousFont(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPopupList.ambigiousFont);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_ambigiousFont(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			UnityEngine.Object ambigiousFont;
			LuaObject.checkType<UnityEngine.Object>(l, 2, out ambigiousFont);
			uIPopupList.ambigiousFont = ambigiousFont;
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
	public static int get_isOpen(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPopupList.isOpen);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_value(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPopupList.value);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_value(IntPtr l)
	{
		int result;
		try
		{
			UIPopupList uIPopupList = (UIPopupList)LuaObject.checkSelf(l);
			string value;
			LuaObject.checkType(l, 2, out value);
			uIPopupList.value = value;
			LuaObject.pushValue(l, true);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	public static void reg(IntPtr l)
	{
		LuaObject.getTypeTable(l, "UIPopupList");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPopupList.Close));
		LuaObject.addMember(l, "current", new LuaCSFunction(Lua_UIPopupList.get_current), new LuaCSFunction(Lua_UIPopupList.set_current), false);
		LuaObject.addMember(l, "atlas", new LuaCSFunction(Lua_UIPopupList.get_atlas), new LuaCSFunction(Lua_UIPopupList.set_atlas), true);
		LuaObject.addMember(l, "bitmapFont", new LuaCSFunction(Lua_UIPopupList.get_bitmapFont), new LuaCSFunction(Lua_UIPopupList.set_bitmapFont), true);
		LuaObject.addMember(l, "trueTypeFont", new LuaCSFunction(Lua_UIPopupList.get_trueTypeFont), new LuaCSFunction(Lua_UIPopupList.set_trueTypeFont), true);
		LuaObject.addMember(l, "fontSize", new LuaCSFunction(Lua_UIPopupList.get_fontSize), new LuaCSFunction(Lua_UIPopupList.set_fontSize), true);
		LuaObject.addMember(l, "fontStyle", new LuaCSFunction(Lua_UIPopupList.get_fontStyle), new LuaCSFunction(Lua_UIPopupList.set_fontStyle), true);
		LuaObject.addMember(l, "backgroundSprite", new LuaCSFunction(Lua_UIPopupList.get_backgroundSprite), new LuaCSFunction(Lua_UIPopupList.set_backgroundSprite), true);
		LuaObject.addMember(l, "highlightSprite", new LuaCSFunction(Lua_UIPopupList.get_highlightSprite), new LuaCSFunction(Lua_UIPopupList.set_highlightSprite), true);
		LuaObject.addMember(l, "position", new LuaCSFunction(Lua_UIPopupList.get_position), new LuaCSFunction(Lua_UIPopupList.set_position), true);
		LuaObject.addMember(l, "items", new LuaCSFunction(Lua_UIPopupList.get_items), new LuaCSFunction(Lua_UIPopupList.set_items), true);
		LuaObject.addMember(l, "padding", new LuaCSFunction(Lua_UIPopupList.get_padding), new LuaCSFunction(Lua_UIPopupList.set_padding), true);
		LuaObject.addMember(l, "textColor", new LuaCSFunction(Lua_UIPopupList.get_textColor), new LuaCSFunction(Lua_UIPopupList.set_textColor), true);
		LuaObject.addMember(l, "backgroundColor", new LuaCSFunction(Lua_UIPopupList.get_backgroundColor), new LuaCSFunction(Lua_UIPopupList.set_backgroundColor), true);
		LuaObject.addMember(l, "highlightColor", new LuaCSFunction(Lua_UIPopupList.get_highlightColor), new LuaCSFunction(Lua_UIPopupList.set_highlightColor), true);
		LuaObject.addMember(l, "isAnimated", new LuaCSFunction(Lua_UIPopupList.get_isAnimated), new LuaCSFunction(Lua_UIPopupList.set_isAnimated), true);
		LuaObject.addMember(l, "isLocalized", new LuaCSFunction(Lua_UIPopupList.get_isLocalized), new LuaCSFunction(Lua_UIPopupList.set_isLocalized), true);
		LuaObject.addMember(l, "onChange", new LuaCSFunction(Lua_UIPopupList.get_onChange), new LuaCSFunction(Lua_UIPopupList.set_onChange), true);
		LuaObject.addMember(l, "ambigiousFont", new LuaCSFunction(Lua_UIPopupList.get_ambigiousFont), new LuaCSFunction(Lua_UIPopupList.set_ambigiousFont), true);
		LuaObject.addMember(l, "isOpen", new LuaCSFunction(Lua_UIPopupList.get_isOpen), null, true);
		LuaObject.addMember(l, "value", new LuaCSFunction(Lua_UIPopupList.get_value), new LuaCSFunction(Lua_UIPopupList.set_value), true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UIPopupList.constructor), typeof(UIPopupList), typeof(UIWidgetContainer));
	}
}
