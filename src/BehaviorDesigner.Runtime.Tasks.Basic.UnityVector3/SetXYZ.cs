using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityVector3
{
	[TaskCategory("Basic/Vector3"), TaskDescription("Sets the X, Y, and Z values of the Vector3.")]
	public class SetXYZ : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The Vector3 to set the values of")]
		public SharedVector3 vector3Variable;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The X value. Set to None to have the value ignored")]
		public SharedFloat xValue;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The Y value. Set to None to have the value ignored")]
		public SharedFloat yValue;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The Z value. Set to None to have the value ignored")]
		public SharedFloat zValue;

		public override TaskStatus OnUpdate()
		{
			Vector3 value = this.vector3Variable.Value;
			if (!this.xValue.IsNone)
			{
				value.x = this.xValue.Value;
			}
			if (!this.yValue.IsNone)
			{
				value.y = this.yValue.Value;
			}
			if (!this.zValue.IsNone)
			{
				value.z = this.zValue.Value;
			}
			this.vector3Variable.Value = value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.vector3Variable = Vector3.zero;
			this.xValue = (this.yValue = (this.zValue = 0f));
		}
	}
}
