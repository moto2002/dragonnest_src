using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Math
{
	[TaskCategory("Basic/Math"), TaskDescription("Clamps the float between two values.")]
	public class FloatClamp : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The float to clamp")]
		public SharedFloat floatVariable;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The maximum value of the float")]
		public SharedFloat minValue;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The maximum value of the float")]
		public SharedFloat maxValue;

		public override TaskStatus OnUpdate()
		{
			this.floatVariable.Value = Mathf.Clamp(this.floatVariable.Value, this.minValue.Value, this.maxValue.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.floatVariable = (this.minValue = (this.maxValue = 0f));
		}
	}
}
