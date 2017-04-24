using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Math
{
	[TaskCategory("Basic/Math"), TaskDescription("Sets a bool value")]
	public class SetBool : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The bool value to set")]
		public SharedBool boolValue;

		[Tooltip("The variable to store the result")]
		public SharedBool storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = this.boolValue.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.boolValue.Value = false;
			this.storeResult.Value = false;
		}
	}
}
