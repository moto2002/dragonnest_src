using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.tencent.pandora
{
	public class PanelOnDestroyHook : MonoBehaviour
	{
		private void OnDestroy()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("type", "panelDestroy");
			dictionary.Add("content", base.gameObject.name);
			Pandora.Instance.Do(dictionary);
		}
	}
}
