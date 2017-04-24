using LuaInterface;
using System;
using UnityEngine;

public class InputWrap
{
	private static Type classType = typeof(Input);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetAxis", new LuaCSFunction(InputWrap.GetAxis)),
			new LuaMethod("GetAxisRaw", new LuaCSFunction(InputWrap.GetAxisRaw)),
			new LuaMethod("GetButton", new LuaCSFunction(InputWrap.GetButton)),
			new LuaMethod("GetButtonDown", new LuaCSFunction(InputWrap.GetButtonDown)),
			new LuaMethod("GetButtonUp", new LuaCSFunction(InputWrap.GetButtonUp)),
			new LuaMethod("GetKey", new LuaCSFunction(InputWrap.GetKey)),
			new LuaMethod("GetKeyDown", new LuaCSFunction(InputWrap.GetKeyDown)),
			new LuaMethod("GetKeyUp", new LuaCSFunction(InputWrap.GetKeyUp)),
			new LuaMethod("GetJoystickNames", new LuaCSFunction(InputWrap.GetJoystickNames)),
			new LuaMethod("GetMouseButton", new LuaCSFunction(InputWrap.GetMouseButton)),
			new LuaMethod("GetMouseButtonDown", new LuaCSFunction(InputWrap.GetMouseButtonDown)),
			new LuaMethod("GetMouseButtonUp", new LuaCSFunction(InputWrap.GetMouseButtonUp)),
			new LuaMethod("ResetInputAxes", new LuaCSFunction(InputWrap.ResetInputAxes)),
			new LuaMethod("GetAccelerationEvent", new LuaCSFunction(InputWrap.GetAccelerationEvent)),
			new LuaMethod("GetTouch", new LuaCSFunction(InputWrap.GetTouch)),
			new LuaMethod("New", new LuaCSFunction(InputWrap._CreateInput)),
			new LuaMethod("GetClassType", new LuaCSFunction(InputWrap.GetClassType))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("compensateSensors", new LuaCSFunction(InputWrap.get_compensateSensors), new LuaCSFunction(InputWrap.set_compensateSensors)),
			new LuaField("gyro", new LuaCSFunction(InputWrap.get_gyro), null),
			new LuaField("mousePosition", new LuaCSFunction(InputWrap.get_mousePosition), null),
			new LuaField("mouseScrollDelta", new LuaCSFunction(InputWrap.get_mouseScrollDelta), null),
			new LuaField("mousePresent", new LuaCSFunction(InputWrap.get_mousePresent), null),
			new LuaField("simulateMouseWithTouches", new LuaCSFunction(InputWrap.get_simulateMouseWithTouches), new LuaCSFunction(InputWrap.set_simulateMouseWithTouches)),
			new LuaField("anyKey", new LuaCSFunction(InputWrap.get_anyKey), null),
			new LuaField("anyKeyDown", new LuaCSFunction(InputWrap.get_anyKeyDown), null),
			new LuaField("inputString", new LuaCSFunction(InputWrap.get_inputString), null),
			new LuaField("acceleration", new LuaCSFunction(InputWrap.get_acceleration), null),
			new LuaField("accelerationEvents", new LuaCSFunction(InputWrap.get_accelerationEvents), null),
			new LuaField("accelerationEventCount", new LuaCSFunction(InputWrap.get_accelerationEventCount), null),
			new LuaField("touches", new LuaCSFunction(InputWrap.get_touches), null),
			new LuaField("touchCount", new LuaCSFunction(InputWrap.get_touchCount), null),
			new LuaField("touchSupported", new LuaCSFunction(InputWrap.get_touchSupported), null),
			new LuaField("multiTouchEnabled", new LuaCSFunction(InputWrap.get_multiTouchEnabled), new LuaCSFunction(InputWrap.set_multiTouchEnabled)),
			new LuaField("location", new LuaCSFunction(InputWrap.get_location), null),
			new LuaField("compass", new LuaCSFunction(InputWrap.get_compass), null),
			new LuaField("deviceOrientation", new LuaCSFunction(InputWrap.get_deviceOrientation), null),
			new LuaField("imeCompositionMode", new LuaCSFunction(InputWrap.get_imeCompositionMode), new LuaCSFunction(InputWrap.set_imeCompositionMode)),
			new LuaField("compositionString", new LuaCSFunction(InputWrap.get_compositionString), null),
			new LuaField("imeIsSelected", new LuaCSFunction(InputWrap.get_imeIsSelected), null),
			new LuaField("compositionCursorPos", new LuaCSFunction(InputWrap.get_compositionCursorPos), new LuaCSFunction(InputWrap.set_compositionCursorPos))
		};
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Input", typeof(Input), regs, fields, typeof(object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateInput(IntPtr L)
	{
		if (LuaDLL.lua_gettop(L) == 0)
		{
			Input o = new Input();
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Input.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, InputWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_compensateSensors(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.compensateSensors);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gyro(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Input.gyro);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mousePosition(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.mousePosition);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mouseScrollDelta(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.mouseScrollDelta);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mousePresent(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.mousePresent);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_simulateMouseWithTouches(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.simulateMouseWithTouches);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_anyKey(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.anyKey);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_anyKeyDown(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.anyKeyDown);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_inputString(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.inputString);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_acceleration(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.acceleration);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_accelerationEvents(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, Input.accelerationEvents);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_accelerationEventCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.accelerationEventCount);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_touches(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, Input.touches);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_touchCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.touchCount);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_touchSupported(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.touchSupported);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_multiTouchEnabled(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.multiTouchEnabled);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_location(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Input.location);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_compass(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Input.compass);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_deviceOrientation(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.deviceOrientation);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_imeCompositionMode(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.imeCompositionMode);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_compositionString(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.compositionString);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_imeIsSelected(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.imeIsSelected);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_compositionCursorPos(IntPtr L)
	{
		LuaScriptMgr.Push(L, Input.compositionCursorPos);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_compensateSensors(IntPtr L)
	{
		Input.compensateSensors = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_simulateMouseWithTouches(IntPtr L)
	{
		Input.simulateMouseWithTouches = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_multiTouchEnabled(IntPtr L)
	{
		Input.multiTouchEnabled = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_imeCompositionMode(IntPtr L)
	{
		Input.imeCompositionMode = (IMECompositionMode)((int)LuaScriptMgr.GetNetObject(L, 3, typeof(IMECompositionMode)));
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_compositionCursorPos(IntPtr L)
	{
		Input.compositionCursorPos = LuaScriptMgr.GetVector2(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAxis(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		float axis = Input.GetAxis(luaString);
		LuaScriptMgr.Push(L, axis);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAxisRaw(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		float axisRaw = Input.GetAxisRaw(luaString);
		LuaScriptMgr.Push(L, axisRaw);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetButton(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		bool button = Input.GetButton(luaString);
		LuaScriptMgr.Push(L, button);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetButtonDown(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		bool buttonDown = Input.GetButtonDown(luaString);
		LuaScriptMgr.Push(L, buttonDown);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetButtonUp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		bool buttonUp = Input.GetButtonUp(luaString);
		LuaScriptMgr.Push(L, buttonUp);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKey(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(KeyCode)))
		{
			KeyCode key = (KeyCode)((int)LuaScriptMgr.GetLuaObject(L, 1));
			bool key2 = Input.GetKey(key);
			LuaScriptMgr.Push(L, key2);
			return 1;
		}
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(string)))
		{
			string @string = LuaScriptMgr.GetString(L, 1);
			bool key3 = Input.GetKey(@string);
			LuaScriptMgr.Push(L, key3);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Input.GetKey");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKeyDown(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(KeyCode)))
		{
			KeyCode key = (KeyCode)((int)LuaScriptMgr.GetLuaObject(L, 1));
			bool keyDown = Input.GetKeyDown(key);
			LuaScriptMgr.Push(L, keyDown);
			return 1;
		}
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(string)))
		{
			string @string = LuaScriptMgr.GetString(L, 1);
			bool keyDown2 = Input.GetKeyDown(@string);
			LuaScriptMgr.Push(L, keyDown2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Input.GetKeyDown");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetKeyUp(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(KeyCode)))
		{
			KeyCode key = (KeyCode)((int)LuaScriptMgr.GetLuaObject(L, 1));
			bool keyUp = Input.GetKeyUp(key);
			LuaScriptMgr.Push(L, keyUp);
			return 1;
		}
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(string)))
		{
			string @string = LuaScriptMgr.GetString(L, 1);
			bool keyUp2 = Input.GetKeyUp(@string);
			LuaScriptMgr.Push(L, keyUp2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: Input.GetKeyUp");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetJoystickNames(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string[] joystickNames = Input.GetJoystickNames();
		LuaScriptMgr.PushArray(L, joystickNames);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetMouseButton(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int button = (int)LuaScriptMgr.GetNumber(L, 1);
		bool mouseButton = Input.GetMouseButton(button);
		LuaScriptMgr.Push(L, mouseButton);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetMouseButtonDown(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int button = (int)LuaScriptMgr.GetNumber(L, 1);
		bool mouseButtonDown = Input.GetMouseButtonDown(button);
		LuaScriptMgr.Push(L, mouseButtonDown);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetMouseButtonUp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int button = (int)LuaScriptMgr.GetNumber(L, 1);
		bool mouseButtonUp = Input.GetMouseButtonUp(button);
		LuaScriptMgr.Push(L, mouseButtonUp);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetInputAxes(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Input.ResetInputAxes();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetAccelerationEvent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int index = (int)LuaScriptMgr.GetNumber(L, 1);
		AccelerationEvent accelerationEvent = Input.GetAccelerationEvent(index);
		LuaScriptMgr.PushValue(L, accelerationEvent);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTouch(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int index = (int)LuaScriptMgr.GetNumber(L, 1);
		Touch touch = Input.GetTouch(index);
		LuaScriptMgr.Push(L, touch);
		return 1;
	}
}
