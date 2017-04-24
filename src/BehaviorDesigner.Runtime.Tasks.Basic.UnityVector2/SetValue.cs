using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityVector2
{
	[TaskCategory("Basic/Vector2"), TaskDescription("Sets the value of the Vector2.")]
	public class SetValue : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The Vector2 to get the values of")]
		public SharedVector2 vector2Value;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The Vector2 to set the values of")]
		public SharedVector2 vector2Variable;

		public override TaskStatus OnUpdate()
		{
			this.vector2Variable.Value = this.vector2Value.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.vector2Value = (this.vector2Variable = Vector2.zero);
		}
	}
}
