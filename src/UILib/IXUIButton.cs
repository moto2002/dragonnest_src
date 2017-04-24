using System;

namespace UILib
{
	public interface IXUIButton : IXUIObject, IXUICD
	{
		int spriteWidth
		{
			get;
		}

		int spriteHeight
		{
			get;
		}

		int spriteDepth
		{
			get;
			set;
		}

		void SetCaption(string strText);

		void SetEnable(bool bEnable, bool withcollider = false);

		void SetGrey(bool bGrey);

		void SetAlpha(float f);

		void CloseScrollView();

		void RegisterClickEventHandler(ButtonClickEventHandler eventHandler);

		void RegisterPressEventHandler(ButtonPressEventHandler eventHandler);

		void RegisterDragEventHandler(ButtonDragEventHandler eventHandler);

		void SetSpriteWithPrefix(string prefix);

		void SetAudioClip(string name);

		void SetSprites(string normal, string hover, string press);

		ButtonClickEventHandler GetClickEventHandler();

		ButtonPressEventHandler GetPressEventHandler();

		void ResetState();

		void ResetPanel();
	}
}
