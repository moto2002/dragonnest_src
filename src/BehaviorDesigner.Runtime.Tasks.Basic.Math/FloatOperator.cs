using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Math
{
	[TaskCategory("Basic/Math"), TaskDescription("Performs a math operation on two floats: Add, Subtract, Multiply, Divide, Min, or Max.")]
	public class FloatOperator : BehaviorDesigner.Runtime.Tasks.Action
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
		public FloatOperator.Operation operation;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The first float")]
		public SharedFloat float1;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The second float")]
		public SharedFloat float2;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The variable to store the result")]
		public SharedFloat storeResult;

		public override TaskStatus OnUpdate()
		{
			switch (this.operation)
			{
			case FloatOperator.Operation.Add:
				this.storeResult.Value = this.float1.Value + this.float2.Value;
				break;
			case FloatOperator.Operation.Subtract:
				this.storeResult.Value = this.float1.Value - this.float2.Value;
				break;
			case FloatOperator.Operation.Multiply:
				this.storeResult.Value = this.float1.Value * this.float2.Value;
				break;
			case FloatOperator.Operation.Divide:
				this.storeResult.Value = this.float1.Value / this.float2.Value;
				break;
			case FloatOperator.Operation.Min:
				this.storeResult.Value = Mathf.Min(this.float1.Value, this.float2.Value);
				break;
			case FloatOperator.Operation.Max:
				this.storeResult.Value = Mathf.Max(this.float1.Value, this.float2.Value);
				break;
			}
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.operation = FloatOperator.Operation.Add;
			this.float1.Value = 0f;
			this.float2.Value = 0f;
			this.storeResult.Value = 0f;
		}
	}
}
