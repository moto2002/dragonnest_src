using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Sets the SharedTransformList variable to the specified object. Returns Success.")]
	public class SetSharedTransformList : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The value to set the SharedTransformList to.")]
		public SharedTransformList targetValue;

		[RequiredField, Tooltip("The SharedTransformList to set")]
		public SharedTransformList targetVariable;

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
