using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityVector3
{
	[TaskCategory("Basic/Vector3"), TaskDescription("Normalize the Vector3.")]
	public class Normalize : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The Vector3 to normalize")]
		public SharedVector3 vector3Variable;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The normalized resut")]
		public SharedVector3 storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = Vector3.Normalize(this.vector3Variable.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.vector3Variable = (this.storeResult = Vector3.zero);
		}
	}
}
