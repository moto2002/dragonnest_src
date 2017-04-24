using System;

namespace XUtliPoolLib
{
	public class AssetBundleData
	{
		public string shortName;

		public uint fullName;

		public string hash;

		public string debugName;

		public AssetBundleExportType compositeType;

		public uint[] dependencies;

		public bool isAnalyzed;

		public AssetBundleData[] dependList;
	}
}
