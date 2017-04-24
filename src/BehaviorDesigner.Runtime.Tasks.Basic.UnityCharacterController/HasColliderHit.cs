using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityCharacterController
{
	[TaskCategory("Basic/CharacterController"), TaskDescription("Returns Success if the collider hit another object, otherwise Failure.")]
	public class HasColliderHit : Conditional
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The tag of the GameObject to check for a collision against")]
		public SharedString tag = string.Empty;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The object that started the collision")]
		public SharedGameObject collidedGameObject;

		private bool enteredCollision;

		public override TaskStatus OnUpdate()
		{
			return (!this.enteredCollision) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnEnd()
		{
			this.enteredCollision = false;
		}

		public override void OnControllerColliderHit(ControllerColliderHit hit)
		{
			if (string.IsNullOrEmpty(this.tag.Value) || this.tag.Value.Equals(hit.gameObject.tag))
			{
				this.collidedGameObject.Value = hit.gameObject;
				this.enteredCollision = true;
			}
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.tag = string.Empty;
			this.collidedGameObject = null;
		}
	}
}
