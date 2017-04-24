using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.tencent.gsdk
{
	internal class FpsRecorder
	{
		private const int hTs = -10;

		private const int llTs = -10;

		private const int lrTs = -4;

		private int mCusTs;

		private float mDotFreq = 1f;

		private double mLastDotTime;

		private string mTagId;

		private List<int> mFps = new List<int>();

		private List<int> mFpsDots = new List<int>();

		private int mLastFps = -1;

		private int mHTimes;

		private int mLTimes;

		private int mCusTimes;

		private float mInterval;

		private GameObject mGameObject;

		private FpsInfo mLastInfo;

		public FpsRecorder(float interval, int cusTs, int dotFreq)
		{
			this.mInterval = interval;
			this.mCusTs = cusTs;
			this.mDotFreq = (float)dotFreq / 1000f;
			this.mLastDotTime = (double)Time.realtimeSinceStartup;
		}

		public void Start(string tagId)
		{
			this.mTagId = tagId;
			this.mGameObject = new GameObject("GSDKFpsGameObject" + this.GetHashCode());
			this.mGameObject.AddComponent<FpsComponent>();
			this.mGameObject.GetComponent<FpsComponent>().init(this, this.mInterval);
			UnityEngine.Object.DontDestroyOnLoad(this.mGameObject);
		}

		public void Finish()
		{
			if (this.mLastInfo == null)
			{
				this.Save();
			}
			if (this.mGameObject != null)
			{
				UnityEngine.Object.Destroy(this.mGameObject);
				this.mGameObject = null;
			}
		}

		public void Clear()
		{
			this.resetData();
			if (this.mGameObject != null)
			{
				UnityEngine.Object.Destroy(this.mGameObject);
				this.mGameObject = null;
			}
		}

		public void Save()
		{
			if (this.mFps.Count <= 0)
			{
				return;
			}
			int num = 0;
			int num2 = this.mFps[0];
			int num3 = this.mFps[0];
			foreach (int current in this.mFps)
			{
				num += current;
				if (current > num3)
				{
					num3 = current;
				}
				if (current < num2)
				{
					num2 = current;
				}
			}
			int avg = num / this.mFps.Count;
			string fpsDotsStr = this.GetFpsDotsStr();
			FpsInfo fpsInfo = new FpsInfo(this.mTagId, avg, num3, num2, this.mFps.Count, this.mHTimes, this.mLTimes, this.mCusTimes, fpsDotsStr);
			this.mLastInfo = fpsInfo;
		}

		public string GetFpsDotsStr()
		{
			string text = string.Empty;
			int count = this.mFpsDots.Count;
			for (int i = 0; i < count; i++)
			{
				string text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					string.Empty,
					this.mFpsDots[i],
					","
				});
			}
			return text;
		}

		private void resetData()
		{
			this.mTagId = string.Empty;
			if (this.mFps != null)
			{
				this.mFps.Clear();
			}
			if (this.mFpsDots != null)
			{
				this.mFpsDots.Clear();
			}
			this.mLastFps = -1;
			this.mHTimes = 0;
			this.mLTimes = 0;
			this.mCusTimes = 0;
			this.mLastInfo = null;
		}

		public void Add(int fps)
		{
			if (fps < 0)
			{
				return;
			}
			this.mFps.Add(fps);
			if (this.mLastFps > 0)
			{
				int num = fps - this.mLastFps;
				if (num < -10)
				{
					this.mHTimes++;
				}
				else if (num >= -10 && num < -4)
				{
					this.mLTimes++;
				}
				if (num <= this.mCusTs)
				{
					this.mCusTimes++;
				}
			}
			this.mLastFps = fps;
			double num2 = (double)Time.realtimeSinceStartup;
			if (this.mDotFreq > 0f && this.mLastDotTime + (double)this.mDotFreq <= num2)
			{
				this.mFpsDots.Add(fps);
				this.mLastDotTime = num2;
			}
		}

		public int GetFps()
		{
			return this.mLastFps;
		}

		public FpsInfo GetLastFpsInfo()
		{
			return this.mLastInfo;
		}

		public List<int> GetFpsDots()
		{
			List<int> list = new List<int>();
			int count = this.mFpsDots.Count;
			for (int i = 0; i < count; i++)
			{
				list.Add(this.mFpsDots[i]);
			}
			return list;
		}
	}
}
