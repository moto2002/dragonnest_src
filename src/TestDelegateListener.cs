using System;
using UnityEngine;

public class TestDelegateListener : MonoBehaviour
{
	public Action onClick;

	public TestLuaDelegate.VoidDelegate onEvClick;

	private void OnGUI()
	{
		if (GUI.Button(new Rect(10f, 10f, 200f, 20f), "测试委托1") && this.onClick != null)
		{
			this.onClick();
		}
		if (GUI.Button(new Rect(10f, 50f, 200f, 20f), "测试委托2") && this.onEvClick != null)
		{
			this.onEvClick(base.gameObject);
		}
	}
}
