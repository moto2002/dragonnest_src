using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
	[TaskCategory("Basic/Transform"), TaskDescription("Stores the position of the Transform. Returns Success.")]
	public class GetPosition : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Can the target GameObject be empty?")]
		public SharedBool allowEmptyTarget;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The position of the Transform")]
		public SharedVector3 storeValue;

		private Transform targetTransform;

		private GameObject prevGameObject;

		public override void OnStart()
		{
			if (!this.allowEmptyTarget.Value)
			{
				GameObject defaultGameObject = base.GetDefaultGameObject(this.targetGameObject.Value);
				if (defaultGameObject != this.prevGameObject)
				{
					this.targetTransform = defaultGameObject.GetComponent<Transform>();
					this.prevGameObject = defaultGameObject;
				}
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.targetTransform == null)
			{
				Debug.LogWarning("Transform is null");
				return TaskStatus.Failure;
			}
			this.storeValue.Value = this.targetTransform.position;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.allowEmptyTarget = false;
			this.storeValue = Vector3.zero;
		}
	}
}
