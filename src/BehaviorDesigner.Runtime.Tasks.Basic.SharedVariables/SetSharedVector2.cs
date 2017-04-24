using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Sets the SharedVector2 variable to the specified object. Returns Success.")]
	public class SetSharedVector2 : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The value to set the SharedVector2 to")]
		public SharedVector2 targetValue;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The SharedVector2 to set")]
		public SharedVector2 targetVariable;

		public override TaskStatus OnUpdate()
		{
			this.targetVariable.Value = this.targetValue.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetValue = Vector2.zero;
			this.targetVariable = Vector2.zero;
		}
	}
}
