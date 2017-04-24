using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;

public class XUIProgress : XUIObject, IXUIObject, IXUIProgress
{
	protected float mTargetValue = -1f;

	public uint totalSection = 1u;

	public List<Color> SectionColors;

	public UILabel sectionText;

	private UISlider m_uiSlider;

	private UIWidget m_Fore;

	private UIWidget m_Back;

	private UIWidget m_Dynm;

	protected float perSection;

	protected float logicalValue;

	protected float mDynamicThreshold = 0.01f;

	protected float mDynamicVal;

	protected float mDynamicSection;

	protected float mDynamicDelta;

	protected int mDynamicStep = 12;

	protected int targetSection = -1;

	protected float targetValue = -1f;

	public float value
	{
		get
		{
			return this.m_uiSlider.value;
		}
		set
		{
			if (this.totalSection <= 1u)
			{
				this.m_uiSlider.value = value;
				this._SetSection((int)this.totalSection);
				if (value < this.logicalValue)
				{
					this.targetSection = 0;
					this.targetValue = value;
					this.mDynamicVal = this.logicalValue;
					this.mDynamicSection = 0f;
					this.mDynamicDelta = (this.mDynamicVal - value) / (float)this.mDynamicStep;
				}
			}
			else
			{
				int num = 0;
				float num2 = 0f;
				this.GetSectionAndValue(value, ref num, ref num2);
				this.m_uiSlider.value = num2;
				int num3 = 0;
				float num4 = 0f;
				this.GetSectionAndValue(this.logicalValue, ref num3, ref num4);
				if (num3 == num && num4 - num2 > this.mDynamicThreshold)
				{
					this.targetSection = num;
					this.targetValue = num2;
					this.mDynamicVal = num4;
					this.mDynamicSection = (float)num3;
					this.mDynamicDelta = (this.mDynamicVal - num2) / (float)this.mDynamicStep;
				}
				else if (num != num3)
				{
					this.targetSection = num;
					this.targetValue = num2;
					this.mDynamicVal = num4;
					this.mDynamicSection = (float)num3;
					this.mDynamicDelta = (this.mDynamicVal - num2 + 1f) / (float)this.mDynamicStep;
					this._SetSection(num);
				}
				if (this.SectionColors.Count > 0)
				{
					Color color = this.SectionColors[num % this.SectionColors.Count];
					this.m_Fore.color = color;
					if (num > 0)
					{
						Color color2 = this.SectionColors[(num - 1) % this.SectionColors.Count];
						this.m_Back.alpha = 1f;
						this.m_Back.color = color2;
					}
					else
					{
						this.m_Back.alpha = 0f;
					}
				}
			}
			this.logicalValue = value;
		}
	}

	public int width
	{
		get
		{
			return this.m_uiSlider.backgroundWidget.width;
		}
		set
		{
			this.m_uiSlider.backgroundWidget.width = value;
		}
	}

	public GameObject foreground
	{
		get
		{
			return this.m_uiSlider.mFG.gameObject;
		}
	}

	private void _SetSection(int sec)
	{
		if (this.sectionText != null)
		{
			if (this.totalSection <= 1u)
			{
				this.sectionText.alpha = 0f;
			}
			else
			{
				this.sectionText.alpha = 1f;
				this.sectionText.text = "x" + sec.ToString();
			}
		}
	}

	private void Update()
	{
		if (this.targetSection > -1 && this.targetValue > -1f)
		{
			int depth = this.m_Fore.depth - 1;
			if (this.mDynamicSection == (float)this.targetSection)
			{
				if (this.mDynamicVal <= this.targetValue)
				{
					this.m_uiSlider.SetDynamicGround(0f, depth);
					this.targetSection = -1;
					this.targetValue = -1f;
				}
			}
			else if (this.mDynamicSection > (float)this.targetSection)
			{
				depth = this.m_Fore.depth + 1;
				if (this.mDynamicVal <= 0f)
				{
					this.mDynamicSection = (float)this.targetSection;
					this.mDynamicVal = 1f;
				}
			}
			this.m_uiSlider.SetDynamicGround(this.mDynamicVal, depth);
			this.UpdateDynamicValue();
		}
		else
		{
			this.m_uiSlider.SetDynamicGround(0f, this.m_Fore.depth - 1);
		}
	}

	protected void UpdateDynamicValue()
	{
		this.mDynamicVal -= this.mDynamicDelta;
	}

	public void ForceUpdate()
	{
	}

	public void SetDepthOffset(int d)
	{
		UIWidget[] componentsInChildren = base.gameObject.GetComponentsInChildren<UIWidget>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].depth += d;
		}
	}

	public void SetValueWithAnimation(float value)
	{
	}

	public void SetTotalSection(uint section)
	{
		this.totalSection = section;
		this.perSection = 1f / this.totalSection;
	}

	protected void GetSectionAndValue(float logicalValue, ref int section, ref float v)
	{
		section = (int)(logicalValue / this.perSection);
		v = (logicalValue - (float)section * this.perSection) / this.perSection;
	}

	protected override void OnAwake()
	{
		base.OnAwake();
		this.m_uiSlider = base.GetComponent<UISlider>();
		if (null == this.m_uiSlider)
		{
			Debug.LogError("null == m_uiSlider");
		}
		this.m_Fore = this.m_uiSlider.mFG;
		this.m_Back = this.m_uiSlider.mBG;
		this.m_Dynm = this.m_uiSlider.mDG;
		if (this.sectionText != null)
		{
			this.sectionText.text = string.Empty;
		}
	}

	public void SetForegroundColor(Color c)
	{
		this.m_Fore.color = c;
	}
}
