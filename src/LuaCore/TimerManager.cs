using System;
using System.Collections.Generic;
using UnityEngine;

namespace LuaCore
{
	public class TimerManager : Single<TimerManager>
	{
		private enum enTimerType
		{
			Normal,
			FrameSync
		}

		private List<Timer>[] m_timers;

		private int m_timerSequence;

		public override void Init()
		{
			this.m_timers = new List<Timer>[Enum.GetValues(typeof(TimerManager.enTimerType)).Length];
			for (int i = 0; i < this.m_timers.Length; i++)
			{
				this.m_timers[i] = new List<Timer>();
			}
			this.m_timerSequence = 0;
		}

		public void Update()
		{
			this.AdvanceTimer((int)(Time.deltaTime * 1000f), TimerManager.enTimerType.Normal);
		}

		public void UpdateLogic(int delta)
		{
			this.AdvanceTimer(delta, TimerManager.enTimerType.FrameSync);
		}

		private void AdvanceTimer(int delta, TimerManager.enTimerType timerType)
		{
			List<Timer> list = this.m_timers[(int)timerType];
			int i = 0;
			while (i < list.Count)
			{
				if (list[i].IsFinished())
				{
					list.RemoveAt(i);
				}
				else
				{
					list[i].Update(delta);
					i++;
				}
			}
		}

		public int AddTimer(int time, int loop, Timer.OnTimeUpHandler onTimeUpHandler)
		{
			return this.AddTimer(time, loop, onTimeUpHandler, false);
		}

		public int AddTimer(int time, int loop, Timer.OnTimeUpHandler onTimeUpHandler, bool useFrameSync)
		{
			this.m_timerSequence++;
			this.m_timers[(!useFrameSync) ? 0 : 1].Add(new Timer(time, loop, onTimeUpHandler, this.m_timerSequence));
			return this.m_timerSequence;
		}

		public void RemoveTimer(int sequence)
		{
			for (int i = 0; i < this.m_timers.Length; i++)
			{
				List<Timer> list = this.m_timers[i];
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].IsSequenceMatched(sequence))
					{
						list.RemoveAt(j);
						return;
					}
				}
			}
		}

		public void RemoveTimerSafely(ref int sequence)
		{
			if (sequence != 0)
			{
				this.RemoveTimer(sequence);
				sequence = 0;
			}
		}

		public void PauseTimer(int sequence)
		{
			Timer timer = this.GetTimer(sequence);
			if (timer != null)
			{
				timer.Pause();
			}
		}

		public void ResumeTimer(int sequence)
		{
			Timer timer = this.GetTimer(sequence);
			if (timer != null)
			{
				timer.Resume();
			}
		}

		public void ResetTimer(int sequence)
		{
			Timer timer = this.GetTimer(sequence);
			if (timer != null)
			{
				timer.Reset();
			}
		}

		public int GetTimerCurrent(int sequence)
		{
			Timer timer = this.GetTimer(sequence);
			if (timer != null)
			{
				return timer.CurrentTime;
			}
			return -1;
		}

		private Timer GetTimer(int sequence)
		{
			for (int i = 0; i < this.m_timers.Length; i++)
			{
				List<Timer> list = this.m_timers[i];
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].IsSequenceMatched(sequence))
					{
						return list[j];
					}
				}
			}
			return null;
		}

		public void RemoveTimer(Timer.OnTimeUpHandler onTimeUpHandler)
		{
			this.RemoveTimer(onTimeUpHandler, false);
		}

		public void RemoveTimer(Timer.OnTimeUpHandler onTimeUpHandler, bool useFrameSync)
		{
			List<Timer> list = this.m_timers[(!useFrameSync) ? 0 : 1];
			int i = 0;
			while (i < list.Count)
			{
				if (list[i].IsDelegateMatched(onTimeUpHandler))
				{
					list.RemoveAt(i);
				}
				else
				{
					i++;
				}
			}
		}

		public void RemoveAllTimer(bool useFrameSync)
		{
			this.m_timers[(!useFrameSync) ? 0 : 1].Clear();
		}

		public void RemoveAllTimer()
		{
			for (int i = 0; i < this.m_timers.Length; i++)
			{
				this.m_timers[i].Clear();
			}
		}
	}
}
