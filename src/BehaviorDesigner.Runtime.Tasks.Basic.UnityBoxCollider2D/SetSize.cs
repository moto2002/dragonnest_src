using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityBoxCollider2D
{
	[TaskCategory("Basic/BoxCollider2D"), TaskDescription("Sets the size of the BoxCollider2D. Returns Success.")]
	public class SetSize : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The size of the BoxCollider2D")]
		public SharedVector2 size;

		private BoxCollider2D boxCollider2D;

		private GameObject prevGameObject;

		public override void OnStart()
		{
			GameObject defaultGameObject = base.GetDefaultGameObject(this.targetGameObject.Value);
			if (defaultGameObject != this.prevGameObject)
			{
				this.boxCollider2D = defaultGameObject.GetComponent<BoxCollider2D>();
				this.prevGameObject = defaultGameObject;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.boxCollider2D == null)
			{
				Debug.LogWarning("BoxCollider2D is null");
				return TaskStatus.Failure;
			}
			this.boxCollider2D.size = this.size.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.size = Vector2.zero;
		}
	}
}
