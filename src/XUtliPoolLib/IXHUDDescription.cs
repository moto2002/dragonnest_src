using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IXHUDDescription : IXInterface
	{
		AnimationCurve GetPosCurve();

		AnimationCurve GetAlphaCurve();

		AnimationCurve GetScaleCurve();
	}
}
