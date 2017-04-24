using System;
using UnityEngine;

public class XTransferWall : XWall
{
	public enum transfer_type
	{
		current_scene,
		other_scene
	}

	public XTransferWall.transfer_type targetScene;

	public int sceneID;

	public GameObject targetPos;

	protected override void OnTriggered()
	{
		if (this.targetScene == XTransferWall.transfer_type.current_scene)
		{
			if (this.targetPos != null)
			{
				this._interface.TransferToSceneLocation(this.targetPos.transform.position, this.targetPos.transform.forward);
			}
		}
		else if (this.targetScene == XTransferWall.transfer_type.other_scene && this.sceneID > 0)
		{
			this._interface.TransferToNewScene((uint)this.sceneID);
		}
	}
}
