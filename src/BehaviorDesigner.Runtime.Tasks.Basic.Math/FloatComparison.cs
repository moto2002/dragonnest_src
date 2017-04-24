using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Math
{
	[TaskCategory("Basic/Math"), TaskDescription("Performs comparison between two floats: less than, less than or equal to, equal to, not equal to, greater than or equal to, or greater than.")]
	public class FloatComparison : Conditional
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
		public FloatComparison.Operation operation;

		[Tooltip("The first float")]
		public SharedFloat float1;

		[Tooltip("The second float")]
		public SharedFloat float2;

		public override TaskStatus OnUpdate()
		{
			switch (this.operation)
			{
			case FloatComparison.Operation.LessThan:
				return (this.float1.Value >= this.float2.Value) ? TaskStatus.Failure : TaskStatus.Success;
			case FloatComparison.Operation.LessThanOrEqualTo:
				return (this.float1.Value > this.float2.Value) ? TaskStatus.Failure : TaskStatus.Success;
			case FloatComparison.Operation.EqualTo:
				return (this.float1.Value != this.float2.Value) ? TaskStatus.Failure : TaskStatus.Success;
			case FloatComparison.Operation.NotEqualTo:
				return (this.float1.Value == this.float2.Value) ? TaskStatus.Failure : TaskStatus.Success;
			case FloatComparison.Operation.GreaterThanOrEqualTo:
				return (this.float1.Value < this.float2.Value) ? TaskStatus.Failure : TaskStatus.Success;
			case FloatComparison.Operation.GreaterThan:
				return (this.float1.Value <= this.float2.Value) ? TaskStatus.Failure : TaskStatus.Success;
			default:
				return TaskStatus.Failure;
			}
		}

		public override void OnReset()
		{
			this.operation = FloatComparison.Operation.LessThan;
			this.float1.Value = 0f;
			this.float2.Value = 0f;
		}
	}
}
