using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IXCurve : IXInterface
	{
		AnimationCurve GetCurve();

		float GetMaxValue();

		float GetLandValue();
	}
}
