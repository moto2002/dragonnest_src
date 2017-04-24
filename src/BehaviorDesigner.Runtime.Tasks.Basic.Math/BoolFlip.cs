using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Math
{
	[TaskCategory("Basic/Math"), TaskDescription("Flips the value of the bool.")]
	public class BoolFlip : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The bool to flip the value of")]
		public SharedBool boolVariable;

		public override TaskStatus OnUpdate()
		{
			this.boolVariable.Value = !this.boolVariable.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.boolVariable.Value = false;
		}
	}
}
