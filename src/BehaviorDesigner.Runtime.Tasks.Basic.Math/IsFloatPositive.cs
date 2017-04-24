using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Math
{
	[TaskCategory("Basic/Math"), TaskDescription("Is the float a positive value?")]
	public class IsFloatPositive : Conditional
	{
		[Tooltip("The float to check if positive")]
		public SharedFloat floatVariable;

		public override TaskStatus OnUpdate()
		{
			return (this.floatVariable.Value <= 0f) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.floatVariable = 0f;
		}
	}
}
