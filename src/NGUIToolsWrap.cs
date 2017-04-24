using LuaInterface;
using System;
using UnityEngine;

public class NGUIToolsWrap
{
	private static Type classType = typeof(NGUITools);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("PlaySound", new LuaCSFunction(NGUIToolsWrap.PlaySound)),
			new LuaMethod("PlayFmod", new LuaCSFunction(NGUIToolsWrap.PlayFmod)),
			new LuaMethod("OpenURL", new LuaCSFunction(NGUIToolsWrap.OpenURL)),
			new LuaMethod("RandomRange", new LuaCSFunction(NGUIToolsWrap.RandomRange)),
			new LuaMethod("GetHierarchy", new LuaCSFunction(NGUIToolsWrap.GetHierarchy)),
			new LuaMethod("FindCameraForLayer", new LuaCSFunction(NGUIToolsWrap.FindCameraForLayer)),
			new LuaMethod("AddWidgetCollider", new LuaCSFunction(NGUIToolsWrap.AddWidgetCollider)),
			new LuaMethod("UpdateWidgetCollider", new LuaCSFunction(NGUIToolsWrap.UpdateWidgetCollider)),
			new LuaMethod("GetTypeName", new LuaCSFunction(NGUIToolsWrap.GetTypeName)),
			new LuaMethod("RegisterUndo", new LuaCSFunction(NGUIToolsWrap.RegisterUndo)),
			new LuaMethod("SetDirty", new LuaCSFunction(NGUIToolsWrap.SetDirty)),
			new LuaMethod("AddChild", new LuaCSFunction(NGUIToolsWrap.AddChild)),
			new LuaMethod("CalculateRaycastDepth", new LuaCSFunction(NGUIToolsWrap.CalculateRaycastDepth)),
			new LuaMethod("CalculateNextDepth", new LuaCSFunction(NGUIToolsWrap.CalculateNextDepth)),
			new LuaMethod("AdjustDepth", new LuaCSFunction(NGUIToolsWrap.AdjustDepth)),
			new LuaMethod("BringForward", new LuaCSFunction(NGUIToolsWrap.BringForward)),
			new LuaMethod("PushBack", new LuaCSFunction(NGUIToolsWrap.PushBack)),
			new LuaMethod("NormalizeDepths", new LuaCSFunction(NGUIToolsWrap.NormalizeDepths)),
			new LuaMethod("NormalizeWidgetDepths", new LuaCSFunction(NGUIToolsWrap.NormalizeWidgetDepths)),
			new LuaMethod("NormalizePanelDepths", new LuaCSFunction(NGUIToolsWrap.NormalizePanelDepths)),
			new LuaMethod("CreateUI", new LuaCSFunction(NGUIToolsWrap.CreateUI)),
			new LuaMethod("SetChildLayer", new LuaCSFunction(NGUIToolsWrap.SetChildLayer)),
			new LuaMethod("AddSprite", new LuaCSFunction(NGUIToolsWrap.AddSprite)),
			new LuaMethod("GetRoot", new LuaCSFunction(NGUIToolsWrap.GetRoot)),
			new LuaMethod("Destroy", new LuaCSFunction(NGUIToolsWrap.Destroy)),
			new LuaMethod("DestroyImmediate", new LuaCSFunction(NGUIToolsWrap.DestroyImmediate)),
			new LuaMethod("Broadcast", new LuaCSFunction(NGUIToolsWrap.Broadcast)),
			new LuaMethod("IsChild", new LuaCSFunction(NGUIToolsWrap.IsChild)),
			new LuaMethod("SetActive", new LuaCSFunction(NGUIToolsWrap.SetActive)),
			new LuaMethod("SetActiveChildren", new LuaCSFunction(NGUIToolsWrap.SetActiveChildren)),
			new LuaMethod("GetActive", new LuaCSFunction(NGUIToolsWrap.GetActive)),
			new LuaMethod("SetActiveSelf", new LuaCSFunction(NGUIToolsWrap.SetActiveSelf)),
			new LuaMethod("SetLayer", new LuaCSFunction(NGUIToolsWrap.SetLayer)),
			new LuaMethod("Round", new LuaCSFunction(NGUIToolsWrap.Round)),
			new LuaMethod("MakePixelPerfect", new LuaCSFunction(NGUIToolsWrap.MakePixelPerfect)),
			new LuaMethod("Save", new LuaCSFunction(NGUIToolsWrap.Save)),
			new LuaMethod("Load", new LuaCSFunction(NGUIToolsWrap.Load)),
			new LuaMethod("ApplyPMA", new LuaCSFunction(NGUIToolsWrap.ApplyPMA)),
			new LuaMethod("MarkParentAsChanged", new LuaCSFunction(NGUIToolsWrap.MarkParentAsChanged)),
			new LuaMethod("ParentPanelChanged", new LuaCSFunction(NGUIToolsWrap.ParentPanelChanged)),
			new LuaMethod("GetSides", new LuaCSFunction(NGUIToolsWrap.GetSides)),
			new LuaMethod("GetWorldCorners", new LuaCSFunction(NGUIToolsWrap.GetWorldCorners)),
			new LuaMethod("GetFuncName", new LuaCSFunction(NGUIToolsWrap.GetFuncName)),
			new LuaMethod("New", new LuaCSFunction(NGUIToolsWrap._CreateNGUITools)),
			new LuaMethod("GetClassType", new LuaCSFunction(NGUIToolsWrap.GetClassType))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("mEnableLoadingUpdate", new LuaCSFunction(NGUIToolsWrap.get_mEnableLoadingUpdate), new LuaCSFunction(NGUIToolsWrap.set_mEnableLoadingUpdate)),
			new LuaField("soundVolume", new LuaCSFunction(NGUIToolsWrap.get_soundVolume), new LuaCSFunction(NGUIToolsWrap.set_soundVolume)),
			new LuaField("fileAccess", new LuaCSFunction(NGUIToolsWrap.get_fileAccess), null),
			new LuaField("clipboard", new LuaCSFunction(NGUIToolsWrap.get_clipboard), new LuaCSFunction(NGUIToolsWrap.set_clipboard))
		};
		LuaScriptMgr.RegisterLib(L, "NGUITools", typeof(NGUITools), regs, fields, null);
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateNGUITools(IntPtr L)
	{
		LuaDLL.luaL_error(L, "NGUITools class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, NGUIToolsWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mEnableLoadingUpdate(IntPtr L)
	{
		LuaScriptMgr.Push(L, NGUITools.mEnableLoadingUpdate);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_soundVolume(IntPtr L)
	{
		LuaScriptMgr.Push(L, NGUITools.soundVolume);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fileAccess(IntPtr L)
	{
		LuaScriptMgr.Push(L, NGUITools.fileAccess);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_clipboard(IntPtr L)
	{
		LuaScriptMgr.Push(L, NGUITools.clipboard);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mEnableLoadingUpdate(IntPtr L)
	{
		NGUITools.mEnableLoadingUpdate = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_soundVolume(IntPtr L)
	{
		NGUITools.soundVolume = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clipboard(IntPtr L)
	{
		NGUITools.clipboard = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlaySound(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			AudioClip clip = (AudioClip)LuaScriptMgr.GetUnityObject(L, 1, typeof(AudioClip));
			AudioSource obj = NGUITools.PlaySound(clip);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		if (num == 2)
		{
			AudioClip clip2 = (AudioClip)LuaScriptMgr.GetUnityObject(L, 1, typeof(AudioClip));
			float volume = (float)LuaScriptMgr.GetNumber(L, 2);
			AudioSource obj2 = NGUITools.PlaySound(clip2, volume);
			LuaScriptMgr.Push(L, obj2);
			return 1;
		}
		if (num == 3)
		{
			AudioClip clip3 = (AudioClip)LuaScriptMgr.GetUnityObject(L, 1, typeof(AudioClip));
			float volume2 = (float)LuaScriptMgr.GetNumber(L, 2);
			float pitch = (float)LuaScriptMgr.GetNumber(L, 3);
			AudioSource obj3 = NGUITools.PlaySound(clip3, volume2, pitch);
			LuaScriptMgr.Push(L, obj3);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.PlaySound");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayFmod(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		NGUITools.PlayFmod(luaString);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OpenURL(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			string luaString = LuaScriptMgr.GetLuaString(L, 1);
			WWW o = NGUITools.OpenURL(luaString);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		if (num == 2)
		{
			string luaString2 = LuaScriptMgr.GetLuaString(L, 1);
			WWWForm form = (WWWForm)LuaScriptMgr.GetNetObject(L, 2, typeof(WWWForm));
			WWW o2 = NGUITools.OpenURL(luaString2, form);
			LuaScriptMgr.PushObject(L, o2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.OpenURL");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RandomRange(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int min = (int)LuaScriptMgr.GetNumber(L, 1);
		int max = (int)LuaScriptMgr.GetNumber(L, 2);
		int d = NGUITools.RandomRange(min, max);
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetHierarchy(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameObject obj = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		string hierarchy = NGUITools.GetHierarchy(obj);
		LuaScriptMgr.Push(L, hierarchy);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindCameraForLayer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int layer = (int)LuaScriptMgr.GetNumber(L, 1);
		Camera obj = NGUITools.FindCameraForLayer(layer);
		LuaScriptMgr.Push(L, obj);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddWidgetCollider(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			BoxCollider obj = NGUITools.AddWidgetCollider(go);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		if (num == 2)
		{
			GameObject go2 = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			bool boolean = LuaScriptMgr.GetBoolean(L, 2);
			BoxCollider obj2 = NGUITools.AddWidgetCollider(go2, boolean);
			LuaScriptMgr.Push(L, obj2);
			return 1;
		}
		if (num == 3)
		{
			GameObject go3 = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			UIWidget w = (UIWidget)LuaScriptMgr.GetUnityObject(L, 2, typeof(UIWidget));
			bool boolean2 = LuaScriptMgr.GetBoolean(L, 3);
			BoxCollider obj3 = NGUITools.AddWidgetCollider(go3, w, boolean2);
			LuaScriptMgr.Push(L, obj3);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.AddWidgetCollider");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateWidgetCollider(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UIWidget w = (UIWidget)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIWidget));
		BoxCollider box = (BoxCollider)LuaScriptMgr.GetUnityObject(L, 2, typeof(BoxCollider));
		bool boolean = LuaScriptMgr.GetBoolean(L, 3);
		NGUITools.UpdateWidgetCollider(w, box, boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTypeName(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UnityEngine.Object unityObject = LuaScriptMgr.GetUnityObject(L, 1, typeof(UnityEngine.Object));
		string typeName = NGUITools.GetTypeName(unityObject);
		LuaScriptMgr.Push(L, typeName);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RegisterUndo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UnityEngine.Object unityObject = LuaScriptMgr.GetUnityObject(L, 1, typeof(UnityEngine.Object));
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		NGUITools.RegisterUndo(unityObject, luaString);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetDirty(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UnityEngine.Object unityObject = LuaScriptMgr.GetUnityObject(L, 1, typeof(UnityEngine.Object));
		NGUITools.SetDirty(unityObject);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddChild(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			GameObject parent = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			GameObject obj = NGUITools.AddChild(parent);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(GameObject), typeof(GameObject)))
		{
			GameObject parent2 = (GameObject)LuaScriptMgr.GetLuaObject(L, 1);
			GameObject prefab = (GameObject)LuaScriptMgr.GetLuaObject(L, 2);
			GameObject obj2 = NGUITools.AddChild(parent2, prefab);
			LuaScriptMgr.Push(L, obj2);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(GameObject), typeof(bool)))
		{
			GameObject parent3 = (GameObject)LuaScriptMgr.GetLuaObject(L, 1);
			bool undo = LuaDLL.lua_toboolean(L, 2);
			GameObject obj3 = NGUITools.AddChild(parent3, undo);
			LuaScriptMgr.Push(L, obj3);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.AddChild");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateRaycastDepth(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		int d = NGUITools.CalculateRaycastDepth(go);
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateNextDepth(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			int d = NGUITools.CalculateNextDepth(go);
			LuaScriptMgr.Push(L, d);
			return 1;
		}
		if (num == 2)
		{
			GameObject go2 = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			bool boolean = LuaScriptMgr.GetBoolean(L, 2);
			int d2 = NGUITools.CalculateNextDepth(go2, boolean);
			LuaScriptMgr.Push(L, d2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.CalculateNextDepth");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AdjustDepth(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		int adjustment = (int)LuaScriptMgr.GetNumber(L, 2);
		int d = NGUITools.AdjustDepth(go, adjustment);
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int BringForward(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		NGUITools.BringForward(go);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PushBack(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		NGUITools.PushBack(go);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int NormalizeDepths(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		NGUITools.NormalizeDepths();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int NormalizeWidgetDepths(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		NGUITools.NormalizeWidgetDepths();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int NormalizePanelDepths(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		NGUITools.NormalizePanelDepths();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateUI(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			bool boolean = LuaScriptMgr.GetBoolean(L, 1);
			UIPanel obj = NGUITools.CreateUI(boolean);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		if (num == 2)
		{
			bool boolean2 = LuaScriptMgr.GetBoolean(L, 1);
			int layer = (int)LuaScriptMgr.GetNumber(L, 2);
			UIPanel obj2 = NGUITools.CreateUI(boolean2, layer);
			LuaScriptMgr.Push(L, obj2);
			return 1;
		}
		if (num == 3)
		{
			Transform trans = (Transform)LuaScriptMgr.GetUnityObject(L, 1, typeof(Transform));
			bool boolean3 = LuaScriptMgr.GetBoolean(L, 2);
			int layer2 = (int)LuaScriptMgr.GetNumber(L, 3);
			UIPanel obj3 = NGUITools.CreateUI(trans, boolean3, layer2);
			LuaScriptMgr.Push(L, obj3);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.CreateUI");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetChildLayer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Transform t = (Transform)LuaScriptMgr.GetUnityObject(L, 1, typeof(Transform));
		int layer = (int)LuaScriptMgr.GetNumber(L, 2);
		NGUITools.SetChildLayer(t, layer);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddSprite(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		UIAtlas atlas = (UIAtlas)LuaScriptMgr.GetUnityObject(L, 2, typeof(UIAtlas));
		string luaString = LuaScriptMgr.GetLuaString(L, 3);
		UISprite obj = NGUITools.AddSprite(go, atlas, luaString);
		LuaScriptMgr.Push(L, obj);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRoot(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		GameObject root = NGUITools.GetRoot(go);
		LuaScriptMgr.Push(L, root);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Destroy(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UnityEngine.Object unityObject = LuaScriptMgr.GetUnityObject(L, 1, typeof(UnityEngine.Object));
		NGUITools.Destroy(unityObject);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DestroyImmediate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UnityEngine.Object unityObject = LuaScriptMgr.GetUnityObject(L, 1, typeof(UnityEngine.Object));
		NGUITools.DestroyImmediate(unityObject);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Broadcast(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			string luaString = LuaScriptMgr.GetLuaString(L, 1);
			NGUITools.Broadcast(luaString);
			return 0;
		}
		if (num == 2)
		{
			string luaString2 = LuaScriptMgr.GetLuaString(L, 1);
			object varObject = LuaScriptMgr.GetVarObject(L, 2);
			NGUITools.Broadcast(luaString2, varObject);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.Broadcast");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsChild(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Transform parent = (Transform)LuaScriptMgr.GetUnityObject(L, 1, typeof(Transform));
		Transform child = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
		bool b = NGUITools.IsChild(parent, child);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetActive(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			bool boolean = LuaScriptMgr.GetBoolean(L, 2);
			NGUITools.SetActive(go, boolean);
			return 0;
		}
		if (num == 3)
		{
			GameObject go2 = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			bool boolean2 = LuaScriptMgr.GetBoolean(L, 2);
			bool boolean3 = LuaScriptMgr.GetBoolean(L, 3);
			NGUITools.SetActive(go2, boolean2, boolean3);
			return 0;
		}
		if (num == 4)
		{
			GameObject go3 = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			bool boolean4 = LuaScriptMgr.GetBoolean(L, 2);
			bool boolean5 = LuaScriptMgr.GetBoolean(L, 3);
			bool boolean6 = LuaScriptMgr.GetBoolean(L, 4);
			NGUITools.SetActive(go3, boolean4, boolean5, boolean6);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.SetActive");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetActiveChildren(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		NGUITools.SetActiveChildren(go, boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetActive(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(GameObject)))
		{
			GameObject go = (GameObject)LuaScriptMgr.GetLuaObject(L, 1);
			bool active = NGUITools.GetActive(go);
			LuaScriptMgr.Push(L, active);
			return 1;
		}
		if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(Behaviour)))
		{
			Behaviour mb = (Behaviour)LuaScriptMgr.GetLuaObject(L, 1);
			bool active2 = NGUITools.GetActive(mb);
			LuaScriptMgr.Push(L, active2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.GetActive");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetActiveSelf(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		bool boolean = LuaScriptMgr.GetBoolean(L, 2);
		NGUITools.SetActiveSelf(go, boolean);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetLayer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		int layer = (int)LuaScriptMgr.GetNumber(L, 2);
		NGUITools.SetLayer(go, layer);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Round(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Vector3 vector = LuaScriptMgr.GetVector3(L, 1);
		Vector3 v = NGUITools.Round(vector);
		LuaScriptMgr.Push(L, v);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MakePixelPerfect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Transform t = (Transform)LuaScriptMgr.GetUnityObject(L, 1, typeof(Transform));
		NGUITools.MakePixelPerfect(t);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Save(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		byte[] arrayNumber = LuaScriptMgr.GetArrayNumber<byte>(L, 2);
		bool b = NGUITools.Save(luaString, arrayNumber);
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Load(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 1);
		byte[] o = NGUITools.Load(luaString);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ApplyPMA(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Color color = LuaScriptMgr.GetColor(L, 1);
		Color clr = NGUITools.ApplyPMA(color);
		LuaScriptMgr.Push(L, clr);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MarkParentAsChanged(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		NGUITools.MarkParentAsChanged(go);
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ParentPanelChanged(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 2)
		{
			GameObject go = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			UIPanel panel = (UIPanel)LuaScriptMgr.GetUnityObject(L, 2, typeof(UIPanel));
			NGUITools.ParentPanelChanged(go, panel);
			return 0;
		}
		if (num == 3)
		{
			GameObject go2 = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
			UIRect parent = (UIRect)LuaScriptMgr.GetUnityObject(L, 2, typeof(UIRect));
			UIPanel panel2 = (UIPanel)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIPanel));
			NGUITools.ParentPanelChanged(go2, parent, panel2);
			return 0;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.ParentPanelChanged");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSides(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			Camera cam = (Camera)LuaScriptMgr.GetUnityObject(L, 1, typeof(Camera));
			Vector3[] sides = cam.GetSides();
			LuaScriptMgr.PushArray(L, sides);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Camera), typeof(Transform)))
		{
			Camera cam2 = (Camera)LuaScriptMgr.GetLuaObject(L, 1);
			Transform relativeTo = (Transform)LuaScriptMgr.GetLuaObject(L, 2);
			Vector3[] sides2 = cam2.GetSides(relativeTo);
			LuaScriptMgr.PushArray(L, sides2);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Camera), typeof(float)))
		{
			Camera cam3 = (Camera)LuaScriptMgr.GetLuaObject(L, 1);
			float depth = (float)LuaDLL.lua_tonumber(L, 2);
			Vector3[] sides3 = cam3.GetSides(depth);
			LuaScriptMgr.PushArray(L, sides3);
			return 1;
		}
		if (num == 3)
		{
			Camera cam4 = (Camera)LuaScriptMgr.GetUnityObject(L, 1, typeof(Camera));
			float depth2 = (float)LuaScriptMgr.GetNumber(L, 2);
			Transform relativeTo2 = (Transform)LuaScriptMgr.GetUnityObject(L, 3, typeof(Transform));
			Vector3[] sides4 = cam4.GetSides(depth2, relativeTo2);
			LuaScriptMgr.PushArray(L, sides4);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.GetSides");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetWorldCorners(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			Camera cam = (Camera)LuaScriptMgr.GetUnityObject(L, 1, typeof(Camera));
			Vector3[] worldCorners = cam.GetWorldCorners();
			LuaScriptMgr.PushArray(L, worldCorners);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Camera), typeof(Transform)))
		{
			Camera cam2 = (Camera)LuaScriptMgr.GetLuaObject(L, 1);
			Transform relativeTo = (Transform)LuaScriptMgr.GetLuaObject(L, 2);
			Vector3[] worldCorners2 = cam2.GetWorldCorners(relativeTo);
			LuaScriptMgr.PushArray(L, worldCorners2);
			return 1;
		}
		if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Camera), typeof(float)))
		{
			Camera cam3 = (Camera)LuaScriptMgr.GetLuaObject(L, 1);
			float depth = (float)LuaDLL.lua_tonumber(L, 2);
			Vector3[] worldCorners3 = cam3.GetWorldCorners(depth);
			LuaScriptMgr.PushArray(L, worldCorners3);
			return 1;
		}
		if (num == 3)
		{
			Camera cam4 = (Camera)LuaScriptMgr.GetUnityObject(L, 1, typeof(Camera));
			float depth2 = (float)LuaScriptMgr.GetNumber(L, 2);
			Transform relativeTo2 = (Transform)LuaScriptMgr.GetUnityObject(L, 3, typeof(Transform));
			Vector3[] worldCorners4 = cam4.GetWorldCorners(depth2, relativeTo2);
			LuaScriptMgr.PushArray(L, worldCorners4);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.GetWorldCorners");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetFuncName(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		object varObject = LuaScriptMgr.GetVarObject(L, 1);
		string luaString = LuaScriptMgr.GetLuaString(L, 2);
		string funcName = NGUITools.GetFuncName(varObject, luaString);
		LuaScriptMgr.Push(L, funcName);
		return 1;
	}
}
