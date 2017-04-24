using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityQuaternion
{
	[TaskCategory("Basic/Quaternion"), TaskDescription("Stores the quaternion identity.")]
	public class Identity : BehaviorDesigner.Runtime.Tasks.Action
	{
		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The identity")]
		public SharedQuaternion storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = Quaternion.identity;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.storeResult = Quaternion.identity;
		}
	}
}
