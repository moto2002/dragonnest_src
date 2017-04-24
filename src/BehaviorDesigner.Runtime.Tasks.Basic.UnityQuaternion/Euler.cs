using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityQuaternion
{
	[TaskCategory("Basic/Quaternion"), TaskDescription("Stores the quaternion of a euler vector.")]
	public class Euler : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The euler vector")]
		public SharedVector3 eulerVector;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The stored quaternion")]
		public SharedQuaternion storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = Quaternion.Euler(this.eulerVector.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.eulerVector = Vector3.zero;
			this.storeResult = Quaternion.identity;
		}
	}
}
