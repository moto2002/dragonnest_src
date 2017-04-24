using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Sets the SharedQuaternion variable to the specified object. Returns Success.")]
	public class SetSharedQuaternion : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The value to set the SharedQuaternion to")]
		public SharedQuaternion targetValue;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The SharedQuaternion to set")]
		public SharedQuaternion targetVariable;

		public override TaskStatus OnUpdate()
		{
			this.targetVariable.Value = this.targetValue.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetValue = Quaternion.identity;
			this.targetVariable = Quaternion.identity;
		}
	}
}
