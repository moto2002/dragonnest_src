using System;
using UnityEngine;
using XUtliPoolLib;

public class HUDDescription : MonoBehaviour, IXInterface, IXHUDDescription
{
	public AnimationCurve offsetCurve = new AnimationCurve(new Keyframe[]
	{
		new Keyframe(0f, 0f),
		new Keyframe(3f, 40f)
	});

	public AnimationCurve alphaCurve = new AnimationCurve(new Keyframe[]
	{
		new Keyframe(1f, 1f),
		new Keyframe(3f, 0f)
	});

	public AnimationCurve scaleCurve = new AnimationCurve(new Keyframe[]
	{
		new Keyframe(0f, 0f),
		new Keyframe(0.25f, 1f)
	});

	public bool Deprecated
	{
		get;
		set;
	}

	public AnimationCurve GetPosCurve()
	{
		return this.offsetCurve;
	}

	public AnimationCurve GetAlphaCurve()
	{
		return this.alphaCurve;
	}

	public AnimationCurve GetScaleCurve()
	{
		return this.scaleCurve;
	}
}
