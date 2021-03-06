using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityVector3
{
	[TaskCategory("Basic/Vector3"), TaskDescription("Returns the angle between two Vector3s.")]
	public class Angle : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The first Vector3")]
		public SharedVector3 firstVector3;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The second Vector3")]
		public SharedVector3 secondVector3;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The angle")]
		public SharedFloat storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = Vector3.Angle(this.firstVector3.Value, this.secondVector3.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.firstVector3 = (this.secondVector3 = Vector3.zero);
			this.storeResult = 0f;
		}
	}
}
