using BehaviorDesigner.Runtime.Tasks;
using System;

namespace BehaviorDesigner.Runtime.ObjectDrawers
{
	public class FloatSliderAttribute : ObjectDrawerAttribute
	{
		public float min;

		public float max;

		public FloatSliderAttribute(float min, float max)
		{
			this.min = min;
			this.max = max;
		}
	}
}
