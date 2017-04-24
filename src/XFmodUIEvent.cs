using System;
using UnityEngine;

public class XFmodUIEvent : MonoBehaviour
{
	private static GameObject _ui_audio;

	public string Name = string.Empty;

	public float Delay;

	private float _start_time;

	private void Start()
	{
		if (XFmodUIEvent._ui_audio == null)
		{
			if (GameObject.Find("UIRoot") != null)
			{
				XFmodUIEvent._ui_audio = GameObject.Find("UIRoot").gameObject;
			}
			else
			{
				XFmodUIEvent._ui_audio = GameObject.Find("UIRoot(Clone)").gameObject;
			}
		}
		this._start_time = Time.time;
	}

	private void FixedUpdate()
	{
		if (Time.time - this._start_time > this.Delay)
		{
			if (XFmodUIEvent._ui_audio != null)
			{
				XFmod fmodComponent = this.GetFmodComponent(XFmodUIEvent._ui_audio);
				fmodComponent.PlayOneShot("event:/" + this.Name, Vector3.zero);
			}
			UnityEngine.Object.Destroy(this);
		}
	}

	public XFmod GetFmodComponent(GameObject go)
	{
		XFmod xFmod = go.GetComponent<XFmod>();
		if (xFmod == null)
		{
			xFmod = go.AddComponent<XFmod>();
		}
		return xFmod;
	}
}
