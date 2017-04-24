using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityInput
{
	[TaskCategory("Basic/Input"), TaskDescription("Stores the state of the specified button.")]
	public class GetButton : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The name of the button")]
		public SharedString buttonName;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The stored result")]
		public SharedBool storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = Input.GetButton(this.buttonName.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.buttonName = "Fire1";
			this.storeResult = false;
		}
	}
}
