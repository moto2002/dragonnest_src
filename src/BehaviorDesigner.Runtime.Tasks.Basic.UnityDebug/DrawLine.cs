using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityDebug
{
	[TaskCategory("Basic/Debug"), TaskDescription("Draws a debug line")]
	public class DrawLine : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The start position")]
		public SharedVector3 start;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The end position")]
		public SharedVector3 end;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The color")]
		public SharedColor color = Color.white;

		public override TaskStatus OnUpdate()
		{
			Debug.DrawLine(this.start.Value, this.end.Value, this.color.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.start = Vector3.zero;
			this.end = Vector3.zero;
			this.color = Color.white;
		}
	}
}
