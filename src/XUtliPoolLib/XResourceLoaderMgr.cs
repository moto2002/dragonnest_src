using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using XUpdater;

namespace XUtliPoolLib
{
	public sealed class XResourceLoaderMgr : XSingleton<XResourceLoaderMgr>
	{
		public class UniteObjectInfo
		{
			public uint hashID;

			public UnityEngine.Object asset;

			public int refCount;

			public AssetBundleInfo assetBundleInfo;

			public Queue<UnityEngine.Object> objPool;

			public string loc = "";

			private uint m_flag;

			public bool IsNoReleaseAsset
			{
				get
				{
					return (this.m_flag & XResourceLoaderMgr.NoReleaseAsset) != 0u;
				}
				set
				{
					if (value)
					{
						this.m_flag |= XResourceLoaderMgr.NoReleaseAsset;
						return;
					}
					this.m_flag &= ~XResourceLoaderMgr.NoReleaseAsset;
				}
			}

			public bool IsSharedResource
			{
				get
				{
					return (this.m_flag & XResourceLoaderMgr.SharedResource) != 0u;
				}
				set
				{
					if (value)
					{
						this.m_flag |= XResourceLoaderMgr.SharedResource;
						return;
					}
					this.m_flag &= ~XResourceLoaderMgr.SharedResource;
				}
			}

			public bool IsDontDestroyAsset
			{
				get
				{
					return (this.m_flag & XResourceLoaderMgr.DontDestroyAsset) != 0u;
				}
				set
				{
					if (value)
					{
						this.m_flag |= XResourceLoaderMgr.DontDestroyAsset;
						return;
					}
					this.m_flag &= ~XResourceLoaderMgr.DontDestroyAsset;
				}
			}

			private void InitAB(string location, string suffix)
			{
				if (XSingleton<XUpdater>.singleton.ABManager != null)
				{
					string path = "Assets.Resources." + location.Replace('/', '.') + suffix;
					this.assetBundleInfo = XSingleton<XUpdater>.singleton.ABManager.LoadImm(path);
				}
			}

			public bool Init(string location, string suffix, uint hash, bool isSharedResource, bool isNoReleaseAsset, Type t, bool showLog)
			{
				this.loc = location;
				this.IsSharedResource = isSharedResource;
				this.IsNoReleaseAsset = isNoReleaseAsset;
				this.hashID = hash;
				this.InitAB(location, suffix);
				if (this.assetBundleInfo != null)
				{
					this.asset = this.assetBundleInfo.mainObject;
				}
				else
				{
					this.asset = Resources.Load(location, t);
				}
				if (this.asset == null && showLog)
				{
					XResourceLoaderMgr.LoadErrorLog(location);
					return false;
				}
				return true;
			}

			public bool InitAnim(string location, string suffix, uint hash, bool isNoReleaseAsset)
			{
				this.loc = location;
				this.IsSharedResource = true;
				this.IsNoReleaseAsset = isNoReleaseAsset;
				this.hashID = hash;
				this.InitAB(location, suffix);
				float length = 0f;
				AnimationClip animationClip;
				if (this.assetBundleInfo != null)
				{
					animationClip = (this.assetBundleInfo.mainObject as AnimationClip);
					if (animationClip != null)
					{
						length = float.Parse(this.assetBundleInfo.config.text);
					}
				}
				else
				{
					animationClip = Resources.Load<AnimationClip>(location);
					if (animationClip != null)
					{
						length = animationClip.length;
					}
				}
				if (animationClip == null)
				{
					XResourceLoaderMgr.LoadErrorLog(location);
					return false;
				}
				XAnimationClip xAnimationClip = ScriptableObject.CreateInstance<XAnimationClip>();
				xAnimationClip.clip = animationClip;
				xAnimationClip.length = length;
				this.asset = xAnimationClip;
				return true;
			}

			public bool InitAsync(string location, uint hash, UnityEngine.Object asyncAsset, AssetBundleInfo info, bool isSharedResource, bool isNoReleaseAsset, bool showLog)
			{
				this.loc = location;
				this.IsSharedResource = isSharedResource;
				this.IsNoReleaseAsset = isNoReleaseAsset;
				this.hashID = hash;
				this.assetBundleInfo = info;
				if (this.assetBundleInfo != null)
				{
					this.asset = this.assetBundleInfo.mainObject;
				}
				else
				{
					this.asset = asyncAsset;
				}
				if (this.asset == null && showLog)
				{
					XResourceLoaderMgr.LoadErrorLog(location);
					return false;
				}
				return true;
			}

			public UnityEngine.Object Get(bool useObjPool)
			{
				UnityEngine.Object @object = null;
				if (this.IsSharedResource)
				{
					@object = this.asset;
				}
				else if (useObjPool && this.objPool != null && this.objPool.Count > 0)
				{
					@object = this.objPool.Dequeue();
				}
				else if (this.asset != null)
				{
					@object = UnityEngine.Object.Instantiate(this.asset);
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("null asset when instantiate asset", null, null, null, null, null);
				}
				if (@object != null)
				{
					this.refCount++;
					if (this.assetBundleInfo != null && this.refCount == 1)
					{
						this.assetBundleInfo.Retain();
					}
				}
				return @object;
			}

