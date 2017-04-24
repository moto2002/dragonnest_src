using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
	public class XFxMgr : XSingleton<XFxMgr>
	{
		private Dictionary<int, XFx> _fxs = new Dictionary<int, XFx>();

		private List<XFx> _sticky = new List<XFx>();

		private Queue<XFx> fxPool = new Queue<XFx>();

		private XTimerMgr.ElapsedEventHandler _innerDestroyFxCb;

		public int CameraLayerMask = -1;

		public static bool EmptyFx = false;

		public static int MaxParticleCount = -1;

		public XFxMgr()
		{
			this._innerDestroyFxCb = new XTimerMgr.ElapsedEventHandler(this.InnerDestroyFx);
		}

		private XFx GetFx()
		{
			return new XFx();
		}

		private void ReturnFx(XFx fx)
		{
		}

		public XFx CreateFx(string prefab_location, bool import = false)
		{
			UnityEngine.Object @object = null;
			if (!XFxMgr.EmptyFx)
			{
				@object = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(prefab_location, true, false);
			}
			GameObject gameObject = @object as GameObject;
			if (gameObject == null)
			{
				gameObject = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("Prefabs/empty", true, false) as GameObject);
			}
			XFx fx = this.GetFx();
			fx.FxName = prefab_location;
			fx.Fx = gameObject;
			if (!gameObject.activeSelf)
			{
				gameObject.SetActive(true);
			}
			fx.InitComponent(gameObject.transform, import);
			fx.StartSize = 1f;
			fx.DelayDestroy = 0f;
			this._fxs.Add(fx.InstanceID, fx);
			return fx;
		}

		public XFx CreateAndPlay(string location, Transform parent, float speed_ratio, Vector3 scale, Vector3 offset, bool follow, float duration, bool import = false)
		{
			XFx xFx = this.CreateFx(location, import);
			xFx.Play(parent, speed_ratio, scale, offset, follow, false);
			xFx.DelayDestroy = duration;
			XSingleton<XFxMgr>.singleton.DestroyFx(xFx, false);
			return xFx;
		}

		public XFx CreateAndPlay(string location, Transform parent, bool follow, float duration, bool import = false)
		{
			return this.CreateAndPlay(location, parent, 1f, Vector3.one, Vector3.zero, follow, duration, import);
		}

		public XFx CreateUIFx(string location, Transform parent, Vector3 scale)
		{
			XFx xFx = this.CreateFx(location, true);
			int layer = LayerMask.NameToLayer("UI");
			xFx.Fx.layer = layer;
			if (xFx.FxAnimation != null)
			{
				xFx.FxAnimation.gameObject.layer = layer;
			}
			if (xFx.FxAnimator != null)
			{
				xFx.FxAnimator.gameObject.layer = layer;
			}
			if (xFx.Particles != null)
			{
				for (int i = 0; i < xFx.Particles.Count; i++)
				{
					xFx.Particles[i].gameObject.layer = layer;
				}
			}
			if (xFx.Projectors != null)
			{
				for (int j = 0; j < xFx.Projectors.Count; j++)
				{
					xFx.Projectors[j].gameObject.layer = layer;
				}
			}
			xFx.Play(parent, 1f, scale, Vector3.zero, true, false);
			return xFx;
		}

		public XFx CreateUIFx(string location, Transform parent)
		{
			return this.CreateUIFx(location, parent, Vector3.one);
		}

		public void DestroyFx(XFx fx, bool bImmediately = true)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(fx.Token);
			if (bImmediately || fx.DelayDestroy <= 0f)
			{
				this.InnerDestroyFx(fx);
				return;
			}
			if (fx.IsPause)
			{
				fx.Resume();
			}
			fx.Token = XSingleton<XTimerMgr>.singleton.SetTimer(fx.DelayDestroy, this._innerDestroyFxCb, fx);
		}

		public void Stop(XFx fx)
		{
			fx.Stop();
		}

		public void OnLeaveScene()
		{
			this.Clear();
		}

		public void OnLeaveStage()
		{
			this.Clear();
		}

		public void RegToSticky(XFx fx)
		{
			if (!this._sticky.Contains(fx))
			{
				this._sticky.Add(fx);
			}
		}

		public void PostUpdate()
		{
			for (int i = 0; i < this._sticky.Count; i++)
			{
				this._sticky[i].StickToGround();
			}
		}

		private void InnerDestroyFx(object o)
		{
			XFx xFx = o as XFx;
			if (xFx == null)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Destroy Fx error: ", o.ToString(), null, null, null, null);
				return;
			}
			if (xFx.Token != 0u)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(xFx.Token);
			}
			if (this._fxs.ContainsKey(xFx.InstanceID))
			{
				this._fxs.Remove(xFx.InstanceID);
				this._sticky.Remove(xFx);
				this.Destroy(xFx);
			}
		}

		private void Destroy(XFx fx)
		{
			if (fx.Fx == null)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Error fx ", fx.FxName, " already be deleted~!", null, null, null);
				return;
			}
			fx.Stop();
			fx.Fx.transform.parent = null;
			fx.Fx.transform.position = XResourceLoaderMgr.Far_Far_Away;
			if (fx.callback != null)
			{
				fx.callback(fx);
			}
			fx.Clear();
			XSingleton<XResourceLoaderMgr>.singleton.Destroy(fx.Fx, true);
			fx.Fx = null;
			this.ReturnFx(fx);
		}

		public void Clear()
		{
			foreach (XFx current in this._fxs.Values)
			{
				this.Destroy(current);
			}
			this._sticky.Clear();
			this._fxs.Clear();
			this.fxPool.Clear();
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
