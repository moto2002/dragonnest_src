using System;
using System.Linq;
using UnityEngine;

public class LightMapSetter : MonoBehaviour
{
	public Texture2D[] LightMapNear;

	public Texture2D[] LightMapFar;

	private LightmapData[] lightMaps;

	private void Awake()
	{
		this.LightMapNear = this.LightMapNear.OrderBy((Texture2D t2d) => t2d.name, new NaturalSortComparer<string>(true)).ToArray<Texture2D>();
		this.LightMapFar = this.LightMapFar.OrderBy((Texture2D t2d) => t2d.name, new NaturalSortComparer<string>(true)).ToArray<Texture2D>();
		int num = Math.Max(this.LightMapFar.Length, this.LightMapNear.Length);
		if (num == 0)
		{
			this.lightMaps = null;
			return;
		}
		this.lightMaps = new LightmapData[num];
		for (int i = 0; i < num; i++)
		{
			this.lightMaps[i] = new LightmapData();
			this.lightMaps[i].lightmapNear = ((i >= this.LightMapNear.Length) ? null : this.LightMapNear[i]);
			this.lightMaps[i].lightmapFar = ((i >= this.LightMapFar.Length) ? null : this.LightMapFar[i]);
		}
	}

	public void SetLightMap()
	{
		if (this.lightMaps != null)
		{
			LightmapSettings.lightmaps = this.lightMaps;
		}
	}
}
