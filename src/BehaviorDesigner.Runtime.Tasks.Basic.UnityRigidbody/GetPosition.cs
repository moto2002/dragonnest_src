using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
	[TaskCategory("Basic/Rigidbody"), TaskDescription("Stores the position of the Rigidbody. Returns Success.")]
	public class GetPosition : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Can the target GameObject be empty?")]
		public SharedBool allowEmptyTarget;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The position of the Rigidbody")]
		public SharedVector3 storeValue;

		private Rigidbody rigidbody;

		private GameObject prevGameObject;

		public override void OnStart()
		{
			if (!this.allowEmptyTarget.Value)
			{
				GameObject defaultGameObject = base.GetDefaultGameObject(this.targetGameObject.Value);
				if (defaultGameObject != this.prevGameObject)
				{
					this.rigidbody = defaultGameObject.GetComponent<Rigidbody>();
					this.prevGameObject = defaultGameObject;
				}
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.rigidbody == null)
			{
				Debug.LogWarning("Rigidbody is null");
				return TaskStatus.Failure;
			}
			this.storeValue.Value = this.rigidbody.position;
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
