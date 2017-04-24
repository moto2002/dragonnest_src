using com.tencent.pandora;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Lua_UIRoot : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetPixelSizeAdjustment(IntPtr l)
	{
		int result;
		try
		{
			UIRoot uIRoot = (UIRoot)LuaObject.checkSelf(l);
			int height;
			LuaObject.checkType(l, 2, out height);
			float pixelSizeAdjustment = uIRoot.GetPixelSizeAdjustment(height);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, pixelSizeAdjustment);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int GetPixelSizeAdjustment_s(IntPtr l)
	{
		int result;
		try
		{
			GameObject go;
			LuaObject.checkType<GameObject>(l, 1, out go);
			float pixelSizeAdjustment = UIRoot.GetPixelSizeAdjustment(go);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, pixelSizeAdjustment);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int Broadcast_s(IntPtr l)
	{
		int result;
		try
		{
			int num = LuaDLL.pua_gettop(l);
			if (num == 1)
			{
				string funcName;
				LuaObject.checkType(l, 1, out funcName);
				UIRoot.Broadcast(funcName);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else if (num == 2)
			{
				string funcName2;
				LuaObject.checkType(l, 1, out funcName2);
				object param;
				LuaObject.checkType<object>(l, 2, out param);
				UIRoot.Broadcast(funcName2, param);
				LuaObject.pushValue(l, true);
				result = 1;
			}
			else
			{
				LuaObject.pushValue(l, false);
				LuaDLL.pua_pushstring(l, "No matched override function to call");
				result = 2;
			}
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_list(IntPtr l)
	{
		int result;
		try
		{
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, UIRoot.list);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_list(IntPtr l)
	{
		int result;
		try
		{
			List<UIRoot> list;
			LuaObject.checkType<List<UIRoot>>(l, 2, out list);
			UIRoot.list = list;
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
	public static int get_scalingStyle(IntPtr l)
	{
		int result;
		try
		{
			UIRoot uIRoot = (UIRoot)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushEnum(l, (int)uIRoot.scalingStyle);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_scalingStyle(IntPtr l)
	{
		int result;
		try
		{
			UIRoot uIRoot = (UIRoot)LuaObject.checkSelf(l);
			UIRoot.Scaling scalingStyle;
			LuaObject.checkEnum<UIRoot.Scaling>(l, 2, out scalingStyle);
			uIRoot.scalingStyle = scalingStyle;
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
	public static int get_base_ui_width(IntPtr l)
	{
		int result;
		try
		{
			UIRoot uIRoot = (UIRoot)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRoot.base_ui_width);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_base_ui_width(IntPtr l)
	{
		int result;
		try
		{
			UIRoot uIRoot = (UIRoot)LuaObject.checkSelf(l);
			int base_ui_width;
			LuaObject.checkType(l, 2, out base_ui_width);
			uIRoot.base_ui_width = base_ui_width;
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
	public static int get_base_ui_height(IntPtr l)
	{
		int result;
		try
		{
			UIRoot uIRoot = (UIRoot)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRoot.base_ui_height);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_base_ui_height(IntPtr l)
	{
		int result;
		try
		{
			UIRoot uIRoot = (UIRoot)LuaObject.checkSelf(l);
			int base_ui_height;
			LuaObject.checkType(l, 2, out base_ui_height);
			uIRoot.base_ui_height = base_ui_height;
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
	public static int get_manualHeight(IntPtr l)
	{
		int result;
		try
		{
			UIRoot uIRoot = (UIRoot)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRoot.manualHeight);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_manualHeight(IntPtr l)
	{
		int result;
		try
		{
			UIRoot uIRoot = (UIRoot)LuaObject.checkSelf(l);
			int manualHeight;
			LuaObject.checkType(l, 2, out manualHeight);
			uIRoot.manualHeight = manualHeight;
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
	public static int get_minimumHeight(IntPtr l)
	{
		int result;
		try
		{
			UIRoot uIRoot = (UIRoot)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRoot.minimumHeight);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_minimumHeight(IntPtr l)
	{
		int result;
		try
		{
			UIRoot uIRoot = (UIRoot)LuaObject.checkSelf(l);
			int minimumHeight;
			LuaObject.checkType(l, 2, out minimumHeight);
			uIRoot.minimumHeight = minimumHeight;
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
	public static int get_maximumHeight(IntPtr l)
	{
		int result;
		try
		{
			UIRoot uIRoot = (UIRoot)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRoot.maximumHeight);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_maximumHeight(IntPtr l)
	{
		int result;
		try
		{
			UIRoot uIRoot = (UIRoot)LuaObject.checkSelf(l);
			int maximumHeight;
			LuaObject.checkType(l, 2, out maximumHeight);
			uIRoot.maximumHeight = maximumHeight;
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
	public static int get_adjustByDPI(IntPtr l)
	{
		int result;
		try
		{
			UIRoot uIRoot = (UIRoot)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRoot.adjustByDPI);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_adjustByDPI(IntPtr l)
	{
		int result;
		try
		{
			UIRoot uIRoot = (UIRoot)LuaObject.checkSelf(l);
			bool adjustByDPI;
			LuaObject.checkType(l, 2, out adjustByDPI);
			uIRoot.adjustByDPI = adjustByDPI;
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
	public static int get_shrinkPortraitUI(IntPtr l)
	{
		int result;
		try
		{
			UIRoot uIRoot = (UIRoot)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRoot.shrinkPortraitUI);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_shrinkPortraitUI(IntPtr l)
	{
		int result;
		try
		{
			UIRoot uIRoot = (UIRoot)LuaObject.checkSelf(l);
			bool shrinkPortraitUI;
			LuaObject.checkType(l, 2, out shrinkPortraitUI);
			uIRoot.shrinkPortraitUI = shrinkPortraitUI;
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
	public static int get_activeHeight(IntPtr l)
	{
		int result;
		try
		{
			UIRoot uIRoot = (UIRoot)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRoot.activeHeight);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int get_pixelSizeAdjustment(IntPtr l)
	{
		int result;
		try
		{
			UIRoot uIRoot = (UIRoot)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIRoot.pixelSizeAdjustment);
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
		LuaObject.getTypeTable(l, "UIRoot");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIRoot.GetPixelSizeAdjustment));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIRoot.GetPixelSizeAdjustment_s));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIRoot.Broadcast_s));
		LuaObject.addMember(l, "list", new LuaCSFunction(Lua_UIRoot.get_list), new LuaCSFunction(Lua_UIRoot.set_list), false);
		LuaObject.addMember(l, "scalingStyle", new LuaCSFunction(Lua_UIRoot.get_scalingStyle), new LuaCSFunction(Lua_UIRoot.set_scalingStyle), true);
		LuaObject.addMember(l, "base_ui_width", new LuaCSFunction(Lua_UIRoot.get_base_ui_width), new LuaCSFunction(Lua_UIRoot.set_base_ui_width), true);
		LuaObject.addMember(l, "base_ui_height", new LuaCSFunction(Lua_UIRoot.get_base_ui_height), new LuaCSFunction(Lua_UIRoot.set_base_ui_height), true);
		LuaObject.addMember(l, "manualHeight", new LuaCSFunction(Lua_UIRoot.get_manualHeight), new LuaCSFunction(Lua_UIRoot.set_manualHeight), true);
		LuaObject.addMember(l, "minimumHeight", new LuaCSFunction(Lua_UIRoot.get_minimumHeight), new LuaCSFunction(Lua_UIRoot.set_minimumHeight), true);
		LuaObject.addMember(l, "maximumHeight", new LuaCSFunction(Lua_UIRoot.get_maximumHeight), new LuaCSFunction(Lua_UIRoot.set_maximumHeight), true);
		LuaObject.addMember(l, "adjustByDPI", new LuaCSFunction(Lua_UIRoot.get_adjustByDPI), new LuaCSFunction(Lua_UIRoot.set_adjustByDPI), true);
		LuaObject.addMember(l, "shrinkPortraitUI", new LuaCSFunction(Lua_UIRoot.get_shrinkPortraitUI), new LuaCSFunction(Lua_UIRoot.set_shrinkPortraitUI), true);
		LuaObject.addMember(l, "activeHeight", new LuaCSFunction(Lua_UIRoot.get_activeHeight), null, true);
		LuaObject.addMember(l, "pixelSizeAdjustment", new LuaCSFunction(Lua_UIRoot.get_pixelSizeAdjustment), null, true);
		LuaObject.createTypeMetatable(l, null, typeof(UIRoot), typeof(MonoBehaviour));
	}
}
