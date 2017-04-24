using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
	public sealed class XTimerMgr : XSingleton<XTimerMgr>
	{
		public delegate void ElapsedEventHandler(object param);

		public delegate void AccurateElapsedEventHandler(object param, float delay);

		public delegate void ElapsedIDEventHandler(object param, int id);

		private sealed class XTimer : IComparable<XTimerMgr.XTimer>, IHere
		{
			private double _triggerTime;

			private object _param;

			private object _handler;

			private bool _global;

			private uint _token;

			public double TriggerTime
			{
				get
				{
					return this._triggerTime;
				}
			}

			public bool IsGlobaled
			{
				get
				{
					return this._global;
				}
			}

			public bool IsInPool
			{
				get;
				set;
			}

			public uint Token
			{
				get
				{
					return this._token;
				}
			}

			public int Here
			{
				get;
				set;
			}

			public int Id
			{
				get;
				set;
			}

			public XTimer(double trigger, object handler, object parma, uint token, bool global, int id)
			{
				this.Refine(trigger, handler, parma, token, global, id);
			}

			public void Refine(double trigger, object handler, object parma, uint token, bool global, int id)
			{
				this._triggerTime = trigger;
				this._handler = handler;
				this._param = parma;
				this._global = global;
				this._token = token;
				this.Here = -1;
				this.IsInPool = false;
				this.Id = id;
			}

			public void Refine(double trigger)
			{
				this._triggerTime = trigger;
			}

			public void Fire(float delta)
			{
				if (this._handler is XTimerMgr.AccurateElapsedEventHandler)
				{
					(this._handler as XTimerMgr.AccurateElapsedEventHandler)(this._param, delta);
					return;
				}
				if (this._handler is XTimerMgr.ElapsedIDEventHandler)
				{
					(this._handler as XTimerMgr.ElapsedIDEventHandler)(this._param, this.Id);
					return;
				}
				(this._handler as XTimerMgr.ElapsedEventHandler)(this._param);
			}

			public int CompareTo(XTimerMgr.XTimer other)
			{
				if (this._triggerTime == other._triggerTime)
				{
					return (int)(this._token - other.Token);
				}
				if (this._triggerTime >= other._triggerTime)
				{
					return 1;
				}
				return -1;
			}

			public double TimeLeft()
			{
				return this._triggerTime - XSingleton<XTimerMgr>.singleton.Elapsed;
			}
		}

		private uint _token;

		private double _elapsed;

		private Queue<XTimerMgr.XTimer> _pool = new Queue<XTimerMgr.XTimer>();

		private XHeap<XTimerMgr.XTimer> _timers = new XHeap<XTimerMgr.XTimer>();

		private Dictionary<uint, XTimerMgr.XTimer> _dict = new Dictionary<uint, XTimerMgr.XTimer>(20);

		private float _intervalTime;

		private float _updateTime = 0.1f;

		private bool _fixedUpdate;

		public bool update = true;

		public double Elapsed
		{
			get
			{
				return this._elapsed;
			}
		}

		public bool NeedFixedUpdate
		{
			get
			{
				return this._fixedUpdate;
			}
		}

		public uint SetTimer(float interval, XTimerMgr.ElapsedEventHandler handler, object param)
		{
			this._token += 1u;
			if (interval <= 0f)
			{
				handler(param);
				this._token += 1u;
			}
			else
			{
				double trigger = this._elapsed + Math.Round((double)interval, 3);
				XTimerMgr.XTimer timer = this.GetTimer(trigger, handler, param, this._token, false, -1);
				this._timers.PushHeap(timer);
				this._dict.Add(this._token, timer);
			}
			return this._token;
		}

		public uint SetTimer<TEnum>(float interval, XTimerMgr.ElapsedIDEventHandler handler, object param, TEnum e) where TEnum : struct
		{
			this._token += 1u;
			int id = XFastEnumIntEqualityComparer<TEnum>.ToInt(e);
			if (interval <= 0f)
			{
				handler(param, id);
				this._token += 1u;
			}
			else
			{
				double trigger = this._elapsed + Math.Round((double)interval, 3);
				XTimerMgr.XTimer timer = this.GetTimer(trigger, handler, param, this._token, false, id);
				this._timers.PushHeap(timer);
				this._dict.Add(this._token, timer);
			}
			return this._token;
		}

		public uint SetGlobalTimer(float interval, XTimerMgr.ElapsedEventHandler handler, object param)
		{
			this._token += 1u;
			if (interval <= 0f)
			{
				handler(param);
				this._token += 1u;
			}
			else
			{
				double trigger = this._elapsed + Math.Round((double)interval, 3);
				XTimerMgr.XTimer timer = this.GetTimer(trigger, handler, param, this._token, true, -1);
				this._timers.PushHeap(timer);
				this._dict.Add(this._token, timer);
			}
			return this._token;
		}

		public uint SetTimerAccurate(float interval, XTimerMgr.AccurateElapsedEventHandler handler, object param)
		{
			this._token += 1u;
			if (interval <= 0f)
			{
				handler(param, 0f);
				this._token += 1u;
			}
			else
			{
				double trigger = this._elapsed + Math.Round((double)interval, 3);
				XTimerMgr.XTimer timer = this.GetTimer(trigger, handler, param, this._token, false, -1);
				this._timers.PushHeap(timer);
				this._dict.Add(this._token, timer);
			}
			return this._token;
		}

		public void AdjustTimer(float interval, uint token, bool closed = false)
		{
			XTimerMgr.XTimer xTimer = null;
			if (this._dict.TryGetValue(token, out xTimer) && !xTimer.IsInPool)
			{
				double trigger = closed ? (this._elapsed - (double)(Time.deltaTime * 0.5f) + Math.Round((double)interval, 3)) : (this._elapsed + Math.Round((double)interval, 3));
				double triggerTime = xTimer.TriggerTime;
				xTimer.Refine(trigger);
				this._timers.Adjust(xTimer, triggerTime < xTimer.TriggerTime);
			}
		}

		public void KillTimerAll()
		{
			List<XTimerMgr.XTimer> list = new List<XTimerMgr.XTimer>();
			foreach (XTimerMgr.XTimer current in this._dict.Values)
			{
				if (!current.IsGlobaled)
				{
					list.Add(current);
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				this.KillTimer(list[i]);
			}
			list.Clear();
		}

		private void KillTimer(XTimerMgr.XTimer timer)
		{
			if (timer == null)
			{
				return;
			}
			this._timers.PopHeapAt(timer.Here);
			this.Discard(timer);
		}

		public void KillTimer(uint token)
		{
			if (token == 0u)
			{
				return;
			}
			XTimerMgr.XTimer timer = null;
			if (this._dict.TryGetValue(token, out timer))
			{
				this.KillTimer(timer);
			}
		}

		public double TimeLeft(uint token)
		{
			XTimerMgr.XTimer xTimer = null;
			if (this._dict.TryGetValue(token, out xTimer))
			{
				return xTimer.TimeLeft();
			}
			return 0.0;
		}

		public void Update(float fDeltaT)
		{
			this._elapsed += (double)fDeltaT;
			this._intervalTime += fDeltaT;
			if (this._intervalTime > this._updateTime)
			{
				this._intervalTime = 0f;
				this._fixedUpdate = true;
			}
			this.TriggerTimers();
		}

		public void PostUpdate()
		{
			this._fixedUpdate = false;
		}

		private void TriggerTimers()
		{
			while (this._timers.HeapSize > 0)
			{
				XTimerMgr.XTimer xTimer = this._timers.Peek();
				float num = (float)(this._elapsed - xTimer.TriggerTime);
				if (num < 0f)
				{
					break;
				}
				this.ExecuteTimer(this._timers.PopHeap(), num);
			}
		}

		private void ExecuteTimer(XTimerMgr.XTimer timer, float delta)
		{
			this.Discard(timer);
			timer.Fire(delta);
		}

		private void Discard(XTimerMgr.XTimer timer)
		{
			if (timer.IsInPool)
			{
				return;
			}
			if (this._dict.Remove(timer.Token))
			{
				timer.IsInPool = true;
				this._pool.Enqueue(timer);
			}
		}

		private XTimerMgr.XTimer GetTimer(double trigger, object handler, object parma, uint token, bool global, int id = -1)
		{
			if (this._pool.Count > 0)
			{
				XTimerMgr.XTimer xTimer = this._pool.Dequeue();
				xTimer.Refine(trigger, handler, parma, token, global, id);
				return xTimer;
			}
			return new XTimerMgr.XTimer(trigger, handler, parma, token, global, id);
		}

		public override bool Init()
		{
			return true;
		}

		public override void Uninit()
		{
		}
	}
}
