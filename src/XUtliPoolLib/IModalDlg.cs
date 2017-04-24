using System;
using UILib;

namespace XUtliPoolLib
{
	public interface IModalDlg : IXInterface
	{
		void LuaShow(string content, ButtonClickEventHandler handler, ButtonClickEventHandler handler2);
	}
}
