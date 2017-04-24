using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
	[TaskCategory("Basic/Transform"), TaskDescription("Applies a rotation. Returns Success.")]
	public class RotateAround : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Point to rotate around")]
		public SharedVector3 point;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Axis to rotate around")]
		public SharedVector3 axis;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Amount to rotate")]
		public SharedFloat angle;

		private Transform targetTransform;

		private GameObject prevGameObject;

		public override void OnStart()
		{
			GameObject defaultGameObject = base.GetDefaultGameObject(this.targetGameObject.Value);
			if (defaultGameObject != this.prevGameObject)
			{
				this.targetTransform = defaultGameObject.GetComponent<Transform>();
				this.prevGameObject = defaultGameObject;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.targetTransform == null)
			{
				Debug.LogWarning("Transform is null");
				return TaskStatus.Failure;
			}
			this.targetTransform.RotateAround(this.point.Value, this.axis.Value, this.angle.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.point = Vector3.zero;
			this.axis = Vector3.zero;
			this.angle = 0f;
		}
	}
}
