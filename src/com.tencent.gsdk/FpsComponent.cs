using System;
using UnityEngine;

namespace com.tencent.gsdk
{
	internal class FpsComponent : MonoBehaviour
	{
		private const float minInterval = 0.01f;

		private FpsRecorder mRecorder;

		private double mLastTime;

		private int mFrames;

		private float mInterval = 1f;

		public void init(FpsRecorder r, float itv)
		{
			this.mRecorder = r;
			this.mInterval = ((itv <= 0.01f) ? 0.01f : itv);
		}

		private void Start()
		{
			this.mLastTime = (double)Time.realtimeSinceStartup;
			this.mFrames = 0;
		}

		private void Update()
		{
			this.mFrames++;
			double num = (double)Time.realtimeSinceStartup;
			if (num > this.mLastTime + (double)this.mInterval)
			{
				double num2 = (double)this.mFrames / (num - this.mLastTime);
				this.mFrames = 0;
				this.mLastTime = num;
				if (this.mRecorder != null)
				{
					this.mRecorder.Add((int)num2);
				}
			}
		}

		private void OnDestroy()
		{
		}
	}
}
