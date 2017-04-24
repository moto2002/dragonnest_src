using System;

namespace UILib
{
	public interface IXUIInput : IXUIObject
	{
		string GetText();

		void SetText(string strText);

		void SetCharacterLimit(int num);

		void SetDefault(string strText);

		void RegisterKeyTriggeredEventHandler(InputKeyTriggeredEventHandler eventHandler);

		void RegisterSubmitEventHandler(InputSubmitEventHandler eventHandler);

		void RegisterChangeEventHandler(InputChangeEventHandler eventHandler);

		void selected(bool value);
	}
}
