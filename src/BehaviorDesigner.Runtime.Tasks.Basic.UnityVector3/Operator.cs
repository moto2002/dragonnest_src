using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityVector3
{
	[TaskCategory("Basic/Vector3"), TaskDescription("Performs a math operation on two Vector3s: Add, Subtract, Multiply, Divide, Min, or Max.")]
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

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The first Vector3")]
		public SharedVector3 firstVector3;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The second Vector3")]
		public SharedVector3 secondVector3;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The variable to store the result")]
		public SharedVector3 storeResult;

		public override TaskStatus OnUpdate()
		{
			switch (this.operation)
			{
			case Operator.Operation.Add:
				this.storeResult.Value = this.firstVector3.Value + this.secondVector3.Value;
				break;
			case Operator.Operation.Subtract:
				this.storeResult.Value = this.firstVector3.Value - this.secondVector3.Value;
				break;
			case Operator.Operation.Scale:
				this.storeResult.Value = Vector3.Scale(this.firstVector3.Value, this.secondVector3.Value);
				break;
			}
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.operation = Operator.Operation.Add;
			this.firstVector3 = (this.secondVector3 = (this.storeResult = Vector3.zero));
		}
	}
}
