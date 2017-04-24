using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityInput
{
	[TaskCategory("Basic/Input"), TaskDescription("Returns success when the specified mouse button is pressed.")]
	public class IsMouseUp : Conditional
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The button index")]
		public SharedInt buttonIndex;

		public override TaskStatus OnUpdate()
		{
			return (!Input.GetMouseButtonUp(this.buttonIndex.Value)) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.buttonIndex = 0;
		}
	}
}
