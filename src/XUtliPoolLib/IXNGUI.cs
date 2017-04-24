using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IXNGUI : IXInterface
	{
		bool XNGUIEnable();

		GameObject XNGUICreate(string locate);

		GameObject XPrefabCreate(string locate);

		bool XNGUIDestory(UnityEngine.Object o);

		T XNGUIResource<T>(string locate, bool ignore_null) where T : UnityEngine.Object;

		AssetBundleRequest XNGUISharedResourceAsync<T>(string locate, bool ignore_null = false) where T : UnityEngine.Object;

		bool XNGUIIsDecompress();

		bool XNGUIDecompressStreamAssets(Action<float> percent);

		string XNGUIGetDecompressProgress();

		bool XNGUIDecompressZipBytes(string zipFile, byte[] stream);

		void XNGUIWWW(Action<string> errorinfo);
	}
}
