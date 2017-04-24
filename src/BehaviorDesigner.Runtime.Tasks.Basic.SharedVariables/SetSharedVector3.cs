using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Sets the SharedVector3 variable to the specified object. Returns Success.")]
	public class SetSharedVector3 : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The value to set the SharedVector3 to")]
		public SharedVector3 targetValue;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The SharedVector3 to set")]
		public SharedVector3 targetVariable;

		public override TaskStatus OnUpdate()
		{
			this.targetVariable.Value = this.targetValue.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetValue = Vector3.zero;
			this.targetVariable = Vector3.zero;
		}
	}
}
