using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Math
{
	[TaskCategory("Basic/Math"), TaskDescription("Is the int a positive value?")]
	public class IsIntPositive : Conditional
	{
		[Tooltip("The int to check if positive")]
		public SharedInt intVariable;

		public override TaskStatus OnUpdate()
		{
			return (this.intVariable.Value <= 0) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.intVariable = 0;
		}
	}
}
