using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Math
{
	[TaskCategory("Basic/Math"), TaskDescription("Sets a float value")]
	public class SetFloat : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The float value to set")]
		public SharedFloat floatValue;

		[Tooltip("The variable to store the result")]
		public SharedFloat storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = this.floatValue.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.floatValue.Value = 0f;
			this.storeResult.Value = 0f;
		}
	}
}
