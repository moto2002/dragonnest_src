using System;
using UnityEngine;

namespace XUpdater
{
	internal delegate AsyncWriteRequest HandleBundleDownload(WWW www, XBundleData bundle, string error);
}
