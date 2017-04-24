using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityQuaternion
{
	[TaskCategory("Basic/Quaternion"), TaskDescription("Stores the quaternion after a rotation.")]
	public class RotateTowards : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The from rotation")]
		public SharedQuaternion fromQuaternion;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The to rotation")]
		public SharedQuaternion toQuaternion;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The maximum degrees delta")]
		public SharedFloat maxDeltaDegrees;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The stored result")]
		public SharedQuaternion storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = Quaternion.RotateTowards(this.fromQuaternion.Value, this.toQuaternion.Value, this.maxDeltaDegrees.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.fromQuaternion = (this.toQuaternion = (this.storeResult = Quaternion.identity));
			this.maxDeltaDegrees = 0f;
		}
	}
}
