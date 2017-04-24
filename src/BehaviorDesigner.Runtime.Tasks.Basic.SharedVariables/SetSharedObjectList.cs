using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Sets the SharedObjectList variable to the specified object. Returns Success.")]
	public class SetSharedObjectList : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The value to set the SharedObjectList to.")]
		public SharedObjectList targetValue;

		[RequiredField, Tooltip("The SharedObjectList to set")]
		public SharedObjectList targetVariable;

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
