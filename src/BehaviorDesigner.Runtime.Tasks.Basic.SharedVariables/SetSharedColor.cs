using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Sets the SharedColor variable to the specified object. Returns Success.")]
	public class SetSharedColor : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The value to set the SharedColor to")]
		public SharedColor targetValue;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The SharedColor to set")]
		public SharedColor targetVariable;

		public override TaskStatus OnUpdate()
		{
			this.targetVariable.Value = this.targetValue.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetValue = Color.black;
			this.targetVariable = Color.black;
		}
	}
}
