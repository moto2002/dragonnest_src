using System;
using UnityEngine;

[RequireComponent(typeof(UISprite))]
public class ResizeCanvas : MonoBehaviour
{
	public void Awake()
	{
	}

	public void Start()
	{
		UIRoot uIRoot = NGUITools.FindInParents<UIRoot>(base.gameObject);
		UISprite component = base.GetComponent<UISprite>();
		component.height = Math.Min(uIRoot.base_ui_height, uIRoot.manualHeight);
	}
}
