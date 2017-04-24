using System;

namespace UILib
{
	public interface IXUIScrollBar
	{
		float value
		{
			get;
			set;
		}

		float size
		{
			get;
			set;
		}

		void RegisterScrollBarChangeEventHandler(ScrollBarChangeEventHandler eventHandler);

		void RegisterScrollBarDragFinishedEventHandler(ScrollBarDragFinishedEventHandler eventHandler);
	}
}
