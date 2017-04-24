using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IXDummy
	{
		uint TypeID
		{
			get;
		}

		ulong ID
		{
			get;
		}

		Transform UnityTransform
		{
			get;
		}

		bool Deprecated
		{
			get;
			set;
		}

		XAnimationClip SetAnimation(string anim);

		void ResetAnimation();

		void SetupUIDummy(bool ui);
	}
}
