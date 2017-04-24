using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityVector2
{
	[TaskCategory("Basic/Vector2"), TaskDescription("Clamps the magnitude of the Vector2.")]
	public class ClampMagnitude : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The Vector2 to clamp the magnitude of")]
		public SharedVector2 vector2Variable;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The max length of the magnitude")]
		public SharedFloat maxLength;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The clamp magnitude resut")]
		public SharedVector2 storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = Vector2.ClampMagnitude(this.vector2Variable.Value, this.maxLength.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.vector2Variable = (this.storeResult = Vector2.zero);
			this.maxLength = 0f;
		}
	}
}
