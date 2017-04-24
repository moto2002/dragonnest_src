using System;

namespace UILib
{
	public interface IUIWidget : IUIRect
	{
		IXUIPanel GetPanel();
	}
}
