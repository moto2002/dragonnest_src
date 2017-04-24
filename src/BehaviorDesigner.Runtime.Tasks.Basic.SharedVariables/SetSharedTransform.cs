using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Sets the SharedTransform variable to the specified object. Returns Success.")]
	public class SetSharedTransform : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The value to set the SharedTransform to. If null the variable will be set to the current Transform")]
		public SharedTransform targetValue;

		[RequiredField, Tooltip("The SharedTransform to set")]
		public SharedTransform targetVariable;

		public override TaskStatus OnUpdate()
		{
			this.targetVariable.Value = ((!(this.targetValue.Value != null)) ? this.transform : this.targetValue.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetValue = null;
			this.targetVariable = null;
		}
	}
}
