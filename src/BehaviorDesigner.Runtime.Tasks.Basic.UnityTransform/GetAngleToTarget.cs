using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
	[TaskCategory("Basic/Transform"), TaskDescription("Gets the Angle between a GameObject's forward direction and a target. Returns Success.")]
	public class GetAngleToTarget : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The target object to measure the angle to. If null the targetPosition will be used.")]
		public SharedGameObject targetObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The world position to measure an angle to. If the targetObject is also not null, this value is used as an offset from that object's position.")]
		public SharedVector3 targetPosition;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Ignore height differences when calculating the angle?")]
		public SharedBool ignoreHeight = true;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The angle to the target")]
		public SharedFloat storeValue;

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
			Vector3 a;
			if (this.targetObject.Value != null)
			{
				a = this.targetObject.Value.transform.InverseTransformPoint(this.targetPosition.Value);
			}
			else
			{
				a = this.targetPosition.Value;
			}
			if (this.ignoreHeight.Value)
			{
				a.y = this.targetTransform.position.y;
			}
			Vector3 from = a - this.targetTransform.position;
			this.storeValue.Value = Vector3.Angle(from, this.targetTransform.forward);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.targetObject = null;
			this.targetPosition = Vector3.zero;
			this.ignoreHeight = true;
			this.storeValue = 0f;
		}
	}
}
