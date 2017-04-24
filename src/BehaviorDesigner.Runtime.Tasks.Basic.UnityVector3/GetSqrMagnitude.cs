using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityVector3
{
	[TaskCategory("Basic/Vector3"), TaskDescription("Stores the square magnitude of the Vector3.")]
	public class GetSqrMagnitude : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The Vector3 to get the square magnitude of")]
		public SharedVector3 vector3Variable;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The square magnitude of the vector")]
		public SharedFloat storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = this.vector3Variable.Value.sqrMagnitude;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.vector3Variable = Vector3.zero;
			this.storeResult = 0f;
		}
	}
}
