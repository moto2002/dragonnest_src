using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityCapsuleCollider
{
	[TaskCategory("Basic/CapsuleCollider"), TaskDescription("Sets the height of the CapsuleCollider. Returns Success.")]
	public class SetHeight : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The height of the CapsuleCollider")]
		public SharedFloat direction;

		private CapsuleCollider capsuleCollider;

		private GameObject prevGameObject;

		public override void OnStart()
		{
			GameObject defaultGameObject = base.GetDefaultGameObject(this.targetGameObject.Value);
			if (defaultGameObject != this.prevGameObject)
			{
				this.capsuleCollider = defaultGameObject.GetComponent<CapsuleCollider>();
				this.prevGameObject = defaultGameObject;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.capsuleCollider == null)
			{
				Debug.LogWarning("CapsuleCollider is null");
				return TaskStatus.Failure;
			}
			this.capsuleCollider.height = this.direction.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.direction = 0f;
		}
	}
}
