using System;
using UnityEngine;

namespace UILib
{
	public interface IXUISprite : IXUIObject, IUIWidget, IUIRect, IXUICD
	{
		IXUIAtlas uiAtlas
		{
			get;
		}

		string spriteName
		{
			get;
			set;
		}

		int spriteWidth
		{
			get;
			set;
		}

		int spriteHeight
		{
			get;
			set;
		}

		int spriteDepth
		{
			get;
			set;
		}

		Vector4 drawRegion
		{
			get;
			set;
		}

		void SetAlpha(float alpha);

		float GetAlpha();

		bool SetSprite(string strSprite, string strAtlas);

		bool SetSprite(string strSprite);

		void SetEnabled(bool bEnabled);

		void SetGrey(bool bGrey);

		void SetColor(Color c);

		void SetAudioClip(string name);

		void CloseScrollView();

		void MakePixelPerfect();

		void RegisterSpriteClickEventHandler(SpriteClickEventHandler eventHandler);

		void RegisterSpritePressEventHandler(SpritePressEventHandler eventHandler);

		void RegisterSpriteDragEventHandler(SpriteDragEventHandler eventHandler);

		void SetRootAsUIPanel(bool bFlag);

		void SetFillAmount(float val);

		void SetFlipHorizontal(bool bValue);

		void SetFlipVertical(bool bValue);

		void ResetAnimationAndPlay();

		SpriteClickEventHandler GetSpriteClickHandler();

		SpritePressEventHandler GetSpritePressHandler();

		void ResetPanel();

		void UpdateAnchors();

		bool IsEnabled();

		void DelayLoadSprite();
	}
}
