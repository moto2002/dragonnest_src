using System;
using System.IO;

namespace XUtliPoolLib
{
	internal class AssetBundleDataBinaryReader : AssetBundleDataReader
	{
		public override void Read(Stream fs)
		{
			if (fs.Length < 4L)
			{
				return;
			}
			BinaryReader binaryReader = new BinaryReader(fs);
			char[] array = binaryReader.ReadChars(4);
			if (array[0] != 'A' || array[1] != 'B' || array[2] != 'D' || array[3] != 'B')
			{
				return;
			}
			int num = binaryReader.ReadInt32();
			uint[] array2 = new uint[num];
			for (int i = 0; i < num; i++)
			{
				array2[i] = uint.Parse(binaryReader.ReadString().Replace(".ab", ""));
			}
			while (fs.Position != fs.Length)
			{
				string debugName = binaryReader.ReadString();
				uint num2 = array2[binaryReader.ReadInt32()];
				string text = binaryReader.ReadString();
				string hash = binaryReader.ReadString();
				int compositeType = binaryReader.ReadInt32();
				int num3 = binaryReader.ReadInt32();
				uint[] array3 = new uint[num3];
				if (!this.shortName2FullName.ContainsKey(text))
				{
					this.shortName2FullName.Add(text, num2);
				}
				for (int j = 0; j < num3; j++)
				{
					array3[j] = array2[binaryReader.ReadInt32()];
				}
				AssetBundleData assetBundleData = new AssetBundleData();
				assetBundleData.hash = hash;
				assetBundleData.fullName = num2;
				assetBundleData.shortName = text;
				assetBundleData.debugName = debugName;
				assetBundleData.dependencies = array3;
				assetBundleData.compositeType = (AssetBundleExportType)compositeType;
				this.infoMap[num2] = assetBundleData;
			}
			binaryReader.Close();
		}
	}
}
