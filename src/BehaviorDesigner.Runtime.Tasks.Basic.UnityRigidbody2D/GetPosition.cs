using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody2D
{
	[TaskCategory("Basic/Rigidbody2D"), TaskDescription("Stores the position of the Rigidbody2D. Returns Success.")]
	public class GetPosition : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Can the target GameObject be empty?")]
		public SharedBool allowEmptyTarget;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The velocity of the Rigidbody2D")]
		public SharedVector2 storeValue;

		private Rigidbody2D rigidbody2D;

		private GameObject prevGameObject;

		public override void OnStart()
		{
			if (!this.allowEmptyTarget.Value)
			{
				GameObject defaultGameObject = base.GetDefaultGameObject(this.targetGameObject.Value);
				if (defaultGameObject != this.prevGameObject)
				{
					this.rigidbody2D = defaultGameObject.GetComponent<Rigidbody2D>();
					this.prevGameObject = defaultGameObject;
				}
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.rigidbody2D == null)
			{
				Debug.LogWarning("Rigidbody2D is null");
				return TaskStatus.Failure;
			}
			this.storeValue.Value = this.rigidbody2D.position;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.allowEmptyTarget = false;
			this.storeValue = Vector2.zero;
		}
	}
}
