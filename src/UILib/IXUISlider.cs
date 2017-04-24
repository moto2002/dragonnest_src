using System;

namespace UILib
{
	public interface IXUISlider : IXUIObject
	{
		float Value
		{
			get;
			set;
		}

		void RegisterValueChangeEventHandler(SliderValueChangeEventHandler eventHandler);

		void RegisterClickEventHandler(SliderClickEventHandler eventHandler);
	}
}
