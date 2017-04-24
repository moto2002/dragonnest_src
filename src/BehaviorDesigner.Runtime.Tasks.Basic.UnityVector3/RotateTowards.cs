using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityVector3
{
	[TaskCategory("Basic/Vector3"), TaskDescription("Rotate the current rotation to the target rotation.")]
	public class RotateTowards : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The current rotation in euler angles")]
		public SharedVector3 currentRotation;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The target rotation in euler angles")]
		public SharedVector3 targetRotation;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The maximum delta of the degrees")]
		public SharedFloat maxDegreesDelta;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The maximum delta of the magnitude")]
		public SharedFloat maxMagnitudeDelta;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The rotation resut")]
		public SharedVector3 storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = Vector3.RotateTowards(this.currentRotation.Value, this.targetRotation.Value, this.maxDegreesDelta.Value * 0.0174532924f * Time.deltaTime, this.maxMagnitudeDelta.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.currentRotation = (this.targetRotation = (this.storeResult = Vector3.zero));
			this.maxDegreesDelta = (this.maxMagnitudeDelta = 0f);
		}
	}
}
