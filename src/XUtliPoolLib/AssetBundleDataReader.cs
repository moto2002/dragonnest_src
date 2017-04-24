using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class AssetBundleDataReader
	{
		public Dictionary<uint, AssetBundleData> infoMap = new Dictionary<uint, AssetBundleData>();

		protected Dictionary<string, uint> shortName2FullName = new Dictionary<string, uint>();

		public virtual void Read(Stream fs)
		{
			StreamReader streamReader = new StreamReader(fs);
			char[] array = new char[6];
			streamReader.Read(array, 0, array.Length);
			if (array[0] != 'A' || array[1] != 'B' || array[2] != 'D' || array[3] != 'T')
			{
				return;
			}
			while (true)
			{
				string text = streamReader.ReadLine();
				if (string.IsNullOrEmpty(text))
				{
					break;
				}
				uint num = uint.Parse(streamReader.ReadLine().Replace(".ab", ""));
				string text2 = streamReader.ReadLine();
				string hash = streamReader.ReadLine();
				int compositeType = Convert.ToInt32(streamReader.ReadLine());
				int num2 = Convert.ToInt32(streamReader.ReadLine());
				uint[] array2 = new uint[num2];
				if (!this.shortName2FullName.ContainsKey(text2))
				{
					this.shortName2FullName.Add(text2, num);
				}
				for (int i = 0; i < num2; i++)
				{
					array2[i] = uint.Parse(streamReader.ReadLine().Replace(".ab", ""));
				}
				streamReader.ReadLine();
				AssetBundleData assetBundleData = new AssetBundleData();
				assetBundleData.debugName = text;
				assetBundleData.hash = hash;
				assetBundleData.fullName = num;
				assetBundleData.shortName = text2;
				assetBundleData.dependencies = array2;
				assetBundleData.compositeType = (AssetBundleExportType)compositeType;
				this.infoMap[num] = assetBundleData;
			}
			streamReader.Close();
		}

		public void Analyze()
		{
			Dictionary<uint, AssetBundleData>.Enumerator enumerator = this.infoMap.GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<uint, AssetBundleData> current = enumerator.Current;
				this.Analyze(current.Value);
			}
		}

		private void Analyze(AssetBundleData abd)
		{
			if (!abd.isAnalyzed)
			{
				abd.isAnalyzed = true;
				abd.dependList = new AssetBundleData[abd.dependencies.Length];
				for (int i = 0; i < abd.dependencies.Length; i++)
				{
					AssetBundleData assetBundleInfo = this.GetAssetBundleInfo(abd.dependencies[i]);
					abd.dependList[i] = assetBundleInfo;
					this.Analyze(assetBundleInfo);
				}
			}
		}

		public uint GetFullName(string shortName)
		{
			uint result = 0u;
			this.shortName2FullName.TryGetValue(shortName, out result);
			return result;
		}

		public AssetBundleData GetAssetBundleInfoByShortName(string shortName)
		{
			uint fullName = this.GetFullName(shortName);
			if (fullName != 0u && this.infoMap.ContainsKey(fullName))
			{
				return this.infoMap[fullName];
			}
			return null;
		}

		public AssetBundleData GetAssetBundleInfo(uint fullName)
		{
			if (fullName != 0u && this.infoMap.ContainsKey(fullName))
			{
				return this.infoMap[fullName];
			}
			return null;
		}
	}
}
