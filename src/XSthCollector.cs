using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

public class XSthCollector : XUIObject, IXUIObject, IXUISthCollector
{
	public List<GameObject> SthList = new List<GameObject>();

	public Vector3 Src = new Vector3(0f, 0f, 0f);

	public Vector3 Des = new Vector3(-450f, -280f, 0f);

	public int Count = 15;

	public float EmitInterval = 0.01f;

	public int EmitDegreeRange = 300;

	public float MinEmitSpeed = 1900f;

	public float MaxEmitSpeed = 2100f;

	public float SrcAcceleration = 20000f;

	public float DesAcceleration = 8000f;

	public float SthAcceleration = 10000f;

	public float MinStartFindDesTime = 0.3f;

	public float MaxStartFindDesTime = 0.6f;

	public float MinIdleSpeed = 30f;

	private List<XSth> m_SthList;

	private bool m_bActive;

	private string m_CurName;

	private GameObject m_CurSthGo;

	private Dictionary<string, List<XSth>> m_SthListMap = new Dictionary<string, List<XSth>>();

	private Dictionary<string, GameObject> m_SthTplMap = new Dictionary<string, GameObject>();

	private List<XSth> m_ExternalSthList = new List<XSth>();

	private Vector3 m_Direction;

	private SthArrivedEventHandler m_SthArrivedEventHandler;

	private CollectFinishEventHandler m_CollectFinishEventHandler;

	private int m_ArrivedCount;

	private void Awake()
	{
		for (int i = 0; i < this.SthList.Count; i++)
		{
			this.m_SthTplMap.Add(this.SthList[i].name, this.SthList[i]);
			this.SthList[i].SetActive(false);
		}
		this.m_Direction = (this.Des - this.Src).normalized;
	}

	private void OnEnable()
	{
		this.m_bActive = false;
		if (this.m_SthList != null)
		{
			for (int i = 0; i < this.m_SthList.Count; i++)
			{
				this.m_SthList[i].bEnable = false;
			}
		}
	}

	public void SetPosition(Vector3 srcGlobalPos, Vector3 desGlobalPos)
	{
		this.Src = base.transform.worldToLocalMatrix * srcGlobalPos;
		this.Des = base.transform.worldToLocalMatrix * desGlobalPos;
		this.m_Direction = (this.Des - this.Src).normalized;
	}

	public void SetSth(List<GameObject> goes)
	{
		for (int i = this.m_ExternalSthList.Count; i < goes.Count; i++)
		{
			XSth item = new XSth();
			this.m_ExternalSthList.Add(item);
		}
		for (int j = this.m_ExternalSthList.Count - 1; j >= goes.Count; j--)
		{
			this.m_ExternalSthList.RemoveAt(j);
		}
		this.m_SthList = this.m_ExternalSthList;
		for (int k = 0; k < this.m_ExternalSthList.Count; k++)
		{
			this.m_SthList[k].Go = goes[k];
			goes[k].SetActive(false);
			this.m_SthList[k].bEnable = false;
		}
	}

	public void SetSth(string name)
	{
		if (this.m_SthList != null && this.m_CurName != name)
		{
			for (int i = 0; i < this.m_SthList.Count; i++)
			{
				this.m_SthList[i].bEnable = false;
			}
		}
		if (!this.m_SthTplMap.TryGetValue(name, out this.m_CurSthGo))
		{
			Debug.LogError("Cant find tpl name: " + name);
			return;
		}
		if (!this.m_SthListMap.TryGetValue(name, out this.m_SthList))
		{
			this.m_SthList = new List<XSth>();
			this.m_SthListMap.Add(name, this.m_SthList);
		}
		this._GenerateSth();
	}

	private void _GenerateSth()
	{
		if (this.m_SthList.Count != this.Count)
		{
			this.m_CurSthGo.SetActive(true);
			for (int i = this.m_SthList.Count; i < this.Count; i++)
			{
				XSth xSth = new XSth();
				GameObject gameObject = UnityEngine.Object.Instantiate(this.m_CurSthGo) as GameObject;
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = Vector3.one;
				xSth.Go = gameObject;
				gameObject.SetActive(false);
				this.m_SthList.Add(xSth);
			}
			this.m_CurSthGo.SetActive(false);
			for (int j = this.m_SthList.Count - 1; j >= this.Count; j--)
			{
				this.m_SthList[j].Destroy();
				this.m_SthList.RemoveAt(j);
			}
		}
		for (int k = 0; k < this.m_SthList.Count; k++)
		{
			this.m_SthList[k].bEnable = false;
		}
	}

