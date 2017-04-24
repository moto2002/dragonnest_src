using System;

namespace UILib
{
	public interface IXUIBehaviour : IXUIObject
	{
		IXUIDlg uiDlgInterface
		{
			get;
		}

		IXUIObject[] uiChilds
		{
			get;
		}
	}
}
