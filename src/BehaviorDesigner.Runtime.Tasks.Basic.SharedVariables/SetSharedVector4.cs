using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Sets the SharedVector4 variable to the specified object. Returns Success.")]
	public class SetSharedVector4 : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The value to set the SharedVector4 to")]
		public SharedVector4 targetValue;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The SharedVector4 to set")]
		public SharedVector4 targetVariable;

		public override TaskStatus OnUpdate()
		{
			this.targetVariable.Value = this.targetValue.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetValue = Vector4.zero;
			this.targetVariable = Vector4.zero;
		}
	}
}
