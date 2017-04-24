using System;
using UnityEngine;

namespace UILib
{
	public interface IXUIDragDropItem : IXUIObject
	{
		void RegisterOnStartEventHandler(OnDropStartEventHandler eventHandler);

		void RegisterOnFinishEventHandler(OnDropReleaseEventHandler eventHandler);

		void SetCloneOnDrag(bool cloneOnDrag);

		void SetRestriction(int restriction);

		void SetParent(Transform parent, bool addPanel = false, int depth = 0);

		void SetActive(bool active);

		OnDropStartEventHandler GetStartEventHandler();

		OnDropReleaseEventHandler GetReleaseEventHandler();
	}
}
