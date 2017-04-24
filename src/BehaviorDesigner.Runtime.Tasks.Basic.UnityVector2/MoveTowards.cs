using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityVector2
{
	[TaskCategory("Basic/Vector2"), TaskDescription("Move from the current position to the target position.")]
	public class MoveTowards : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The current position")]
		public SharedVector2 currentPosition;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The target position")]
		public SharedVector2 targetPosition;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The movement speed")]
		public SharedFloat speed;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The move resut")]
		public SharedVector2 storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = Vector2.MoveTowards(this.currentPosition.Value, this.targetPosition.Value, this.speed.Value * Time.deltaTime);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.currentPosition = (this.targetPosition = (this.storeResult = Vector2.zero));
			this.speed = 0f;
		}
	}
}
