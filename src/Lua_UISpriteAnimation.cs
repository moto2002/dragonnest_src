using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UISpriteAnimation : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Reset(IntPtr l)
	{
		int result;
		try
		{
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)LuaObject.checkSelf(l);
			uISpriteAnimation.Reset();
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
	public static int StopAndReset(IntPtr l)
	{
		int result;
		try
		{
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)LuaObject.checkSelf(l);
			uISpriteAnimation.StopAndReset();
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
	public static int get_sprite(IntPtr l)
	{
		int result;
		try
		{
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteAnimation.sprite);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_LastLoopFinishTime(IntPtr l)
	{
		int result;
		try
		{
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteAnimation.LastLoopFinishTime);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_LastLoopFinishTime(IntPtr l)
	{
		int result;
		try
		{
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)LuaObject.checkSelf(l);
			float lastLoopFinishTime;
			LuaObject.checkType(l, 2, out lastLoopFinishTime);
			uISpriteAnimation.LastLoopFinishTime = lastLoopFinishTime;
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
	public static int get_frames(IntPtr l)
	{
		int result;
		try
		{
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteAnimation.frames);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_framesPerSecond(IntPtr l)
	{
		int result;
		try
		{
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteAnimation.framesPerSecond);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_framesPerSecond(IntPtr l)
	{
		int result;
		try
		{
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)LuaObject.checkSelf(l);
			int framesPerSecond;
			LuaObject.checkType(l, 2, out framesPerSecond);
			uISpriteAnimation.framesPerSecond = framesPerSecond;
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
	public static int get_namePrefix(IntPtr l)
	{
		int result;
		try
		{
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteAnimation.namePrefix);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_namePrefix(IntPtr l)
	{
		int result;
		try
		{
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)LuaObject.checkSelf(l);
			string namePrefix;
			LuaObject.checkType(l, 2, out namePrefix);
			uISpriteAnimation.namePrefix = namePrefix;
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
	public static int get_loop(IntPtr l)
	{
		int result;
		try
		{
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteAnimation.loop);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_loop(IntPtr l)
	{
		int result;
		try
		{
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)LuaObject.checkSelf(l);
			bool loop;
			LuaObject.checkType(l, 2, out loop);
			uISpriteAnimation.loop = loop;
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
	public static int get_loopinterval(IntPtr l)
	{
		int result;
		try
		{
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteAnimation.loopinterval);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_loopinterval(IntPtr l)
	{
		int result;
		try
		{
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)LuaObject.checkSelf(l);
			int loopinterval;
			LuaObject.checkType(l, 2, out loopinterval);
			uISpriteAnimation.loopinterval = loopinterval;
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
	public static int get_disableWhenFinish(IntPtr l)
	{
		int result;
		try
		{
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteAnimation.disableWhenFinish);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_disableWhenFinish(IntPtr l)
	{
		int result;
		try
		{
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)LuaObject.checkSelf(l);
			bool disableWhenFinish;
			LuaObject.checkType(l, 2, out disableWhenFinish);
			uISpriteAnimation.disableWhenFinish = disableWhenFinish;
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
	public static int get_isPlaying(IntPtr l)
	{
		int result;
		try
		{
			UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uISpriteAnimation.isPlaying);
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
		LuaObject.getTypeTable(l, "UISpriteAnimation");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UISpriteAnimation.Reset));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UISpriteAnimation.StopAndReset));
		LuaObject.addMember(l, "sprite", new LuaCSFunction(Lua_UISpriteAnimation.get_sprite), null, true);
		LuaObject.addMember(l, "LastLoopFinishTime", new LuaCSFunction(Lua_UISpriteAnimation.get_LastLoopFinishTime), new LuaCSFunction(Lua_UISpriteAnimation.set_LastLoopFinishTime), true);
		LuaObject.addMember(l, "frames", new LuaCSFunction(Lua_UISpriteAnimation.get_frames), null, true);
		LuaObject.addMember(l, "framesPerSecond", new LuaCSFunction(Lua_UISpriteAnimation.get_framesPerSecond), new LuaCSFunction(Lua_UISpriteAnimation.set_framesPerSecond), true);
		LuaObject.addMember(l, "namePrefix", new LuaCSFunction(Lua_UISpriteAnimation.get_namePrefix), new LuaCSFunction(Lua_UISpriteAnimation.set_namePrefix), true);
		LuaObject.addMember(l, "loop", new LuaCSFunction(Lua_UISpriteAnimation.get_loop), new LuaCSFunction(Lua_UISpriteAnimation.set_loop), true);
		LuaObject.addMember(l, "loopinterval", new LuaCSFunction(Lua_UISpriteAnimation.get_loopinterval), new LuaCSFunction(Lua_UISpriteAnimation.set_loopinterval), true);
		LuaObject.addMember(l, "disableWhenFinish", new LuaCSFunction(Lua_UISpriteAnimation.get_disableWhenFinish), new LuaCSFunction(Lua_UISpriteAnimation.set_disableWhenFinish), true);
		LuaObject.addMember(l, "isPlaying", new LuaCSFunction(Lua_UISpriteAnimation.get_isPlaying), null, true);
		LuaObject.createTypeMetatable(l, null, typeof(UISpriteAnimation), typeof(MonoBehaviour));
	}
}
