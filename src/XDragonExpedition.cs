using System;
using UnityEngine;
using XUtliPoolLib;

public class XDragonExpedition : MonoBehaviour, IXDragonExpedition
{
	private RaycastHit[] hits;

	public Camera mCamera;

	public float MoveSpeed = 5f;

	public float MIN_POS;

	public float MAX_POS = 100f;

	private Vector3 curPos = Vector3.zero;

	public void Drag(float delta)
	{
		this.MoveCamera(delta);
	}

	public Transform GetGO(string name)
	{
		return base.transform.FindChild(name);
	}

	public void SetLimitPos(float MinPos)
	{
		this.MIN_POS = MinPos;
	}

	public GameObject Click()
	{
		Vector3 vector = this.mCamera.ScreenToViewportPoint(Input.mousePosition);
		Ray ray = this.mCamera.ScreenPointToRay(Input.mousePosition);
		float distance = this.mCamera.farClipPlane - this.mCamera.nearClipPlane;
		this.hits = Physics.RaycastAll(ray, distance);
		for (int i = 0; i < this.hits.Length; i++)
		{
			if (this.hits[i].collider.gameObject.name.StartsWith("building"))
			{
				return this.hits[i].collider.gameObject;
			}
		}
		return null;
	}

	public Camera GetDragonCamera()
	{
		return this.mCamera;
	}

	private void Start()
	{
		this.curPos = this.mCamera.transform.localPosition;
	}

	private void MoveCamera(float delta)
	{
		this.curPos.x = this.curPos.x + delta * this.MoveSpeed;
		if (this.curPos.x < this.MIN_POS)
		{
			this.curPos.x = this.MIN_POS;
		}
		if (this.curPos.x > this.MAX_POS)
		{
			this.curPos.x = this.MAX_POS;
		}
		this.mCamera.transform.localPosition = this.curPos;
	}
}
