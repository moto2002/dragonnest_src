using System;
using System.Collections.Generic;
using UnityEngine;

namespace UILib
{
	public interface IXUIWrapContent : IXUIObject
	{
		bool enableBounds
		{
			get;
			set;
		}

		Vector2 itemSize
		{
			get;
			set;
		}

		int widthDimension
		{
			get;
			set;
		}

		int heightDimensionMax
		{
			get;
		}

		int maxItemCount
		{
			get;
		}

		void SetContentCount(int num, bool fadeIn = false);

		void SetOffset(int offset);

		void RegisterItemUpdateEventHandler(WrapItemUpdateEventHandler eventHandler);

		void RegisterItemInitEventHandler(WrapItemInitEventHandler eventHandler);

		void InitContent();

		void RefreshAllVisibleContents();

		void GetActiveList(List<GameObject> ret);
	}
}
