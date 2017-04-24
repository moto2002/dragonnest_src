using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UIPlaySound : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Play(IntPtr l)
	{
		int result;
		try
		{
			UIPlaySound uIPlaySound = (UIPlaySound)LuaObject.checkSelf(l);
			uIPlaySound.Play();
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
	public static int get_audioClip(IntPtr l)
	{
		int result;
		try
		{
			UIPlaySound uIPlaySound = (UIPlaySound)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPlaySound.audioClip);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_audioClip(IntPtr l)
	{
		int result;
		try
		{
			UIPlaySound uIPlaySound = (UIPlaySound)LuaObject.checkSelf(l);
			AudioClip audioClip;
			LuaObject.checkType<AudioClip>(l, 2, out audioClip);
			uIPlaySound.audioClip = audioClip;
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
	public static int get_trigger(IntPtr l)
	{
		int result;
		try
		{
			UIPlaySound uIPlaySound = (UIPlaySound)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIPlaySound.trigger);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_trigger(IntPtr l)
	{
		int result;
		try
		{
			UIPlaySound uIPlaySound = (UIPlaySound)LuaObject.checkSelf(l);
			UIPlaySound.Trigger trigger;
			LuaObject.checkEnum<UIPlaySound.Trigger>(l, 2, out trigger);
			uIPlaySound.trigger = trigger;
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
	public static int get_volume(IntPtr l)
	{
		int result;
		try
		{
			UIPlaySound uIPlaySound = (UIPlaySound)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPlaySound.volume);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_volume(IntPtr l)
	{
		int result;
		try
		{
			UIPlaySound uIPlaySound = (UIPlaySound)LuaObject.checkSelf(l);
			float volume;
			LuaObject.checkType(l, 2, out volume);
			uIPlaySound.volume = volume;
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
	public static int get_pitch(IntPtr l)
	{
		int result;
		try
		{
			UIPlaySound uIPlaySound = (UIPlaySound)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIPlaySound.pitch);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_pitch(IntPtr l)
	{
		int result;
		try
		{
			UIPlaySound uIPlaySound = (UIPlaySound)LuaObject.checkSelf(l);
			float pitch;
			LuaObject.checkType(l, 2, out pitch);
			uIPlaySound.pitch = pitch;
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
		LuaObject.getTypeTable(l, "UIPlaySound");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIPlaySound.Play));
		LuaObject.addMember(l, "audioClip", new LuaCSFunction(Lua_UIPlaySound.get_audioClip), new LuaCSFunction(Lua_UIPlaySound.set_audioClip), true);
		LuaObject.addMember(l, "trigger", new LuaCSFunction(Lua_UIPlaySound.get_trigger), new LuaCSFunction(Lua_UIPlaySound.set_trigger), true);
		LuaObject.addMember(l, "volume", new LuaCSFunction(Lua_UIPlaySound.get_volume), new LuaCSFunction(Lua_UIPlaySound.set_volume), true);
		LuaObject.addMember(l, "pitch", new LuaCSFunction(Lua_UIPlaySound.get_pitch), new LuaCSFunction(Lua_UIPlaySound.set_pitch), true);
		LuaObject.createTypeMetatable(l, null, typeof(UIPlaySound), typeof(MonoBehaviour));
	}
}
