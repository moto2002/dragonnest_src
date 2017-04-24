using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Sets the SharedBool variable to the specified object. Returns Success.")]
	public class SetSharedBool : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The value to set the SharedBool to")]
		public SharedBool targetValue;

		[RequiredField, Tooltip("The SharedBool to set")]
		public SharedBool targetVariable;

		public override TaskStatus OnUpdate()
		{
			this.targetVariable.Value = this.targetValue.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetValue = false;
			this.targetVariable = false;
		}
	}
}
