using LuaInterface;
using System;
using System.Collections.Generic;
using System.Reflection;
using UILib;
using UnityEngine;
using UnityEngine.Events;

public static class DelegateFactory
{
	private delegate Delegate DelegateValue(LuaFunction func);

	private static Dictionary<Type, DelegateFactory.DelegateValue> dict = new Dictionary<Type, DelegateFactory.DelegateValue>();

	[NoToLua]
	public static void Register(IntPtr L)
	{
		DelegateFactory.dict.Add(typeof(Action<GameObject>), new DelegateFactory.DelegateValue(DelegateFactory.Action_GameObject));
		DelegateFactory.dict.Add(typeof(Action), new DelegateFactory.DelegateValue(DelegateFactory.Action));
		DelegateFactory.dict.Add(typeof(UnityAction), new DelegateFactory.DelegateValue(DelegateFactory.UnityEngine_Events_UnityAction));
		DelegateFactory.dict.Add(typeof(MemberFilter), new DelegateFactory.DelegateValue(DelegateFactory.System_Reflection_MemberFilter));
		DelegateFactory.dict.Add(typeof(TypeFilter), new DelegateFactory.DelegateValue(DelegateFactory.System_Reflection_TypeFilter));
		DelegateFactory.dict.Add(typeof(Application.LogCallback), new DelegateFactory.DelegateValue(DelegateFactory.Application_LogCallback));
		DelegateFactory.dict.Add(typeof(UICamera.OnScreenResize), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_OnScreenResize));
		DelegateFactory.dict.Add(typeof(UICamera.OnCustomInput), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_OnCustomInput));
		DelegateFactory.dict.Add(typeof(UIWidget.OnDimensionsChanged), new DelegateFactory.DelegateValue(DelegateFactory.UIWidget_OnDimensionsChanged));
		DelegateFactory.dict.Add(typeof(UIWidget.HitCheck), new DelegateFactory.DelegateValue(DelegateFactory.UIWidget_HitCheck));
		DelegateFactory.dict.Add(typeof(UIProgressBar.OnDragFinished), new DelegateFactory.DelegateValue(DelegateFactory.UIProgressBar_OnDragFinished));
		DelegateFactory.dict.Add(typeof(SliderValueChangeEventHandler), new DelegateFactory.DelegateValue(DelegateFactory.UILib_SliderValueChangeEventHandler));
		DelegateFactory.dict.Add(typeof(UIGrid.OnReposition), new DelegateFactory.DelegateValue(DelegateFactory.UIGrid_OnReposition));
		DelegateFactory.dict.Add(typeof(BetterList<Transform>.CompareFunc), new DelegateFactory.DelegateValue(DelegateFactory.CompareFunc_Transform));
		DelegateFactory.dict.Add(typeof(UIInput.OnValidate), new DelegateFactory.DelegateValue(DelegateFactory.UIInput_OnValidate));
		DelegateFactory.dict.Add(typeof(UIScrollView.OnDragFinished), new DelegateFactory.DelegateValue(DelegateFactory.UIScrollView_OnDragFinished));
		DelegateFactory.dict.Add(typeof(UITable.OnReposition), new DelegateFactory.DelegateValue(DelegateFactory.UITable_OnReposition));
		DelegateFactory.dict.Add(typeof(UIEventListener.VoidDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UIEventListener_VoidDelegate));
		DelegateFactory.dict.Add(typeof(UIEventListener.BoolDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UIEventListener_BoolDelegate));
		DelegateFactory.dict.Add(typeof(UIEventListener.FloatDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UIEventListener_FloatDelegate));
		DelegateFactory.dict.Add(typeof(UIEventListener.VectorDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UIEventListener_VectorDelegate));
		DelegateFactory.dict.Add(typeof(UIEventListener.ObjectDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UIEventListener_ObjectDelegate));
		DelegateFactory.dict.Add(typeof(UIEventListener.KeyCodeDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UIEventListener_KeyCodeDelegate));
		DelegateFactory.dict.Add(typeof(EventDelegate.Callback), new DelegateFactory.DelegateValue(DelegateFactory.EventDelegate_Callback));
		DelegateFactory.dict.Add(typeof(SpringPanel.OnFinished), new DelegateFactory.DelegateValue(DelegateFactory.SpringPanel_OnFinished));
		DelegateFactory.dict.Add(typeof(DelManager.GameObjDelegate), new DelegateFactory.DelegateValue(DelegateFactory.DelManager_GameObjDelegate));
		DelegateFactory.dict.Add(typeof(ButtonClickEventHandler), new DelegateFactory.DelegateValue(DelegateFactory.UILib_ButtonClickEventHandler));
		DelegateFactory.dict.Add(typeof(SpriteClickEventHandler), new DelegateFactory.DelegateValue(DelegateFactory.UILib_SpriteClickEventHandler));
		DelegateFactory.dict.Add(typeof(RefreshRenderQueueCb), new DelegateFactory.DelegateValue(DelegateFactory.UILib_RefreshRenderQueueCb));
	}

	[NoToLua]
	public static Delegate CreateDelegate(Type t, LuaFunction func)
	{
		DelegateFactory.DelegateValue delegateValue = null;
		if (!DelegateFactory.dict.TryGetValue(t, out delegateValue))
		{
			Debugger.LogError("Delegate {0} not register", new object[]
			{
				t.FullName
			});
			return null;
		}
		return delegateValue(func);
	}

	public static Delegate Action_GameObject(LuaFunction func)
	{
		return new Action<GameObject>(delegate(GameObject param0)
		{
			int oldTop = func.BeginPCall();
			IntPtr luaState = func.GetLuaState();
			LuaScriptMgr.Push(luaState, param0);
			func.PCall(oldTop, 1);
			func.EndPCall(oldTop);
		});
	}

	public static Delegate Action(LuaFunction func)
	{
		return new Action(delegate
		{
			func.Call();
		});
	}

	public static Delegate UnityEngine_Events_UnityAction(LuaFunction func)
	{
		return new UnityAction(delegate
		{
			func.Call();
		});
	}

	public static Delegate System_Reflection_MemberFilter(LuaFunction func)
	{
		return new MemberFilter(delegate(MemberInfo param0, object param1)
		{
			int oldTop = func.BeginPCall();
			IntPtr luaState = func.GetLuaState();
			LuaScriptMgr.PushObject(luaState, param0);
			LuaScriptMgr.PushVarObject(luaState, param1);
			func.PCall(oldTop, 2);
			object[] array = func.PopValues(oldTop);
			func.EndPCall(oldTop);
			return (bool)array[0];
		});
	}

	public static Delegate System_Reflection_TypeFilter(LuaFunction func)
	{
		return new TypeFilter(delegate(Type param0, object param1)
		{
			int oldTop = func.BeginPCall();
			IntPtr luaState = func.GetLuaState();
			LuaScriptMgr.Push(luaState, param0);
			LuaScriptMgr.PushVarObject(luaState, param1);
			func.PCall(oldTop, 2);
			object[] array = func.PopValues(oldTop);
			func.EndPCall(oldTop);
			return (bool)array[0];
		});
	}

	public static Delegate Application_LogCallback(LuaFunction func)
	{
		return new Application.LogCallback(delegate(string param0, string param1, LogType param2)
		{
			int oldTop = func.BeginPCall();
			IntPtr luaState = func.GetLuaState();
			LuaScriptMgr.Push(luaState, param0);
			LuaScriptMgr.Push(luaState, param1);
			LuaScriptMgr.Push(luaState, param2);
			func.PCall(oldTop, 3);
			func.EndPCall(oldTop);
		});
	}

	public static Delegate UICamera_OnScreenResize(LuaFunction func)
	{
		return new UICamera.OnScreenResize(delegate
		{
			func.Call();
		});
	}

	public static Delegate UICamera_OnCustomInput(LuaFunction func)
	{
		return new UICamera.OnCustomInput(delegate
		{
			func.Call();
		});
	}

	public static Delegate UIWidget_OnDimensionsChanged(LuaFunction func)
	{
		return new UIWidget.OnDimensionsChanged(delegate
		{
			func.Call();
		});
	}

	public static Delegate UIWidget_HitCheck(LuaFunction func)
	{
		return new UIWidget.HitCheck(delegate(Vector3 param0)
		{
			int oldTop = func.BeginPCall();
			IntPtr luaState = func.GetLuaState();
			LuaScriptMgr.Push(luaState, param0);
			func.PCall(oldTop, 1);
			object[] array = func.PopValues(oldTop);
			func.EndPCall(oldTop);
			return (bool)array[0];
		});
	}

	public static Delegate UIProgressBar_OnDragFinished(LuaFunction func)
	{
		return new UIProgressBar.OnDragFinished(delegate
		{
			func.Call();
		});
	}

	public static Delegate UILib_SliderValueChangeEventHandler(LuaFunction func)
	{
		return new SliderValueChangeEventHandler(delegate(float param0)
		{
			int oldTop = func.BeginPCall();
			IntPtr luaState = func.GetLuaState();
			LuaScriptMgr.Push(luaState, param0);
			func.PCall(oldTop, 1);
			object[] array = func.PopValues(oldTop);
			func.EndPCall(oldTop);
			return (bool)array[0];
		});
	}

	public static Delegate UIGrid_OnReposition(LuaFunction func)
	{
		return new UIGrid.OnReposition(delegate
		{
			func.Call();
		});
	}

	public static Delegate CompareFunc_Transform(LuaFunction func)
	{
		return new BetterList<Transform>.CompareFunc(delegate(Transform param0, Transform param1)
		{
			int oldTop = func.BeginPCall();
			IntPtr luaState = func.GetLuaState();
			LuaScriptMgr.Push(luaState, param0);
			LuaScriptMgr.Push(luaState, param1);
			func.PCall(oldTop, 2);
			object[] array = func.PopValues(oldTop);
			func.EndPCall(oldTop);
			return (int)array[0];
		});
	}

	public static Delegate UIInput_OnValidate(LuaFunction func)
	{
		return new UIInput.OnValidate(delegate(string param0, int param1, char param2)
		{
			int oldTop = func.BeginPCall();
			IntPtr luaState = func.GetLuaState();
			LuaScriptMgr.Push(luaState, param0);
			LuaScriptMgr.Push(luaState, param1);
			LuaScriptMgr.Push(luaState, param2);
			func.PCall(oldTop, 3);
			object[] array = func.PopValues(oldTop);
			func.EndPCall(oldTop);
			return (char)array[0];
		});
	}

	public static Delegate UIScrollView_OnDragFinished(LuaFunction func)
	{
		return new UIScrollView.OnDragFinished(delegate
		{
			func.Call();
		});
	}

	public static Delegate UITable_OnReposition(LuaFunction func)
	{
		return new UITable.OnReposition(delegate
		{
			func.Call();
		});
	}

	public static Delegate UIEventListener_VoidDelegate(LuaFunction func)
	{
		return new UIEventListener.VoidDelegate(delegate(GameObject param0)
		{
			int oldTop = func.BeginPCall();
			IntPtr luaState = func.GetLuaState();
			LuaScriptMgr.Push(luaState, param0);
			func.PCall(oldTop, 1);
			func.EndPCall(oldTop);
		});
	}

	public static Delegate UIEventListener_BoolDelegate(LuaFunction func)
	{
		return new UIEventListener.BoolDelegate(delegate(GameObject param0, bool param1)
		{
			int oldTop = func.BeginPCall();
			IntPtr luaState = func.GetLuaState();
			LuaScriptMgr.Push(luaState, param0);
			LuaScriptMgr.Push(luaState, param1);
			func.PCall(oldTop, 2);
			func.EndPCall(oldTop);
		});
	}

	public static Delegate UIEventListener_FloatDelegate(LuaFunction func)
	{
		return new UIEventListener.FloatDelegate(delegate(GameObject param0, float param1)
		{
			int oldTop = func.BeginPCall();
			IntPtr luaState = func.GetLuaState();
			LuaScriptMgr.Push(luaState, param0);
			LuaScriptMgr.Push(luaState, param1);
			func.PCall(oldTop, 2);
			func.EndPCall(oldTop);
		});
	}

	public static Delegate UIEventListener_VectorDelegate(LuaFunction func)
	{
		return new UIEventListener.VectorDelegate(delegate(GameObject param0, Vector2 param1)
		{
			int oldTop = func.BeginPCall();
			IntPtr luaState = func.GetLuaState();
			LuaScriptMgr.Push(luaState, param0);
			LuaScriptMgr.Push(luaState, param1);
			func.PCall(oldTop, 2);
			func.EndPCall(oldTop);
		});
	}

	public static Delegate UIEventListener_ObjectDelegate(LuaFunction func)
	{
		return new UIEventListener.ObjectDelegate(delegate(GameObject param0, GameObject param1)
		{
			int oldTop = func.BeginPCall();
			IntPtr luaState = func.GetLuaState();
			LuaScriptMgr.Push(luaState, param0);
			LuaScriptMgr.Push(luaState, param1);
			func.PCall(oldTop, 2);
			func.EndPCall(oldTop);
		});
	}

	public static Delegate UIEventListener_KeyCodeDelegate(LuaFunction func)
	{
		return new UIEventListener.KeyCodeDelegate(delegate(GameObject param0, KeyCode param1)
		{
			int oldTop = func.BeginPCall();
			IntPtr luaState = func.GetLuaState();
			LuaScriptMgr.Push(luaState, param0);
			LuaScriptMgr.Push(luaState, param1);
			func.PCall(oldTop, 2);
			func.EndPCall(oldTop);
		});
	}

	public static Delegate EventDelegate_Callback(LuaFunction func)
	{
		return new EventDelegate.Callback(delegate
		{
			func.Call();
		});
	}

	public static Delegate SpringPanel_OnFinished(LuaFunction func)
	{
		return new SpringPanel.OnFinished(delegate
		{
			func.Call();
		});
	}

	public static Delegate DelManager_GameObjDelegate(LuaFunction func)
	{
		return new DelManager.GameObjDelegate(delegate(GameObject param0)
		{
			int oldTop = func.BeginPCall();
			IntPtr luaState = func.GetLuaState();
			LuaScriptMgr.Push(luaState, param0);
			func.PCall(oldTop, 1);
			func.EndPCall(oldTop);
		});
	}

	public static Delegate UILib_ButtonClickEventHandler(LuaFunction func)
	{
		return new ButtonClickEventHandler(delegate(IXUIButton param0)
		{
			int oldTop = func.BeginPCall();
			IntPtr luaState = func.GetLuaState();
			LuaScriptMgr.PushObject(luaState, param0);
			func.PCall(oldTop, 1);
			object[] array = func.PopValues(oldTop);
			func.EndPCall(oldTop);
			return (bool)array[0];
		});
	}

	public static Delegate UILib_SpriteClickEventHandler(LuaFunction func)
	{
		return new SpriteClickEventHandler(delegate(IXUISprite param0)
		{
			int oldTop = func.BeginPCall();
			IntPtr luaState = func.GetLuaState();
			LuaScriptMgr.PushObject(luaState, param0);
			func.PCall(oldTop, 1);
			func.EndPCall(oldTop);
		});
	}

	public static Delegate UILib_RefreshRenderQueueCb(LuaFunction func)
	{
		return new RefreshRenderQueueCb(delegate(int param0)
		{
			int oldTop = func.BeginPCall();
			IntPtr luaState = func.GetLuaState();
			LuaScriptMgr.Push(luaState, param0);
			func.PCall(oldTop, 1);
			object[] array = func.PopValues(oldTop);
			func.EndPCall(oldTop);
			return (bool)array[0];
		});
	}

	public static void Clear()
	{
		DelegateFactory.dict.Clear();
	}
}
