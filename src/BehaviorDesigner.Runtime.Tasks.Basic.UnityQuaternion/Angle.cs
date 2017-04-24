using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityQuaternion
{
	[TaskCategory("Basic/Quaternion"), TaskDescription("Stores the angle in degrees between two rotations.")]
	public class Angle : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The first rotation")]
		public SharedQuaternion firstRotation;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The second rotation")]
		public SharedQuaternion secondRotation;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The stored result")]
		public SharedFloat storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = Quaternion.Angle(this.firstRotation.Value, this.secondRotation.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.firstRotation = (this.secondRotation = Quaternion.identity);
			this.storeResult = 0f;
		}
	}
}
