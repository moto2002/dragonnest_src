using System;

namespace UILib
{
	public interface IXUILongPress : IXUIObject
	{
		void RegisterSpriteLongPressEventHandler(SpriteClickEventHandler eventHandler);
	}
}
