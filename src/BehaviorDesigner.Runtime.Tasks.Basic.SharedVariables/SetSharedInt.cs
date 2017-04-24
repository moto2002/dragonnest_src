using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Sets the SharedInt variable to the specified object. Returns Success.")]
	public class SetSharedInt : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The value to set the SharedInt to")]
		public SharedInt targetValue;

		[RequiredField, Tooltip("The SharedInt to set")]
		public SharedInt targetVariable;

		public override TaskStatus OnUpdate()
		{
			this.targetVariable.Value = this.targetValue.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetValue = 0;
			this.targetVariable = 0;
		}
	}
}
