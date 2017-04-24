using System;
using UILib;
using UnityEngine;

public class XUISlider : XUIObject, IXUIObject, IXUISlider
{
	private SliderClickEventHandler m_clickedEventHandler;

	private UISlider m_uiSlider;

	public float Value
	{
		get
		{
			return this.m_uiSlider.value;
		}
		set
		{
			this.m_uiSlider.value = value;
		}
	}

	protected override void OnAwake()
	{
		base.OnAwake();
		this.m_uiSlider = base.GetComponent<UISlider>();
		if (null == this.m_uiSlider)
		{
			Debug.LogError("null == m_uiSlider");
		}
	}

	public void RegisterValueChangeEventHandler(SliderValueChangeEventHandler eventHandler)
	{
		this.m_uiSlider.eventHandler = eventHandler;
	}

	public void RegisterClickEventHandler(SliderClickEventHandler eventHandler)
	{
		UIEventListener.Get(base.gameObject).onClick = new UIEventListener.VoidDelegate(this.OnSliderClick);
		this.m_clickedEventHandler = eventHandler;
	}

	private void OnSliderClick(GameObject slider)
	{
		if (this.m_clickedEventHandler != null)
		{
			this.m_clickedEventHandler(slider);
		}
	}
}
