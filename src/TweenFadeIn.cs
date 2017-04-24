using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using XUtliPoolLib;

[ExecuteInEditMode]
public class TweenFadeIn : MonoBehaviour, IXTweenFadeIn
{
	public float Duration = 0.2f;

	public float StartDelay;

	public float DelayInterval = 0.05f;

	public int Group = 666;

	public Vector3 MoveDeltaPos = new Vector3(0f, 40f, 0f);

	public int TweenPlayItemNum = 999;

	private float InitAlpha;

	private float delayTime;

	public bool _editor_need_init = true;

	private bool _need_to_init = true;

	[HideInInspector]
	[NonSerialized]
	public UIWidget Widget;

	[HideInInspector]
	[NonSerialized]
	public TweenPosition PosT;

	[HideInInspector]
	[NonSerialized]
	public TweenAlpha AlpT;

	[HideInInspector]
	[NonSerialized]
	public UIPlayTween PlayT;

	private void Awake()
	{
		if (!Application.isPlaying && !this.Get_Component())
		{
			this.Add_Component();
		}
	}

	public void PlayFadeIn()
	{
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		if (this._need_to_init)
		{
			this._need_to_init = false;
			this._Init();
		}
		float num = 0f;
		if (!XUITool.Instance.GetTweenFadeInDelayByGroup(this.Group, this.DelayInterval, this.TweenPlayItemNum, out num))
		{
			this.Widget.alpha = this.AlpT.to;
			return;
		}
		this.delayTime = this.StartDelay + num;
		this.PosT.delay = this.delayTime;
		this.AlpT.delay = this.delayTime;
		base.StartCoroutine(this.IEPlay());
	}

	private void _Init()
	{
		this.Get_Component();
	}

	[DebuggerHidden]
	private IEnumerator IEPlay()
	{
		TweenFadeIn.<IEPlay>c__Iterator4 <IEPlay>c__Iterator = new TweenFadeIn.<IEPlay>c__Iterator4();
		<IEPlay>c__Iterator.<>f__this = this;
		return <IEPlay>c__Iterator;
	}

	private void SetInitAlpha()
	{
		Color color = this.Widget.color;
		this.Widget.color = new Color(color.r, color.g, color.b, this.InitAlpha);
	}

	public void ResetGroupDelay()
	{
		XUITool.Instance.ResetGroupDelay(this.Group);
	}

	private void OnDisable()
	{
		if (null == this.PosT || null == this.AlpT)
		{
			return;
		}
		if (!this.PosT.enabled || !this.AlpT.enabled)
		{
			return;
		}
		base.transform.localPosition = this.PosT.to;
		this.Widget.alpha = this.AlpT.to;
		this.PlayT.Stop();
	}

	private bool Get_Component()
	{
		this.Widget = base.GetComponent<UIWidget>();
		TweenPosition[] components = base.GetComponents<TweenPosition>();
		for (int i = 0; i < components.Length; i++)
		{
			if (components[i].tweenGroup == this.Group)
			{
				this.PosT = components[i];
				break;
			}
		}
		if (this.PosT == null)
		{
			return false;
		}
		TweenAlpha[] components2 = base.GetComponents<TweenAlpha>();
		for (int j = 0; j < components2.Length; j++)
		{
			if (components2[j].tweenGroup == this.Group)
			{
				this.AlpT = components2[j];
				break;
			}
		}
		if (this.AlpT == null)
		{
			return false;
		}
		UIPlayTween[] components3 = base.GetComponents<UIPlayTween>();
		for (int k = 0; k < components3.Length; k++)
		{
			if (components3[k].tweenGroup == this.Group)
			{
				this.PlayT = components3[k];
				break;
			}
		}
		return !(this.PlayT == null);
	}

	public void Add_Component()
	{
		if (null == base.GetComponent<UIWidget>())
		{
			base.gameObject.AddComponent<UISprite>();
		}
		this.Widget = base.GetComponent<UIWidget>();
		this.PosT = base.gameObject.AddComponent<TweenPosition>();
		this.PosT.enabled = false;
		this.AlpT = base.gameObject.AddComponent<TweenAlpha>();
		this.AlpT.enabled = false;
		this.AlpT.from = 0f;
		this.AlpT.to = 1f;
		this.PlayT = base.gameObject.AddComponent<UIPlayTween>();
	}
}
