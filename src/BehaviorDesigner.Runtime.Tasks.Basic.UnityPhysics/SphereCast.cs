using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityPhysics
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=117"), TaskCategory("Basic/Physics"), TaskDescription("Casts a sphere against all colliders in the scene. Returns success if a collider was hit.")]
	public class SphereCast : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("Starts the spherecast at the GameObject's position. If null the originPosition will be used")]
		public SharedGameObject originGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Starts the sherecast at the position. Only used if originGameObject is null")]
		public SharedVector3 originPosition;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The radius of the spherecast")]
		public SharedFloat radius;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The direction of the spherecast")]
		public SharedVector3 direction;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The length of the spherecast. Set to -1 for infinity")]
		public SharedFloat distance = -1f;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Selectively ignore colliders")]
		public LayerMask layerMask = -1;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Use world or local space. The direction is in world space if no GameObject is specified")]
		public Space space = Space.Self;

		[SharedRequired, BehaviorDesigner.Runtime.Tasks.Tooltip("Stores the hit object of the spherecast")]
		public SharedGameObject storeHitObject;

		[SharedRequired, BehaviorDesigner.Runtime.Tasks.Tooltip("Stores the hit point of the spherecast")]
		public SharedVector3 storeHitPoint;

		[SharedRequired, BehaviorDesigner.Runtime.Tasks.Tooltip("Stores the hit normal of the spherecast")]
		public SharedVector3 storeHitNormal;

		[SharedRequired, BehaviorDesigner.Runtime.Tasks.Tooltip("Stores the hit distance of the spherecast")]
		public SharedFloat storeHitDistance;

		public override TaskStatus OnUpdate()
		{
			Vector3 vector = this.direction.Value;
			Vector3 origin;
			if (this.originGameObject.Value != null)
			{
				origin = this.originGameObject.Value.transform.position;
				if (this.space == Space.Self)
				{
					vector = this.originGameObject.Value.transform.TransformDirection(this.direction.Value);
				}
			}
			else
			{
				origin = this.originPosition.Value;
			}
			RaycastHit raycastHit;
			if (Physics.SphereCast(origin, this.radius.Value, vector, out raycastHit, (this.distance.Value != -1f) ? this.distance.Value : float.PositiveInfinity, this.layerMask))
			{
				this.storeHitObject.Value = raycastHit.collider.gameObject;
				this.storeHitPoint.Value = raycastHit.point;
				this.storeHitNormal.Value = raycastHit.normal;
				this.storeHitDistance.Value = raycastHit.distance;
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}

		public override void OnReset()
		{
			this.originGameObject = null;
			this.originPosition = Vector3.zero;
			this.radius = 0f;
			this.direction = Vector3.zero;
			this.distance = -1f;
			this.layerMask = -1;
			this.space = Space.Self;
		}
	}
}
