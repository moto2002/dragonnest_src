using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityInput
{
	[TaskCategory("Basic/Input"), TaskDescription("Returns success when the specified mouse button is pressed.")]
	public class IsMouseDown : Conditional
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The button index")]
		public SharedInt buttonIndex;

		public override TaskStatus OnUpdate()
		{
			return (!Input.GetMouseButtonDown(this.buttonIndex.Value)) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.buttonIndex = 0;
		}
	}
}
