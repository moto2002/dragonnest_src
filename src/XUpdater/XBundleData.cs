using System;

namespace XUpdater
{
	[Serializable]
	public class XBundleData
	{
		public string Name;

		public string MD5;

		public uint Size;

		public AssetLevel Level;
	}
}
