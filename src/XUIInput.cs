using System;
using UILib;
using UnityEngine;

public class XUIInput : XUIObject, IXUIObject, IXUIInput
{
	private UIInput m_uiInput;

	private InputKeyTriggeredEventHandler m_keyTriggerEventHandler;

	private InputSubmitEventHandler m_submitEventHandler;

	private InputChangeEventHandler m_changeEventHandler;

	protected override void OnAwake()
	{
		base.OnAwake();
		this.m_uiInput = base.GetComponent<UIInput>();
		if (null == this.m_uiInput)
		{
			Debug.LogError("null == m_uiInput");
		}
	}

	public void selected(bool value)
	{
		this.m_uiInput.isSelected = value;
	}

	public string GetText()
	{
		if (null != this.m_uiInput)
		{
			return this.m_uiInput.value;
		}
		return string.Empty;
	}

	public void SetText(string strText)
	{
		if (null != this.m_uiInput)
		{
			this.m_uiInput.value = strText;
		}
	}

	public void SetDefault(string strText)
	{
		if (null != this.m_uiInput)
		{
			this.m_uiInput.defaultText = strText;
		}
	}

	public void RegisterKeyTriggeredEventHandler(InputKeyTriggeredEventHandler eventHandler)
	{
		EventDelegate.Add(this.m_uiInput.onKeyTriggered, new EventDelegate.Callback(this.OnKeyTriggered));
		this.m_keyTriggerEventHandler = eventHandler;
	}

	public void OnKeyTriggered()
	{
		if (this.m_keyTriggerEventHandler != null)
		{
			this.m_keyTriggerEventHandler(this, UIInput.current.recentKey);
		}
	}

	public void RegisterSubmitEventHandler(InputSubmitEventHandler eventHandler)
	{
		EventDelegate.Add(this.m_uiInput.onSubmit, new EventDelegate.Callback(this.OnSubmit));
		this.m_submitEventHandler = eventHandler;
	}

	public void OnSubmit()
	{
		if (this.m_submitEventHandler != null)
		{
			this.m_submitEventHandler(this);
		}
	}

	public void RegisterChangeEventHandler(InputChangeEventHandler eventHandler)
	{
		EventDelegate.Add(this.m_uiInput.onChange, new EventDelegate.Callback(this.OnChange));
		this.m_changeEventHandler = eventHandler;
	}

	public void OnChange()
	{
		if (this.m_changeEventHandler != null)
		{
			this.m_changeEventHandler(this);
		}
	}

	public void SetCharacterLimit(int num)
	{
		this.m_uiInput.characterLimit = num;
	}
}
