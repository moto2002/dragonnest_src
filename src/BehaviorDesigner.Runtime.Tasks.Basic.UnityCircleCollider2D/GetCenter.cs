using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityCircleCollider2D
{
	[TaskCategory("Basic/CircleCollider2D"), TaskDescription("Stores the center of the CircleCollider2D. Returns Success.")]
	public class GetCenter : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The center of the CircleCollider2D")]
		public SharedVector2 storeValue;

		private CircleCollider2D circleCollider2D;

		private GameObject prevGameObject;

		public override void OnStart()
		{
			GameObject defaultGameObject = base.GetDefaultGameObject(this.targetGameObject.Value);
			if (defaultGameObject != this.prevGameObject)
			{
				this.circleCollider2D = defaultGameObject.GetComponent<CircleCollider2D>();
				this.prevGameObject = defaultGameObject;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.circleCollider2D == null)
			{
				Debug.LogWarning("CircleCollider2D is null");
				return TaskStatus.Failure;
			}
			this.storeValue.Value = this.circleCollider2D.center;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.storeValue = Vector2.zero;
		}
	}
}
