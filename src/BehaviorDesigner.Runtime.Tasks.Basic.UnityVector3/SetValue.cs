using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityVector3
{
	[TaskCategory("Basic/Vector3"), TaskDescription("Sets the value of the Vector3.")]
	public class SetValue : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The Vector3 to get the values of")]
		public SharedVector3 vector3Value;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The Vector3 to set the values of")]
		public SharedVector3 vector3Variable;

		public override TaskStatus OnUpdate()
		{
			this.vector3Variable.Value = this.vector3Value.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.vector3Value = (this.vector3Variable = Vector3.zero);
		}
	}
}
