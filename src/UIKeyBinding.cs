using System;
using UnityEngine;

[AddComponentMenu("Game/UI/Key Binding")]
public class UIKeyBinding : MonoBehaviour
{
	public enum Action
	{
		PressAndClick,
		Select
	}

	public enum Modifier
	{
		None,
		Shift,
		Control,
		Alt
	}

	public KeyCode keyCode;

	public UIKeyBinding.Modifier modifier;

	public UIKeyBinding.Action action;

	private bool mIgnoreUp;

	private bool mIsInput;

	private void Start()
	{
		UIInput component = base.GetComponent<UIInput>();
		this.mIsInput = (component != null);
		if (component != null)
		{
			EventDelegate.Add(component.onSubmit, new EventDelegate.Callback(this.OnSubmit));
		}
	}

	private void OnSubmit()
	{
		if (UICamera.currentKey == this.keyCode && this.IsModifierActive())
		{
			this.mIgnoreUp = true;
		}
	}

	private bool IsModifierActive()
	{
		if (this.modifier == UIKeyBinding.Modifier.None)
		{
			return true;
		}
		if (this.modifier == UIKeyBinding.Modifier.Alt)
		{
			if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
			{
				return true;
			}
		}
		else if (this.modifier == UIKeyBinding.Modifier.Control)
		{
			if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
			{
				return true;
			}
		}
		else if (this.modifier == UIKeyBinding.Modifier.Shift && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
		{
			return true;
		}
		return false;
	}

	private void Update()
	{
		if (this.keyCode == KeyCode.None || !this.IsModifierActive())
		{
			return;
		}
		if (this.action == UIKeyBinding.Action.PressAndClick)
		{
			if (UICamera.inputHasFocus)
			{
				return;
			}
			UICamera.currentTouch = UICamera.controller;
			UICamera.currentScheme = UICamera.ControlScheme.Mouse;
			UICamera.currentTouch.current = base.gameObject;
			if (Input.GetKeyDown(this.keyCode))
			{
				UICamera.Notify(base.gameObject, "OnPress", true);
			}
			if (Input.GetKeyUp(this.keyCode))
			{
				UICamera.Notify(base.gameObject, "OnPress", false);
				UICamera.Notify(base.gameObject, "OnClick", null);
			}
			UICamera.currentTouch.current = null;
		}
		else if (this.action == UIKeyBinding.Action.Select && Input.GetKeyUp(this.keyCode))
		{
			if (this.mIsInput)
			{
				if (!this.mIgnoreUp && !UICamera.inputHasFocus)
				{
					UICamera.selectedObject = base.gameObject;
				}
				this.mIgnoreUp = false;
			}
			else
			{
				UICamera.selectedObject = base.gameObject;
			}
		}
	}
}
