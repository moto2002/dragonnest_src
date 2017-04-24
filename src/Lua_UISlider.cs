using com.tencent.pandora;
using System;

public class Lua_UISlider : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int constructor(IntPtr l)
	{
		int result;
		try
		{
			UISlider o = new UISlider();
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

	public static void reg(IntPtr l)
	{
		LuaObject.getTypeTable(l, "UISlider");
		LuaObject.createTypeMetatable(l, new LuaCSFunction(Lua_UISlider.constructor), typeof(UISlider), typeof(UIProgressBar));
	}
}
