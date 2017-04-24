using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody2D
{
	[TaskCategory("Basic/Rigidbody2D"), TaskDescription("Applies a torque to the Rigidbody2D. Returns Success.")]
	public class AddTorque : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The amount of torque to apply")]
		public SharedFloat torque;

		private Rigidbody2D rigidbody2D;

		private GameObject prevGameObject;

		public override void OnStart()
		{
			GameObject defaultGameObject = base.GetDefaultGameObject(this.targetGameObject.Value);
			if (defaultGameObject != this.prevGameObject)
			{
				this.rigidbody2D = defaultGameObject.GetComponent<Rigidbody2D>();
				this.prevGameObject = defaultGameObject;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.rigidbody2D == null)
			{
				Debug.LogWarning("Rigidbody2D is null");
				return TaskStatus.Failure;
			}
			this.rigidbody2D.AddTorque(this.torque.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.torque = 0f;
		}
	}
}
