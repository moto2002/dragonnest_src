using System;
using UnityEngine;
using XUtliPoolLib;

[ExecuteInEditMode]
public class XCameraWall : XWall
{
	public XCameraWall Associated;

	public XCurve Curve;

	public bool BeginWith;

	public float Angle;

	public bool VerticalOnly;

	public float VerticalShiftAngle;

	protected override void OnTriggered()
	{
		float sector = Vector3.Angle(base.transform.forward, this.Associated.transform.forward);
		Vector3 eulerAngles = base.transform.rotation.eulerAngles;
		eulerAngles.y = 0f;
		Vector3 cornerdir = Quaternion.AngleAxis(eulerAngles.z, base.transform.forward) * XSingleton<XCommon>.singleton.HorizontalRotateVetor3(base.transform.forward, 90f, true);
		if (this._forward_collision)
		{
			if (!this.VerticalOnly)
			{
				if (this.BeginWith)
				{
					this._interface.CameraWallEnter(this.Curve.Curve, base.transform.parent.transform.position, cornerdir, sector, this.Angle, this.Associated.Angle, this.BeginWith);
				}
				else
				{
					this._interface.CameraWallExit(this.Angle);
				}
			}
			this._interface.CameraWallVertical(this.VerticalShiftAngle);
		}
		else
		{
			if (!this.VerticalOnly)
			{
				if (this.BeginWith)
				{
					this._interface.CameraWallExit(this.Angle);
				}
				else
				{
					this._interface.CameraWallEnter(this.Curve.Curve, base.transform.parent.transform.position, cornerdir, sector, this.Angle, this.Associated.Angle, this.BeginWith);
				}
			}
			this._interface.CameraWallVertical(-this.VerticalShiftAngle);
		}
	}
}
