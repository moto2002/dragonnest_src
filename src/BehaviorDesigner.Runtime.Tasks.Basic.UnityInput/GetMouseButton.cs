using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityInput
{
	[TaskCategory("Basic/Input"), TaskDescription("Stores the state of the specified mouse button.")]
	public class GetMouseButton : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The index of the button")]
		public SharedInt buttonIndex;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The stored result")]
		public SharedBool storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = Input.GetMouseButton(this.buttonIndex.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.buttonIndex = 0;
			this.storeResult = false;
		}
	}
}
