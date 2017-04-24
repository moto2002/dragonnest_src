using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UILib;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

public class XUITool : MonoBehaviour, IXUITool
{
	private Dictionary<int, uint> _TweenFadeInGroupDelayNum = new Dictionary<int, uint>();

	private IXGameUI m_gameui;

	private LoadUIAsynEventHandler m_loadUIAsynEventHandler;

	private static XUITool s_instance;

	public static XUITool Instance
	{
		get
		{
			return XUITool.s_instance;
		}
	}

	public IXGameUI XGameUI
	{
		get
		{
			if (this.m_gameui == null)
			{
				this.m_gameui = XSingleton<XInterfaceMgr>.singleton.GetInterface<IXGameUI>(XSingleton<XCommon>.singleton.XHash("XGameUI"));
			}
			return this.m_gameui;
		}
	}

	void IXUITool.Destroy(UnityEngine.Object obj)
	{
		NGUITools.Destroy(obj);
	}

	public Camera GetUICamera()
	{
		return UICamera.currentCamera;
	}

	public void SetActive(GameObject obj, bool state)
	{
		NGUITools.SetActive(obj, state);
	}

	public void SetLayer(GameObject go, int layer)
	{
		go.layer = layer;
		Transform transform = go.transform;
		int i = 0;
		int childCount = transform.childCount;
		while (i < childCount)
		{
			Transform child = transform.GetChild(i);
			this.SetLayer(child.gameObject, layer);
			i++;
		}
	}

	public void SetUIDepthDelta(GameObject go, int delta)
	{
		XUISprite[] componentsInChildren = go.GetComponentsInChildren<XUISprite>();
		XUILabel[] componentsInChildren2 = go.GetComponentsInChildren<XUILabel>();
		XUITexture[] componentsInChildren3 = go.GetComponentsInChildren<XUITexture>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].spriteDepth += delta;
		}
		for (int j = 0; j < componentsInChildren2.Length; j++)
		{
			componentsInChildren2[j].spriteDepth += delta;
		}
		for (int k = 0; k < componentsInChildren3.Length; k++)
		{
			componentsInChildren3[k].spriteDepth += delta;
		}
	}

	public void SetUIEventFallThrough(GameObject obj)
	{
		UICamera.fallThrough = obj;
	}

	public void SetUIGenericEventHandle(GameObject obj)
	{
		UICamera.genericEventHandler = obj;
	}

	public void ShowTooltip(string str)
	{
		UITooltip.ShowText(str);
	}

	public void RegisterLoadUIAsynEventHandler(LoadUIAsynEventHandler eventHandler)
	{
		this.m_loadUIAsynEventHandler = eventHandler;
	}

	public void LoadResAsyn(string strFile, LoadUIFinishedEventHandler eventHandler)
	{
		if (this.m_loadUIAsynEventHandler == null)
		{
			UnityEngine.Debug.LogError("null == m_loadUIAsynEventHandler");
		}
	}

	public void SetCursor(string strSpriteName)
	{
	}

	public void SetCursor(string strSprite, string strAtlas)
	{
	}

	public void PlayAnim(Animation anim, string strClipName, AnimFinishedEventHandler eventHandler)
	{
		if (null == anim || strClipName == null || strClipName.Length == 0)
		{
			eventHandler();
			return;
		}
	}

	private void Awake()
	{
		XUITool.s_instance = this;
	}

	public void MarkParentAsChanged(GameObject go)
	{
		NGUITools.MarkParentAsChanged(go);
	}

	public void HideGameObject(GameObject go)
	{
		NGUITools.ParentPanelChanged(go, XSingleton<XUICommon>.singleton.m_inVisiablePanel);
	}

	public void ShowGameObject(GameObject go, IXUIPanel panel)
	{
		XUIPanel xUIPanel = panel as XUIPanel;
		if (xUIPanel != null)
		{
			NGUITools.ParentPanelChanged(go, xUIPanel.UIComponent as UIPanel);
		}
		else
		{
			NGUITools.MarkParentAsChanged(go);
		}
	}

	public void ChangePanel(GameObject go, IUIRect parent, IXUIPanel panel)
	{
		XUIPanel xUIPanel = panel as XUIPanel;
		UIRect parent2 = parent as UIRect;
		if (xUIPanel != null)
		{
			NGUITools.ParentPanelChanged(go, parent2, xUIPanel.UIComponent as UIPanel);
		}
	}

	public void ChangePanel(GameObject go, IUIRect parent, IUIPanel panel)
	{
		UIPanel uIPanel = panel as UIPanel;
		UIRect parent2 = parent as UIRect;
		if (uIPanel != null)
		{
			NGUITools.ParentPanelChanged(go, parent2, uIPanel);
		}
	}

	public string GetLocalizedStr(string key)
	{
		return Localization.Get(key);
	}

	public Vector2 CalculatePrintedSize(string text)
	{
		return NGUIText.CalculatePrintedSize(text, -1);
	}

	public void ReleaseAllDrawCall()
	{
		UIDrawCall.ReleaseInactive();
	}

	public bool GetTweenFadeInDelayByGroup(int group, float interval, int max, out float addDelay)
	{
		addDelay = 0f;
		if (this._TweenFadeInGroupDelayNum.Count == 0)
		{
			base.StartCoroutine(this.ClearFadeInGroupDict());
		}
		uint num;
		if (!this._TweenFadeInGroupDelayNum.TryGetValue(group, out num))
		{
			this._TweenFadeInGroupDelayNum[group] = 0u;
			num = 0u;
			addDelay = 0f;
			return true;
		}
		this._TweenFadeInGroupDelayNum[group] = num + 1u;
		num += 1u;
		if ((ulong)num >= (ulong)((long)max))
		{
			return false;
		}
		addDelay = num * interval;
		return true;
	}

	[DebuggerHidden]
	private IEnumerator ClearFadeInGroupDict()
	{
		XUITool.<ClearFadeInGroupDict>c__Iterator16 <ClearFadeInGroupDict>c__Iterator = new XUITool.<ClearFadeInGroupDict>c__Iterator16();
		<ClearFadeInGroupDict>c__Iterator.<>f__this = this;
		return <ClearFadeInGroupDict>c__Iterator;
	}

	public void ResetGroupDelay(int group)
	{
		if (this._TweenFadeInGroupDelayNum.ContainsKey(group))
		{
			this._TweenFadeInGroupDelayNum.Remove(group);
		}
	}

	public void SetRootPanelUpdateFreq(int count)
	{
		XSingleton<XUICommon>.singleton.SetRootPanelUpdateFreq(count);
	}

	public void PreLoad(bool half)
	{
		if (half)
		{
			XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<GameObject>("atlas/UI/common/BillboardHalf", ".prefab", true);
			XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<GameObject>("atlas/UI/common/TitleHalf", ".prefab", true);
		}
		else
		{
			XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<GameObject>("atlas/UI/common/Billboard", ".prefab", true);
			XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<GameObject>("atlas/UI/common/Title", ".prefab", true);
		}
	}

	public void EnableUILoadingUpdate(bool enable)
	{
		NGUITools.mEnableLoadingUpdate = enable;
	}

	public void SetUIOptOption(bool globalMerge, bool selectMerge, bool lowDeviceMerge)
	{
		if (XSingleton<XUpdater>.singleton.XPlatform.GetQualityLevel() == 0 && !lowDeviceMerge)
		{
			UIPanel.GlobalUseMerge = false;
			UIPanel.SelectUseMerge = selectMerge;
		}
		else
		{
			UIPanel.GlobalUseMerge = globalMerge;
			UIPanel.SelectUseMerge = selectMerge;
		}
	}
}
