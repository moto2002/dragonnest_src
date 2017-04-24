using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityVector2
{
	[TaskCategory("Basic/Vector2"), TaskDescription("Normalize the Vector2.")]
	public class Normalize : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The Vector2 to normalize")]
		public SharedVector2 vector2Variable;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The normalized resut")]
		public SharedVector2 storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = this.vector2Variable.Value.normalized;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.vector2Variable = (this.storeResult = Vector2.zero);
		}
	}
}
