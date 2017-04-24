using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityCapsuleCollider
{
	[TaskCategory("Basic/CapsuleCollider"), TaskDescription("Sets the center of the CapsuleCollider. Returns Success.")]
	public class SetCenter : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The center of the CapsuleCollider")]
		public SharedVector3 center;

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
			this.capsuleCollider.center = this.center.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.center = Vector3.zero;
		}
	}
}
