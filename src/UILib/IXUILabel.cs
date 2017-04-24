using System;
using UnityEngine;

namespace UILib
{
	public interface IXUILabel : IXUIObject
	{
		float AlphaVar
		{
			get;
		}

		float Alpha
		{
			get;
			set;
		}

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

		int fontSize
		{
			get;
			set;
		}

		Color GetColor();

		string GetText();

		void SetText(string strText);

		void SetRootAsUIPanel(bool bFlag);

		void SetColor(Color c);

		void SetEffectColor(Color c);

		void SetGradient(bool bEnable, Color top, Color bottom);

		void ToggleGradient(bool bEnable);

		void SetEnabled(bool bEnabled);

		Vector2 GetPrintSize();

		void SetDepthOffset(int d);

		void RegisterLabelClickEventHandler(LabelClickEventHandler eventHandler);

		void SetIdentity(int i);

		bool HasIdentityChanged(int i);
	}
}
