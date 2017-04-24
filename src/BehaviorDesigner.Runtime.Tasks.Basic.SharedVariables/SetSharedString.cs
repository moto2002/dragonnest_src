using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Sets the SharedString variable to the specified object. Returns Success.")]
	public class SetSharedString : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The value to set the SharedString to")]
		public SharedString targetValue;

		[RequiredField, Tooltip("The SharedString to set")]
		public SharedString targetVariable;

		public override TaskStatus OnUpdate()
		{
			this.targetVariable.Value = this.targetValue.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetValue = string.Empty;
			this.targetVariable = string.Empty;
		}
	}
}
