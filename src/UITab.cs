using System;
using UnityEngine;

[AddComponentMenu("NGUI/UI/Tab")]
public class UITab : MonoBehaviour
{
	public delegate void OnTabClick();

	public UIWidget[] tabSprite;

	public bool startsChecked = true;

	public Transform tabRoot;

	public bool mChecked;

	private bool mStarted;

	public UITab.OnTabClick onTabClick;

	public GameObject eventReceiver;

	public string functionName = "OnTabClick";

	public bool isChecked
	{
		get
		{
			return this.mChecked;
		}
		set
		{
			this.mChecked = value;
			this.Set(value);
		}
	}

	private void Awake()
	{
		UIWidget[] array = this.tabSprite;
		for (int i = 0; i < array.Length; i++)
		{
			UIWidget uIWidget = array[i];
			if (uIWidget != null)
			{
				uIWidget.alpha = ((!this.startsChecked) ? 0f : 1f);
			}
		}
		if (this.tabRoot == null)
		{
			this.tabRoot = base.transform.parent;
		}
	}

	private void OnClick()
	{
		if (this.mChecked)
		{
			return;
		}
		if (base.enabled)
		{
			this.isChecked = !this.isChecked;
			this.DispatcherEvents();
		}
	}

	public void Set(bool state)
	{
		if (this.tabRoot != null && state)
		{
			UITab[] componentsInChildren = this.tabRoot.GetComponentsInChildren<UITab>(true);
			int i = 0;
			int num = componentsInChildren.Length;
			while (i < num)
			{
				UITab uITab = componentsInChildren[i];
				if (uITab != this && uITab.tabRoot == this.tabRoot)
				{
					uITab.Set(false);
					uITab.mChecked = false;
				}
				i++;
			}
		}
		this.mChecked = state;
		for (int j = 0; j < this.tabSprite.Length; j++)
		{
			if (this.tabSprite[j] != null)
			{
				TweenAlpha.Begin(this.tabSprite[j].gameObject, 0.15f, (!this.mChecked) ? 0f : 1f);
			}
		}
		this.DispatcherEvents();
	}

	private void DispatcherEvents()
	{
		if (this.eventReceiver != null && !string.IsNullOrEmpty(this.functionName) && Application.isPlaying)
		{
			this.eventReceiver.SendMessage(this.functionName, SendMessageOptions.DontRequireReceiver);
		}
		if (this.onTabClick != null)
		{
			this.onTabClick();
		}
	}
}
