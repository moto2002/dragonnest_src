using LuaInterface;
using System;
using UnityEngine;

public class UILabelWrap
{
	private static Type classType = typeof(UILabel);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetSides", new LuaCSFunction(UILabelWrap.GetSides)),
			new LuaMethod("MarkAsChanged", new LuaCSFunction(UILabelWrap.MarkAsChanged)),
			new LuaMethod("ProcessText", new LuaCSFunction(UILabelWrap.ProcessText)),
			new LuaMethod("UpdateDefaultPrintedSize", new LuaCSFunction(UILabelWrap.UpdateDefaultPrintedSize)),
			new LuaMethod("MakePixelPerfect", new LuaCSFunction(UILabelWrap.MakePixelPerfect)),
			new LuaMethod("AssumeNaturalSize", new LuaCSFunction(UILabelWrap.AssumeNaturalSize)),
			new LuaMethod("GetCharacterIndexAtPosition", new LuaCSFunction(UILabelWrap.GetCharacterIndexAtPosition)),
			new LuaMethod("GetWordAtPosition", new LuaCSFunction(UILabelWrap.GetWordAtPosition)),
			new LuaMethod("GetWordAtCharacterIndex", new LuaCSFunction(UILabelWrap.GetWordAtCharacterIndex)),
			new LuaMethod("GetUrlAtPosition", new LuaCSFunction(UILabelWrap.GetUrlAtPosition)),
			new LuaMethod("GetUrlAtCharacterIndex", new LuaCSFunction(UILabelWrap.GetUrlAtCharacterIndex)),
			new LuaMethod("GetCharacterIndex", new LuaCSFunction(UILabelWrap.GetCharacterIndex)),
			new LuaMethod("PrintOverlay", new LuaCSFunction(UILabelWrap.PrintOverlay)),
			new LuaMethod("OnFill", new LuaCSFunction(UILabelWrap.OnFill)),
			new LuaMethod("ApplyOffset", new LuaCSFunction(UILabelWrap.ApplyOffset)),
			new LuaMethod("CalculateOffsetToFit", new LuaCSFunction(UILabelWrap.CalculateOffsetToFit)),
			new LuaMethod("SetCurrentProgress", new LuaCSFunction(UILabelWrap.SetCurrentProgress)),
			new LuaMethod("SetCurrentPercent", new LuaCSFunction(UILabelWrap.SetCurrentPercent)),
			new LuaMethod("SetCurrentSelection", new LuaCSFunction(UILabelWrap.SetCurrentSelection)),
			new LuaMethod("Wrap", new LuaCSFunction(UILabelWrap.Wrap)),
			new LuaMethod("UpdateNGUIText", new LuaCSFunction(UILabelWrap.UpdateNGUIText)),
			new LuaMethod("New", new LuaCSFunction(UILabelWrap._CreateUILabel)),
			new LuaMethod("GetClassType", new LuaCSFunction(UILabelWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UILabelWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("keepCrispWhenShrunk", new LuaCSFunction(UILabelWrap.get_keepCrispWhenShrunk), new LuaCSFunction(UILabelWrap.set_keepCrispWhenShrunk)),
			new LuaField("isAnchoredHorizontally", new LuaCSFunction(UILabelWrap.get_isAnchoredHorizontally), null),
			new LuaField("isAnchoredVertically", new LuaCSFunction(UILabelWrap.get_isAnchoredVertically), null),
			new LuaField("material", new LuaCSFunction(UILabelWrap.get_material), new LuaCSFunction(UILabelWrap.set_material)),
			new LuaField("bitmapFont", new LuaCSFunction(UILabelWrap.get_bitmapFont), new LuaCSFunction(UILabelWrap.set_bitmapFont)),
			new LuaField("trueTypeFont", new LuaCSFunction(UILabelWrap.get_trueTypeFont), new LuaCSFunction(UILabelWrap.set_trueTypeFont)),
			new LuaField("ambigiousFont", new LuaCSFunction(UILabelWrap.get_ambigiousFont), new LuaCSFunction(UILabelWrap.set_ambigiousFont)),
			new LuaField("text", new LuaCSFunction(UILabelWrap.get_text), new LuaCSFunction(UILabelWrap.set_text)),
			new LuaField("defaultFontSize", new LuaCSFunction(UILabelWrap.get_defaultFontSize), null),
			new LuaField("fontSize", new LuaCSFunction(UILabelWrap.get_fontSize), new LuaCSFunction(UILabelWrap.set_fontSize)),
			new LuaField("fontStyle", new LuaCSFunction(UILabelWrap.get_fontStyle), new LuaCSFunction(UILabelWrap.set_fontStyle)),
			new LuaField("alignment", new LuaCSFunction(UILabelWrap.get_alignment), new LuaCSFunction(UILabelWrap.set_alignment)),
			new LuaField("applyGradient", new LuaCSFunction(UILabelWrap.get_applyGradient), new LuaCSFunction(UILabelWrap.set_applyGradient)),
			new LuaField("gradientTop", new LuaCSFunction(UILabelWrap.get_gradientTop), new LuaCSFunction(UILabelWrap.set_gradientTop)),
			new LuaField("gradientBottom", new LuaCSFunction(UILabelWrap.get_gradientBottom), new LuaCSFunction(UILabelWrap.set_gradientBottom)),
			new LuaField("spacingX", new LuaCSFunction(UILabelWrap.get_spacingX), new LuaCSFunction(UILabelWrap.set_spacingX)),
			new LuaField("spacingY", new LuaCSFunction(UILabelWrap.get_spacingY), new LuaCSFunction(UILabelWrap.set_spacingY)),
			new LuaField("supportEncoding", new LuaCSFunction(UILabelWrap.get_supportEncoding), new LuaCSFunction(UILabelWrap.set_supportEncoding)),
			new LuaField("symbolStyle", new LuaCSFunction(UILabelWrap.get_symbolStyle), new LuaCSFunction(UILabelWrap.set_symbolStyle)),
			new LuaField("overflowMethod", new LuaCSFunction(UILabelWrap.get_overflowMethod), new LuaCSFunction(UILabelWrap.set_overflowMethod)),
			new LuaField("multiLine", new LuaCSFunction(UILabelWrap.get_multiLine), new LuaCSFunction(UILabelWrap.set_multiLine)),
			new LuaField("localCorners", new LuaCSFunction(UILabelWrap.get_localCorners), null),
			new LuaField("worldCorners", new LuaCSFunction(UILabelWrap.get_worldCorners), null),
			new LuaField("drawingDimensions", new LuaCSFunction(UILabelWrap.get_drawingDimensions), null),
			new LuaField("maxLineCount", new LuaCSFunction(UILabelWrap.get_maxLineCount), new LuaCSFunction(UILabelWrap.set_maxLineCount)),
			new LuaField("effectStyle", new LuaCSFunction(UILabelWrap.get_effectStyle), new LuaCSFunction(UILabelWrap.set_effectStyle)),
			new LuaField("effectColor", new LuaCSFunction(UILabelWrap.get_effectColor), new LuaCSFunction(UILabelWrap.set_effectColor)),
			new LuaField("effectDistance", new LuaCSFunction(UILabelWrap.get_effectDistance), new LuaCSFunction(UILabelWrap.set_effectDistance)),
			new LuaField("processedText", new LuaCSFunction(UILabelWrap.get_processedText), null),
			new LuaField("printedSize", new LuaCSFunction(UILabelWrap.get_printedSize), null),
			new LuaField("localSize", new LuaCSFunction(UILabelWrap.get_localSize), null)
		};
		LuaScriptMgr.RegisterLib(L, "UILabel", typeof(UILabel), regs, fields, typeof(UIWidget));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUILabel(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UILabel class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UILabelWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_keepCrispWhenShrunk(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name keepCrispWhenShrunk");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index keepCrispWhenShrunk on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.keepCrispWhenShrunk);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isAnchoredHorizontally(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isAnchoredHorizontally");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isAnchoredHorizontally on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.isAnchoredHorizontally);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isAnchoredVertically(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isAnchoredVertically");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isAnchoredVertically on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.isAnchoredVertically);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_material(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
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
		LuaScriptMgr.Push(L, uILabel.material);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bitmapFont(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bitmapFont");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bitmapFont on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.bitmapFont);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_trueTypeFont(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name trueTypeFont");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index trueTypeFont on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.trueTypeFont);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ambigiousFont(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ambigiousFont");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ambigiousFont on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.ambigiousFont);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_text(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name text");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index text on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.text);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultFontSize(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name defaultFontSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index defaultFontSize on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.defaultFontSize);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fontSize(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fontSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fontSize on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.fontSize);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fontStyle(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fontStyle");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fontStyle on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.fontStyle);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_alignment(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name alignment");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index alignment on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.alignment);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_applyGradient(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name applyGradient");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index applyGradient on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.applyGradient);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gradientTop(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gradientTop");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gradientTop on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.gradientTop);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gradientBottom(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gradientBottom");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gradientBottom on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.gradientBottom);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_spacingX(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spacingX");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spacingX on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.spacingX);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_spacingY(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spacingY");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spacingY on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.spacingY);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_supportEncoding(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name supportEncoding");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index supportEncoding on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.supportEncoding);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_symbolStyle(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name symbolStyle");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index symbolStyle on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.symbolStyle);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_overflowMethod(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name overflowMethod");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index overflowMethod on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.overflowMethod);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_multiLine(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name multiLine");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index multiLine on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.multiLine);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localCorners(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name localCorners");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index localCorners on a nil value");
			}
		}
		LuaScriptMgr.PushArray(L, uILabel.localCorners);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_worldCorners(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name worldCorners");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index worldCorners on a nil value");
			}
		}
		LuaScriptMgr.PushArray(L, uILabel.worldCorners);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_drawingDimensions(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
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
		LuaScriptMgr.Push(L, uILabel.drawingDimensions);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxLineCount(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxLineCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxLineCount on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.maxLineCount);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_effectStyle(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name effectStyle");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index effectStyle on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.effectStyle);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_effectColor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name effectColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index effectColor on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.effectColor);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_effectDistance(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name effectDistance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index effectDistance on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.effectDistance);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_processedText(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name processedText");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index processedText on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.processedText);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_printedSize(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name printedSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index printedSize on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.printedSize);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localSize(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name localSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index localSize on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uILabel.localSize);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_keepCrispWhenShrunk(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name keepCrispWhenShrunk");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index keepCrispWhenShrunk on a nil value");
			}
		}
		uILabel.keepCrispWhenShrunk = (UILabel.Crispness)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UILabel.Crispness)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_material(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
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
		uILabel.material = (Material)LuaScriptMgr.GetUnityObject(L, 3, typeof(Material));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bitmapFont(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bitmapFont");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bitmapFont on a nil value");
			}
		}
		uILabel.bitmapFont = (UIFont)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIFont));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_trueTypeFont(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name trueTypeFont");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index trueTypeFont on a nil value");
			}
		}
		uILabel.trueTypeFont = (Font)LuaScriptMgr.GetUnityObject(L, 3, typeof(Font));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ambigiousFont(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ambigiousFont");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ambigiousFont on a nil value");
			}
		}
		uILabel.ambigiousFont = LuaScriptMgr.GetUnityObject(L, 3, typeof(UnityEngine.Object));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_text(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name text");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index text on a nil value");
			}
		}
		uILabel.text = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fontSize(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fontSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fontSize on a nil value");
			}
		}
		uILabel.fontSize = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fontStyle(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fontStyle");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fontStyle on a nil value");
			}
		}
		uILabel.fontStyle = (FontStyle)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(FontStyle)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_alignment(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name alignment");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index alignment on a nil value");
			}
		}
		uILabel.alignment = (NGUIText.Alignment)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(NGUIText.Alignment)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_applyGradient(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name applyGradient");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index applyGradient on a nil value");
			}
		}
		uILabel.applyGradient = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_gradientTop(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gradientTop");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gradientTop on a nil value");
			}
		}
		uILabel.gradientTop = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_gradientBottom(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gradientBottom");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gradientBottom on a nil value");
			}
		}
		uILabel.gradientBottom = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_spacingX(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spacingX");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spacingX on a nil value");
			}
		}
		uILabel.spacingX = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_spacingY(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spacingY");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spacingY on a nil value");
			}
		}
		uILabel.spacingY = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_supportEncoding(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name supportEncoding");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index supportEncoding on a nil value");
			}
		}
		uILabel.supportEncoding = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_symbolStyle(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name symbolStyle");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index symbolStyle on a nil value");
			}
		}
		uILabel.symbolStyle = (NGUIText.SymbolStyle)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(NGUIText.SymbolStyle)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_overflowMethod(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name overflowMethod");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index overflowMethod on a nil value");
			}
		}
		uILabel.overflowMethod = (UILabel.Overflow)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UILabel.Overflow)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_multiLine(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name multiLine");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index multiLine on a nil value");
			}
		}
		uILabel.multiLine = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxLineCount(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxLineCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxLineCount on a nil value");
			}
		}
		uILabel.maxLineCount = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_effectStyle(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name effectStyle");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index effectStyle on a nil value");
			}
		}
		uILabel.effectStyle = (UILabel.Effect)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UILabel.Effect)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_effectColor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name effectColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index effectColor on a nil value");
			}
		}
		uILabel.effectColor = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_effectDistance(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UILabel uILabel = (UILabel)luaObject;
		if (uILabel == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name effectDistance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index effectDistance on a nil value");
			}
		}
		uILabel.effectDistance = LuaScriptMgr.GetVector2(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSides(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
		Transform relativeTo = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
		Vector3[] sides = uILabel.GetSides(relativeTo);
		LuaScriptMgr.PushArray(L, sides);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MarkAsChanged(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
		uILabel.MarkAsChanged();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ProcessText(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
		uILabel.ProcessText();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateDefaultPrintedSize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
		uILabel.UpdateDefaultPrintedSize();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MakePixelPerfect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
		uILabel.MakePixelPerfect();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AssumeNaturalSize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
		uILabel.AssumeNaturalSize();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCharacterIndexAtPosition(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(UILabel), typeof(LuaTable)))
		{
			UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
			Vector2 vector = LuaScriptMgr.GetVector2(L, 2);
			int characterIndexAtPosition = uILabel.GetCharacterIndexAtPosition(vector);
			LuaScriptMgr.Push(L, characterIndexAtPosition);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(UILabel), typeof(LuaTable)))
		{
			UILabel uILabel2 = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
			Vector3 vector2 = LuaScriptMgr.GetVector3(L, 2);
			int characterIndexAtPosition2 = uILabel2.GetCharacterIndexAtPosition(vector2);
			LuaScriptMgr.Push(L, characterIndexAtPosition2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: UILabel.GetCharacterIndexAtPosition");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetWordAtPosition(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(UILabel), typeof(LuaTable)))
		{
			UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
			Vector2 vector = LuaScriptMgr.GetVector2(L, 2);
			string wordAtPosition = uILabel.GetWordAtPosition(vector);
			LuaScriptMgr.Push(L, wordAtPosition);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(UILabel), typeof(LuaTable)))
		{
			UILabel uILabel2 = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
			Vector3 vector2 = LuaScriptMgr.GetVector3(L, 2);
			string wordAtPosition2 = uILabel2.GetWordAtPosition(vector2);
			LuaScriptMgr.Push(L, wordAtPosition2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: UILabel.GetWordAtPosition");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetWordAtCharacterIndex(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
		int characterIndex = (int)LuaScriptMgr.GetNumber(L, 2);
		string wordAtCharacterIndex = uILabel.GetWordAtCharacterIndex(characterIndex);
		LuaScriptMgr.Push(L, wordAtCharacterIndex);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetUrlAtPosition(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(UILabel), typeof(LuaTable)))
		{
			UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
			Vector2 vector = LuaScriptMgr.GetVector2(L, 2);
			string urlAtPosition = uILabel.GetUrlAtPosition(vector);
			LuaScriptMgr.Push(L, urlAtPosition);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(UILabel), typeof(LuaTable)))
		{
			UILabel uILabel2 = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
			Vector3 vector2 = LuaScriptMgr.GetVector3(L, 2);
			string urlAtPosition2 = uILabel2.GetUrlAtPosition(vector2);
			LuaScriptMgr.Push(L, urlAtPosition2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: UILabel.GetUrlAtPosition");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetUrlAtCharacterIndex(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
		int characterIndex = (int)LuaScriptMgr.GetNumber(L, 2);
		string urlAtCharacterIndex = uILabel.GetUrlAtCharacterIndex(characterIndex);
		LuaScriptMgr.Push(L, urlAtCharacterIndex);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCharacterIndex(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
		int currentIndex = (int)LuaScriptMgr.GetNumber(L, 2);
		KeyCode key = (KeyCode)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(KeyCode)));
		int characterIndex = uILabel.GetCharacterIndex(currentIndex, key);
		LuaScriptMgr.Push(L, characterIndex);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PrintOverlay(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 7);
		UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
		int start = (int)LuaScriptMgr.GetNumber(L, 2);
		int end = (int)LuaScriptMgr.GetNumber(L, 3);
		UIGeometry caret = (UIGeometry)LuaScriptMgr.GetNetObject(L, 4, typeof(UIGeometry));
		UIGeometry highlight = (UIGeometry)LuaScriptMgr.GetNetObject(L, 5, typeof(UIGeometry));
		Color color = LuaScriptMgr.GetColor(L, 6);
		Color color2 = LuaScriptMgr.GetColor(L, 7);
		uILabel.PrintOverlay(start, end, caret, highlight, color, color2);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnFill(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
		BetterList<Vector3> verts = (BetterList<Vector3>)LuaScriptMgr.GetNetObject(L, 2, typeof(BetterList<Vector3>));
		BetterList<Vector2> uvs = (BetterList<Vector2>)LuaScriptMgr.GetNetObject(L, 3, typeof(BetterList<Vector2>));
		BetterList<Color32> cols = (BetterList<Color32>)LuaScriptMgr.GetNetObject(L, 4, typeof(BetterList<Color32>));
		uILabel.OnFill(verts, uvs, cols);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ApplyOffset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
		BetterList<Vector3> verts = (BetterList<Vector3>)LuaScriptMgr.GetNetObject(L, 2, typeof(BetterList<Vector3>));
		int start = (int)LuaScriptMgr.GetNumber(L, 3);
		Vector2 v = uILabel.ApplyOffset(verts, start);
		LuaScriptMgr.Push(L, v);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateOffsetToFit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		int d = uILabel.CalculateOffsetToFit(luaString);
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetCurrentProgress(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
		uILabel.SetCurrentProgress();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetCurrentPercent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
		uILabel.SetCurrentPercent();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetCurrentSelection(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
		uILabel.SetCurrentSelection();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Wrap(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 3)
		{
			UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
			string luaString = LuaScriptMgr.GetLuaString(L, 2);
			string str = null;
			bool b = uILabel.Wrap(luaString, out str);
			LuaScriptMgr.Push(L, b);
			LuaScriptMgr.Push(L, str);
			return 2;
		}
		if (num == 4)
		{
			UILabel uILabel2 = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
			string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
			string str2 = null;
			int height = (int)LuaScriptMgr.GetNumber(L, 4);
			bool b2 = uILabel2.Wrap(luaString2, out str2, height);
			LuaScriptMgr.Push(L, b2);
			LuaScriptMgr.Push(L, str2);
			return 2;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: UILabel.Wrap");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateNGUIText(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UILabel uILabel = (UILabel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
		uILabel.UpdateNGUIText();
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
