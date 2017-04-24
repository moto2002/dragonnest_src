using System;
using UnityEngine;

namespace UILib
{
	public interface IXUIComboBox : IXUIObject
	{
		void ModuleInit();

		void AddItem(string text, int value);

		GameObject GetItem(int value);

		void ClearItems();

		bool SelectItem(int value, bool withCallback);

		void RegisterSpriteClickEventHandler(ComboboxClickEventHandler eventHandler);

		void ResetState();
	}
}
