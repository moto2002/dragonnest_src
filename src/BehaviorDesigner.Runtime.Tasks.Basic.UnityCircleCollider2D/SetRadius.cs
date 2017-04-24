using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityCircleCollider2D
{
	[TaskCategory("Basic/CircleCollider2D"), TaskDescription("Sets the radius of the CircleCollider2D. Returns Success.")]
	public class SetRadius : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The radius of the CircleCollider2D")]
		public SharedFloat radius;

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
			this.circleCollider2D.radius = this.radius.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.radius = 0f;
		}
	}
}
