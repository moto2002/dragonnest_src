using System;
using UnityEngine;

namespace FxProNS
{
	public class BloomHelper : Singleton<BloomHelper>, IDisposable
	{
		private static Material _mat;

		private BloomHelperParams p;

		private int bloomSamples = 5;

		private float bloomBlurRadius = 5f;

		public static Material Mat
		{
			get
			{
				if (null == BloomHelper._mat)
				{
					BloomHelper._mat = new Material(Shader.Find("Hidden/BloomPro"))
					{
						hideFlags = HideFlags.HideAndDontSave
					};
				}
				return BloomHelper._mat;
			}
		}

		public void Dispose()
		{
		}
	}
}
