using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Returns success if the variable value is equal to the compareTo value.")]
	public class CompareSharedVector2 : Conditional
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The first variable to compare")]
		public SharedVector2 variable;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The variable to compare to")]
		public SharedVector2 compareTo;

		public override TaskStatus OnUpdate()
		{
			return (!this.variable.Value.Equals(this.compareTo.Value)) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.variable = Vector2.zero;
			this.compareTo = Vector2.zero;
		}
	}
}
