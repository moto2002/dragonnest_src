using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/UI/Sprite Animation"), ExecuteInEditMode, RequireComponent(typeof(UISprite))]
public class UISpriteAnimation : MonoBehaviour
{
	[HideInInspector, SerializeField]
	private int mFPS = 30;

	[HideInInspector, SerializeField]
	private string mPrefix = string.Empty;

	[HideInInspector, SerializeField]
	private bool mLoop = true;

	[HideInInspector, SerializeField]
	private int mInterval;

	[HideInInspector, SerializeField]
	private bool mDisableWhenFinish = true;

	private UISprite mSprite;

	private float mDelta;

	private int mIndex;

	private int mPresentIndex;

	private bool mActive = true;

	private List<string> mSpriteNames = new List<string>();

	private float mLastLoopFinishTime;

	private SpriteAnimationFinishEventHandler finishHandler;

	public UISprite sprite
	{
		get
		{
			return this.mSprite;
		}
	}

	public float LastLoopFinishTime
	{
		get
		{
			return this.mLastLoopFinishTime;
		}
		set
		{
			this.mLastLoopFinishTime = value;
		}
	}

	public int frames
	{
		get
		{
			return this.mSpriteNames.Count;
		}
	}

	public int framesPerSecond
	{
		get
		{
			return this.mFPS;
		}
		set
		{
			this.mFPS = value;
		}
	}

	public string namePrefix
	{
		get
		{
			return this.mPrefix;
		}
		set
		{
			if (this.mPrefix != value)
			{
				this.mPrefix = value;
				this.RebuildSpriteList();
			}
		}
	}

	public bool loop
	{
		get
		{
			return this.mLoop;
		}
		set
		{
			this.mLoop = value;
		}
	}

	public int loopinterval
	{
		get
		{
			return this.mInterval;
		}
		set
		{
			this.mInterval = value;
		}
	}

	public bool disableWhenFinish
	{
		get
		{
			return this.mDisableWhenFinish;
		}
		set
		{
			this.mDisableWhenFinish = value;
		}
	}

	public bool isPlaying
	{
		get
		{
			return this.mActive;
		}
	}

	public SpriteAnimationFinishEventHandler FinishHandler
	{
		set
		{
			this.finishHandler = value;
		}
	}

	private void Start()
	{
		this.RebuildSpriteList();
	}

	private void Update()
	{
		if (this.mActive && this.mSpriteNames.Count > 1 && Application.isPlaying && (float)this.mFPS > 0f)
		{
			this.mDelta += RealTime.deltaTime;
			float num = 1f / (float)this.mFPS;
			if (num < this.mDelta)
			{
				this.mDelta = ((num <= 0f) ? 0f : (this.mDelta - num));
				if (this.loopinterval > 0 && RealTime.time - this.mLastLoopFinishTime < (float)this.loopinterval - num)
				{
					return;
				}
				if (this.mPresentIndex != this.mIndex)
				{
					this.mPresentIndex = this.mIndex;
				}
				else if (++this.mIndex >= this.mSpriteNames.Count)
				{
					this.mIndex = 0;
					if (this.loopinterval == 0)
					{
						this.mPresentIndex = 0;
					}
					this.mActive = this.loop;
					this.mLastLoopFinishTime = RealTime.time;
					if (!this.loop)
					{
						if (this.disableWhenFinish)
						{
							base.gameObject.SetActive(false);
						}
						if (this.finishHandler != null)
						{
							this.finishHandler();
						}
					}
				}
				else
				{
					this.mPresentIndex++;
				}
				if (this.mActive)
				{
					this.mSprite.spriteName = this.mSpriteNames[this.mPresentIndex];
				}
			}
		}
	}

	private void RebuildSpriteList()
	{
		if (this.mSprite == null)
		{
			this.mSprite = base.GetComponent<UISprite>();
		}
		this.mSpriteNames.Clear();
		if (this.mSprite != null && this.mSprite.atlas != null)
		{
			List<UISpriteData> spriteList = this.mSprite.atlas.spriteList;
			int i = 0;
			int count = spriteList.Count;
			while (i < count)
			{
				UISpriteData uISpriteData = spriteList[i];
				if (string.IsNullOrEmpty(this.mPrefix) || uISpriteData.name.StartsWith(this.mPrefix))
				{
					this.mSpriteNames.Add(uISpriteData.name);
				}
				i++;
			}
			this.mSpriteNames.Sort();
		}
	}

	public void Reset()
	{
		this.mActive = true;
		this.mIndex = 0;
		this.mPresentIndex = 0;
		if (this.mSprite != null && this.mSpriteNames.Count > 0)
		{
			this.mSprite.spriteName = this.mSpriteNames[this.mIndex];
		}
	}

	public void StopAndReset()
	{
		this.mActive = false;
		this.mIndex = 0;
		this.mPresentIndex = 0;
		if (this.mSprite != null && this.mSpriteNames.Count > 0)
		{
			this.mSprite.spriteName = this.mSpriteNames[this.mIndex];
		}
	}
}
