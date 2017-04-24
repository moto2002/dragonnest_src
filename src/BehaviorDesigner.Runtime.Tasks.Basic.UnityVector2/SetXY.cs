using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityVector2
{
	[TaskCategory("Basic/Vector2"), TaskDescription("Sets the X and Y values of the Vector2.")]
	public class SetXY : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The Vector2 to set the values of")]
		public SharedVector2 vector2Variable;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The X value. Set to None to have the value ignored")]
		public SharedFloat xValue;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The Y value. Set to None to have the value ignored")]
		public SharedFloat yValue;

		public override TaskStatus OnUpdate()
		{
			Vector2 value = this.vector2Variable.Value;
			if (!this.xValue.IsNone)
			{
				value.x = this.xValue.Value;
			}
			if (!this.yValue.IsNone)
			{
				value.y = this.yValue.Value;
			}
			this.vector2Variable.Value = value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.vector2Variable = Vector2.zero;
			this.xValue = (this.yValue = 0f);
		}
	}
}
