using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityVector3
{
	[TaskCategory("Basic/Vector3"), TaskDescription("Multiply the Vector3 by a float.")]
	public class Multiply : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The Vector3 to multiply of")]
		public SharedVector3 vector3Variable;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The value to multiply the Vector3 of")]
		public SharedFloat multiplyBy;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The multiplication resut")]
		public SharedVector3 storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = this.vector3Variable.Value * this.multiplyBy.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.vector3Variable = (this.storeResult = Vector3.zero);
			this.multiplyBy = 0f;
		}
	}
}
