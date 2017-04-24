using System;
using UnityEngine;

namespace UILib
{
	public interface IXUIProgress : IXUIObject
	{
		float value
		{
			get;
			set;
		}

		int width
		{
			get;
			set;
		}

		GameObject foreground
		{
			get;
		}

		void SetValueWithAnimation(float value);

		void SetTotalSection(uint section);

		void SetDepthOffset(int d);

		void SetForegroundColor(Color c);

		void ForceUpdate();
	}
}
