using com.tencent.pandora;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Lua_UIInput : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Validate(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			string val;
			LuaObject.checkType(l, 2, out val);
			string s = uIInput.Validate(val);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, s);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Submit(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			uIInput.Submit();
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
	public static int UpdateLabel(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			uIInput.UpdateLabel();
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
	public static int RemoveFocus(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			uIInput.RemoveFocus();
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
	public static int SaveValue(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			uIInput.SaveValue();
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
	public static int LoadValue(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			uIInput.LoadValue();
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
			LuaObject.pushValue(l, UIInput.current);
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
			UIInput current;
			LuaObject.checkType<UIInput>(l, 2, out current);
			UIInput.current = current;
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
	public static int get_selection(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, UIInput.selection);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_selection(IntPtr l)
	{
		int result;
		try
		{
			UIInput selection;
			LuaObject.checkType<UIInput>(l, 2, out selection);
			UIInput.selection = selection;
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
	public static int get_label(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIInput.label);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_label(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			UILabel label;
			LuaObject.checkType<UILabel>(l, 2, out label);
			uIInput.label = label;
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
	public static int get_inputType(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIInput.inputType);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_inputType(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			UIInput.InputType inputType;
			LuaObject.checkEnum<UIInput.InputType>(l, 2, out inputType);
			uIInput.inputType = inputType;
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
	public static int get_keyboardType(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIInput.keyboardType);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_keyboardType(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			UIInput.KeyboardType keyboardType;
			LuaObject.checkEnum<UIInput.KeyboardType>(l, 2, out keyboardType);
			uIInput.keyboardType = keyboardType;
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
	public static int get_validation(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIInput.validation);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_validation(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			UIInput.Validation validation;
			LuaObject.checkEnum<UIInput.Validation>(l, 2, out validation);
			uIInput.validation = validation;
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
	public static int get_characterLimit(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIInput.characterLimit);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_characterLimit(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			int characterLimit;
			LuaObject.checkType(l, 2, out characterLimit);
			uIInput.characterLimit = characterLimit;
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
	public static int get_savedAs(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIInput.savedAs);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_savedAs(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			string savedAs;
			LuaObject.checkType(l, 2, out savedAs);
			uIInput.savedAs = savedAs;
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
	public static int get_selectOnTab(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIInput.selectOnTab);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_selectOnTab(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			GameObject selectOnTab;
			LuaObject.checkType<GameObject>(l, 2, out selectOnTab);
			uIInput.selectOnTab = selectOnTab;
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
	public static int get_activeTextColor(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIInput.activeTextColor);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_activeTextColor(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			Color activeTextColor;
			LuaObject.checkType(l, 2, out activeTextColor);
			uIInput.activeTextColor = activeTextColor;
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
	public static int get_caretColor(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIInput.caretColor);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_caretColor(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			Color caretColor;
			LuaObject.checkType(l, 2, out caretColor);
			uIInput.caretColor = caretColor;
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
	public static int get_selectionColor(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIInput.selectionColor);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_selectionColor(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			Color selectionColor;
			LuaObject.checkType(l, 2, out selectionColor);
			uIInput.selectionColor = selectionColor;
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
	public static int get_onSubmit(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIInput.onSubmit);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_onSubmit(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			List<EventDelegate> onSubmit;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onSubmit);
			uIInput.onSubmit = onSubmit;
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
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIInput.onChange);
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
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			List<EventDelegate> onChange;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onChange);
			uIInput.onChange = onChange;
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
	public static int get_onKeyTriggered(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIInput.onKeyTriggered);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_onKeyTriggered(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			List<EventDelegate> onKeyTriggered;
			LuaObject.checkType<List<EventDelegate>>(l, 2, out onKeyTriggered);
			uIInput.onKeyTriggered = onKeyTriggered;
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
	public static int set_onValidate(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			UIInput.OnValidate onValidate;
			int num = LuaDelegation.checkDelegate(l, 2, out onValidate);
			if (num == 0)
			{
				uIInput.onValidate = onValidate;
			}
			else if (num == 1)
			{
				UIInput expr_30 = uIInput;
				expr_30.onValidate = (UIInput.OnValidate)Delegate.Combine(expr_30.onValidate, onValidate);
			}
			else if (num == 2)
			{
				UIInput expr_53 = uIInput;
				expr_53.onValidate = (UIInput.OnValidate)Delegate.Remove(expr_53.onValidate, onValidate);
			}
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
	public static int get_recentKey(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIInput.recentKey);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_recentKey(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			KeyCode recentKey;
			LuaObject.checkEnum<KeyCode>(l, 2, out recentKey);
			uIInput.recentKey = recentKey;
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
	public static int get_defaultText(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIInput.defaultText);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_defaultText(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			string defaultText;
			LuaObject.checkType(l, 2, out defaultText);
			uIInput.defaultText = defaultText;
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
	public static int get_value(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIInput.value);
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
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			string value;
			LuaObject.checkType(l, 2, out value);
			uIInput.value = value;
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
	public static int get_isSelected(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIInput.isSelected);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_isSelected(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			bool isSelected;
			LuaObject.checkType(l, 2, out isSelected);
			uIInput.isSelected = isSelected;
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
	public static int get_cursorPosition(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIInput.cursorPosition);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_cursorPosition(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			int cursorPosition;
			LuaObject.checkType(l, 2, out cursorPosition);
			uIInput.cursorPosition = cursorPosition;
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
	public static int get_selectionStart(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIInput.selectionStart);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_selectionStart(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			int selectionStart;
			LuaObject.checkType(l, 2, out selectionStart);
			uIInput.selectionStart = selectionStart;
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
	public static int get_selectionEnd(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIInput.selectionEnd);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_selectionEnd(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			int selectionEnd;
			LuaObject.checkType(l, 2, out selectionEnd);
			uIInput.selectionEnd = selectionEnd;
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
	public static int get_caret(IntPtr l)
	{
		int result;
		try
		{
			UIInput uIInput = (UIInput)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIInput.caret);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	public static void reg(IntPtr l)
	{
		LuaObject.getTypeTable(l, "UIInput");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIInput.Validate));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIInput.Submit));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIInput.UpdateLabel));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIInput.RemoveFocus));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIInput.SaveValue));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIInput.LoadValue));
		LuaObject.addMember(l, "current", new LuaCSFunction(Lua_UIInput.get_current), new LuaCSFunction(Lua_UIInput.set_current), false);
		LuaObject.addMember(l, "selection", new LuaCSFunction(Lua_UIInput.get_selection), new LuaCSFunction(Lua_UIInput.set_selection), false);
		LuaObject.addMember(l, "label", new LuaCSFunction(Lua_UIInput.get_label), new LuaCSFunction(Lua_UIInput.set_label), true);
		LuaObject.addMember(l, "inputType", new LuaCSFunction(Lua_UIInput.get_inputType), new LuaCSFunction(Lua_UIInput.set_inputType), true);
		LuaObject.addMember(l, "keyboardType", new LuaCSFunction(Lua_UIInput.get_keyboardType), new LuaCSFunction(Lua_UIInput.set_keyboardType), true);
		LuaObject.addMember(l, "validation", new LuaCSFunction(Lua_UIInput.get_validation), new LuaCSFunction(Lua_UIInput.set_validation), true);
		LuaObject.addMember(l, "characterLimit", new LuaCSFunction(Lua_UIInput.get_characterLimit), new LuaCSFunction(Lua_UIInput.set_characterLimit), true);
		LuaObject.addMember(l, "savedAs", new LuaCSFunction(Lua_UIInput.get_savedAs), new LuaCSFunction(Lua_UIInput.set_savedAs), true);
		LuaObject.addMember(l, "selectOnTab", new LuaCSFunction(Lua_UIInput.get_selectOnTab), new LuaCSFunction(Lua_UIInput.set_selectOnTab), true);
		LuaObject.addMember(l, "activeTextColor", new LuaCSFunction(Lua_UIInput.get_activeTextColor), new LuaCSFunction(Lua_UIInput.set_activeTextColor), true);
		LuaObject.addMember(l, "caretColor", new LuaCSFunction(Lua_UIInput.get_caretColor), new LuaCSFunction(Lua_UIInput.set_caretColor), true);
		LuaObject.addMember(l, "selectionColor", new LuaCSFunction(Lua_UIInput.get_selectionColor), new LuaCSFunction(Lua_UIInput.set_selectionColor), true);
		LuaObject.addMember(l, "onSubmit", new LuaCSFunction(Lua_UIInput.get_onSubmit), new LuaCSFunction(Lua_UIInput.set_onSubmit), true);
		LuaObject.addMember(l, "onChange", new LuaCSFunction(Lua_UIInput.get_onChange), new LuaCSFunction(Lua_UIInput.set_onChange), true);
		LuaObject.addMember(l, "onKeyTriggered", new LuaCSFunction(Lua_UIInput.get_onKeyTriggered), new LuaCSFunction(Lua_UIInput.set_onKeyTriggered), true);
		LuaObject.addMember(l, "onValidate", null, new LuaCSFunction(Lua_UIInput.set_onValidate), true);
		LuaObject.addMember(l, "recentKey", new LuaCSFunction(Lua_UIInput.get_recentKey), new LuaCSFunction(Lua_UIInput.set_recentKey), true);
		LuaObject.addMember(l, "defaultText", new LuaCSFunction(Lua_UIInput.get_defaultText), new LuaCSFunction(Lua_UIInput.set_defaultText), true);
		LuaObject.addMember(l, "value", new LuaCSFunction(Lua_UIInput.get_value), new LuaCSFunction(Lua_UIInput.set_value), true);
		LuaObject.addMember(l, "isSelected", new LuaCSFunction(Lua_UIInput.get_isSelected), new LuaCSFunction(Lua_UIInput.set_isSelected), true);
		LuaObject.addMember(l, "cursorPosition", new LuaCSFunction(Lua_UIInput.get_cursorPosition), new LuaCSFunction(Lua_UIInput.set_cursorPosition), true);
		LuaObject.addMember(l, "selectionStart", new LuaCSFunction(Lua_UIInput.get_selectionStart), new LuaCSFunction(Lua_UIInput.set_selectionStart), true);
		LuaObject.addMember(l, "selectionEnd", new LuaCSFunction(Lua_UIInput.get_selectionEnd), new LuaCSFunction(Lua_UIInput.set_selectionEnd), true);
		LuaObject.addMember(l, "caret", new LuaCSFunction(Lua_UIInput.get_caret), null, true);
		LuaObject.createTypeMetatable(l, null, typeof(UIInput), typeof(MonoBehaviour));
	}
}
