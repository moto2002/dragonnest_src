using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Math
{
	[TaskCategory("Basic/Math"), TaskDescription("Performs a math operation on two bools: AND, OR, NAND, or XOR.")]
	public class BoolOperator : BehaviorDesigner.Runtime.Tasks.Action
	{
		public enum Operation
		{
			AND,
			OR,
			NAND,
			XOR
		}

		[Tooltip("The operation to perform")]
		public BoolOperator.Operation operation;

		[Tooltip("The first bool")]
		public SharedBool bool1;

		[Tooltip("The second bool")]
		public SharedBool bool2;

		[Tooltip("The variable to store the result")]
		public SharedBool storeResult;

		public override TaskStatus OnUpdate()
		{
			switch (this.operation)
			{
			case BoolOperator.Operation.AND:
				this.storeResult.Value = (this.bool1.Value && this.bool2.Value);
				break;
			case BoolOperator.Operation.OR:
				this.storeResult.Value = (this.bool1.Value || this.bool2.Value);
				break;
			case BoolOperator.Operation.NAND:
				this.storeResult.Value = (!this.bool1.Value || !this.bool2.Value);
				break;
			case BoolOperator.Operation.XOR:
				this.storeResult.Value = (this.bool1.Value ^ this.bool2.Value);
				break;
			}
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.operation = BoolOperator.Operation.AND;
			this.bool1.Value = false;
			this.bool2.Value = false;
			this.storeResult.Value = false;
		}
	}
}
