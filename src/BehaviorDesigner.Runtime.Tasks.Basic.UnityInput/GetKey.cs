using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityInput
{
	[TaskCategory("Basic/Input"), TaskDescription("Stores the pressed state of the specified key.")]
	public class GetKey : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The key to test.")]
		public KeyCode key;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The stored result")]
		public SharedBool storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = Input.GetKey(this.key);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.key = KeyCode.None;
			this.storeResult = false;
		}
	}
}
