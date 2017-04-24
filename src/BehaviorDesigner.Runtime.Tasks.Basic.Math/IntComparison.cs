using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Math
{
	[TaskCategory("Basic/Math"), TaskDescription("Performs comparison between two integers: less than, less than or equal to, equal to, not equal to, greater than or equal to, or greater than.")]
	public class IntComparison : Conditional
	{
		public enum Operation
		{
			LessThan,
			LessThanOrEqualTo,
			EqualTo,
			NotEqualTo,
			GreaterThanOrEqualTo,
			GreaterThan
		}

		[Tooltip("The operation to perform")]
		public IntComparison.Operation operation;

		[Tooltip("The first integer")]
		public SharedInt integer1;

		[Tooltip("The second integer")]
		public SharedInt integer2;

		public override TaskStatus OnUpdate()
		{
			switch (this.operation)
			{
			case IntComparison.Operation.LessThan:
				return (this.integer1.Value >= this.integer2.Value) ? TaskStatus.Failure : TaskStatus.Success;
			case IntComparison.Operation.LessThanOrEqualTo:
				return (this.integer1.Value > this.integer2.Value) ? TaskStatus.Failure : TaskStatus.Success;
			case IntComparison.Operation.EqualTo:
				return (this.integer1.Value != this.integer2.Value) ? TaskStatus.Failure : TaskStatus.Success;
			case IntComparison.Operation.NotEqualTo:
				return (this.integer1.Value == this.integer2.Value) ? TaskStatus.Failure : TaskStatus.Success;
			case IntComparison.Operation.GreaterThanOrEqualTo:
				return (this.integer1.Value < this.integer2.Value) ? TaskStatus.Failure : TaskStatus.Success;
			case IntComparison.Operation.GreaterThan:
				return (this.integer1.Value <= this.integer2.Value) ? TaskStatus.Failure : TaskStatus.Success;
			default:
				return TaskStatus.Failure;
			}
		}

		public override void OnReset()
		{
			this.operation = IntComparison.Operation.LessThan;
			this.integer1.Value = 0;
			this.integer2.Value = 0;
		}
	}
}
