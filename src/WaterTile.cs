using System;
using UnityEngine;

[ExecuteInEditMode]
public class WaterTile : MonoBehaviour
{
	public PlanarReflection reflection;

	public WaterBase waterBase;

	public void Start()
	{
		this.AcquireComponents();
	}

	private void AcquireComponents()
	{
		if (!this.reflection)
		{
			if (base.transform.parent)
			{
				this.reflection = base.transform.parent.GetComponent<PlanarReflection>();
			}
			else
			{
				this.reflection = base.transform.GetComponent<PlanarReflection>();
			}
		}
		if (!this.waterBase)
		{
			if (base.transform.parent)
			{
				this.waterBase = base.transform.parent.GetComponent<WaterBase>();
			}
			else
			{
				this.waterBase = base.transform.GetComponent<WaterBase>();
			}
		}
	}

	public void OnWillRenderObject()
	{
		if (this.reflection)
		{
			this.reflection.WaterTileBeingRendered(base.transform, Camera.current);
		}
		if (this.waterBase)
		{
			this.waterBase.WaterTileBeingRendered(base.transform, Camera.current);
		}
	}
}
