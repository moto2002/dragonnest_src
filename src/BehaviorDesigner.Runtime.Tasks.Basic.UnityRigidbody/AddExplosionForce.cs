using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRigidbody
{
	[TaskCategory("Basic/Rigidbody"), TaskDescription("Applies a force to the rigidbody that simulates explosion effects. Returns Success.")]
	public class AddExplosionForce : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The force of the explosion")]
		public SharedFloat explosionForce;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The position of the explosion")]
		public SharedVector3 explosionPosition;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The radius of the explosion")]
		public SharedFloat explosionRadius;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Applies the force as if it was applied from beneath the object")]
		public float upwardsModifier;

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
			this.rigidbody.AddExplosionForce(this.explosionForce.Value, this.explosionPosition.Value, this.explosionRadius.Value, this.upwardsModifier, this.forceMode);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.explosionForce = 0f;
			this.explosionPosition = Vector3.zero;
			this.explosionRadius = 0f;
			this.upwardsModifier = 0f;
			this.forceMode = ForceMode.Force;
		}
	}
}
