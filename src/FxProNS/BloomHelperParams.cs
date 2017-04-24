using System;
using UnityEngine;

namespace FxProNS
{
	[Serializable]
	public class BloomHelperParams
	{
		public EffectsQuality Quality;

		public Color BloomTint = new Color(0.431372553f, 0.9019608f, 1f, 1f);

		[Range(0f, 0.99f)]
		public float BloomThreshold = 0.8f;

		[Range(0f, 3f)]
		public float BloomIntensity = 0.7f;

		[Range(0.01f, 3f)]
		public float BloomSoftness = 0.5f;
	}
}
