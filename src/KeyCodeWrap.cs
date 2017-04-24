using LuaInterface;
using System;
using UnityEngine;

public class KeyCodeWrap
{
	private static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("None", new LuaCSFunction(KeyCodeWrap.GetNone)),
		new LuaMethod("Backspace", new LuaCSFunction(KeyCodeWrap.GetBackspace)),
		new LuaMethod("Delete", new LuaCSFunction(KeyCodeWrap.GetDelete)),
		new LuaMethod("Tab", new LuaCSFunction(KeyCodeWrap.GetTab)),
		new LuaMethod("Clear", new LuaCSFunction(KeyCodeWrap.GetClear)),
		new LuaMethod("Return", new LuaCSFunction(KeyCodeWrap.GetReturn)),
		new LuaMethod("Pause", new LuaCSFunction(KeyCodeWrap.GetPause)),
		new LuaMethod("Escape", new LuaCSFunction(KeyCodeWrap.GetEscape)),
		new LuaMethod("Space", new LuaCSFunction(KeyCodeWrap.GetSpace)),
		new LuaMethod("Keypad0", new LuaCSFunction(KeyCodeWrap.GetKeypad0)),
		new LuaMethod("Keypad1", new LuaCSFunction(KeyCodeWrap.GetKeypad1)),
		new LuaMethod("Keypad2", new LuaCSFunction(KeyCodeWrap.GetKeypad2)),
		new LuaMethod("Keypad3", new LuaCSFunction(KeyCodeWrap.GetKeypad3)),
		new LuaMethod("Keypad4", new LuaCSFunction(KeyCodeWrap.GetKeypad4)),
		new LuaMethod("Keypad5", new LuaCSFunction(KeyCodeWrap.GetKeypad5)),
		new LuaMethod("Keypad6", new LuaCSFunction(KeyCodeWrap.GetKeypad6)),
		new LuaMethod("Keypad7", new LuaCSFunction(KeyCodeWrap.GetKeypad7)),
		new LuaMethod("Keypad8", new LuaCSFunction(KeyCodeWrap.GetKeypad8)),
		new LuaMethod("Keypad9", new LuaCSFunction(KeyCodeWrap.GetKeypad9)),
		new LuaMethod("KeypadPeriod", new LuaCSFunction(KeyCodeWrap.GetKeypadPeriod)),
		new LuaMethod("KeypadDivide", new LuaCSFunction(KeyCodeWrap.GetKeypadDivide)),
		new LuaMethod("KeypadMultiply", new LuaCSFunction(KeyCodeWrap.GetKeypadMultiply)),
		new LuaMethod("KeypadMinus", new LuaCSFunction(KeyCodeWrap.GetKeypadMinus)),
		new LuaMethod("KeypadPlus", new LuaCSFunction(KeyCodeWrap.GetKeypadPlus)),
		new LuaMethod("KeypadEnter", new LuaCSFunction(KeyCodeWrap.GetKeypadEnter)),
		new LuaMethod("KeypadEquals", new LuaCSFunction(KeyCodeWrap.GetKeypadEquals)),
		new LuaMethod("UpArrow", new LuaCSFunction(KeyCodeWrap.GetUpArrow)),
		new LuaMethod("DownArrow", new LuaCSFunction(KeyCodeWrap.GetDownArrow)),
		new LuaMethod("RightArrow", new LuaCSFunction(KeyCodeWrap.GetRightArrow)),
		new LuaMethod("LeftArrow", new LuaCSFunction(KeyCodeWrap.GetLeftArrow)),
		new LuaMethod("Insert", new LuaCSFunction(KeyCodeWrap.GetInsert)),
		new LuaMethod("Home", new LuaCSFunction(KeyCodeWrap.GetHome)),
		new LuaMethod("End", new LuaCSFunction(KeyCodeWrap.GetEnd)),
		new LuaMethod("PageUp", new LuaCSFunction(KeyCodeWrap.GetPageUp)),
		new LuaMethod("PageDown", new LuaCSFunction(KeyCodeWrap.GetPageDown)),
		new LuaMethod("F1", new LuaCSFunction(KeyCodeWrap.GetF1)),
		new LuaMethod("F2", new LuaCSFunction(KeyCodeWrap.GetF2)),
		new LuaMethod("F3", new LuaCSFunction(KeyCodeWrap.GetF3)),
		new LuaMethod("F4", new LuaCSFunction(KeyCodeWrap.GetF4)),
		new LuaMethod("F5", new LuaCSFunction(KeyCodeWrap.GetF5)),
		new LuaMethod("F6", new LuaCSFunction(KeyCodeWrap.GetF6)),
		new LuaMethod("F7", new LuaCSFunction(KeyCodeWrap.GetF7)),
		new LuaMethod("F8", new LuaCSFunction(KeyCodeWrap.GetF8)),
		new LuaMethod("F9", new LuaCSFunction(KeyCodeWrap.GetF9)),
		new LuaMethod("F10", new LuaCSFunction(KeyCodeWrap.GetF10)),
		new LuaMethod("F11", new LuaCSFunction(KeyCodeWrap.GetF11)),
		new LuaMethod("F12", new LuaCSFunction(KeyCodeWrap.GetF12)),
		new LuaMethod("F13", new LuaCSFunction(KeyCodeWrap.GetF13)),
		new LuaMethod("F14", new LuaCSFunction(KeyCodeWrap.GetF14)),
		new LuaMethod("F15", new LuaCSFunction(KeyCodeWrap.GetF15)),
		new LuaMethod("Alpha0", new LuaCSFunction(KeyCodeWrap.GetAlpha0)),
		new LuaMethod("Alpha1", new LuaCSFunction(KeyCodeWrap.GetAlpha1)),
		new LuaMethod("Alpha2", new LuaCSFunction(KeyCodeWrap.GetAlpha2)),
		new LuaMethod("Alpha3", new LuaCSFunction(KeyCodeWrap.GetAlpha3)),
		new LuaMethod("Alpha4", new LuaCSFunction(KeyCodeWrap.GetAlpha4)),
		new LuaMethod("Alpha5", new LuaCSFunction(KeyCodeWrap.GetAlpha5)),
		new LuaMethod("Alpha6", new LuaCSFunction(KeyCodeWrap.GetAlpha6)),
		new LuaMethod("Alpha7", new LuaCSFunction(KeyCodeWrap.GetAlpha7)),
		new LuaMethod("Alpha8", new LuaCSFunction(KeyCodeWrap.GetAlpha8)),
		new LuaMethod("Alpha9", new LuaCSFunction(KeyCodeWrap.GetAlpha9)),
		new LuaMethod("Exclaim", new LuaCSFunction(KeyCodeWrap.GetExclaim)),
		new LuaMethod("DoubleQuote", new LuaCSFunction(KeyCodeWrap.GetDoubleQuote)),
		new LuaMethod("Hash", new LuaCSFunction(KeyCodeWrap.GetHash)),
		new LuaMethod("Dollar", new LuaCSFunction(KeyCodeWrap.GetDollar)),
		new LuaMethod("Ampersand", new LuaCSFunction(KeyCodeWrap.GetAmpersand)),
		new LuaMethod("Quote", new LuaCSFunction(KeyCodeWrap.GetQuote)),
		new LuaMethod("LeftParen", new LuaCSFunction(KeyCodeWrap.GetLeftParen)),
		new LuaMethod("RightParen", new LuaCSFunction(KeyCodeWrap.GetRightParen)),
		new LuaMethod("Asterisk", new LuaCSFunction(KeyCodeWrap.GetAsterisk)),
		new LuaMethod("Plus", new LuaCSFunction(KeyCodeWrap.GetPlus)),
		new LuaMethod("Comma", new LuaCSFunction(KeyCodeWrap.GetComma)),
		new LuaMethod("Minus", new LuaCSFunction(KeyCodeWrap.GetMinus)),
		new LuaMethod("Period", new LuaCSFunction(KeyCodeWrap.GetPeriod)),
		new LuaMethod("Slash", new LuaCSFunction(KeyCodeWrap.GetSlash)),
		new LuaMethod("Colon", new LuaCSFunction(KeyCodeWrap.GetColon)),
		new LuaMethod("Semicolon", new LuaCSFunction(KeyCodeWrap.GetSemicolon)),
		new LuaMethod("Less", new LuaCSFunction(KeyCodeWrap.GetLess)),
		new LuaMethod("Equals", new LuaCSFunction(KeyCodeWrap.GetEquals)),
		new LuaMethod("Greater", new LuaCSFunction(KeyCodeWrap.GetGreater)),
		new LuaMethod("Question", new LuaCSFunction(KeyCodeWrap.GetQuestion)),
		new LuaMethod("At", new LuaCSFunction(KeyCodeWrap.GetAt)),
		new LuaMethod("LeftBracket", new LuaCSFunction(KeyCodeWrap.GetLeftBracket)),
		new LuaMethod("Backslash", new LuaCSFunction(KeyCodeWrap.GetBackslash)),
		new LuaMethod("RightBracket", new LuaCSFunction(KeyCodeWrap.GetRightBracket)),
		new LuaMethod("Caret", new LuaCSFunction(KeyCodeWrap.GetCaret)),
		new LuaMethod("Underscore", new LuaCSFunction(KeyCodeWrap.GetUnderscore)),
		new LuaMethod("BackQuote", new LuaCSFunction(KeyCodeWrap.GetBackQuote)),
		new LuaMethod("A", new LuaCSFunction(KeyCodeWrap.GetA)),
		new LuaMethod("B", new LuaCSFunction(KeyCodeWrap.GetB)),
		new LuaMethod("C", new LuaCSFunction(KeyCodeWrap.GetC)),
		new LuaMethod("D", new LuaCSFunction(KeyCodeWrap.GetD)),
		new LuaMethod("E", new LuaCSFunction(KeyCodeWrap.GetE)),
		new LuaMethod("F", new LuaCSFunction(KeyCodeWrap.GetF)),
		new LuaMethod("G", new LuaCSFunction(KeyCodeWrap.GetG)),
		new LuaMethod("H", new LuaCSFunction(KeyCodeWrap.GetH)),
		new LuaMethod("I", new LuaCSFunction(KeyCodeWrap.GetI)),
		new LuaMethod("J", new LuaCSFunction(KeyCodeWrap.GetJ)),
		new LuaMethod("K", new LuaCSFunction(KeyCodeWrap.GetK)),
		new LuaMethod("L", new LuaCSFunction(KeyCodeWrap.GetL)),
		new LuaMethod("M", new LuaCSFunction(KeyCodeWrap.GetM)),
		new LuaMethod("N", new LuaCSFunction(KeyCodeWrap.GetN)),
		new LuaMethod("O", new LuaCSFunction(KeyCodeWrap.GetO)),
		new LuaMethod("P", new LuaCSFunction(KeyCodeWrap.GetP)),
		new LuaMethod("Q", new LuaCSFunction(KeyCodeWrap.GetQ)),
		new LuaMethod("R", new LuaCSFunction(KeyCodeWrap.GetR)),
		new LuaMethod("S", new LuaCSFunction(KeyCodeWrap.GetS)),
		new LuaMethod("T", new LuaCSFunction(KeyCodeWrap.GetT)),
		new LuaMethod("U", new LuaCSFunction(KeyCodeWrap.GetU)),
		new LuaMethod("V", new LuaCSFunction(KeyCodeWrap.GetV)),
		new LuaMethod("W", new LuaCSFunction(KeyCodeWrap.GetW)),
		new LuaMethod("X", new LuaCSFunction(KeyCodeWrap.GetX)),
		new LuaMethod("Y", new LuaCSFunction(KeyCodeWrap.GetY)),
		new LuaMethod("Z", new LuaCSFunction(KeyCodeWrap.GetZ)),
		new LuaMethod("Numlock", new LuaCSFunction(KeyCodeWrap.GetNumlock)),
		new LuaMethod("CapsLock", new LuaCSFunction(KeyCodeWrap.GetCapsLock)),
		new LuaMethod("ScrollLock", new LuaCSFunction(KeyCodeWrap.GetScrollLock)),
		new LuaMethod("RightShift", new LuaCSFunction(KeyCodeWrap.GetRightShift)),
		new LuaMethod("LeftShift", new LuaCSFunction(KeyCodeWrap.GetLeftShift)),
		new LuaMethod("RightControl", new LuaCSFunction(KeyCodeWrap.GetRightControl)),
		new LuaMethod("LeftControl", new LuaCSFunction(KeyCodeWrap.GetLeftControl)),
		new LuaMethod("RightAlt", new LuaCSFunction(KeyCodeWrap.GetRightAlt)),
		new LuaMethod("LeftAlt", new LuaCSFunction(KeyCodeWrap.GetLeftAlt)),
		new LuaMethod("LeftCommand", new LuaCSFunction(KeyCodeWrap.GetLeftCommand)),
		new LuaMethod("LeftApple", new LuaCSFunction(KeyCodeWrap.GetLeftApple)),
		new LuaMethod("LeftWindows", new LuaCSFunction(KeyCodeWrap.GetLeftWindows)),
		new LuaMethod("RightCommand", new LuaCSFunction(KeyCodeWrap.GetRightCommand)),
		new LuaMethod("RightApple", new LuaCSFunction(KeyCodeWrap.GetRightApple)),
		new LuaMethod("RightWindows", new LuaCSFunction(KeyCodeWrap.GetRightWindows)),
		new LuaMethod("AltGr", new LuaCSFunction(KeyCodeWrap.GetAltGr)),
		new LuaMethod("Help", new LuaCSFunction(KeyCodeWrap.GetHelp)),
		new LuaMethod("Print", new LuaCSFunction(KeyCodeWrap.GetPrint)),
		new LuaMethod("SysReq", new LuaCSFunction(KeyCodeWrap.GetSysReq)),
		new LuaMethod("Break", new LuaCSFunction(KeyCodeWrap.GetBreak)),
		new LuaMethod("Menu", new LuaCSFunction(KeyCodeWrap.GetMenu)),
		new LuaMethod("Mouse0", new LuaCSFunction(KeyCodeWrap.GetMouse0)),
		new LuaMethod("Mouse1", new LuaCSFunction(KeyCodeWrap.GetMouse1)),
		new LuaMethod("Mouse2", new LuaCSFunction(KeyCodeWrap.GetMouse2)),
		new LuaMethod("Mouse3", new LuaCSFunction(KeyCodeWrap.GetMouse3)),
		new LuaMethod("Mouse4", new LuaCSFunction(KeyCodeWrap.GetMouse4)),
		new LuaMethod("Mouse5", new LuaCSFunction(KeyCodeWrap.GetMouse5)),
		new LuaMethod("Mouse6", new LuaCSFunction(KeyCodeWrap.GetMouse6)),
		new LuaMethod("JoystickButton0", new LuaCSFunction(KeyCodeWrap.GetJoystickButton0)),
		new LuaMethod("JoystickButton1", new LuaCSFunction(KeyCodeWrap.GetJoystickButton1)),
		new LuaMethod("JoystickButton2", new LuaCSFunction(KeyCodeWrap.GetJoystickButton2)),
		new LuaMethod("JoystickButton3", new LuaCSFunction(KeyCodeWrap.GetJoystickButton3)),
		new LuaMethod("JoystickButton4", new LuaCSFunction(KeyCodeWrap.GetJoystickButton4)),
		new LuaMethod("JoystickButton5", new LuaCSFunction(KeyCodeWrap.GetJoystickButton5)),
		new LuaMethod("JoystickButton6", new LuaCSFunction(KeyCodeWrap.GetJoystickButton6)),
		new LuaMethod("JoystickButton7", new LuaCSFunction(KeyCodeWrap.GetJoystickButton7)),
		new LuaMethod("JoystickButton8", new LuaCSFunction(KeyCodeWrap.GetJoystickButton8)),
		new LuaMethod("JoystickButton9", new LuaCSFunction(KeyCodeWrap.GetJoystickButton9)),
		new LuaMethod("JoystickButton10", new LuaCSFunction(KeyCodeWrap.GetJoystickButton10)),
		new LuaMethod("JoystickButton11", new LuaCSFunction(KeyCodeWrap.GetJoystickButton11)),
		new LuaMethod("JoystickButton12", new LuaCSFunction(KeyCodeWrap.GetJoystickButton12)),
		new LuaMethod("JoystickButton13", new LuaCSFunction(KeyCodeWrap.GetJoystickButton13)),
		new LuaMethod("JoystickButton14", new LuaCSFunction(KeyCodeWrap.GetJoystickButton14)),
		new LuaMethod("JoystickButton15", new LuaCSFunction(KeyCodeWrap.GetJoystickButton15)),
		new LuaMethod("JoystickButton16", new LuaCSFunction(KeyCodeWrap.GetJoystickButton16)),
		new LuaMethod("JoystickButton17", new LuaCSFunction(KeyCodeWrap.GetJoystickButton17)),
		new LuaMethod("JoystickButton18", new LuaCSFunction(KeyCodeWrap.GetJoystickButton18)),
		new LuaMethod("JoystickButton19", new LuaCSFunction(KeyCodeWrap.GetJoystickButton19)),
		new LuaMethod("Joystick1Button0", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button0)),
		new LuaMethod("Joystick1Button1", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button1)),
		new LuaMethod("Joystick1Button2", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button2)),
		new LuaMethod("Joystick1Button3", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button3)),
		new LuaMethod("Joystick1Button4", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button4)),
		new LuaMethod("Joystick1Button5", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button5)),
		new LuaMethod("Joystick1Button6", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button6)),
		new LuaMethod("Joystick1Button7", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button7)),
		new LuaMethod("Joystick1Button8", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button8)),
		new LuaMethod("Joystick1Button9", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button9)),
		new LuaMethod("Joystick1Button10", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button10)),
		new LuaMethod("Joystick1Button11", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button11)),
		new LuaMethod("Joystick1Button12", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button12)),
		new LuaMethod("Joystick1Button13", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button13)),
		new LuaMethod("Joystick1Button14", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button14)),
		new LuaMethod("Joystick1Button15", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button15)),
		new LuaMethod("Joystick1Button16", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button16)),
		new LuaMethod("Joystick1Button17", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button17)),
		new LuaMethod("Joystick1Button18", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button18)),
		new LuaMethod("Joystick1Button19", new LuaCSFunction(KeyCodeWrap.GetJoystick1Button19)),
		new LuaMethod("Joystick2Button0", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button0)),
		new LuaMethod("Joystick2Button1", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button1)),
		new LuaMethod("Joystick2Button2", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button2)),
		new LuaMethod("Joystick2Button3", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button3)),
		new LuaMethod("Joystick2Button4", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button4)),
		new LuaMethod("Joystick2Button5", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button5)),
		new LuaMethod("Joystick2Button6", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button6)),
		new LuaMethod("Joystick2Button7", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button7)),
		new LuaMethod("Joystick2Button8", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button8)),
		new LuaMethod("Joystick2Button9", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button9)),
		new LuaMethod("Joystick2Button10", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button10)),
		new LuaMethod("Joystick2Button11", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button11)),
		new LuaMethod("Joystick2Button12", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button12)),
		new LuaMethod("Joystick2Button13", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button13)),
		new LuaMethod("Joystick2Button14", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button14)),
		new LuaMethod("Joystick2Button15", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button15)),
		new LuaMethod("Joystick2Button16", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button16)),
		new LuaMethod("Joystick2Button17", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button17)),
		new LuaMethod("Joystick2Button18", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button18)),
		new LuaMethod("Joystick2Button19", new LuaCSFunction(KeyCodeWrap.GetJoystick2Button19)),
		new LuaMethod("Joystick3Button0", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button0)),
		new LuaMethod("Joystick3Button1", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button1)),
		new LuaMethod("Joystick3Button2", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button2)),
		new LuaMethod("Joystick3Button3", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button3)),
		new LuaMethod("Joystick3Button4", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button4)),
		new LuaMethod("Joystick3Button5", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button5)),
		new LuaMethod("Joystick3Button6", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button6)),
		new LuaMethod("Joystick3Button7", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button7)),
		new LuaMethod("Joystick3Button8", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button8)),
		new LuaMethod("Joystick3Button9", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button9)),
		new LuaMethod("Joystick3Button10", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button10)),
		new LuaMethod("Joystick3Button11", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button11)),
		new LuaMethod("Joystick3Button12", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button12)),
		new LuaMethod("Joystick3Button13", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button13)),
		new LuaMethod("Joystick3Button14", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button14)),
		new LuaMethod("Joystick3Button15", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button15)),
		new LuaMethod("Joystick3Button16", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button16)),
		new LuaMethod("Joystick3Button17", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button17)),
		new LuaMethod("Joystick3Button18", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button18)),
		new LuaMethod("Joystick3Button19", new LuaCSFunction(KeyCodeWrap.GetJoystick3Button19)),
		new LuaMethod("Joystick4Button0", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button0)),
		new LuaMethod("Joystick4Button1", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button1)),
		new LuaMethod("Joystick4Button2", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button2)),
		new LuaMethod("Joystick4Button3", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button3)),
		new LuaMethod("Joystick4Button4", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button4)),
		new LuaMethod("Joystick4Button5", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button5)),
		new LuaMethod("Joystick4Button6", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button6)),
		new LuaMethod("Joystick4Button7", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button7)),
		new LuaMethod("Joystick4Button8", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button8)),
		new LuaMethod("Joystick4Button9", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button9)),
		new LuaMethod("Joystick4Button10", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button10)),
		new LuaMethod("Joystick4Button11", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button11)),
		new LuaMethod("Joystick4Button12", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button12)),
		new LuaMethod("Joystick4Button13", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button13)),
		new LuaMethod("Joystick4Button14", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button14)),
		new LuaMethod("Joystick4Button15", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button15)),
		new LuaMethod("Joystick4Button16", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button16)),
		new LuaMethod("Joystick4Button17", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button17)),
		new LuaMethod("Joystick4Button18", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button18)),
		new LuaMethod("Joystick4Button19", new LuaCSFunction(KeyCodeWrap.GetJoystick4Button19)),
		new LuaMethod("IntToEnum", new LuaCSFunction(KeyCodeWrap.IntToEnum))
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.KeyCode", typeof(KeyCode), KeyCodeWrap.enums);
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetNone(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.None);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetBackspace(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Backspace);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDelete(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Delete);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTab(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Tab);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClear(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Clear);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetReturn(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Return);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPause(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Pause);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetEscape(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Escape);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSpace(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Space);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKeypad0(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad0);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKeypad1(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad1);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKeypad2(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad2);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKeypad3(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad3);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKeypad4(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad4);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKeypad5(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad5);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKeypad6(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad6);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKeypad7(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad7);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKeypad8(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad8);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKeypad9(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Keypad9);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKeypadPeriod(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.KeypadPeriod);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKeypadDivide(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.KeypadDivide);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKeypadMultiply(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.KeypadMultiply);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKeypadMinus(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.KeypadMinus);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKeypadPlus(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.KeypadPlus);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKeypadEnter(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.KeypadEnter);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKeypadEquals(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.KeypadEquals);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetUpArrow(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.UpArrow);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDownArrow(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.DownArrow);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRightArrow(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.RightArrow);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLeftArrow(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.LeftArrow);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetInsert(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Insert);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetHome(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Home);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetEnd(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.End);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPageUp(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.PageUp);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPageDown(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.PageDown);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetF1(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F1);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetF2(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F2);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetF3(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F3);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetF4(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F4);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetF5(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F5);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetF6(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F6);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetF7(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F7);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetF8(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F8);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetF9(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F9);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetF10(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F10);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetF11(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F11);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetF12(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F12);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetF13(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F13);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetF14(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F14);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetF15(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F15);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAlpha0(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha0);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAlpha1(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha1);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAlpha2(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha2);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAlpha3(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha3);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAlpha4(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha4);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAlpha5(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha5);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAlpha6(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha6);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAlpha7(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha7);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAlpha8(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha8);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAlpha9(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Alpha9);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetExclaim(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Exclaim);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDoubleQuote(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.DoubleQuote);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetHash(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Hash);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDollar(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Dollar);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAmpersand(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Ampersand);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetQuote(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Quote);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLeftParen(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.LeftParen);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRightParen(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.RightParen);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAsterisk(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Asterisk);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPlus(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Plus);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetComma(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Comma);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetMinus(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Minus);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPeriod(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Period);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSlash(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Slash);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetColon(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Colon);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSemicolon(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Semicolon);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLess(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Less);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetEquals(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Equals);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetGreater(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Greater);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetQuestion(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Question);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAt(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.At);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLeftBracket(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.LeftBracket);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetBackslash(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Backslash);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRightBracket(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.RightBracket);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCaret(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Caret);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetUnderscore(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Underscore);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetBackQuote(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.BackQuote);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetA(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.A);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetB(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.B);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetC(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.C);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetD(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.D);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetE(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.E);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetF(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.F);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetG(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.G);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetH(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.H);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetI(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.I);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJ(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.J);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetK(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.K);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetL(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.L);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetM(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.M);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetN(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.N);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetO(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.O);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetP(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.P);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetQ(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Q);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetR(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.R);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetS(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.S);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetT(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.T);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetU(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.U);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetV(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.V);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetW(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.W);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetX(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.X);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetY(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Y);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetZ(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Z);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetNumlock(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Numlock);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCapsLock(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.CapsLock);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetScrollLock(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.ScrollLock);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRightShift(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.RightShift);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLeftShift(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.LeftShift);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRightControl(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.RightControl);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLeftControl(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.LeftControl);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRightAlt(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.RightAlt);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLeftAlt(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.LeftAlt);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLeftCommand(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.LeftCommand);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLeftApple(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.LeftCommand);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLeftWindows(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.LeftWindows);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRightCommand(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.RightCommand);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRightApple(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.RightCommand);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRightWindows(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.RightWindows);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAltGr(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.AltGr);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetHelp(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Help);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPrint(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Print);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSysReq(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.SysReq);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetBreak(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Break);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetMenu(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Menu);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetMouse0(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Mouse0);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetMouse1(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Mouse1);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetMouse2(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Mouse2);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetMouse3(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Mouse3);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetMouse4(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Mouse4);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetMouse5(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Mouse5);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetMouse6(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Mouse6);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton0(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton0);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton1(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton1);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton2(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton2);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton3(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton3);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton4(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton4);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton5(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton5);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton6(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton6);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton7(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton7);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton8(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton8);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton9(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton9);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton10(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton10);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton11(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton11);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton12(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton12);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton13(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton13);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton14(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton14);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton15(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton15);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton16(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton16);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton17(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton17);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton18(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton18);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickButton19(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.JoystickButton19);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button0(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button0);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button1(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button1);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button2(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button2);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button3(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button3);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button4(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button4);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button5(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button5);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button6(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button6);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button7(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button7);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button8(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button8);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button9(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button9);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button10(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button10);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button11(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button11);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button12(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button12);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button13(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button13);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button14(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button14);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button15(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button15);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button16(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button16);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button17(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button17);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button18(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button18);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick1Button19(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick1Button19);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button0(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button0);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button1(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button1);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button2(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button2);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button3(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button3);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button4(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button4);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button5(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button5);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button6(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button6);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button7(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button7);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button8(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button8);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button9(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button9);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button10(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button10);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button11(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button11);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button12(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button12);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button13(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button13);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button14(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button14);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button15(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button15);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button16(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button16);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button17(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button17);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button18(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button18);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick2Button19(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick2Button19);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button0(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button0);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button1(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button1);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button2(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button2);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button3(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button3);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button4(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button4);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button5(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button5);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button6(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button6);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button7(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button7);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button8(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button8);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button9(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button9);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button10(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button10);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button11(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button11);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button12(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button12);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button13(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button13);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button14(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button14);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button15(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button15);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button16(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button16);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button17(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button17);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button18(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button18);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick3Button19(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick3Button19);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button0(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button0);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button1(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button1);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button2(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button2);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button3(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button3);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button4(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button4);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button5(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button5);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button6(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button6);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button7(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button7);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button8(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button8);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button9(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button9);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button10(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button10);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button11(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button11);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button12(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button12);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button13(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button13);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button14(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button14);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button15(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button15);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button16(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button16);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button17(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button17);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button18(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button18);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystick4Button19(IntPtr L)
	{
		LuaScriptMgr.Push(L, KeyCode.Joystick4Button19);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		KeyCode keyCode = (KeyCode)num;
		LuaScriptMgr.Push(L, keyCode);
		return 1;
	}
}
