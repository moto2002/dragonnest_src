using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityBoxCollider
{
	[TaskCategory("Basic/BoxCollider"), TaskDescription("Sets the size of the BoxCollider. Returns Success.")]
	public class SetSize : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The size of the BoxCollider")]
		public SharedVector3 size;

		private BoxCollider boxCollider;

		private GameObject prevGameObject;

		public override void OnStart()
		{
			GameObject defaultGameObject = base.GetDefaultGameObject(this.targetGameObject.Value);
			if (defaultGameObject != this.prevGameObject)
			{
				this.boxCollider = defaultGameObject.GetComponent<BoxCollider>();
				this.prevGameObject = defaultGameObject;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.boxCollider == null)
			{
				Debug.LogWarning("BoxCollider is null");
				return TaskStatus.Failure;
			}
			this.boxCollider.size = this.size.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.size = Vector3.zero;
		}
	}
}
