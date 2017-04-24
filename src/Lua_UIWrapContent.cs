using com.tencent.pandora;
using System;
using UnityEngine;

public class Lua_UIWrapContent : LuaObject
{
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int SortBasedOnScrollMovement(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			uIWrapContent.SortBasedOnScrollMovement();
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
	public static int SortAlphabetically(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			uIWrapContent.SortAlphabetically();
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
	public static int OnEnable(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			uIWrapContent.OnEnable();
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
	public static int OnDisable(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			uIWrapContent.OnDisable();
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
	public static int CreatePlaceHolder(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			uIWrapContent.CreatePlaceHolder();
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
	public static int UpdatePlaceHolder(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			uIWrapContent.UpdatePlaceHolder();
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
	public static int Init(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			bool b = uIWrapContent.Init();
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
	public static int SetContentCount(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			int contentCount;
			LuaObject.checkType(l, 2, out contentCount);
			uIWrapContent.SetContentCount(contentCount);
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
	public static int AdjustContent(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			uIWrapContent.AdjustContent();
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
	public static int SetChildPositionOffset(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			int offset;
			LuaObject.checkType(l, 2, out offset);
			bool bUpdate;
			LuaObject.checkType(l, 3, out bUpdate);
			uIWrapContent.SetChildPositionOffset(offset, bUpdate);
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
	public static int RefreshAllChildrenContent(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			uIWrapContent.RefreshAllChildrenContent();
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
	public static int WrapContent(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			uIWrapContent.WrapContent();
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
	public static int get_itemSize(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWrapContent.itemSize);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_itemSize(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			Vector2 itemSize;
			LuaObject.checkType(l, 2, out itemSize);
			uIWrapContent.itemSize = itemSize;
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
	public static int get_cullContent(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWrapContent.cullContent);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_cullContent(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			bool cullContent;
			LuaObject.checkType(l, 2, out cullContent);
			uIWrapContent.cullContent = cullContent;
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
	public static int get_WidthDimension(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWrapContent.WidthDimension);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_WidthDimension(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			int widthDimension;
			LuaObject.checkType(l, 2, out widthDimension);
			uIWrapContent.WidthDimension = widthDimension;
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
	public static int get_bBounds(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWrapContent.bBounds);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_bBounds(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			bool bBounds;
			LuaObject.checkType(l, 2, out bBounds);
			uIWrapContent.bBounds = bBounds;
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
	public static int get_HeightDimemsionMax(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWrapContent.HeightDimemsionMax);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaObject.error(l, e);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	public static int set_HeightDimemsionMax(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			int heightDimemsionMax;
			LuaObject.checkType(l, 2, out heightDimemsionMax);
			uIWrapContent.HeightDimemsionMax = heightDimemsionMax;
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
	public static int set_updateHandler(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			WrapContentItemUpdateEventHandler wrapContentItemUpdateEventHandler;
			int num = LuaDelegation.checkDelegate(l, 2, out wrapContentItemUpdateEventHandler);
			if (num == 0)
			{
				uIWrapContent.updateHandler = wrapContentItemUpdateEventHandler;
			}
			else if (num == 1)
			{
				UIWrapContent expr_30 = uIWrapContent;
				expr_30.updateHandler = (WrapContentItemUpdateEventHandler)Delegate.Combine(expr_30.updateHandler, wrapContentItemUpdateEventHandler);
			}
			else if (num == 2)
			{
				UIWrapContent expr_53 = uIWrapContent;
				expr_53.updateHandler = (WrapContentItemUpdateEventHandler)Delegate.Remove(expr_53.updateHandler, wrapContentItemUpdateEventHandler);
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
	public static int get_ItemList(IntPtr l)
	{
		int result;
		try
		{
			UIWrapContent uIWrapContent = (UIWrapContent)LuaObject.checkSelf(l);
			LuaObject.pushValue(l, true);
			LuaObject.pushValue(l, uIWrapContent.ItemList);
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
		LuaObject.getTypeTable(l, "UIWrapContent");
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWrapContent.SortBasedOnScrollMovement));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWrapContent.SortAlphabetically));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWrapContent.OnEnable));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWrapContent.OnDisable));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWrapContent.CreatePlaceHolder));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWrapContent.UpdatePlaceHolder));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWrapContent.Init));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWrapContent.SetContentCount));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWrapContent.AdjustContent));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWrapContent.SetChildPositionOffset));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWrapContent.RefreshAllChildrenContent));
		LuaObject.addMember(l, new LuaCSFunction(Lua_UIWrapContent.WrapContent));
		LuaObject.addMember(l, "itemSize", new LuaCSFunction(Lua_UIWrapContent.get_itemSize), new LuaCSFunction(Lua_UIWrapContent.set_itemSize), true);
		LuaObject.addMember(l, "cullContent", new LuaCSFunction(Lua_UIWrapContent.get_cullContent), new LuaCSFunction(Lua_UIWrapContent.set_cullContent), true);
		LuaObject.addMember(l, "WidthDimension", new LuaCSFunction(Lua_UIWrapContent.get_WidthDimension), new LuaCSFunction(Lua_UIWrapContent.set_WidthDimension), true);
		LuaObject.addMember(l, "bBounds", new LuaCSFunction(Lua_UIWrapContent.get_bBounds), new LuaCSFunction(Lua_UIWrapContent.set_bBounds), true);
		LuaObject.addMember(l, "HeightDimemsionMax", new LuaCSFunction(Lua_UIWrapContent.get_HeightDimemsionMax), new LuaCSFunction(Lua_UIWrapContent.set_HeightDimemsionMax), true);
		LuaObject.addMember(l, "updateHandler", null, new LuaCSFunction(Lua_UIWrapContent.set_updateHandler), true);
		LuaObject.addMember(l, "ItemList", new LuaCSFunction(Lua_UIWrapContent.get_ItemList), null, true);
		LuaObject.createTypeMetatable(l, null, typeof(UIWrapContent), typeof(MonoBehaviour));
	}
}
