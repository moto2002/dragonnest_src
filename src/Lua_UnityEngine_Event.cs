using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UnityEngine_Event : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				Event o = new Event();
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else if (num == 2)
			{
				Event other;
				LuaObject.checkType<Event>(l, 2, out other);
				Event o = new Event(other);
				LuaObject.pushValue(l, true);
				LuaObject.pushValue(l, o);
				result = 2;
			}
			else
			{
				result = LuaObject.error(l, "New object failed.");
			}
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetTypeForControl(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			int controlID;
			LuaObject.checkType(l, 2, out controlID);
			EventType typeForControl = @event.GetTypeForControl(controlID);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)typeForControl);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Use(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			@event.Use();
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
	public static int PopEvent_s(IntPtr l)
	{
		int result;
		try
		{
			Event outEvent;
			LuaObject.checkType<Event>(l, 1, out outEvent);
			bool b = Event.PopEvent(outEvent);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, b);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetEventCount_s(IntPtr l)
	{
		int result;
		try
		{
			int eventCount = Event.GetEventCount();
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, eventCount);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int KeyboardEvent_s(IntPtr l)
	{
		int result;
		try
		{
			string key;
			LuaObject.checkType(l, 1, out key);
			Event o = Event.KeyboardEvent(key);
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
	public static int get_rawType(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)@event.rawType);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_type(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)@event.type);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_type(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			EventType type;
			LuaObject.checkEnum<EventType>(l, 2, out type);
			@event.type = type;
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
	public static int get_mousePosition(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, @event.mousePosition);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_mousePosition(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			Vector2 mousePosition;
			LuaObject.checkType(l, 2, out mousePosition);
			@event.mousePosition = mousePosition;
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
	public static int get_delta(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, @event.delta);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_delta(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			Vector2 delta;
			LuaObject.checkType(l, 2, out delta);
			@event.delta = delta;
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
	public static int get_button(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, @event.button);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_button(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			int button;
			LuaObject.checkType(l, 2, out button);
			@event.button = button;
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
	public static int get_modifiers(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)@event.modifiers);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_modifiers(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			EventModifiers modifiers;
			LuaObject.checkEnum<EventModifiers>(l, 2, out modifiers);
			@event.modifiers = modifiers;
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
	public static int get_pressure(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, @event.pressure);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_pressure(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			float pressure;
			LuaObject.checkType(l, 2, out pressure);
			@event.pressure = pressure;
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
	public static int get_clickCount(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, @event.clickCount);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_clickCount(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			int clickCount;
			LuaObject.checkType(l, 2, out clickCount);
			@event.clickCount = clickCount;
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
	public static int get_character(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, @event.character);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_character(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			char character;
			LuaObject.checkType(l, 2, out character);
			@event.character = character;
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
	public static int get_commandName(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, @event.commandName);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_commandName(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			string commandName;
			LuaObject.checkType(l, 2, out commandName);
			@event.commandName = commandName;
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
	public static int get_keyCode(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)@event.keyCode);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_keyCode(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			KeyCode keyCode;
			LuaObject.checkEnum<KeyCode>(l, 2, out keyCode);
			@event.keyCode = keyCode;
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
	public static int get_shift(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, @event.shift);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_shift(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			bool shift;
			LuaObject.checkType(l, 2, out shift);
			@event.shift = shift;
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
	public static int get_control(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, @event.control);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_control(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			bool control;
			LuaObject.checkType(l, 2, out control);
			@event.control = control;
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
	public static int get_alt(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, @event.alt);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_alt(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			bool alt;
			LuaObject.checkType(l, 2, out alt);
			@event.alt = alt;
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
	public static int get_command(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, @event.command);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_command(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			bool command;
			LuaObject.checkType(l, 2, out command);
			@event.command = command;
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
	public static int get_capsLock(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, @event.capsLock);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_capsLock(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			bool capsLock;
			LuaObject.checkType(l, 2, out capsLock);
			@event.capsLock = capsLock;
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
	public static int get_numeric(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, @event.numeric);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_numeric(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			bool numeric;
			LuaObject.checkType(l, 2, out numeric);
			@event.numeric = numeric;
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
	public static int get_functionKey(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, @event.functionKey);
			result = 2;
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
			LuaObject.pushValue(l, Event.current);
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
			Event current;
			LuaObject.checkType<Event>(l, 2, out current);
			Event.current = current;
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
	public static int get_isKey(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, @event.isKey);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_isMouse(IntPtr l)
	{
		int result;
		try
		{
			Event @event = (Event)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, @event.isMouse);
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
		LuaObject.getTypeTable(l, "UnityEngine.Event");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Event.GetTypeForControl));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Event.Use));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Event.PopEvent_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Event.GetEventCount_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UnityEngine_Event.KeyboardEvent_s));
		LuaObject.addMember(l, "rawType", new LuaCSFunction(Lua_UnityEngine_Event.get_rawType), null, true);
		LuaObject.addMember(l, "type", new LuaCSFunction(Lua_UnityEngine_Event.get_type), new LuaCSFunction(Lua_UnityEngine_Event.set_type), true);
		LuaObject.addMember(l, "mousePosition", new LuaCSFunction(Lua_UnityEngine_Event.get_mousePosition), new LuaCSFunction(Lua_UnityEngine_Event.set_mousePosition), true);
		LuaObject.addMember(l, "delta", new LuaCSFunction(Lua_UnityEngine_Event.get_delta), new LuaCSFunction(Lua_UnityEngine_Event.set_delta), true);
		LuaObject.addMember(l, "button", new LuaCSFunction(Lua_UnityEngine_Event.get_button), new LuaCSFunction(Lua_UnityEngine_Event.set_button), true);
		LuaObject.addMember(l, "modifiers", new LuaCSFunction(Lua_UnityEngine_Event.get_modifiers), new LuaCSFunction(Lua_UnityEngine_Event.set_modifiers), true);
		LuaObject.addMember(l, "pressure", new LuaCSFunction(Lua_UnityEngine_Event.get_pressure), new LuaCSFunction(Lua_UnityEngine_Event.set_pressure), true);
		LuaObject.addMember(l, "clickCount", new LuaCSFunction(Lua_UnityEngine_Event.get_clickCount), new LuaCSFunction(Lua_UnityEngine_Event.set_clickCount), true);
		LuaObject.addMember(l, "character", new LuaCSFunction(Lua_UnityEngine_Event.get_character), new LuaCSFunction(Lua_UnityEngine_Event.set_character), true);
		LuaObject.addMember(l, "commandName", new LuaCSFunction(Lua_UnityEngine_Event.get_commandName), new LuaCSFunction(Lua_UnityEngine_Event.set_commandName), true);
		LuaObject.addMember(l, "keyCode", new LuaCSFunction(Lua_UnityEngine_Event.get_keyCode), new LuaCSFunction(Lua_UnityEngine_Event.set_keyCode), true);
		LuaObject.addMember(l, "shift", new LuaCSFunction(Lua_UnityEngine_Event.get_shift), new LuaCSFunction(Lua_UnityEngine_Event.set_shift), true);
		LuaObject.addMember(l, "control", new LuaCSFunction(Lua_UnityEngine_Event.get_control), new LuaCSFunction(Lua_UnityEngine_Event.set_control), true);
		LuaObject.addMember(l, "alt", new LuaCSFunction(Lua_UnityEngine_Event.get_alt), new LuaCSFunction(Lua_UnityEngine_Event.set_alt), true);
		LuaObject.addMember(l, "command", new LuaCSFunction(Lua_UnityEngine_Event.get_command), new LuaCSFunction(Lua_UnityEngine_Event.set_command), true);
		LuaObject.addMember(l, "capsLock", new LuaCSFunction(Lua_UnityEngine_Event.get_capsLock), new LuaCSFunction(Lua_UnityEngine_Event.set_capsLock), true);
		LuaObject.addMember(l, "numeric", new LuaCSFunction(Lua_UnityEngine_Event.get_numeric), new LuaCSFunction(Lua_UnityEngine_Event.set_numeric), true);
		LuaObject.addMember(l, "functionKey", new LuaCSFunction(Lua_UnityEngine_Event.get_functionKey), null, true);
		LuaObject.addMember(l, "current", new LuaCSFunction(Lua_UnityEngine_Event.get_current), new LuaCSFunction(Lua_UnityEngine_Event.set_current), false);
		LuaObject.addMember(l, "isKey", new LuaCSFunction(Lua_UnityEngine_Event.get_isKey), null, true);
		LuaObject.addMember(l, "isMouse", new LuaCSFunction(Lua_UnityEngine_Event.get_isMouse), null, true);
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UnityEngine_Event.constructor), typeof(Event));
	}
}