			public bool Return(UnityEngine.Object obj, bool useObjPool)
			{
				this.refCount--;
				if (this.asset != null && !this.IsNoReleaseAsset && this.refCount <= 0)
				{
					if (this.objPool != null)
					{
						while (this.objPool.Count > 0)
						{
							UnityEngine.Object obj2 = this.objPool.Dequeue();
							UnityEngine.Object.Destroy(obj2);
						}
						QueuePool<UnityEngine.Object>.Release(this.objPool);
						this.objPool = null;
					}
					if (obj != this.asset)
					{
						UnityEngine.Object.Destroy(obj);
					}
					if (this.assetBundleInfo != null)
					{
						this.assetBundleInfo.Release();
					}
					else if (!XResourceLoaderMgr.UniteObjectInfo.CanDestroy(this.asset))
					{
						Resources.UnloadAsset(this.asset);
					}
					return true;
				}
				if (!this.IsSharedResource && obj != null)
				{
					if (useObjPool)
					{
						if (obj is GameObject)
						{
							GameObject gameObject = obj as GameObject;
							gameObject.transform.position = XResourceLoaderMgr.Far_Far_Away;
							gameObject.transform.rotation = Quaternion.identity;
							gameObject.transform.parent = null;
						}
						if (this.objPool == null)
						{
							this.objPool = QueuePool<UnityEngine.Object>.Get();
						}
						this.objPool.Enqueue(obj);
					}
					else if (XResourceLoaderMgr.UniteObjectInfo.CanDestroy(obj))
					{
						UnityEngine.Object.Destroy(obj);
					}
				}
				return false;
			}

			public void Clear()
			{
				this.loc = "";
				this.hashID = 0u;
				this.asset = null;
				this.refCount = 0;
				this.assetBundleInfo = null;
				if (this.objPool != null)
				{
					QueuePool<UnityEngine.Object>.Release(this.objPool);
					this.objPool = null;
				}
			}

			public void ClearPool()
			{
				if (this.objPool != null)
				{
					QueuePool<UnityEngine.Object>.Release(this.objPool);
					this.objPool = null;
				}
			}

			public static bool CanDestroy(UnityEngine.Object obj)
			{
				return obj is GameObject || obj is ScriptableObject || obj is Material;
			}
		}

		public static uint NoReleaseAsset = 1u;

		public static uint SharedResource = 2u;

		public static uint DontDestroyAsset = 4u;

		public static readonly Vector3 Far_Far_Away = new Vector3(0f, -100f, 0f);

		public bool useNewMgr;

		private Dictionary<uint, AssetBundleInfo> _bundle_pool = new Dictionary<uint, AssetBundleInfo>();

		private Dictionary<uint, int> _asset_ref_count = new Dictionary<uint, int>();

		private Dictionary<uint, Queue<UnityEngine.Object>> _object_pool = new Dictionary<uint, Queue<UnityEngine.Object>>();

		private Dictionary<uint, UnityEngine.Object> _asset_pool = new Dictionary<uint, UnityEngine.Object>();

		private Dictionary<uint, UnityEngine.Object> _script_pool = new Dictionary<uint, UnityEngine.Object>();

		private Dictionary<int, uint> _reverse_map = new Dictionary<int, uint>();

		private Dictionary<uint, XResourceLoaderMgr.UniteObjectInfo> m_assetPool = new Dictionary<uint, XResourceLoaderMgr.UniteObjectInfo>();

		private Dictionary<int, XResourceLoaderMgr.UniteObjectInfo> m_instanceIDAssetMap = new Dictionary<int, XResourceLoaderMgr.UniteObjectInfo>();

		private Queue<XResourceLoaderMgr.UniteObjectInfo> m_objInfoPool = new Queue<XResourceLoaderMgr.UniteObjectInfo>();

		private BeforeUnityUnLoadResource m_BeforeUnityUnLoadResourceCb;

		private XmlSerializer[] xmlSerializerCache = new XmlSerializer[2];

		private MemoryStream shareMemoryStream = new MemoryStream(65536);

		private List<LoadAsyncTask> _async_task_list = new List<LoadAsyncTask>();

		private List<IDelayLoad> delayUpdateList = new List<IDelayLoad>();

		public static double delayTime = 0.5;

		private double currentDelayTime = -1.0;

		public bool processDelay;

		public bool isCurrentLoading;

		public XResourceLoaderMgr()
		{
			this.xmlSerializerCache[0] = new XmlSerializer(typeof(XSkillData));
			this.xmlSerializerCache[1] = new XmlSerializer(typeof(XCutSceneData));
		}

		public void ReleasePool()
		{
			if (this.useNewMgr)
			{
				using (Dictionary<uint, XResourceLoaderMgr.UniteObjectInfo>.Enumerator enumerator = this.m_assetPool.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<uint, XResourceLoaderMgr.UniteObjectInfo> current = enumerator.Current;
						XResourceLoaderMgr.UniteObjectInfo value = current.Value;
						if (value.asset != null && !value.IsDontDestroyAsset)
						{
							current.Value.ClearPool();
						}
					}
					goto IL_15C;
				}
			}
			foreach (KeyValuePair<uint, Queue<UnityEngine.Object>> current2 in this._object_pool)
			{
				while (current2.Value.Count > 0)
				{
					this.Destroy(current2.Value.Dequeue(), false);
				}
			}
			this._object_pool.Clear();
			this._asset_pool.Clear();
			this._script_pool.Clear();
			List<uint> list = new List<uint>(this._asset_ref_count.Keys);
			for (int i = 0; i < list.Count; i++)
			{
				this._asset_ref_count[list[i]] = 0;
			}
			foreach (KeyValuePair<uint, AssetBundleInfo> current3 in this._bundle_pool)
			{
				current3.Value.Release();
			}
			this._bundle_pool.Clear();
			IL_15C:
			for (int j = 0; j < this._async_task_list.Count; j++)
			{
				this._async_task_list[j].loadCbList.Clear();
			}
			this._async_task_list.Clear();
			this.shareMemoryStream.Close();
			this.shareMemoryStream = new MemoryStream(65536);
			this.delayUpdateList.Clear();
			if (XSingleton<XUpdater>.singleton.ABManager != null)
			{
				XSingleton<XUpdater>.singleton.ABManager.UnloadUnusedBundle(false);
			}
		}

