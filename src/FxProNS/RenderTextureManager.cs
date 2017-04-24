using System;
using System.Collections.Generic;
using UnityEngine;

namespace FxProNS
{
	public class RenderTextureManager : IDisposable
	{
		private static RenderTextureManager instance;

		private List<RenderTexture> allRenderTextures;

		private List<RenderTexture> availableRenderTextures;

		public static RenderTextureManager Instance
		{
			get
			{
				RenderTextureManager arg_17_0;
				if ((arg_17_0 = RenderTextureManager.instance) == null)
				{
					arg_17_0 = (RenderTextureManager.instance = new RenderTextureManager());
				}
				return arg_17_0;
			}
		}

		public RenderTexture RequestRenderTexture(int _width, int _height, int _depth, RenderTextureFormat _format)
		{
			if (this.allRenderTextures == null)
			{
				this.allRenderTextures = new List<RenderTexture>();
			}
			if (this.availableRenderTextures == null)
			{
				this.availableRenderTextures = new List<RenderTexture>();
			}
			RenderTexture renderTexture = null;
			int i = 0;
			int count = this.availableRenderTextures.Count;
			while (i < count)
			{
				RenderTexture renderTexture2 = this.availableRenderTextures[i];
				if (!(null == renderTexture2))
				{
					if (renderTexture2.width == _width && renderTexture2.height == _height && renderTexture2.depth == _depth && renderTexture2.format == _format)
					{
						renderTexture = renderTexture2;
					}
				}
				i++;
			}
			if (null != renderTexture)
			{
				this.MakeRenderTextureNonAvailable(renderTexture);
				renderTexture.DiscardContents(true, true);
				return renderTexture;
			}
			renderTexture = this.CreateNewTexture(_width, _height, _depth, _format);
			this.MakeRenderTextureNonAvailable(renderTexture);
			return renderTexture;
		}

		public RenderTexture ReleaseRenderTexture(RenderTexture _tex)
		{
			if (null == _tex || this.availableRenderTextures == null)
			{
				return null;
			}
			if (this.availableRenderTextures.Contains(_tex))
			{
				return null;
			}
			this.availableRenderTextures.Add(_tex);
			return null;
		}

		public void SafeAssign(ref RenderTexture a, RenderTexture b)
		{
			if (a == b)
			{
				return;
			}
			this.ReleaseRenderTexture(a);
			a = b;
		}

		public void MakeRenderTextureNonAvailable(RenderTexture _tex)
		{
			if (this.availableRenderTextures.Contains(_tex))
			{
				this.availableRenderTextures.Remove(_tex);
			}
		}

		private RenderTexture CreateNewTexture(int _width, int _height, int _depth, RenderTextureFormat _format)
		{
			RenderTexture renderTexture = new RenderTexture(_width, _height, _depth, _format);
			renderTexture.Create();
			renderTexture.DiscardContents(true, true);
			this.allRenderTextures.Add(renderTexture);
			this.availableRenderTextures.Add(renderTexture);
			return renderTexture;
		}

		public void PrintRenderTextureStats()
		{
			string text = "<color=blue>availableRenderTextures: </color>" + this.availableRenderTextures.Count + "\n";
			int i = 0;
			int count = this.availableRenderTextures.Count;
			while (i < count)
			{
				RenderTexture rt = this.availableRenderTextures[i];
				text = text + "\t" + this.RenderTexToString(rt) + "\n";
				i++;
			}
			Debug.Log(text);
			text = "<color=green>allRenderTextures:</color>" + this.allRenderTextures.Count + "\n";
			int j = 0;
			int count2 = this.allRenderTextures.Count;
			while (j < count2)
			{
				RenderTexture rt2 = this.allRenderTextures[j];
				text = text + "\t" + this.RenderTexToString(rt2) + "\n";
				j++;
			}
			Debug.Log(text);
		}

		private string RenderTexToString(RenderTexture _rt)
		{
			if (null == _rt)
			{
				return "null";
			}
			return string.Concat(new object[]
			{
				_rt.width,
				" x ",
				_rt.height,
				"\t",
				_rt.depth,
				"\t",
				_rt.format
			});
		}

		private void PrintRenderTexturesCount(string _prefix = "")
		{
			Debug.Log(string.Concat(new object[]
			{
				_prefix,
				": ",
				this.allRenderTextures.Count - this.availableRenderTextures.Count,
				"/",
				this.allRenderTextures.Count
			}));
		}

		public void ReleaseAllRenderTextures()
		{
			if (this.allRenderTextures == null)
			{
				return;
			}
			int i = 0;
			int count = this.allRenderTextures.Count;
			while (i < count)
			{
				RenderTexture renderTexture = this.allRenderTextures[i];
				if (!this.availableRenderTextures.Contains(renderTexture))
				{
					this.ReleaseRenderTexture(renderTexture);
				}
				i++;
			}
		}

		public void PrintBalance()
		{
			Debug.Log(string.Concat(new object[]
			{
				"RenderTextures balance: ",
				this.allRenderTextures.Count - this.availableRenderTextures.Count,
				"/",
				this.allRenderTextures.Count
			}));
		}

		public void Dispose()
		{
			if (this.allRenderTextures != null)
			{
				int i = 0;
				int count = this.allRenderTextures.Count;
				while (i < count)
				{
					RenderTexture renderTexture = this.allRenderTextures[i];
					renderTexture.Release();
					i++;
				}
				this.allRenderTextures.Clear();
			}
			if (this.availableRenderTextures != null)
			{
				this.availableRenderTextures.Clear();
			}
		}
	}
}
