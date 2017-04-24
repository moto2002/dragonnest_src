using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface ILoopScrollView
	{
		GameObject gameobject
		{
			get;
		}

		void Init(List<LoopItemData> datas, DelegateHandler onItemInitCallback, Action onDragfinish, int pivot = 0);

		GameObject GetTpl();

		bool IsScrollLast();

		void ResetScroll();

		void SetDepth(int delpth);

		GameObject GetFirstItem();

		GameObject GetLastItem();

		void AddItem(LoopItemData data);

		void SetClipSize(Vector2 size);
	}
}
