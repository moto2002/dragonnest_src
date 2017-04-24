using System;
using UnityEngine;

[ExecuteInEditMode, RequireComponent(typeof(Projector))]
public class ShapeProjectorsControl : MonoBehaviour
{
	private Projector projector;

	public bool enableAnim;

	public Color tintColor = Color.red;

	public Color outlineColor = Color.white;

	public float colorTransition = 1.1f;

	public float colorScale = 1f;

	public float outlineWidth = 0.1f;

	public float outlineScale = 1f;

	public float angle;

	public float argAccuracy = 0.01f;

	private Material projectorMat;

	private Color innerTintColor = Color.red;

	private Color innerOutlineColor = Color.white;

	private Vector4 innerArg = new Vector4(1.01f, 1f, 0.1f, 1f);

	private float innerAngle;

	private bool hasAngle;

	private static float colorT = 0.00390625f;

	private void Awake()
	{
		if (this.projector == null)
		{
			this.projector = base.GetComponent<Projector>();
		}
		if (this.projector != null)
		{
			this.projectorMat = this.projector.material;
			if (this.projectorMat != null)
			{
				this.innerTintColor = this.projectorMat.GetColor("_TintColor");
				this.innerOutlineColor = this.projectorMat.GetColor("_OutlineColor");
				this.innerArg = this.projectorMat.GetVector("_Arg");
				this.hasAngle = this.projectorMat.HasProperty("_Angle");
				if (this.hasAngle)
				{
					this.innerAngle = this.projectorMat.GetFloat("_Angle");
				}
			}
		}
	}

	private void Update()
	{
		if (this.enableAnim && this.projectorMat != null)
		{
			float num = Mathf.Abs(this.innerTintColor.r - this.tintColor.r);
			float num2 = Mathf.Abs(this.innerTintColor.g - this.tintColor.g);
			float num3 = Mathf.Abs(this.innerTintColor.b - this.tintColor.b);
			float num4 = Mathf.Abs(this.innerTintColor.a - this.tintColor.a);
			if (num >= ShapeProjectorsControl.colorT || num2 >= ShapeProjectorsControl.colorT || num3 >= ShapeProjectorsControl.colorT || num4 >= ShapeProjectorsControl.colorT)
			{
				this.innerTintColor = this.tintColor;
				this.projectorMat.SetColor("_TintColor", this.tintColor);
			}
			num = Mathf.Abs(this.innerOutlineColor.r - this.outlineColor.r);
			num2 = Mathf.Abs(this.innerOutlineColor.g - this.outlineColor.g);
			num3 = Mathf.Abs(this.innerOutlineColor.b - this.outlineColor.b);
			num4 = Mathf.Abs(this.innerOutlineColor.a - this.outlineColor.a);
			if (num >= ShapeProjectorsControl.colorT || num2 >= ShapeProjectorsControl.colorT || num3 >= ShapeProjectorsControl.colorT || num4 >= ShapeProjectorsControl.colorT)
			{
				this.innerOutlineColor = this.outlineColor;
				this.projectorMat.SetColor("_OutlineColor", this.outlineColor);
			}
			float num5 = Mathf.Abs(this.innerArg.x - this.colorTransition);
			float num6 = Mathf.Abs(this.innerArg.y - this.colorScale);
			float num7 = Mathf.Abs(this.innerArg.z - this.outlineWidth);
			float num8 = Mathf.Abs(this.innerArg.w - this.outlineScale);
			if (num5 >= this.argAccuracy || num6 > this.argAccuracy || num7 > this.argAccuracy || num8 > this.argAccuracy)
			{
				this.innerArg.x = this.colorTransition;
				this.innerArg.y = this.colorScale;
				this.innerArg.z = this.outlineWidth;
				this.innerArg.w = this.outlineScale;
				this.projectorMat.SetVector("_Arg", this.innerArg);
			}
			if (this.hasAngle)
			{
				float num9 = Mathf.Abs(this.innerAngle - this.angle);
				if (num9 >= this.argAccuracy)
				{
					this.projectorMat.SetFloat("_Angle", this.angle);
				}
			}
		}
	}
}
