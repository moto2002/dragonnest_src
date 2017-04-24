using System;
using UnityEngine;

public class XSth
{
	public enum SthState
	{
		IDLE,
		DIRECTION_ADJUSTING,
		FLAME_OUT
	}

	public GameObject Go;

	public Vector3 Speed;

	public float MinIdleSpeed;

	public Vector3 Acceleration;

	public float Time;

	public float DelayTime;

	public float StartFindDesTime;

	public Vector3 Des;

	public XSth.SthState State;

	private bool m_bEnable;

	public bool bEnable
	{
		get
		{
			return this.m_bEnable;
		}
		set
		{
			this.m_bEnable = value;
			this.Acceleration = Vector3.zero;
			this.State = XSth.SthState.IDLE;
			if (!this.m_bEnable)
			{
				this.Go.SetActive(false);
			}
		}
	}

	public void Destroy()
	{
		UnityEngine.Object.Destroy(this.Go);
	}

	public bool Update(float t)
	{
		if (!this.bEnable)
		{
			return this.bEnable;
		}
		if (this.DelayTime > 0f)
		{
			this.DelayTime -= t;
			if (this.DelayTime > 0f)
			{
				return true;
			}
			t = -this.DelayTime;
		}
		this.Time += t;
		Vector3 speed = this.Speed + this.Acceleration * t;
		Vector3 localPosition = this.Go.transform.localPosition;
		if (this.State == XSth.SthState.IDLE)
		{
			if (speed.x * this.Speed.x + speed.y * this.Speed.y <= 0f)
			{
				speed = this.Speed.normalized * this.MinIdleSpeed;
			}
			if (this.Time > this.StartFindDesTime)
			{
				this.State = XSth.SthState.DIRECTION_ADJUSTING;
			}
		}
		if (this.State == XSth.SthState.DIRECTION_ADJUSTING)
		{
			Vector3 vector = this.Des - localPosition;
			float num = this.Speed.x * vector.y - this.Speed.y * vector.x;
			float num2 = vector.x * speed.y - vector.y * speed.x;
			if (num * num2 > 0f)
			{
				speed = speed.magnitude * vector.normalized;
				this.State = XSth.SthState.FLAME_OUT;
			}
		}
		if (!this.Go.activeSelf)
		{
			this.Go.SetActive(true);
		}
		this.Speed = speed;
		Vector3 vector2 = localPosition + this.Speed * t;
		if ((vector2 - localPosition).sqrMagnitude >= (this.Des - localPosition).sqrMagnitude)
		{
			this.bEnable = false;
		}
		else
		{
			this.Go.transform.localPosition = vector2;
		}
		return this.bEnable;
	}
}