	[ContextMenu("Emit")]
	public void Emit()
	{
		float num = 0f;
		int i = 0;
		while (i < this.m_SthList.Count)
		{
			XSth xSth = this.m_SthList[i];
			xSth.DelayTime = num;
			xSth.Speed = XSingleton<XCommon>.singleton.RandomFloat(this.MinEmitSpeed, this.MaxEmitSpeed) * this._RandEmitDir();
			xSth.StartFindDesTime = XSingleton<XCommon>.singleton.RandomFloat(this.MinStartFindDesTime, this.MaxStartFindDesTime);
			xSth.Time = 0f;
			xSth.MinIdleSpeed = this.MinIdleSpeed;
			xSth.Go.transform.localPosition = this.Src;
			xSth.Des = this.Des;
			xSth.bEnable = true;
			i++;
			num += this.EmitInterval;
		}
		this.m_bActive = true;
		this.m_ArrivedCount = 0;
	}

	private Vector3 _RandEmitDir()
	{
		float num = (float)this.EmitDegreeRange * 0.0174532924f;
		float f = XSingleton<XCommon>.singleton.RandomFloat(num) - num / 2f;
		float num2 = Mathf.Sin(f);
		float num3 = Mathf.Cos(f);
		Vector3 direction = this.m_Direction;
		direction.x = this.m_Direction.x * num3 - this.m_Direction.y * num2;
		direction.y = this.m_Direction.x * num2 + this.m_Direction.y * num3;
		return direction;
	}

	private Vector3 _GetAcceleration(XSth sth, float t)
	{
		Vector3 localPosition = sth.Go.transform.localPosition;
		Vector3 vector = Vector3.zero;
		Vector3 normalized = (this.Des - localPosition).normalized;
		if (sth.State == XSth.SthState.FLAME_OUT)
		{
			vector += normalized * this.DesAcceleration;
		}
		Vector3 normalized2 = (this.Src - localPosition).normalized;
		if (sth.State == XSth.SthState.IDLE)
		{
			vector += normalized2 * this.SrcAcceleration;
		}
		if (sth.State == XSth.SthState.DIRECTION_ADJUSTING)
		{
			float num = normalized.x * sth.Speed.y - normalized.y * sth.Speed.x;
			Vector3 b = new Vector3(-sth.Speed.y, sth.Speed.x, sth.Speed.z);
			if ((b.x * sth.Speed.y - b.y * sth.Speed.x) * num < 0f)
			{
				b.x = -b.x;
				b.y = -b.y;
			}
			b = b.normalized * this.SthAcceleration;
			vector += b;
		}
		return vector;
	}

	private void Update()
	{
		if (!this.m_bActive)
		{
			return;
		}
		this.m_bActive = false;
		for (int i = 0; i < this.m_SthList.Count; i++)
		{
			XSth xSth = this.m_SthList[i];
			if (xSth.bEnable)
			{
				this.m_bActive = true;
				if (!xSth.Update(Time.deltaTime) && this.m_SthArrivedEventHandler != null)
				{
					this.m_SthArrivedEventHandler(this.m_ArrivedCount++);
				}
				if (xSth.DelayTime <= 0f)
				{
					xSth.Acceleration = this._GetAcceleration(xSth, Time.deltaTime);
				}
			}
		}
		if (!this.m_bActive && this.m_CollectFinishEventHandler != null)
		{
			this.m_CollectFinishEventHandler();
		}
	}

	public void RegisterSthArrivedEventHandler(SthArrivedEventHandler eventHandler)
	{
		this.m_SthArrivedEventHandler = eventHandler;
	}

	public void RegisterCollectFinishEventHandler(CollectFinishEventHandler eventHandler)
	{
		this.m_CollectFinishEventHandler = eventHandler;
	}
}
