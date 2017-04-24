using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UIKeyBinding : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_keyCode(IntPtr l)
	{
		int result;
		try
		{
			UIKeyBinding uIKeyBinding = (UIKeyBinding)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIKeyBinding.keyCode);
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
			UIKeyBinding uIKeyBinding = (UIKeyBinding)LuaObject.checkSelf(l);
			KeyCode keyCode;
			LuaObject.checkEnum<KeyCode>(l, 2, out keyCode);
			uIKeyBinding.keyCode = keyCode;
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
	public static int get_modifier(IntPtr l)
	{
		int result;
		try
		{
			UIKeyBinding uIKeyBinding = (UIKeyBinding)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIKeyBinding.modifier);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_modifier(IntPtr l)
	{
		int result;
		try
		{
			UIKeyBinding uIKeyBinding = (UIKeyBinding)LuaObject.checkSelf(l);
			UIKeyBinding.Modifier modifier;
			LuaObject.checkEnum<UIKeyBinding.Modifier>(l, 2, out modifier);
			uIKeyBinding.modifier = modifier;
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
	public static int get_action(IntPtr l)
	{
		int result;
		try
		{
			UIKeyBinding uIKeyBinding = (UIKeyBinding)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIKeyBinding.action);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_action(IntPtr l)
	{
		int result;
		try
		{
			UIKeyBinding uIKeyBinding = (UIKeyBinding)LuaObject.checkSelf(l);
			UIKeyBinding.Action action;
			LuaObject.checkEnum<UIKeyBinding.Action>(l, 2, out action);
			uIKeyBinding.action = action;
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
		LuaObject.getTypeTable(l, "UIKeyBinding");
		LuaObject.addMember(l, "keyCode", new LuaCSFunction(Lua_UIKeyBinding.get_keyCode), new LuaCSFunction(Lua_UIKeyBinding.set_keyCode), true);
		LuaObject.addMember(l, "modifier", new LuaCSFunction(Lua_UIKeyBinding.get_modifier), new LuaCSFunction(Lua_UIKeyBinding.set_modifier), true);
		LuaObject.addMember(l, "action", new LuaCSFunction(Lua_UIKeyBinding.get_action), new LuaCSFunction(Lua_UIKeyBinding.set_action), true);
		LuaObject.createTypeMetatable(l, null, typeof(UIKeyBinding), typeof(MonoBehaviour));
	}
}
