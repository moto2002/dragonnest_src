using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[ExecuteInEditMode, RequireComponent(typeof(Projector))]
public class ProjectorsControl : MonoBehaviour
{
	public delegate void TransitionCompleted();

	private Projector projector;

	public bool enableAnim;

	public Color color = Color.white;

	public float falloff = 1f;

	public float amplify = 1f;

	public float argAccuracy = 0.01f;

	private Texture texture;

	private Material projectorMat;

	private Color innerColor = Color.white;

	private Vector4 innerArg = new Vector4(1f, 1f, 0f, 0f);

	private Texture innerTexture;

	private static float colorT = 0.00390625f;

	public event ProjectorsControl.TransitionCompleted OnPulseCompleted
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.OnPulseCompleted = (ProjectorsControl.TransitionCompleted)Delegate.Combine(this.OnPulseCompleted, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.OnPulseCompleted = (ProjectorsControl.TransitionCompleted)Delegate.Remove(this.OnPulseCompleted, value);
		}
	}

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
				this.innerColor = this.projectorMat.GetColor("_Color");
				this.innerArg = this.projectorMat.GetVector("_Args");
				this.innerTexture = this.projectorMat.GetTexture("_ShadowTex");
			}
		}
	}

	private void Update()
	{
		if (this.enableAnim && this.projectorMat != null)
		{
			float num = Mathf.Abs(this.innerColor.r - this.color.r);
			float num2 = Mathf.Abs(this.innerColor.g - this.color.g);
			float num3 = Mathf.Abs(this.innerColor.b - this.color.b);
			float num4 = Mathf.Abs(this.innerColor.a - this.color.a);
			if (num >= ProjectorsControl.colorT || num2 >= ProjectorsControl.colorT || num3 >= ProjectorsControl.colorT || num4 >= ProjectorsControl.colorT)
			{
				this.innerColor = this.color;
				this.projectorMat.SetColor("_Color", this.color);
			}
			float num5 = Mathf.Abs(this.innerArg.x - this.falloff);
			float num6 = Mathf.Abs(this.innerArg.y - this.amplify);
			if (num5 >= this.argAccuracy || num6 > this.argAccuracy)
			{
				this.innerArg.x = this.falloff;
				this.innerArg.y = this.amplify;
				this.projectorMat.SetVector("_Args", this.innerArg);
			}
			if (this.texture != null && this.innerTexture != this.texture)
			{
				this.innerTexture = this.texture;
				this.projectorMat.SetTexture("_ShadowTex", this.innerTexture);
			}
		}
	}
}
