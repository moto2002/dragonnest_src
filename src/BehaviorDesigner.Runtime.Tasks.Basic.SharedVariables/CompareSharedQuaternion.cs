using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Returns success if the variable value is equal to the compareTo value.")]
	public class CompareSharedQuaternion : Conditional
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The first variable to compare")]
		public SharedQuaternion variable;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The variable to compare to")]
		public SharedQuaternion compareTo;

		public override TaskStatus OnUpdate()
		{
			return (!this.variable.Value.Equals(this.compareTo.Value)) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.variable = Quaternion.identity;
			this.compareTo = Quaternion.identity;
		}
	}
}
