using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityQuaternion
{
	[TaskCategory("Basic/Quaternion"), TaskDescription("Stores the rotation which rotates the specified degrees around the specified axis.")]
	public class AngleAxis : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The number of degrees")]
		public SharedFloat degrees;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The axis direction")]
		public SharedVector3 axis;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The stored result")]
		public SharedQuaternion storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = Quaternion.AngleAxis(this.degrees.Value, this.axis.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.degrees = 0f;
			this.axis = Vector3.zero;
			this.storeResult = Quaternion.identity;
		}
	}
}
