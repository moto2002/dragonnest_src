using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Math
{
	[TaskCategory("Basic/Math"), TaskDescription("Clamps the int between two values.")]
	public class IntClamp : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The int to clamp")]
		public SharedInt intVariable;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The maximum value of the int")]
		public SharedInt minValue;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The maximum value of the int")]
		public SharedInt maxValue;

		public override TaskStatus OnUpdate()
		{
			this.intVariable.Value = Mathf.Clamp(this.intVariable.Value, this.minValue.Value, this.maxValue.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.intVariable = (this.minValue = (this.maxValue = 0));
		}
	}
}
