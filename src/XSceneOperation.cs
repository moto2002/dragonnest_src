using System;
using XUtliPoolLib;

internal class XSceneOperation : XUIObject, IXInterface, IXSceneOperation
{
	public bool Deprecated
	{
		get;
		set;
	}

	public void SetLightMap()
	{
		LightMapSetter component = base.GetComponent<LightMapSetter>();
		if (component != null)
		{
			component.SetLightMap();
		}
	}
}
