using System;
using UnityEngine;
using XUtliPoolLib;

public class XCurve : MonoBehaviour, IXInterface, IXCurve
{
	public float Max_Value;

	public float Land_Value;

	public AnimationCurve Curve = new AnimationCurve();

	public bool Deprecated
	{
		get;
		set;
	}

	public AnimationCurve GetCurve()
	{
		return this.Curve;
	}

	public float GetMaxValue()
	{
		return this.Max_Value;
	}

	public float GetLandValue()
	{
		return this.Land_Value;
	}
}
