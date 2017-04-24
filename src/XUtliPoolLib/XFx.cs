using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
	public class XFx
	{
		private float _startSize = 1f;

		private uint _timer_token;

		private float _startProjectorSize = 1f;

		private bool _pause;

		private bool _sticky_to_ground;

		private GameObject _fx;

		private Animation _animation;

		private Animator _animator;

		private List<ParticleSystem> _particles = new List<ParticleSystem>();

		private List<Projector> _projectors = new List<Projector>();

		private IWeaponTail _weaponTail;

		public static int ParticleCount;

		public OnFxDestroyed callback;

		public int InstanceID
		{
			get
			{
				if (!(this._fx == null))
				{
					return this._fx.GetInstanceID();
				}
				return 0;
			}
		}

		public float DelayDestroy
		{
			get;
			set;
		}

		public string FxName
		{
			get;
			set;
		}

		public bool IsSticky
		{
			get
			{
				return this._sticky_to_ground;
			}
		}

		public bool IsPause
		{
			get
			{
				return this._pause;
			}
		}

		public uint Token
		{
			get
			{
				return this._timer_token;
			}
			set
			{
				this._timer_token = value;
			}
		}

		public float StartSize
		{
			get
			{
				return this._startSize;
			}
			set
			{
				this._startSize = value;
			}
		}

		public GameObject Fx
		{
			get
			{
				return this._fx;
			}
			set
			{
				this._fx = value;
			}
		}

		public Animation FxAnimation
		{
			get
			{
				return this._animation;
			}
		}

		public Animator FxAnimator
		{
			get
			{
				return this._animator;
			}
		}

		public List<ParticleSystem> Particles
		{
			get
			{
				return this._particles;
			}
		}

		public List<Projector> Projectors
		{
			get
			{
				return this._projectors;
			}
		}

		private bool PrePlayParticle(ParticleSystem ps, int qualityLayer)
		{
			int num = 1 << ps.gameObject.layer;
			if ((num & qualityLayer) == 0)
			{
				if (ps.gameObject.activeSelf)
				{
					ps.gameObject.SetActive(false);
				}
				return false;
			}
			return true;
		}

		public void InitComponent(Transform t, bool import)
		{
			this._animation = t.GetComponentInChildren<Animation>();
			this._animator = t.GetComponentInChildren<Animator>();
			this._particles.Clear();
			t.GetComponentsInChildren<ParticleSystem>(false, this._particles);
			this._projectors.Clear();
			t.GetComponentsInChildren<Projector>(true, this._projectors);
			if (!import && XFxMgr.MaxParticleCount >= 0 && this._particles.Count > XFxMgr.MaxParticleCount)
			{
				for (int i = this._particles.Count - 1; i >= XFxMgr.MaxParticleCount; i--)
				{
					UnityEngine.Object.Destroy(this._particles[i].gameObject);
				}
				this._particles.RemoveRange(XFxMgr.MaxParticleCount, this._particles.Count - XFxMgr.MaxParticleCount);
			}
			for (int j = 0; j < this._particles.Count; j++)
			{
				this.PrePlayParticle(this._particles[j], XSingleton<XFxMgr>.singleton.CameraLayerMask);
			}
			this._weaponTail = t.GetComponentInChildren<IWeaponTail>();
		}

		public void Clear()
		{
			this._animation = null;
			this._animator = null;
			this._particles.Clear();
			this._projectors.Clear();
			this._weaponTail = null;
		}

		public void Play(Vector3 position, Quaternion rotation)
		{
			this.Play(position, rotation, 1f, Vector3.one);
		}

		public void Play(Vector3 position, Quaternion rotation, float speed_ratio, Vector3 scale)
		{
			this._startSize = scale.x;
			this._fx.transform.position = position;
			this._fx.transform.rotation = rotation;
			this._fx.transform.localScale = scale;
			if (this._particles != null)
			{
				XFx.ParticleCount += this._particles.Count;
				for (int i = 0; i < this._particles.Count; i++)
				{
					ParticleSystem particleSystem = this._particles[i];
					particleSystem.playbackSpeed /= speed_ratio;
					particleSystem.startSize *= this._startSize;
					particleSystem.time = 0f;
					particleSystem.Play(false);
				}
			}
			if (this._animation != null)
			{
				this._animation.enabled = true;
				this._animation.Play();
			}
			if (this._animator != null)
			{
				this._animator.enabled = true;
				this._animator.speed = 1f / speed_ratio;
				this._animator.Play(this._animator.name, -1, 0f);
			}
			this._startProjectorSize = 1f;
			if (this._projectors != null)
			{
				float aspectRatio = 1f;
				if (scale.z > 0f)
				{
					aspectRatio = scale.x / scale.z;
					this._startProjectorSize = scale.z;
				}
				for (int j = 0; j < this._projectors.Count; j++)
				{
					this._projectors[j].enabled = true;
					this._projectors[j].aspectRatio = aspectRatio;
					this._projectors[j].orthoGraphicSize *= this._startProjectorSize;
				}
			}
			if (this._weaponTail != null)
			{
				this._weaponTail.Activate();
			}
			this._pause = false;
		}

		public void Play(Transform parent, float speed_ratio, Vector3 scale, Vector3 offset, bool follow, bool sticky = false)
		{
			this._startSize = scale.x;
			if (follow)
			{
				this._fx.transform.parent = parent;
				this._fx.transform.localPosition = Vector3.zero;
				this._fx.transform.localRotation = Quaternion.identity;
				this._fx.transform.localScale = scale;
				this._fx.transform.localPosition += parent.rotation * offset;
			}
			else
			{
				this._fx.transform.position = parent.position + parent.rotation * offset;
				this._fx.transform.rotation = parent.rotation;
				this._fx.transform.localScale = scale;
			}
			if (this._particles != null)
			{
				XFx.ParticleCount += this._particles.Count;
				for (int i = 0; i < this._particles.Count; i++)
				{
					ParticleSystem particleSystem = this._particles[i];
					particleSystem.playbackSpeed /= speed_ratio;
					particleSystem.startSize *= this._startSize;
					particleSystem.time = 0f;
					particleSystem.Play(false);
				}
			}
			if (this._animation != null)
			{
				this._animation.enabled = true;
				this._animation.Play();
			}
			if (this._animator != null)
			{
				this._animator.enabled = true;
				this._animator.speed = 1f / speed_ratio;
				this._animator.Play(this._animator.name, -1, 0f);
			}
			if (this._projectors != null)
			{
				this._startProjectorSize = 1f;
				float aspectRatio = 1f;
				if (scale.z > 0f)
				{
					aspectRatio = scale.x / scale.z;
					this._startProjectorSize = scale.z;
				}
				for (int j = 0; j < this._projectors.Count; j++)
				{
					this._projectors[j].enabled = true;
					this._projectors[j].aspectRatio = aspectRatio;
					this._projectors[j].orthoGraphicSize *= this._startProjectorSize;
				}
			}
			if (this._weaponTail != null)
			{
				this._weaponTail.Activate();
			}
			this._pause = false;
			if (sticky)
			{
				this.Sticky();
			}
		}

		public void Play(Transform parent, float speed_ratio, Vector3 scale, bool follow)
		{
			this.Play(parent, speed_ratio, scale, Vector3.zero, follow, false);
		}

		public void Play(Transform parent, bool follow)
		{
			this.Play(parent, 1f, Vector3.one, follow);
		}

		public void Stop()
		{
			if (this._fx == null)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("XFx.Stop: Error fx ", this.FxName, " already be deleted~!", null, null, null);
			}
			else
			{
				this._fx.transform.localScale = Vector3.one;
			}
			if (this._particles != null)
			{
				for (int i = 0; i < this._particles.Count; i++)
				{
					ParticleSystem particleSystem = this._particles[i];
					particleSystem.playbackSpeed = 1f;
					particleSystem.startSize /= this._startSize;
					particleSystem.Stop(false);
					particleSystem.Clear();
				}
			}
			if (this._animation != null)
			{
				this._animation.Stop();
				this._animation.enabled = false;
			}
			if (this._animator != null)
			{
				this._animator.speed = 1f;
				this._animator.enabled = false;
			}
			if (this._projectors != null)
			{
				for (int j = 0; j < this._projectors.Count; j++)
				{
					this._projectors[j].enabled = false;
					if (this._startProjectorSize > 0f)
					{
						this._projectors[j].orthoGraphicSize /= this._startProjectorSize;
					}
				}
			}
			if (this._weaponTail != null)
			{
				this._weaponTail.Deactivate();
			}
			this._pause = false;
			this._startSize = 1f;
			this._startProjectorSize = 1f;
		}

		public void Pause()
		{
			if (this._pause)
			{
				return;
			}
			if (this._particles != null)
			{
				for (int i = 0; i < this._particles.Count; i++)
				{
					this._particles[i].Pause(false);
				}
			}
			if (this._animation != null)
			{
				AnimationState animationState = this._animation[this._animation.clip.name];
				if (animationState != null)
				{
					animationState.speed = 0f;
				}
			}
			if (this._animator != null)
			{
				this._animator.speed = 0f;
			}
			this._pause = true;
		}

		public void Resume()
		{
			if (this._pause)
			{
				if (this._particles != null)
				{
					for (int i = 0; i < this._particles.Count; i++)
					{
						this._particles[i].Play(false);
					}
				}
				if (this._animation != null)
				{
					AnimationState animationState = this._animation[this._animation.clip.name];
					if (animationState != null)
					{
						animationState.speed = 1f;
					}
				}
				if (this._animator != null)
				{
					this._animator.speed = 1f;
				}
			}
			this._pause = false;
		}

		public void StickToGround()
		{
			if (this._fx == null || this._fx.transform.parent == null)
			{
				return;
			}
			Vector3 zero = Vector3.zero;
			float num = 0f;
			float y = this._fx.transform.parent.localScale.y;
			if (XCurrentGrid.grid.TryGetHeight(this._fx.transform.parent.position, out num))
			{
				zero.y = (num - this._fx.transform.parent.position.y) / y + 0.025f;
			}
			this._fx.transform.localPosition = zero;
		}

		private void OnDestroy()
		{
			if (this._particles != null)
			{
				XFx.ParticleCount -= this._particles.Count;
			}
			if (this._fx != null)
			{
				UnityEngine.Object.Destroy(this._fx);
			}
			this._fx = null;
		}

		private void Sticky()
		{
			XSingleton<XFxMgr>.singleton.RegToSticky(this);
			this.StickToGround();
		}
	}
}
