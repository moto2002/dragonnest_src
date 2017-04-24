using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Math
{
	[TaskCategory("Basic/Math"), TaskDescription("Sets an int value")]
	public class SetInt : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The int value to set")]
		public SharedInt intValue;

		[Tooltip("The variable to store the result")]
		public SharedInt storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = this.intValue.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.intValue.Value = 0;
			this.storeResult.Value = 0;
		}
	}
}
