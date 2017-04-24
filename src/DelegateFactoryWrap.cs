using LuaInterface;
using System;

public class DelegateFactoryWrap
{
	private static Type classType = typeof(DelegateFactory);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Action_GameObject", new LuaCSFunction(DelegateFactoryWrap.Action_GameObject)),
			new LuaMethod("Action", new LuaCSFunction(DelegateFactoryWrap.Action)),
			new LuaMethod("UnityEngine_Events_UnityAction", new LuaCSFunction(DelegateFactoryWrap.UnityEngine_Events_UnityAction)),
			new LuaMethod("System_Reflection_MemberFilter", new LuaCSFunction(DelegateFactoryWrap.System_Reflection_MemberFilter)),
			new LuaMethod("System_Reflection_TypeFilter", new LuaCSFunction(DelegateFactoryWrap.System_Reflection_TypeFilter)),
			new LuaMethod("Application_LogCallback", new LuaCSFunction(DelegateFactoryWrap.Application_LogCallback)),
			new LuaMethod("UICamera_OnScreenResize", new LuaCSFunction(DelegateFactoryWrap.UICamera_OnScreenResize)),
			new LuaMethod("UICamera_OnCustomInput", new LuaCSFunction(DelegateFactoryWrap.UICamera_OnCustomInput)),
			new LuaMethod("UIWidget_OnDimensionsChanged", new LuaCSFunction(DelegateFactoryWrap.UIWidget_OnDimensionsChanged)),
			new LuaMethod("UIWidget_HitCheck", new LuaCSFunction(DelegateFactoryWrap.UIWidget_HitCheck)),
			new LuaMethod("UIProgressBar_OnDragFinished", new LuaCSFunction(DelegateFactoryWrap.UIProgressBar_OnDragFinished)),
			new LuaMethod("UILib_SliderValueChangeEventHandler", new LuaCSFunction(DelegateFactoryWrap.UILib_SliderValueChangeEventHandler)),
			new LuaMethod("UIGrid_OnReposition", new LuaCSFunction(DelegateFactoryWrap.UIGrid_OnReposition)),
			new LuaMethod("CompareFunc_Transform", new LuaCSFunction(DelegateFactoryWrap.CompareFunc_Transform)),
			new LuaMethod("UIInput_OnValidate", new LuaCSFunction(DelegateFactoryWrap.UIInput_OnValidate)),
			new LuaMethod("UIScrollView_OnDragFinished", new LuaCSFunction(DelegateFactoryWrap.UIScrollView_OnDragFinished)),
			new LuaMethod("UITable_OnReposition", new LuaCSFunction(DelegateFactoryWrap.UITable_OnReposition)),
			new LuaMethod("UIEventListener_VoidDelegate", new LuaCSFunction(DelegateFactoryWrap.UIEventListener_VoidDelegate)),
			new LuaMethod("UIEventListener_BoolDelegate", new LuaCSFunction(DelegateFactoryWrap.UIEventListener_BoolDelegate)),
			new LuaMethod("UIEventListener_FloatDelegate", new LuaCSFunction(DelegateFactoryWrap.UIEventListener_FloatDelegate)),
			new LuaMethod("UIEventListener_VectorDelegate", new LuaCSFunction(DelegateFactoryWrap.UIEventListener_VectorDelegate)),
			new LuaMethod("UIEventListener_ObjectDelegate", new LuaCSFunction(DelegateFactoryWrap.UIEventListener_ObjectDelegate)),
			new LuaMethod("UIEventListener_KeyCodeDelegate", new LuaCSFunction(DelegateFactoryWrap.UIEventListener_KeyCodeDelegate)),
			new LuaMethod("EventDelegate_Callback", new LuaCSFunction(DelegateFactoryWrap.EventDelegate_Callback)),
			new LuaMethod("SpringPanel_OnFinished", new LuaCSFunction(DelegateFactoryWrap.SpringPanel_OnFinished)),
			new LuaMethod("DelManager_GameObjDelegate", new LuaCSFunction(DelegateFactoryWrap.DelManager_GameObjDelegate)),
			new LuaMethod("UILib_ButtonClickEventHandler", new LuaCSFunction(DelegateFactoryWrap.UILib_ButtonClickEventHandler)),
			new LuaMethod("UILib_SpriteClickEventHandler", new LuaCSFunction(DelegateFactoryWrap.UILib_SpriteClickEventHandler)),
			new LuaMethod("UILib_RefreshRenderQueueCb", new LuaCSFunction(DelegateFactoryWrap.UILib_RefreshRenderQueueCb)),
			new LuaMethod("Clear", new LuaCSFunction(DelegateFactoryWrap.Clear)),
			new LuaMethod("New", new LuaCSFunction(DelegateFactoryWrap._CreateDelegateFactory)),
			new LuaMethod("GetClassType", new LuaCSFunction(DelegateFactoryWrap.GetClassType))
		};
		LuaScriptMgr.RegisterLib(L, "DelegateFactory", regs);
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateDelegateFactory(IntPtr L)
	{
		LuaDLL.luaL_error(L, "DelegateFactory class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, DelegateFactoryWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Action_GameObject(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.Action_GameObject(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Action(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.Action(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnityEngine_Events_UnityAction(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UnityEngine_Events_UnityAction(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Reflection_MemberFilter(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.System_Reflection_MemberFilter(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Reflection_TypeFilter(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.System_Reflection_TypeFilter(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Application_LogCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.Application_LogCallback(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_OnScreenResize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UICamera_OnScreenResize(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_OnCustomInput(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UICamera_OnCustomInput(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIWidget_OnDimensionsChanged(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UIWidget_OnDimensionsChanged(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIWidget_HitCheck(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UIWidget_HitCheck(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIProgressBar_OnDragFinished(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UIProgressBar_OnDragFinished(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UILib_SliderValueChangeEventHandler(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UILib_SliderValueChangeEventHandler(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIGrid_OnReposition(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UIGrid_OnReposition(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CompareFunc_Transform(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.CompareFunc_Transform(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIInput_OnValidate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UIInput_OnValidate(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIScrollView_OnDragFinished(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UIScrollView_OnDragFinished(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UITable_OnReposition(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UITable_OnReposition(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIEventListener_VoidDelegate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UIEventListener_VoidDelegate(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIEventListener_BoolDelegate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UIEventListener_BoolDelegate(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIEventListener_FloatDelegate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UIEventListener_FloatDelegate(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIEventListener_VectorDelegate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UIEventListener_VectorDelegate(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIEventListener_ObjectDelegate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UIEventListener_ObjectDelegate(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIEventListener_KeyCodeDelegate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UIEventListener_KeyCodeDelegate(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EventDelegate_Callback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.EventDelegate_Callback(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SpringPanel_OnFinished(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.SpringPanel_OnFinished(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DelManager_GameObjDelegate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.DelManager_GameObjDelegate(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UILib_ButtonClickEventHandler(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UILib_ButtonClickEventHandler(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UILib_SpriteClickEventHandler(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UILib_SpriteClickEventHandler(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UILib_RefreshRenderQueueCb(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction luaFunction = LuaScriptMgr.GetLuaFunction(L, 1);
		Delegate o = DelegateFactory.UILib_RefreshRenderQueueCb(luaFunction);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Clear(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		DelegateFactory.Clear();
		return 0;
	}
}
