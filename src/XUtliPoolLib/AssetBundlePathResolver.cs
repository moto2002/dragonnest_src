using System;
using System.IO;
using UnityEngine;

namespace XUtliPoolLib
{
	public class AssetBundlePathResolver
	{
		public static AssetBundlePathResolver instance;

		private DirectoryInfo cacheDir;

		public virtual string BundleSaveDirName
		{
			get
			{
				return "AssetBundles";
			}
		}

		public string AndroidBundleSavePath
		{
			get
			{
				return "Assets/StreamingAssets/update/Android/" + this.BundleSaveDirName;
			}
		}

		public string iOSBundleSavePath
		{
			get
			{
				return "Assets/StreamingAssets/update/iOS/" + this.BundleSaveDirName;
			}
		}

		public string DefaultBundleSavePath
		{
			get
			{
				return "Assets/StreamingAssets/update/" + this.BundleSaveDirName;
			}
		}

		public virtual string AndroidHashCacheSaveFile
		{
			get
			{
				return "Assets/AssetBundles/Android/cache.txt";
			}
		}

		public virtual string iOSHashCacheSaveFile
		{
			get
			{
				return "Assets/AssetBundles/iOS/cache.txt";
			}
		}

		public virtual string DefaultHashCacheSaveFile
		{
			get
			{
				return "Assets/AssetBundles/cache.txt";
			}
		}

		public virtual string DependFileName
		{
			get
			{
				return "dep.all";
			}
		}

		public virtual string BundleCacheDir
		{
			get
			{
				if (this.cacheDir == null)
				{
					RuntimePlatform platform = Application.platform;
					string path;
					if (platform != RuntimePlatform.IPhonePlayer)
					{
						if (platform == RuntimePlatform.Android)
						{
							path = string.Format("{0}/update/AssetBundles", Application.persistentDataPath);
						}
						else
						{
							path = string.Format("{0}/update/AssetBundles", Application.persistentDataPath);
						}
					}
					else
					{
						path = string.Format("{0}/update/AssetBundles", Application.persistentDataPath);
					}
					this.cacheDir = new DirectoryInfo(path);
					if (!this.cacheDir.Exists)
					{
						this.cacheDir.Create();
					}
				}
				return this.cacheDir.FullName;
			}
		}

		public AssetBundlePathResolver()
		{
			AssetBundlePathResolver.instance = this;
		}

		public virtual string GetEditorModePath(string abName)
		{
			abName = abName.Replace(".", "/");
			int num = abName.LastIndexOf("/");
			if (num == -1)
			{
				return abName;
			}
			return string.Format("{0}.{1}", abName.Substring(0, num), abName.Substring(num + 1));
		}

		public virtual string GetBundleSourceFile(string path, bool forWWW = true)
		{
			RuntimePlatform platform = Application.platform;
			string result;
			if (platform != RuntimePlatform.IPhonePlayer)
			{
				if (platform == RuntimePlatform.Android)
				{
					if (forWWW)
					{
						result = string.Format("jar:file://{0}!/assets/update/Android/{1}/{2}", Application.dataPath, this.BundleSaveDirName, path);
					}
					else
					{
						result = string.Format("{0}!assets/update/Android/{1}/{2}", Application.dataPath, this.BundleSaveDirName, path);
					}
				}
				else if (forWWW)
				{
					result = string.Format("file://{0}/StreamingAssets/update/{1}/{2}", Application.dataPath, this.BundleSaveDirName, path);
				}
				else
				{
					result = string.Format("{0}/StreamingAssets/update/{1}/{2}", Application.dataPath, this.BundleSaveDirName, path);
				}
			}
			else if (forWWW)
			{
				result = string.Format("file://{0}/Raw/update/iOS/{1}/{2}", Application.dataPath, this.BundleSaveDirName, path);
			}
			else
			{
				result = string.Format("{0}/Raw/update/iOS/{1}/{2}", Application.dataPath, this.BundleSaveDirName, path);
			}
			return result;
		}
	}
}
