using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Math
{
	[TaskCategory("Basic/Math"), TaskDescription("Performs a math operation on two integers: Add, Subtract, Multiply, Divide, Min, or Max.")]
	public class IntOperator : BehaviorDesigner.Runtime.Tasks.Action
	{
		public enum Operation
		{
			Add,
			Subtract,
			Multiply,
			Divide,
			Min,
			Max
		}

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The operation to perform")]
		public IntOperator.Operation operation;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The first integer")]
		public SharedInt integer1;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The second integer")]
		public SharedInt integer2;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The variable to store the result")]
		public SharedInt storeResult;

		public override TaskStatus OnUpdate()
		{
			switch (this.operation)
			{
			case IntOperator.Operation.Add:
				this.storeResult.Value = this.integer1.Value + this.integer2.Value;
				break;
			case IntOperator.Operation.Subtract:
				this.storeResult.Value = this.integer1.Value - this.integer2.Value;
				break;
			case IntOperator.Operation.Multiply:
				this.storeResult.Value = this.integer1.Value * this.integer2.Value;
				break;
			case IntOperator.Operation.Divide:
				this.storeResult.Value = this.integer1.Value / this.integer2.Value;
				break;
			case IntOperator.Operation.Min:
				this.storeResult.Value = Mathf.Min(this.integer1.Value, this.integer2.Value);
				break;
			case IntOperator.Operation.Max:
				this.storeResult.Value = Mathf.Max(this.integer1.Value, this.integer2.Value);
				break;
			}
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.operation = IntOperator.Operation.Add;
			this.integer1.Value = 0;
			this.integer2.Value = 0;
			this.storeResult.Value = 0;
		}
	}
}
