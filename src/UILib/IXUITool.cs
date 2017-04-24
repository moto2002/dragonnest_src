using System;
using UnityEngine;

namespace UILib
{
	public interface IXUITool
	{
		void SetActive(GameObject obj, bool state);

		void SetLayer(GameObject go, int layer);

		void SetUIEventFallThrough(GameObject obj);

		void SetUIGenericEventHandle(GameObject obj);

		void ShowTooltip(string str);

		void RegisterLoadUIAsynEventHandler(LoadUIAsynEventHandler eventHandler);

		Camera GetUICamera();

		void PlayAnim(Animation anim, string strClipName, AnimFinishedEventHandler eventHandler);

		void MarkParentAsChanged(GameObject go);

		void Destroy(UnityEngine.Object obj);

		void SetUIDepthDelta(GameObject go, int delta);

		string GetLocalizedStr(string key);

		Vector2 CalculatePrintedSize(string text);

		void ReleaseAllDrawCall();

		void HideGameObject(GameObject go);

		void ShowGameObject(GameObject go, IXUIPanel panel);

		void ChangePanel(GameObject go, IUIRect parent, IXUIPanel panel);

		void ChangePanel(GameObject go, IUIRect parent, IUIPanel panel);

		void SetRootPanelUpdateFreq(int count);

		void PreLoad(bool half);

		void EnableUILoadingUpdate(bool enable);

		void SetUIOptOption(bool globalMerge, bool selectMerge, bool lowDeviceMerge);
	}
}
