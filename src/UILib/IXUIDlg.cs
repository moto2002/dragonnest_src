using System;

namespace UILib
{
	public interface IXUIDlg
	{
		IXUIBehaviour uiBehaviourInterface
		{
			get;
		}

		string fileName
		{
			get;
		}

		int layer
		{
			get;
		}

		int group
		{
			get;
		}

		bool exclusive
		{
			get;
		}

		bool hideMainMenu
		{
			get;
		}

		bool pushstack
		{
			get;
		}

		bool isMainUI
		{
			get;
		}

		bool isHideTutorial
		{
			get;
		}

		bool isHideChat
		{
			get;
		}

		int sysid
		{
			get;
		}

		bool fullscreenui
		{
			get;
		}

		bool needOnTop
		{
			get;
		}

		void OnUpdate();

		void OnPostUpdate();

		void Load();

		void UnLoad(bool bTransfer = false);

		void SetVisiblePure(bool bVisible);

		void SetVisible(bool bVisible, bool bEnableAuto = true);

		bool IsVisible();

		void Reset();

		void SetDepthZ(int nDepthZ);

		bool BindReverse(IXUIBehaviour uiBehaviour);

		void SetAlpha(float a);

		void StackRefresh();

		void LeaveStackTop();

		void SetRelatedVisible(bool bVisible);

		int[] GetTitanBarItems();
	}
}
