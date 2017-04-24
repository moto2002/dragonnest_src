using System;
using System.Collections.Generic;
using UnityEngine;
using XUpdater;

namespace XUtliPoolLib
{
	public class AssetBundleInfo
	{
		public delegate void OnUnloadedHandler(AssetBundleInfo abi);

		public AssetBundleInfo.OnUnloadedHandler onUnloaded;

		internal AssetBundle bundle;

		public uint bundleName;

		public AssetBundleData data;

		public float minLifeTime = 2f;

		private float _readyTime;

		private bool _isReady;

		private UnityEngine.Object _mainObject;

		private TextAsset _config;

		private HashSet<AssetBundleInfo> deps = new HashSet<AssetBundleInfo>();

		private List<uint> depChildren = new List<uint>();

		private List<WeakReference> references = new List<WeakReference>();

		[SerializeField]
		public int refCount
		{
			get;
			private set;
		}

		public bool isUnused
		{
			get
			{
				return this._isReady && Time.time - this._readyTime > this.minLifeTime && ((this.refCount <= 0 && this.UpdateReference() == 0) || this.data.debugName.StartsWith("Assets\\Effect") || this.data.debugName.StartsWith("Assets\\Resources\\Effects"));
			}
		}

		public bool isReady
		{
			get
			{
				return this._isReady;
			}
			set
			{
				this._isReady = value;
			}
		}

		public virtual UnityEngine.Object mainObject
		{
			get
			{
				if (this._mainObject == null && this._isReady)
				{
					this._mainObject = this.bundle.mainAsset;
					this._config = this.LoadAsset<TextAsset>(this._mainObject.name);
					if (this.data.compositeType == AssetBundleExportType.Root && XSingleton<XUpdater>.singleton.ABManager != null)
					{
						XSingleton<XUpdater>.singleton.ABManager.AddUnloadBundleQueue(this);
					}
				}
				return this._mainObject;
			}
		}

		public virtual TextAsset config
		{
			get
			{
				if (this._mainObject == null && this._isReady)
				{
					this._mainObject = this.bundle.mainAsset;
					this._config = this.LoadAsset<TextAsset>(this._mainObject.name);
					if (this.data.compositeType == AssetBundleExportType.Root && XSingleton<XUpdater>.singleton.ABManager != null)
					{
						XSingleton<XUpdater>.singleton.ABManager.AddUnloadBundleQueue(this);
					}
				}
				return this._config;
			}
		}

		public void AddDependency(AssetBundleInfo target)
		{
			if (target != null && this.deps.Add(target))
			{
				target.Retain();
				target.depChildren.Add(this.bundleName);
			}
		}

		public void ResetLifeTime()
		{
			if (this._isReady)
			{
				this._readyTime = Time.time;
			}
		}

		public void Retain()
		{
			this.refCount++;
		}

		public void Release()
		{
			this.refCount--;
		}

		public void Retain(UnityEngine.Object owner)
		{
			if (owner == null)
			{
				throw new Exception("Please set the user!");
			}
			for (int i = 0; i < this.references.Count; i++)
			{
				if (owner.Equals(this.references[i].Target))
				{
					return;
				}
			}
			WeakReference item = new WeakReference(owner);
			this.references.Add(item);
		}

		public void Release(object owner)
		{
			for (int i = 0; i < this.references.Count; i++)
			{
				if (this.references[i].Target == owner)
				{
					this.references.RemoveAt(i);
					return;
				}
			}
		}

		public virtual GameObject Instantiate()
		{
			return this.Instantiate(true);
		}

		public virtual GameObject Instantiate(bool enable)
		{
			if (this.mainObject != null && this.mainObject is GameObject)
			{
				GameObject gameObject = this.mainObject as GameObject;
				gameObject.SetActive(enable);
				UnityEngine.Object @object = UnityEngine.Object.Instantiate(gameObject);
				@object.name = gameObject.name;
				this.Retain(@object);
				return (GameObject)@object;
			}
			return null;
		}

		public virtual GameObject Instantiate(Vector3 position, Quaternion rotation, bool enable = true)
		{
			if (this.mainObject != null && this.mainObject is GameObject)
			{
				GameObject gameObject = this.mainObject as GameObject;
				gameObject.SetActive(enable);
				UnityEngine.Object @object = UnityEngine.Object.Instantiate(gameObject, position, rotation);
				@object.name = gameObject.name;
				this.Retain(@object);
				return (GameObject)@object;
			}
			return null;
		}

		public UnityEngine.Object Require(UnityEngine.Object user)
		{
			this.Retain(user);
			return this.mainObject;
		}

		public UnityEngine.Object Require(Component c, bool autoBindGameObject)
		{
			if (autoBindGameObject && c && c.gameObject)
			{
				return this.Require(c.gameObject);
			}
			return this.Require(c);
		}

		private int UpdateReference()
		{
			for (int i = 0; i < this.references.Count; i++)
			{
				UnityEngine.Object exists = (UnityEngine.Object)this.references[i].Target;
				if (!exists)
				{
					this.references.RemoveAt(i);
					i--;
				}
			}
			return this.references.Count;
		}

		public virtual void Dispose()
		{
			this.UnloadBundle();
			HashSet<AssetBundleInfo>.Enumerator enumerator = this.deps.GetEnumerator();
			while (enumerator.MoveNext())
			{
				AssetBundleInfo current = enumerator.Current;
				current.depChildren.Remove(this.bundleName);
				current.Release();
			}
			this.deps.Clear();
			this.references.Clear();
			if (this.onUnloaded != null)
			{
				this.onUnloaded(this);
			}
		}

		private T LoadAsset<T>(string name) where T : UnityEngine.Object
		{
			return this.bundle.Load(name, typeof(T)) as T;
		}

		public void UnloadBundle()
		{
			if (this.bundle != null)
			{
				if (AssetBundleManager.enableLog)
				{
					XSingleton<XDebug>.singleton.AddLog(string.Concat(new object[]
					{
						"Unload : ",
						this.data.compositeType,
						" >> ",
						this.bundleName,
						"(",
						this.data.debugName,
						")"
					}), null, null, null, null, null, XDebugColor.XDebug_None);
				}
				this.bundle.Unload(false);
				if (XSingleton<XUpdater>.singleton.ABManager != null)
				{
					XSingleton<XUpdater>.singleton.ABManager.DeleteBundleCount();
				}
			}
			this.bundle = null;
		}
	}
}
