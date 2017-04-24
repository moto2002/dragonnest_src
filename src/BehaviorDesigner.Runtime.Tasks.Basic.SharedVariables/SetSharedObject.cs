using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Sets the SharedObject variable to the specified object. Returns Success.")]
	public class SetSharedObject : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The value to set the SharedObject to")]
		public SharedObject targetValue;

		[RequiredField, Tooltip("The SharedTransform to set")]
		public SharedObject targetVariable;

		public override TaskStatus OnUpdate()
		{
			this.targetVariable.Value = this.targetValue.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetValue = null;
			this.targetVariable = null;
		}
	}
}