		public void SetUnloadCallback(BeforeUnityUnLoadResource cb)
		{
			this.m_BeforeUnityUnLoadResourceCb = cb;
		}

		public void CallUnloadCallback()
		{
			if (this.m_BeforeUnityUnLoadResourceCb != null)
			{
				this.m_BeforeUnityUnLoadResourceCb();
			}
		}

		public Stream ReadText(string location, bool error = true)
		{
			TextAsset textAsset = this.XResourcesLoad<TextAsset>(location);
			if (textAsset == null)
			{
				if (!error)
				{
					return null;
				}
				XResourceLoaderMgr.LoadErrorLog(location);
			}
			Stream result;
			try
			{
				this.shareMemoryStream.SetLength(0L);
				this.shareMemoryStream.Write(textAsset.bytes, 0, textAsset.bytes.Length);
				this.shareMemoryStream.Seek(0L, SeekOrigin.Begin);
				result = this.shareMemoryStream;
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(ex.Message, location, null, null, null, null);
				result = this.shareMemoryStream;
			}
			finally
			{
				Resources.UnloadAsset(textAsset);
			}
			return result;
		}

		public bool ReadText(string location, MemoryStream stream, bool error = true)
		{
			bool result = true;
			TextAsset textAsset = this.XResourcesLoad<TextAsset>(location);
			if (textAsset == null)
			{
				if (error)
				{
					XResourceLoaderMgr.LoadErrorLog(location);
				}
				return false;
			}
			try
			{
				stream.Write(textAsset.bytes, 0, textAsset.bytes.Length);
				stream.Seek(0L, SeekOrigin.Begin);
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(ex.Message, location, null, null, null, null);
				result = false;
			}
			finally
			{
				Resources.UnloadAsset(textAsset);
			}
			return result;
		}

		public void ClearStream(Stream s)
		{
			if (s != null)
			{
				if (s == this.shareMemoryStream)
				{
					this.shareMemoryStream.SetLength(0L);
					return;
				}
				s.Close();
			}
		}

		public TextAsset ReadLuaBytes(string filename_without_ext)
		{
			string location = "lua/Hotfix/" + filename_without_ext;
			TextAsset textAsset = this.XResourcesLoad<TextAsset>(location);
			if (textAsset == null)
			{
				return null;
			}
			return textAsset;
		}

		public void ReleaseLuaBytes(TextAsset data)
		{
			Resources.UnloadAsset(data);
		}

		public bool ReadFile(string location, CVSReader reader)
		{
			TextAsset textAsset = this.XResourcesLoad<TextAsset>(location);
			if (textAsset == null || textAsset.bytes == null)
			{
				XResourceLoaderMgr.LoadErrorLog(location);
			}
			this.shareMemoryStream.SetLength(0L);
			this.shareMemoryStream.Write(textAsset.bytes, 0, textAsset.bytes.Length);
			this.shareMemoryStream.Seek(0L, SeekOrigin.Begin);
			bool result;
			try
			{
				bool flag = reader.ReadFile(this.shareMemoryStream);
				if (!flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("in File: ", location, reader.error, null, null, null);
				}
				Resources.UnloadAsset(textAsset);
				result = flag;
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(ex.Message, " in File: ", location, reader.error, null, null);
				result = false;
			}
			finally
			{
				this.shareMemoryStream.SetLength(0L);
			}
			return result;
		}

		public bool ReadFile(byte[] data, CVSReader reader)
		{
			if (data == null || reader == null)
			{
				return false;
			}
			this.shareMemoryStream.SetLength(0L);
			this.shareMemoryStream.Write(data, 0, data.Length);
			this.shareMemoryStream.Seek(0L, SeekOrigin.Begin);
			bool result;
			try
			{
				bool flag = reader.ReadFile(this.shareMemoryStream);
				result = flag;
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("ReadFile: ", ex.Message, null, null, null, null);
				result = false;
			}
			finally
			{
				this.shareMemoryStream.SetLength(0L);
			}
			return result;
		}

