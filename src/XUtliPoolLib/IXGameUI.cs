using System;
using UILib;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IXGameUI : IXInterface
	{
		Transform UIRoot
		{
			get;
			set;
		}

		GameObject[] buttonTpl
		{
			get;
		}

		GameObject[] spriteTpl
		{
			get;
		}

		GameObject DlgControllerTpl
		{
			get;
		}

		int Base_UI_Width
		{
			get;
			set;
		}

		int Base_UI_Height
		{
			get;
			set;
		}

		Camera UICamera
		{
			get;
			set;
		}

		void OnGenericClick();

		void SetOverlayAlpha(float alpha);

		void DelayLoadUISprite(IXUISprite sprite);
	}
}
