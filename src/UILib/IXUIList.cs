using System;

namespace UILib
{
	public interface IXUIList : IXUIObject
	{
		void Refresh();

		void CloseList();

		void SetAnimateSmooth(bool b);

		void RegisterRepositionHandle(OnAfterRepostion reposition);

		IUIRect GetParentUIRect();

		IUIPanel GetParentPanel();
	}
}
