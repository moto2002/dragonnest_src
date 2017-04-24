using System;
using UnityEngine;

namespace XUpdater
{
	internal delegate void HandleFetchBundle(WWW bundle, byte[] bytes, XBundleData data, bool newdownload);
}
