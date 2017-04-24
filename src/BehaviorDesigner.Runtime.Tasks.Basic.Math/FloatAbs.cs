using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Math
{
	[TaskCategory("Basic/Math"), TaskDescription("Stores the absolute value of the float.")]
	public class FloatAbs : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The float to return the absolute value of")]
		public SharedFloat floatVariable;

		public override TaskStatus OnUpdate()
		{
			this.floatVariable.Value = Mathf.Abs(this.floatVariable.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.floatVariable = 0f;
		}
	}
}
