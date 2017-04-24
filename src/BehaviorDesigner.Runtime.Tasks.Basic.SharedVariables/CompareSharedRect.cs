using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Returns success if the variable value is equal to the compareTo value.")]
	public class CompareSharedRect : Conditional
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The first variable to compare")]
		public SharedRect variable;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The variable to compare to")]
		public SharedRect compareTo;

		public override TaskStatus OnUpdate()
		{
			return (!this.variable.Value.Equals(this.compareTo.Value)) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.variable = default(Rect);
			this.compareTo = default(Rect);
		}
	}
}
