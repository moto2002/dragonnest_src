using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityVector2
{
	[TaskCategory("Basic/Vector2"), TaskDescription("Multiply the Vector2 by a float.")]
	public class Multiply : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The Vector2 to multiply of")]
		public SharedVector2 vector2Variable;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The value to multiply the Vector2 of")]
		public SharedFloat multiplyBy;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The multiplication resut")]
		public SharedVector2 storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = this.vector2Variable.Value * this.multiplyBy.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.vector2Variable = (this.storeResult = Vector2.zero);
			this.multiplyBy = 0f;
		}
	}
}
