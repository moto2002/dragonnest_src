using System;
using UnityEngine;

[ExecuteInEditMode, RequireComponent(typeof(UIWidget))]
public class AnimatedColor : MonoBehaviour
{
	public Color color = Color.white;

	private UIWidget mWidget;

	private void OnStart()
	{
		this.mWidget = base.GetComponent<UIWidget>();
	}

	private void LateUpdate()
	{
		this.mWidget.color = this.color;
	}
}
