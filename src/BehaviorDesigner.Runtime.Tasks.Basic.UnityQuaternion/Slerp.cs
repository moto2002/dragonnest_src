using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityQuaternion
{
	[TaskCategory("Basic/Quaternion"), TaskDescription("Spherically lerp between two quaternions.")]
	public class Slerp : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The from rotation")]
		public SharedQuaternion fromQuaternion;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The to rotation")]
		public SharedQuaternion toQuaternion;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The amount to lerp")]
		public SharedFloat amount;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The stored result")]
		public SharedQuaternion storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = Quaternion.Slerp(this.fromQuaternion.Value, this.toQuaternion.Value, this.amount.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.fromQuaternion = (this.toQuaternion = (this.storeResult = Quaternion.identity));
			this.amount = 0f;
		}
	}
}