		public void CreateInAdvance(string location, int num, ECreateHideType hideType)
		{
			if (location == null || location.Length == 0)
			{
				return;
			}
			uint num2 = XSingleton<XCommon>.singleton.XHash(location);
			int num3 = 0;
			if (this.useNewMgr)
			{
				XResourceLoaderMgr.UniteObjectInfo uniteObjectInfo = null;
				if (this.m_assetPool.TryGetValue(num2, out uniteObjectInfo))
				{
					if (uniteObjectInfo.objPool != null)
					{
						num3 = uniteObjectInfo.objPool.Count;
					}
				}
				else
				{
					uniteObjectInfo = this.GetObjectInfo();
					uniteObjectInfo.Init(location, ".prefab", num2, false, false, typeof(GameObject), true);
					this.m_assetPool.Add(num2, uniteObjectInfo);
				}
				if (uniteObjectInfo.objPool == null)
				{
					uniteObjectInfo.objPool = QueuePool<UnityEngine.Object>.Get();
				}
				for (int i = 0; i < num - num3; i++)
				{
					if (uniteObjectInfo.asset != null)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate(uniteObjectInfo.asset) as GameObject;
						if (gameObject != null)
						{
							uniteObjectInfo.objPool.Enqueue(gameObject);
							switch (hideType)
							{
							case ECreateHideType.DisableObject:
								gameObject.SetActive(false);
								break;
							case ECreateHideType.DisableAnim:
							{
								Animator componentInChildren = gameObject.GetComponentInChildren<Animator>();
								if (componentInChildren != null)
								{
									componentInChildren.enabled = false;
								}
								break;
							}
							case ECreateHideType.DisableParticleRenderer:
								XSingleton<XCommon>.singleton.EnableParticleRenderer(gameObject, false);
								break;
							}
						}
					}
				}
				return;
			}
			if (this._object_pool.ContainsKey(num2))
			{
				Queue<UnityEngine.Object> queue = this._object_pool[num2];
				num3 = queue.Count;
			}
			for (int j = 0; j < num - num3; j++)
			{
				UnityEngine.Object @object = this.CreateFromPrefab(location, false, false);
				this.AddToObjectPool(num2, @object);
				GameObject gameObject2 = @object as GameObject;
				if (gameObject2 != null)
				{
					switch (hideType)
					{
					case ECreateHideType.DisableObject:
						gameObject2.SetActive(false);
						break;
					case ECreateHideType.DisableAnim:
					{
						Animator componentInChildren2 = gameObject2.GetComponentInChildren<Animator>();
						if (componentInChildren2 != null)
						{
							componentInChildren2.enabled = false;
						}
						break;
					}
					case ECreateHideType.DisableParticleRenderer:
						XSingleton<XCommon>.singleton.EnableParticleRenderer(gameObject2, false);
						break;
					}
				}
			}
		}

		public XResourceLoaderMgr.UniteObjectInfo GetObject(uint hash, out UnityEngine.Object obj, bool useObjPool)
		{
			XResourceLoaderMgr.UniteObjectInfo uniteObjectInfo = null;
			obj = null;
			if (this.m_assetPool.TryGetValue(hash, out uniteObjectInfo))
			{
				obj = uniteObjectInfo.Get(useObjPool);
				return uniteObjectInfo;
			}
			return null;
		}

		public bool GetObjectAsync(string location, uint hash, UnityEngine.Object asset, AssetBundleInfo info, bool isSharedResource, out XResourceLoaderMgr.UniteObjectInfo uoi)
		{
			uoi = null;
			if (this.m_assetPool.TryGetValue(hash, out uoi))
			{
				XSingleton<XDebug>.singleton.AddWarningLog2("LoadAsync asset:{0},already loaded.", new object[]
				{
					location
				});
				if (asset != uoi.asset)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("not same asset at same path.", null, null, null, null, null);
				}
				return false;
			}
			uoi = this.GetObjectInfo();
			uoi.InitAsync(location, hash, asset, info, isSharedResource, false, true);
			this.m_assetPool.Add(hash, uoi);
			return true;
		}

		public UnityEngine.Object GetObject(XResourceLoaderMgr.UniteObjectInfo uoi, bool isSharedResource, bool useObjPool, bool notAddShared)
		{
			UnityEngine.Object @object = uoi.Get(useObjPool);
			if ((isSharedResource && notAddShared) || !isSharedResource)
			{
				this.m_instanceIDAssetMap.Add(@object.GetInstanceID(), uoi);
			}
			return @object;
		}

		private void ReturnObject(XResourceLoaderMgr.UniteObjectInfo uoi, UnityEngine.Object obj, int instanceID, bool usePool)
		{
			if (uoi != null)
			{
				if (uoi.Return(obj, usePool))
				{
					this.m_assetPool.Remove(uoi.hashID);
					uoi.Clear();
					this.m_objInfoPool.Enqueue(uoi);
					this.m_instanceIDAssetMap.Remove(instanceID);
					return;
				}
				if (!uoi.IsSharedResource)
				{
					this.m_instanceIDAssetMap.Remove(instanceID);
					return;
				}
			}
			else
			{
				if (XResourceLoaderMgr.UniteObjectInfo.CanDestroy(obj))
				{
					UnityEngine.Object.Destroy(obj);
					return;
				}
				Resources.UnloadAsset(obj);
			}
		}

		private XResourceLoaderMgr.UniteObjectInfo GetObjectInfo()
		{
			if (this.m_objInfoPool.Count > 0)
			{
				return this.m_objInfoPool.Dequeue();
			}
			return new XResourceLoaderMgr.UniteObjectInfo();
		}

		private void PushLoadTask(uint hash, out LoadAsyncTask task)
		{
			this.isCurrentLoading = true;
			LoadAsyncTask loadAsyncTask = null;
			int count = this._async_task_list.Count;
			int i;
			for (i = 0; i < count; i++)
			{
				LoadAsyncTask loadAsyncTask2 = this._async_task_list[i];
				if (!loadAsyncTask2.valid)
				{
					loadAsyncTask = loadAsyncTask2;
				}
				else if (loadAsyncTask2.hash == hash)
				{
					task = loadAsyncTask2;
					return;
				}
			}
			if (loadAsyncTask == null)
			{
				for (i++; i < count; i++)
				{
					LoadAsyncTask loadAsyncTask3 = this._async_task_list[i];
					if (!loadAsyncTask3.valid)
					{
						loadAsyncTask = loadAsyncTask3;
						break;
					}
				}
			}
			if (loadAsyncTask == null)
			{
				loadAsyncTask = new LoadAsyncTask();
				this._async_task_list.Add(loadAsyncTask);
			}
			task = loadAsyncTask;
			task.loadCbList.Clear();
			task.complete = false;
			task.valid = true;
		}

		private LoadAsyncTask CreateAsyncTask(string location, string suffix, uint hash, LoadCallBack Cb, bool sharedRes, bool usePool, Type t)
		{
			LoadAsyncTask loadAsyncTask;
			this.PushLoadTask(hash, out loadAsyncTask);
			LoadInfo item;
			item.loadCb = Cb;
			item.usePool = usePool;
			loadAsyncTask.loadCbList.Add(item);
			loadAsyncTask.hash = hash;
			loadAsyncTask.location = location;
			loadAsyncTask.isSharedRes = sharedRes;
			loadAsyncTask.type = LoadFrom.AssetBundle;
			AssetBundleLoader assetBundleLoader = null;
			if (XSingleton<XUpdater>.singleton.ABManager != null)
			{
				string path = "Assets.Resources." + location.Replace('/', '.') + suffix;
				assetBundleLoader = XSingleton<XUpdater>.singleton.ABManager.Load(path, new AssetBundleManager.LoadAssetCompleteHandler(loadAsyncTask.AssetBundleLoadCompleteCb));
			}
			if (assetBundleLoader == null)
			{
				loadAsyncTask.type = LoadFrom.Local;
				loadAsyncTask.loader = Resources.LoadAsync(location, t);
			}
			return loadAsyncTask;
		}

		public GameObject CreateFromPrefab(string location, Vector3 position, Quaternion quaternion)
		{
			GameObject gameObject = this.CreateFromPrefab(location, true, false) as GameObject;
			gameObject.transform.position = position;
			gameObject.transform.rotation = quaternion;
			return gameObject;
		}

		public UnityEngine.Object CreateFromPrefab(string location, bool usePool = true, bool dontDestroy = false)
		{
			if (this.useNewMgr)
			{
				uint num = XSingleton<XCommon>.singleton.XHash(location);
				UnityEngine.Object @object = null;
				XResourceLoaderMgr.UniteObjectInfo uniteObjectInfo = this.GetObject(num, out @object, usePool);
				if (uniteObjectInfo == null)
				{
					uniteObjectInfo = this.GetObjectInfo();
					if (uniteObjectInfo.Init(location, ".prefab", num, false, false, typeof(GameObject), true))
					{
						@object = uniteObjectInfo.Get(usePool);
					}
					this.m_assetPool.Add(num, uniteObjectInfo);
				}
				uniteObjectInfo.IsDontDestroyAsset = dontDestroy;
				if (@object != null)
				{
					this.m_instanceIDAssetMap.Add(@object.GetInstanceID(), uniteObjectInfo);
				}
				return @object;
			}
			uint num2 = XSingleton<XCommon>.singleton.XHash(location);
			UnityEngine.Object object2 = null;
			if (!usePool || !this.GetInObjectPool(ref object2, num2))
			{
				object2 = this.GetAssetInPool(num2);
				if (object2 == null)
				{
					AssetBundleInfo assetBundleInfo = null;
					if (XSingleton<XUpdater>.singleton.ABManager != null)
					{
						string text = "Assets/Resources/" + location + ".prefab";
						text = text.Replace('/', '.');
						assetBundleInfo = XSingleton<XUpdater>.singleton.ABManager.LoadImm(text);
					}
					if (assetBundleInfo != null)
					{
						object2 = this.CreateFromAssetBundle<GameObject>(location, assetBundleInfo, true);
					}
					else
					{
						object2 = this.CreateFromAssets<GameObject>(location, true);
					}
				}
				object2 = UnityEngine.Object.Instantiate(object2);
				if (object2 != null)
				{
					this.AssetsRefRetain(num2);
					this.LogReverseID(object2, num2);
				}
			}
			return object2;
		}

		public LoadAsyncTask CreateFromPrefabAsync(string location, LoadCallBack Cb, bool usePool = true)
		{
			if (!this.useNewMgr)
			{
				uint num = XSingleton<XCommon>.singleton.XHash(location);
				UnityEngine.Object @object = null;
				if (usePool && this.GetInObjectPool(ref @object, num))
				{
					Cb(@object, location, false);
				}
				else
				{
					if (!this._asset_pool.TryGetValue(num, out @object))
					{
						LoadAsyncTask loadAsyncTask;
						this.PushLoadTask(num, out loadAsyncTask);
						LoadInfo item;
						item.loadCb = Cb;
						item.usePool = usePool;
						loadAsyncTask.loadCbList.Add(item);
						loadAsyncTask.hash = num;
						loadAsyncTask.location = location;
						loadAsyncTask.isSharedRes = false;
						loadAsyncTask.type = LoadFrom.AssetBundle;
						AssetBundleLoader assetBundleLoader = null;
						if (XSingleton<XUpdater>.singleton.ABManager != null)
						{
							string text = "Assets/Resources/" + location + ".prefab";
							text = text.Replace('/', '.');
							assetBundleLoader = XSingleton<XUpdater>.singleton.ABManager.Load(text, new AssetBundleManager.LoadAssetCompleteHandler(loadAsyncTask.AssetBundleLoadCompleteCb));
						}
						if (assetBundleLoader == null)
						{
							loadAsyncTask.type = LoadFrom.Local;
							loadAsyncTask.loader = Resources.LoadAsync<GameObject>(location);
						}
						return loadAsyncTask;
					}
					GameObject gameObject = UnityEngine.Object.Instantiate(@object) as GameObject;
					Cb(gameObject, location, false);
					this.AssetsRefRetain(num);
					this.LogReverseID(gameObject, num);
				}
				return null;
			}
			uint hash = XSingleton<XCommon>.singleton.XHash(location);
			UnityEngine.Object obj = null;
			XResourceLoaderMgr.UniteObjectInfo object2 = this.GetObject(hash, out obj, usePool);
			if (object2 != null)
			{
				Cb(obj, location, false);
				return null;
			}
			return this.CreateAsyncTask(location, ".prefab", hash, Cb, false, usePool, typeof(GameObject));
		}

		public T GetSharedResource<T>(string location, string suffix, bool showLog = true) where T : UnityEngine.Object
		{
			if (this.useNewMgr)
			{
				uint num = XSingleton<XCommon>.singleton.XHash(location);
				UnityEngine.Object @object = null;
				if (this.GetObject(num, out @object, false) == null)
				{
					XResourceLoaderMgr.UniteObjectInfo objectInfo = this.GetObjectInfo();
					if (objectInfo.Init(location, suffix, num, true, false, typeof(T), false))
					{
						@object = objectInfo.Get(false);
					}
					this.m_assetPool.Add(num, objectInfo);
					if (@object != null)
					{
						this.m_instanceIDAssetMap.Add(@object.GetInstanceID(), objectInfo);
					}
				}
				return @object as T;
			}
			uint hash = XSingleton<XCommon>.singleton.XHash(location);
			UnityEngine.Object object2 = this.GetAssetInPool(hash);
			if (object2 == null)
			{
				AssetBundleInfo assetBundleInfo = null;
				if (XSingleton<XUpdater>.singleton.ABManager != null)
				{
					string text = "Assets/Resources/" + location + suffix;
					text = text.Replace('/', '.');
					assetBundleInfo = XSingleton<XUpdater>.singleton.ABManager.LoadImm(text);
				}
				if (assetBundleInfo != null)
				{
					object2 = this.CreateFromAssetBundle<T>(location, assetBundleInfo, showLog);
				}
				else
				{
					object2 = this.CreateFromAssets<T>(location, showLog);
				}
			}
			if (object2 != null)
			{
				this.AssetsRefRetain(hash);
			}
			return object2 as T;
		}

		public XAnimationClip GetAnimation(string location, bool showLog = true)
		{
			if (this.useNewMgr)
			{
				uint num = XSingleton<XCommon>.singleton.XHash(location);
				UnityEngine.Object @object = null;
				if (this.GetObject(num, out @object, false) == null)
				{
					XResourceLoaderMgr.UniteObjectInfo objectInfo = this.GetObjectInfo();
					if (objectInfo.InitAnim(location, ".anim", num, false))
					{
						@object = objectInfo.Get(false);
					}
					this.m_assetPool.Add(num, objectInfo);
					if (@object != null)
					{
						this.m_instanceIDAssetMap.Add(@object.GetInstanceID(), objectInfo);
					}
				}
				return @object as XAnimationClip;
			}
			uint hash = XSingleton<XCommon>.singleton.XHash(location);
			UnityEngine.Object object2 = this.GetAssetInPool(hash);
			if (object2 == null)
			{
				AssetBundleInfo assetBundleInfo = null;
				if (XSingleton<XUpdater>.singleton.ABManager != null)
				{
					string text = "Assets/Resources/" + location + ".anim";
					text = text.Replace('/', '.');
					assetBundleInfo = XSingleton<XUpdater>.singleton.ABManager.LoadImm(text);
				}
				if (assetBundleInfo != null)
				{
					object2 = this.CreateFromAssetBundle<XAnimationClip>(location, assetBundleInfo, showLog);
				}
				else
				{
					object2 = this.CreateFromAssets<XAnimationClip>(location, showLog);
				}
			}
			if (object2 != null)
			{
				this.AssetsRefRetain(hash);
			}
			return object2 as XAnimationClip;
		}

		public T CreateFromSharedResource<T>(string location, string suffix, bool showLog = true) where T : UnityEngine.Object
		{
			T sharedResource = this.GetSharedResource<T>(location, suffix, showLog);
			if (sharedResource != null)
			{
				return UnityEngine.Object.Instantiate(sharedResource) as T;
			}
			return default(T);
		}

		public LoadAsyncTask GetShareResourceAsync<T>(string location, string suffix, LoadCallBack Cb) where T : UnityEngine.Object
		{
			if (this.useNewMgr)
			{
				uint hash = XSingleton<XCommon>.singleton.XHash(location);
				UnityEngine.Object obj = null;
				XResourceLoaderMgr.UniteObjectInfo @object = this.GetObject(hash, out obj, false);
				if (@object != null)
				{
					Cb(obj, location, true);
					return null;
				}
				return this.CreateAsyncTask(location, suffix, hash, Cb, true, false, typeof(T));
			}
			else
			{
				uint num = XSingleton<XCommon>.singleton.XHash(location);
				UnityEngine.Object obj2 = null;
				if (this._asset_pool.TryGetValue(num, out obj2))
				{
					Cb(obj2, location, true);
					this.AssetsRefRetain(num);
					return null;
				}
				LoadAsyncTask loadAsyncTask;
				this.PushLoadTask(num, out loadAsyncTask);
				LoadInfo item;
				item.loadCb = Cb;
				item.usePool = true;
				loadAsyncTask.loadCbList.Add(item);
				loadAsyncTask.hash = num;
				loadAsyncTask.location = location;
				loadAsyncTask.isSharedRes = true;
				loadAsyncTask.type = LoadFrom.AssetBundle;
				AssetBundleLoader assetBundleLoader = null;
				if (XSingleton<XUpdater>.singleton.ABManager != null)
				{
					string text = "Assets/Resources/" + location + suffix;
					text = text.Replace('/', '.');
					assetBundleLoader = XSingleton<XUpdater>.singleton.ABManager.Load(text, new AssetBundleManager.LoadAssetCompleteHandler(loadAsyncTask.AssetBundleLoadCompleteCb));
				}
				if (assetBundleLoader == null)
				{
					loadAsyncTask.type = LoadFrom.Local;
					loadAsyncTask.loader = Resources.LoadAsync<T>(location);
				}
				return loadAsyncTask;
			}
		}

		public void Destroy(UnityEngine.Object o, bool returnPool = true)
		{
			if (o == null)
			{
				return;
			}
			this.Destroy(o, o.GetInstanceID(), returnPool);
		}

		private void Destroy(UnityEngine.Object o, int instanceID, bool returnPool = true)
		{
			if (this.useNewMgr)
			{
				XResourceLoaderMgr.UniteObjectInfo uoi = null;
				if (this.m_instanceIDAssetMap.TryGetValue(instanceID, out uoi))
				{
					this.ReturnObject(uoi, o, instanceID, returnPool);
					return;
				}
			}
			else
			{
				uint num = 0u;
				if (returnPool && this._reverse_map.TryGetValue(instanceID, out num))
				{
					this.AddToObjectPool(num, o);
					return;
				}
				if (this._reverse_map.TryGetValue(instanceID, out num))
				{
					this.AssetsRefRelease(num);
					this._reverse_map.Remove(instanceID);
				}
				UnityEngine.Object.Destroy(o);
			}
		}

		public void DestroyShareResource(string location, UnityEngine.Object o)
		{
			if (o == null)
			{
				return;
			}
			if (this.useNewMgr)
			{
				int instanceID = o.GetInstanceID();
				XResourceLoaderMgr.UniteObjectInfo uoi = null;
				if (this.m_instanceIDAssetMap.TryGetValue(instanceID, out uoi))
				{
					this.ReturnObject(uoi, o, instanceID, false);
					return;
				}
				Resources.UnloadAsset(o);
				return;
			}
			else
			{
				uint num = XSingleton<XCommon>.singleton.XHash(location);
				if (this._asset_ref_count.ContainsKey(num))
				{
					this.AssetsRefRelease(num);
					return;
				}
				Resources.UnloadAsset(o);
				return;
			}
		}

		public void LoadABScene(string path)
		{
			AssetBundleInfo assetBundleInfo = XSingleton<XUpdater>.singleton.ABManager.LoadImm(string.Format("Assets/XScene/Scenelib/{0}.unity", path).Replace('/', '.'));
			if (assetBundleInfo != null)
			{
				XSingleton<XDebug>.singleton.AddLog("Load AB Scene Finish!", null, null, null, null, null, XDebugColor.XDebug_None);
			}
		}

		public IXCurve GetCurve(string location)
		{
			GameObject sharedResource = this.GetSharedResource<GameObject>(location, ".prefab", true);
			return sharedResource.GetComponent("XCurve") as IXCurve;
		}

		public T GetData<T>(string pathwithname)
		{
			uint key = XSingleton<XCommon>.singleton.XHash(pathwithname);
			UnityEngine.Object @object = null;
			if (!this._script_pool.TryGetValue(key, out @object))
			{
				TextAsset textAsset = this.XResourcesLoad<TextAsset>(pathwithname);
				if (textAsset == null)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Deserialize file ", pathwithname, " Error!", null, null, null);
				}
				int num = (typeof(T) == typeof(XCutSceneData)) ? 1 : 0;
				XmlSerializer xmlSerializer = this.xmlSerializerCache[num];
				this.shareMemoryStream.Seek(0L, SeekOrigin.Begin);
				this.shareMemoryStream.SetLength(0L);
				this.shareMemoryStream.Write(textAsset.bytes, 0, textAsset.bytes.Length);
				this.shareMemoryStream.Seek(0L, SeekOrigin.Begin);
				object data = xmlSerializer.Deserialize(this.shareMemoryStream);
				XDataWrapper xDataWrapper = ScriptableObject.CreateInstance<XDataWrapper>();
				xDataWrapper.Data = data;
				Resources.UnloadAsset(textAsset);
				@object = xDataWrapper;
				if (null != @object)
				{
					this._script_pool.Add(key, @object);
				}
			}
			return (T)((object)(@object as XDataWrapper).Data);
		}

		public UnityEngine.Object AddAssetInPool(UnityEngine.Object asset, uint hash, AssetBundleInfo info = null)
		{
			if (asset == null)
			{
				return null;
			}
			UnityEngine.Object @object = null;
			if (!this._asset_pool.TryGetValue(hash, out @object))
			{
				@object = asset;
				this._asset_pool.Add(hash, @object);
				if (info != null && !this._bundle_pool.ContainsKey(hash))
				{
					info.Retain();
					this._bundle_pool.Add(hash, info);
				}
			}
			return @object;
		}

		public UnityEngine.Object GetAssetInPool(uint hash)
		{
			UnityEngine.Object result = null;
			this._asset_pool.TryGetValue(hash, out result);
			return result;
		}

		public bool GetInObjectPool(ref UnityEngine.Object o, uint id)
		{
			Queue<UnityEngine.Object> queue = null;
			if (this._object_pool.TryGetValue(id, out queue))
			{
				int count = queue.Count;
				if (count > 0)
				{
					o = queue.Dequeue();
					if (queue.Count == 0)
					{
						this._object_pool.Remove(id);
					}
					return true;
				}
				this._object_pool.Remove(id);
			}
			return false;
		}

		private UnityEngine.Object CreateFromAssets<T>(string location, bool showError = true)
		{
			uint hash = XSingleton<XCommon>.singleton.XHash(location);
			UnityEngine.Object @object;
			if (typeof(T) == typeof(XAnimationClip))
			{
				XAnimationClip xAnimationClip = ScriptableObject.CreateInstance<XAnimationClip>();
				xAnimationClip.clip = (Resources.Load(location, typeof(AnimationClip)) as AnimationClip);
				if (xAnimationClip.clip == null)
				{
					if (showError)
					{
						XResourceLoaderMgr.LoadErrorLog(location);
					}
					return null;
				}
				xAnimationClip.length = xAnimationClip.clip.length;
				@object = xAnimationClip;
			}
			else
			{
				@object = Resources.Load(location, typeof(T));
			}
			@object = this.AddAssetInPool(@object, hash, null);
			if (@object == null)
			{
				if (showError)
				{
					XResourceLoaderMgr.LoadErrorLog(location);
				}
				return null;
			}
			return @object;
		}

		private UnityEngine.Object CreateFromAssetBundle<T>(string location, AssetBundleInfo info, bool showError = true)
		{
			uint hash = XSingleton<XCommon>.singleton.XHash(location);
			UnityEngine.Object @object;
			if (typeof(T) == typeof(XAnimationClip))
			{
				XAnimationClip xAnimationClip = ScriptableObject.CreateInstance<XAnimationClip>();
				xAnimationClip.clip = (info.mainObject as AnimationClip);
				if (xAnimationClip.clip == null)
				{
					if (showError)
					{
						XResourceLoaderMgr.LoadErrorLog(location);
					}
					return null;
				}
				xAnimationClip.length = float.Parse(info.config.ToString());
				@object = xAnimationClip;
			}
			else
			{
				@object = info.mainObject;
			}
			@object = this.AddAssetInPool(@object, hash, info);
			if (@object == null)
			{
				if (showError)
				{
					XResourceLoaderMgr.LoadErrorLog(location);
				}
				return null;
			}
			return @object;
		}

		private void AddToObjectPool(uint id, UnityEngine.Object obj)
		{
			Queue<UnityEngine.Object> queue = null;
			if (!this._object_pool.TryGetValue(id, out queue))
			{
				queue = new Queue<UnityEngine.Object>();
				this._object_pool.Add(id, queue);
			}
			GameObject gameObject = obj as GameObject;
			if (gameObject != null)
			{
				gameObject.transform.position = XResourceLoaderMgr.Far_Far_Away;
				gameObject.transform.rotation = Quaternion.identity;
				gameObject.transform.parent = null;
			}
			queue.Enqueue(obj);
		}

		public void AssetsRefRetain(uint hash)
		{
			int num = 0;
			this._asset_ref_count.TryGetValue(hash, out num);
			num++;
			this._asset_ref_count[hash] = num;
		}

		public void AssetsRefRelease(uint hash)
		{
			int num = 0;
			if (this._asset_ref_count.TryGetValue(hash, out num))
			{
				num--;
				if (num < 0)
				{
					num = 0;
				}
				if (num == 0)
				{
					this._asset_pool.Remove(hash);
					this._asset_ref_count.Remove(hash);
					AssetBundleInfo assetBundleInfo = null;
					if (this._bundle_pool.TryGetValue(hash, out assetBundleInfo))
					{
						assetBundleInfo.Release();
						this._bundle_pool.Remove(hash);
						XSingleton<XUpdater>.singleton.ABManager.UnloadUnusedBundle(false);
						return;
					}
				}
				else
				{
					this._asset_ref_count[hash] = num;
				}
			}
		}

		public void LogReverseID(UnityEngine.Object o, uint id)
		{
			if (o != null)
			{
				int instanceID = o.GetInstanceID();
				if (!this._reverse_map.ContainsKey(instanceID))
				{
					this._reverse_map.Add(instanceID, id);
				}
			}
		}

		internal T XResourcesLoad<T>(string location) where T : UnityEngine.Object
		{
			T t = XSingleton<XUpdater>.singleton.ResourceLoad(XSingleton<XCommon>.singleton.XHash(location)) as T;
			if (!(t == null))
			{
				return t;
			}
			return Resources.Load(location, typeof(T)) as T;
		}

		public static void LoadErrorLog(string prefab)
		{
			XSingleton<XDebug>.singleton.AddErrorLog("Load resource: ", prefab, " error!", null, null, null);
		}

		public void PostUpdate(float deltaTime)
		{
			bool flag = false;
			for (int i = 0; i < this._async_task_list.Count; i++)
			{
				LoadAsyncTask loadAsyncTask = this._async_task_list[i];
				if (loadAsyncTask.valid && loadAsyncTask.CheckComplete())
				{
					loadAsyncTask.valid = false;
					loadAsyncTask.loader = null;
				}
				flag |= loadAsyncTask.valid;
			}
			if (!flag)
			{
				this.isCurrentLoading = false;
			}
			this.UpdateDelayProcess(deltaTime);
		}

		public void AddDelayProcess(IDelayLoad loader)
		{
			int i = 0;
			int count = this.delayUpdateList.Count;
			while (i < count)
			{
				IDelayLoad delayLoad = this.delayUpdateList[i];
				if (delayLoad == loader)
				{
					return;
				}
				i++;
			}
			if (this.currentDelayTime < 0.0)
			{
				this.currentDelayTime = XResourceLoaderMgr.delayTime;
			}
			this.delayUpdateList.Add(loader);
		}

		public void RemoveDelayProcess(IDelayLoad loader)
		{
			this.delayUpdateList.Remove(loader);
		}

		public void UpdateDelayProcess(float deltaTime)
		{
			if (this.delayUpdateList.Count > 0)
			{
				this.currentDelayTime -= XResourceLoaderMgr.delayTime;
				if (this.currentDelayTime <= 0.0)
				{
					IDelayLoad delayLoad = this.delayUpdateList[0];
					EDelayProcessType eDelayProcessType = delayLoad.DelayUpdate();
					if (eDelayProcessType == EDelayProcessType.EFinish)
					{
						this.delayUpdateList.RemoveAt(0);
						if (this.delayUpdateList.Count > 0)
						{
							this.currentDelayTime = XResourceLoaderMgr.delayTime;
						}
					}
				}
			}
		}
	}
}
