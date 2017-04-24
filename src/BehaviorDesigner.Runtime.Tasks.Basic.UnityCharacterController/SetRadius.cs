using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityCharacterController
{
	[TaskCategory("Basic/CharacterController"), TaskDescription("Sets the radius of the CharacterController. Returns Success.")]
	public class SetRadius : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The radius of the CharacterController")]
		public SharedFloat radius;

		private CharacterController characterController;

		private GameObject prevGameObject;

		public override void OnStart()
		{
			GameObject defaultGameObject = base.GetDefaultGameObject(this.targetGameObject.Value);
			if (defaultGameObject != this.prevGameObject)
			{
				this.characterController = defaultGameObject.GetComponent<CharacterController>();
				this.prevGameObject = defaultGameObject;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.characterController == null)
			{
				Debug.LogWarning("CharacterController is null");
				return TaskStatus.Failure;
			}
			this.characterController.radius = this.radius.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.radius = 0f;
		}
	}
}
