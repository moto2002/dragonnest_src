using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIInputWrap
{
	private static Type classType = typeof(UIInput);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Validate", new LuaCSFunction(UIInputWrap.Validate)),
			new LuaMethod("Submit", new LuaCSFunction(UIInputWrap.Submit)),
			new LuaMethod("UpdateLabel", new LuaCSFunction(UIInputWrap.UpdateLabel)),
			new LuaMethod("RemoveFocus", new LuaCSFunction(UIInputWrap.RemoveFocus)),
			new LuaMethod("SaveValue", new LuaCSFunction(UIInputWrap.SaveValue)),
			new LuaMethod("LoadValue", new LuaCSFunction(UIInputWrap.LoadValue)),
			new LuaMethod("New", new LuaCSFunction(UIInputWrap._CreateUIInput)),
			new LuaMethod("GetClassType", new LuaCSFunction(UIInputWrap.GetClassType)),
			new LuaMethod("__eq", new LuaCSFunction(UIInputWrap.Lua_Eq))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("current", new LuaCSFunction(UIInputWrap.get_current), new LuaCSFunction(UIInputWrap.set_current)),
			new LuaField("selection", new LuaCSFunction(UIInputWrap.get_selection), new LuaCSFunction(UIInputWrap.set_selection)),
			new LuaField("label", new LuaCSFunction(UIInputWrap.get_label), new LuaCSFunction(UIInputWrap.set_label)),
			new LuaField("inputType", new LuaCSFunction(UIInputWrap.get_inputType), new LuaCSFunction(UIInputWrap.set_inputType)),
			new LuaField("keyboardType", new LuaCSFunction(UIInputWrap.get_keyboardType), new LuaCSFunction(UIInputWrap.set_keyboardType)),
			new LuaField("validation", new LuaCSFunction(UIInputWrap.get_validation), new LuaCSFunction(UIInputWrap.set_validation)),
			new LuaField("characterLimit", new LuaCSFunction(UIInputWrap.get_characterLimit), new LuaCSFunction(UIInputWrap.set_characterLimit)),
			new LuaField("savedAs", new LuaCSFunction(UIInputWrap.get_savedAs), new LuaCSFunction(UIInputWrap.set_savedAs)),
			new LuaField("selectOnTab", new LuaCSFunction(UIInputWrap.get_selectOnTab), new LuaCSFunction(UIInputWrap.set_selectOnTab)),
			new LuaField("activeTextColor", new LuaCSFunction(UIInputWrap.get_activeTextColor), new LuaCSFunction(UIInputWrap.set_activeTextColor)),
			new LuaField("caretColor", new LuaCSFunction(UIInputWrap.get_caretColor), new LuaCSFunction(UIInputWrap.set_caretColor)),
			new LuaField("selectionColor", new LuaCSFunction(UIInputWrap.get_selectionColor), new LuaCSFunction(UIInputWrap.set_selectionColor)),
			new LuaField("onSubmit", new LuaCSFunction(UIInputWrap.get_onSubmit), new LuaCSFunction(UIInputWrap.set_onSubmit)),
			new LuaField("onChange", new LuaCSFunction(UIInputWrap.get_onChange), new LuaCSFunction(UIInputWrap.set_onChange)),
			new LuaField("onKeyTriggered", new LuaCSFunction(UIInputWrap.get_onKeyTriggered), new LuaCSFunction(UIInputWrap.set_onKeyTriggered)),
			new LuaField("onValidate", new LuaCSFunction(UIInputWrap.get_onValidate), new LuaCSFunction(UIInputWrap.set_onValidate)),
			new LuaField("recentKey", new LuaCSFunction(UIInputWrap.get_recentKey), new LuaCSFunction(UIInputWrap.set_recentKey)),
			new LuaField("defaultText", new LuaCSFunction(UIInputWrap.get_defaultText), new LuaCSFunction(UIInputWrap.set_defaultText)),
			new LuaField("value", new LuaCSFunction(UIInputWrap.get_value), new LuaCSFunction(UIInputWrap.set_value)),
			new LuaField("isSelected", new LuaCSFunction(UIInputWrap.get_isSelected), new LuaCSFunction(UIInputWrap.set_isSelected)),
			new LuaField("cursorPosition", new LuaCSFunction(UIInputWrap.get_cursorPosition), new LuaCSFunction(UIInputWrap.set_cursorPosition)),
			new LuaField("selectionStart", new LuaCSFunction(UIInputWrap.get_selectionStart), new LuaCSFunction(UIInputWrap.set_selectionStart)),
			new LuaField("selectionEnd", new LuaCSFunction(UIInputWrap.get_selectionEnd), new LuaCSFunction(UIInputWrap.set_selectionEnd)),
			new LuaField("caret", new LuaCSFunction(UIInputWrap.get_caret), null)
		};
		LuaScriptMgr.RegisterLib(L, "UIInput", typeof(UIInput), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUIInput(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIInput class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIInputWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_current(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIInput.current);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_selection(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIInput.selection);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_label(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name label");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index label on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIInput.label);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_inputType(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name inputType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index inputType on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIInput.inputType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_keyboardType(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name keyboardType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index keyboardType on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIInput.keyboardType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_validation(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name validation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index validation on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIInput.validation);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_characterLimit(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name characterLimit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index characterLimit on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIInput.characterLimit);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_savedAs(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name savedAs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index savedAs on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIInput.savedAs);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_selectOnTab(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectOnTab");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectOnTab on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIInput.selectOnTab);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_activeTextColor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name activeTextColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index activeTextColor on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIInput.activeTextColor);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_caretColor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name caretColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index caretColor on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIInput.caretColor);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_selectionColor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectionColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectionColor on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIInput.selectionColor);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onSubmit(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onSubmit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onSubmit on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, uIInput.onSubmit);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onChange(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onChange");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onChange on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, uIInput.onChange);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onKeyTriggered(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onKeyTriggered");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onKeyTriggered on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, uIInput.onKeyTriggered);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onValidate(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onValidate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onValidate on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIInput.onValidate);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_recentKey(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name recentKey");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index recentKey on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIInput.recentKey);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultText(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name defaultText");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index defaultText on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIInput.defaultText);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_value(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name value");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index value on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIInput.value);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isSelected(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isSelected");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isSelected on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIInput.isSelected);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cursorPosition(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cursorPosition");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cursorPosition on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIInput.cursorPosition);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_selectionStart(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectionStart");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectionStart on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIInput.selectionStart);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_selectionEnd(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectionEnd");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectionEnd on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIInput.selectionEnd);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_caret(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name caret");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index caret on a nil value");
			}
		}
		LuaScriptMgr.Push(L, uIInput.caret);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_current(IntPtr L)
	{
		UIInput.current = (UIInput)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIInput));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_selection(IntPtr L)
	{
		UIInput.selection = (UIInput)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIInput));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_label(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name label");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index label on a nil value");
			}
		}
		uIInput.label = (UILabel)LuaScriptMgr.GetUnityObject(L, 3, typeof(UILabel));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_inputType(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name inputType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index inputType on a nil value");
			}
		}
		uIInput.inputType = (UIInput.InputType)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UIInput.InputType)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_keyboardType(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name keyboardType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index keyboardType on a nil value");
			}
		}
		uIInput.keyboardType = (UIInput.KeyboardType)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UIInput.KeyboardType)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_validation(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name validation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index validation on a nil value");
			}
		}
		uIInput.validation = (UIInput.Validation)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(UIInput.Validation)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_characterLimit(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name characterLimit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index characterLimit on a nil value");
			}
		}
		uIInput.characterLimit = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_savedAs(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name savedAs");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index savedAs on a nil value");
			}
		}
		uIInput.savedAs = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_selectOnTab(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectOnTab");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectOnTab on a nil value");
			}
		}
		uIInput.selectOnTab = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_activeTextColor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name activeTextColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index activeTextColor on a nil value");
			}
		}
		uIInput.activeTextColor = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_caretColor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name caretColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index caretColor on a nil value");
			}
		}
		uIInput.caretColor = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_selectionColor(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectionColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectionColor on a nil value");
			}
		}
		uIInput.selectionColor = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onSubmit(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onSubmit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onSubmit on a nil value");
			}
		}
		uIInput.onSubmit = (List<EventDelegate>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<EventDelegate>));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onChange(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onChange");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onChange on a nil value");
			}
		}
		uIInput.onChange = (List<EventDelegate>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<EventDelegate>));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onKeyTriggered(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onKeyTriggered");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onKeyTriggered on a nil value");
			}
		}
		uIInput.onKeyTriggered = (List<EventDelegate>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<EventDelegate>));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onValidate(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onValidate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onValidate on a nil value");
			}
		}
		LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
		if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
		{
			uIInput.onValidate = (UIInput.OnValidate)LuaScriptMgr.GetNetObject(L, 3, typeof(UIInput.OnValidate));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
			uIInput.onValidate = delegate(string param0, int param1, char param2)
			{
				int oldTop = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				LuaScriptMgr.Push(L, param1);
				LuaScriptMgr.Push(L, param2);
				func.PCall(oldTop, 3);
				object[] array = func.PopValues(oldTop);
				func.EndPCall(oldTop);
				return (char)array[0];
			};
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_recentKey(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name recentKey");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index recentKey on a nil value");
			}
		}
		uIInput.recentKey = (KeyCode)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(KeyCode)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_defaultText(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name defaultText");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index defaultText on a nil value");
			}
		}
		uIInput.defaultText = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_value(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name value");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index value on a nil value");
			}
		}
		uIInput.value = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isSelected(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isSelected");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isSelected on a nil value");
			}
		}
		uIInput.isSelected = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cursorPosition(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cursorPosition");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cursorPosition on a nil value");
			}
		}
		uIInput.cursorPosition = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_selectionStart(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectionStart");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectionStart on a nil value");
			}
		}
		uIInput.selectionStart = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_selectionEnd(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		UIInput uIInput = (UIInput)luaObject;
		if (uIInput == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name selectionEnd");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index selectionEnd on a nil value");
			}
		}
		uIInput.selectionEnd = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Validate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIInput uIInput = (UIInput)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIInput");
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		string str = uIInput.Validate(luaString);
		LuaScriptMgr.Push(L, str);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Submit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIInput uIInput = (UIInput)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIInput");
		uIInput.Submit();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateLabel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIInput uIInput = (UIInput)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIInput");
		uIInput.UpdateLabel();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveFocus(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIInput uIInput = (UIInput)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIInput");
		uIInput.RemoveFocus();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SaveValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIInput uIInput = (UIInput)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIInput");
		uIInput.SaveValue();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIInput uIInput = (UIInput)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIInput");
		uIInput.LoadValue();
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
