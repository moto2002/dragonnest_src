using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityInput
{
	[TaskCategory("Basic/Input"), TaskDescription("Stores the mouse position.")]
	public class GetMousePosition : BehaviorDesigner.Runtime.Tasks.Action
	{
		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The stored result")]
		public SharedVector2 storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = Input.mousePosition;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.storeResult = Vector2.zero;
		}
	}
}
