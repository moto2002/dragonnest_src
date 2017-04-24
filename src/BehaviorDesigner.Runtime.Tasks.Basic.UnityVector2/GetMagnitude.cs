using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityVector2
{
	[TaskCategory("Basic/Vector2"), TaskDescription("Stores the magnitude of the Vector2.")]
	public class GetMagnitude : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The Vector2 to get the magnitude of")]
		public SharedVector2 vector2Variable;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The magnitude of the vector")]
		public SharedFloat storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = this.vector2Variable.Value.magnitude;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.vector2Variable = Vector2.zero;
			this.storeResult = 0f;
		}
	}
}
