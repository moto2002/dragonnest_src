using System;

namespace com.tencent.pandora
{
	internal struct AssetConfig
	{
		public AssetType type;

		public bool isCacheInMemory;

		public AssetConfig(AssetType type, bool isCacheInMemory)
		{
			this.type = type;
			this.isCacheInMemory = isCacheInMemory;
		}
	}
}
