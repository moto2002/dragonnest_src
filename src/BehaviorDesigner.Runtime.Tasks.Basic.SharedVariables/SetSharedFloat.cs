using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Sets the SharedFloat variable to the specified object. Returns Success.")]
	public class SetSharedFloat : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The value to set the SharedFloat to")]
		public SharedFloat targetValue;

		[RequiredField, Tooltip("The SharedFloat to set")]
		public SharedFloat targetVariable;

		public override TaskStatus OnUpdate()
		{
			this.targetVariable.Value = this.targetValue.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetValue = 0f;
			this.targetVariable = 0f;
		}
	}
}
