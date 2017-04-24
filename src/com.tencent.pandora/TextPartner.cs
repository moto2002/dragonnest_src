using System;
using UnityEngine;

namespace com.tencent.pandora
{
	public class TextPartner : MonoBehaviour
	{
		public static Func<string, Font> GetFont;

		public string fontName;

		private void Awake()
		{
			UILabel component = base.gameObject.GetComponent<UILabel>();
			if (component != null && !string.IsNullOrEmpty(this.fontName) && TextPartner.GetFont != null)
			{
				component.trueTypeFont = TextPartner.GetFont(this.fontName);
			}
		}
	}
}
