using System;

namespace UILib
{
	public interface IXUIInterface
	{
		void ShowUI(string name);

		void HideUI(string name);

		void SetCustomId(string dlgName, string widgetName, uint ID);
	}
}
