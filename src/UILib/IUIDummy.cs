using System;

namespace UILib
{
	public interface IUIDummy : IUIWidget, IUIRect
	{
		int RenderQueue
		{
			get;
		}

		RefreshRenderQueueCb RefreshRenderQueue
		{
			get;
			set;
		}

		int depth
		{
			get;
			set;
		}

		float alpha
		{
			get;
			set;
		}

		void Reset();
	}
}
