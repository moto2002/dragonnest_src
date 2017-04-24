using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnitySphereCollider
{
	[TaskCategory("Basic/SphereCollider"), TaskDescription("Sets the radius of the SphereCollider. Returns Success.")]
	public class SetRadius : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The radius of the SphereCollider")]
		public SharedFloat radius;

		private SphereCollider sphereCollider;

		private GameObject prevGameObject;

		public override void OnStart()
		{
			GameObject defaultGameObject = base.GetDefaultGameObject(this.targetGameObject.Value);
			if (defaultGameObject != this.prevGameObject)
			{
				this.sphereCollider = defaultGameObject.GetComponent<SphereCollider>();
				this.prevGameObject = defaultGameObject;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.sphereCollider == null)
			{
				Debug.LogWarning("SphereCollider is null");
				return TaskStatus.Failure;
			}
			this.sphereCollider.radius = this.radius.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.radius = 0f;
		}
	}
}
