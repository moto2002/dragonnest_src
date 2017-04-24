using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
	[RequiredComponent(typeof(Rigidbody)), TaskCategory("Basic/Rigidbody"), TaskDescription("Applies a force to the rigidbody. Returns Success.")]
	public class AddForce : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The amount of force to apply")]
		public SharedVector3 force;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The type of force")]
		public ForceMode forceMode;

		private Rigidbody rigidbody;

		private GameObject prevGameObject;

		public override void OnStart()
		{
			GameObject defaultGameObject = base.GetDefaultGameObject(this.targetGameObject.Value);
			if (defaultGameObject != this.prevGameObject)
			{
				this.rigidbody = defaultGameObject.GetComponent<Rigidbody>();
				this.prevGameObject = defaultGameObject;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.rigidbody == null)
			{
				Debug.LogWarning("Rigidbody is null");
				return TaskStatus.Failure;
			}
			this.rigidbody.AddForce(this.force.Value, this.forceMode);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			if (this.force != null)
			{
				this.force.Value = Vector3.zero;
			}
			this.forceMode = ForceMode.Force;
		}
	}
}
