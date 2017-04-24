using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityVector2
{
	[TaskCategory("Basic/Vector2"), TaskDescription("Performs a math operation on two Vector2s: Add, Subtract, Multiply, Divide, Min, or Max.")]
	public class Operator : BehaviorDesigner.Runtime.Tasks.Action
	{
		public enum Operation
		{
			Add,
			Subtract,
			Scale
		}

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The operation to perform")]
		public Operator.Operation operation;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The first Vector2")]
		public SharedVector2 firstVector2;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The second Vector2")]
		public SharedVector2 secondVector2;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The variable to store the result")]
		public SharedVector2 storeResult;

		public override TaskStatus OnUpdate()
		{
			switch (this.operation)
			{
			case Operator.Operation.Add:
				this.storeResult.Value = this.firstVector2.Value + this.secondVector2.Value;
				break;
			case Operator.Operation.Subtract:
				this.storeResult.Value = this.firstVector2.Value - this.secondVector2.Value;
				break;
			case Operator.Operation.Scale:
				this.storeResult.Value = Vector2.Scale(this.firstVector2.Value, this.secondVector2.Value);
				break;
			}
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.operation = Operator.Operation.Add;
			this.firstVector2 = (this.secondVector2 = (this.storeResult = Vector2.zero));
		}
	}
}
