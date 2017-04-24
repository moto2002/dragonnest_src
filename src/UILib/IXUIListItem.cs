using System;
using UnityEngine;

namespace UILib
{
	public interface IXUIListItem : IXUIObject
	{
		uint id
		{
			get;
			set;
		}

		int Index
		{
			get;
		}

		void SetIconSprite(string strSprite);

		void SetIconSprite(string strSprite, string strAtlas);

		void SetIconTexture(string strTexture);

		void SetTip(string strTip);

		void SetColor(Color color);

		bool SetText(uint unIndex, string strText);

		void SetEnable(bool bEnable);

		void SetEnableSelect(bool bEnable);

		void Clear();
	}
}
