using System;
using UnityEngine;

public class UILabelFit : MonoBehaviour
{
	public GameObject formatRole;

	public new Camera camera;

	private float distance;

	private float formatDistance = 4f;

	private void Start()
	{
	}

	private void Update()
	{
		this.FormatDis();
		if (this.formatDistance == 0f)
		{
			return;
		}
		this.distance = Vector3.Distance(base.transform.position, Camera.main.transform.position);
		base.transform.localScale = Vector3.one * (this.distance / this.formatDistance);
	}

	private void FormatDis()
	{
		if (this.formatDistance != 0f)
		{
			return;
		}
		if (this.formatRole == null || this.camera == null)
		{
			return;
		}
		this.formatDistance = Vector3.Distance(this.formatRole.transform.position, this.camera.transform.position);
	}
}
