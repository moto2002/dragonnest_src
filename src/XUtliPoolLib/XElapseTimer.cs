using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public class XElapseTimer
	{
		private float m_OriLeftTime;

		private float m_LeftTime;

		private float m_LastTime = -1f;

		private float m_PassTime;

		public float LeftTime
		{
			get
			{
				return this.m_LeftTime;
			}
			set
			{
				this.m_LeftTime = value;
				this.m_OriLeftTime = this.m_LeftTime;
				this.m_LastTime = -1f;
				this.m_PassTime = 0f;
			}
		}

		public float PassTime
		{
			get
			{
				return this.m_PassTime;
			}
		}

		public void Update()
		{
			this.m_PassTime = 0f;
			if (this.m_LastTime < 0f)
			{
				this.m_LastTime = Time.time;
			}
			else
			{
				this.m_PassTime = Time.time - this.m_LastTime;
			}
			this.m_LeftTime = this.m_OriLeftTime - this.m_PassTime;
			if (this.m_LeftTime < 0f)
			{
				this.m_LeftTime = 0f;
			}
		}
	}
}
