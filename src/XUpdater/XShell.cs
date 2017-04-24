using System;
using System.Reflection;
using UnityEngine;
using XUtliPoolLib;

namespace XUpdater
{
	public sealed class XShell : XSingleton<XShell>
	{
		public static readonly int TargetFrame = 30;

		private float _time_scale = 1f;

		private bool _bPause;

		private bool _bPauseTrigger;

		private IEntrance _entrance;

		public bool Pause
		{
			get
			{
				return this._bPause;
			}
			set
			{
				if (XSingleton<XUpdater>.singleton.IsDone)
				{
					this._bPauseTrigger = value;
				}
			}
		}

		public float CurrentTimeMagic
		{
			get
			{
				return Time.timeScale;
			}
		}

		public void PreLaunch()
		{
			this._entrance.Awake();
			if (this._entrance != null)
			{
				IPlatform xPlatform = XSingleton<XUpdater>.singleton.XPlatform;
				if (xPlatform != null)
				{
					this._entrance.SetQualityLevel(xPlatform.GetQualityLevel());
				}
			}
		}

		public void Launch()
		{
			this._entrance.Awake();
		}

		public bool Launched()
		{
			return this._entrance.Awaked;
		}

		public void StartGame()
		{
			this._entrance.Start();
		}

		public void Awake()
		{
			if (!XSingleton<XUpdater>.singleton.IsDone)
			{
				XSingleton<XUpdater>.singleton.Init();
			}
		}

		public void Start()
		{
			Screen.sleepTimeout = -1;
			Application.targetFrameRate = -1;
		}

		private void NetUpdate()
		{
			this._entrance.NetUpdate();
		}

		public void PreUpdate()
		{
			this.NetUpdate();
			if (this.Pause)
			{
				return;
			}
			this._entrance.PreUpdate();
		}

		public void Update()
		{
			if (!XSingleton<XUpdater>.singleton.IsDone)
			{
				XSingleton<XTimerMgr>.singleton.Update(Time.deltaTime);
				XSingleton<XUpdater>.singleton.Update();
				return;
			}
			this.PreUpdate();
			if (this.Pause)
			{
				return;
			}
			if (XSingleton<XTimerMgr>.singleton.update)
			{
				XSingleton<XTimerMgr>.singleton.Update(Time.deltaTime);
			}
			this._entrance.Update();
		}

		public void PostUpdate()
		{
			if (XSingleton<XUpdater>.singleton.IsDone)
			{
				this.PauseChecker();
				this._entrance.FadeUpdate();
				if (this.Pause)
				{
					return;
				}
				this._entrance.PostUpdate();
				if (XSingleton<XTimerMgr>.singleton.NeedFixedUpdate)
				{
					XSingleton<XResourceLoaderMgr>.singleton.PostUpdate(Time.deltaTime);
				}
				XSingleton<XTimerMgr>.singleton.PostUpdate();
			}
			if (XSingleton<XUpdater>.singleton.Reboot)
			{
				this.Quit();
				Application.LoadLevel(0);
			}
		}

		public void Quit()
		{
			if (XSingleton<XUpdater>.singleton.IsDone)
			{
				this._entrance.Quit();
			}
			XSingleton<XUpdater>.singleton.Uninit();
		}

		public void MakeEntrance(Assembly main)
		{
			Type type = main.GetType("XMainClient.XGameEntrance");
			MethodInfo method = type.GetMethod("Fire");
			method.Invoke(null, null);
			this._entrance = XSingleton<XInterfaceMgr>.singleton.GetInterface<IEntrance>(0u);
		}

		public float TimeMagic(float value)
		{
			if (Time.timeScale == 1f && !this._bPause)
			{
				Time.timeScale = value;
				this._time_scale = value;
			}
			return Time.timeScale;
		}

		public void TimeMagicBack()
		{
			Time.timeScale = 1f;
			this._time_scale = 1f;
		}

		private void PauseChecker()
		{
			if (this._bPause == this._bPauseTrigger)
			{
				return;
			}
			this._bPause = this._bPauseTrigger;
			Time.timeScale = (this._bPause ? 0f : this._time_scale);
		}

		public override bool Init()
		{
			return true;
		}

		public override void Uninit()
		{
		}

		public void MonoObjectRegister(string key, MonoBehaviour behavior)
		{
			if (this._entrance != null)
			{
				this._entrance.MonoObjectRegister(key, behavior);
			}
		}
	}
}
