using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityPhysics2D
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=118"), TaskCategory("Basic/Physics2D"), TaskDescription("Casts a ray against all colliders in the scene. Returns success if a collider was hit.")]
	public class Raycast : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("Starts the ray at the GameObject's position. If null the originPosition will be used.")]
		public SharedGameObject originGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Starts the ray at the position. Only used if originGameObject is null.")]
		public SharedVector2 originPosition;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The direction of the ray")]
		public SharedVector2 direction;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The length of the ray. Set to -1 for infinity.")]
		public SharedFloat distance = -1f;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Selectively ignore colliders.")]
		public LayerMask layerMask = -1;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Cast the ray in world or local space. The direction is in world space if no GameObject is specified.")]
		public Space space = Space.Self;

		[SharedRequired, BehaviorDesigner.Runtime.Tasks.Tooltip("Stores the hit object of the raycast.")]
		public SharedGameObject storeHitObject;

		[SharedRequired, BehaviorDesigner.Runtime.Tasks.Tooltip("Stores the hit point of the raycast.")]
		public SharedVector2 storeHitPoint;

		[SharedRequired, BehaviorDesigner.Runtime.Tasks.Tooltip("Stores the hit normal of the raycast.")]
		public SharedVector2 storeHitNormal;

		[SharedRequired, BehaviorDesigner.Runtime.Tasks.Tooltip("Stores the hit distance of the raycast.")]
		public SharedFloat storeHitDistance;

		public override TaskStatus OnUpdate()
		{
			Vector2 vector = this.direction.Value;
			Vector2 origin;
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
			RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, vector, (this.distance.Value != -1f) ? this.distance.Value : float.PositiveInfinity, this.layerMask);
			if (raycastHit2D.collider != null)
			{
				this.storeHitObject.Value = raycastHit2D.collider.gameObject;
				this.storeHitPoint.Value = raycastHit2D.point;
				this.storeHitNormal.Value = raycastHit2D.normal;
				this.storeHitDistance.Value = raycastHit2D.distance;
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}

		public override void OnReset()
		{
			this.originGameObject = null;
			this.originPosition = Vector2.zero;
			this.direction = Vector2.zero;
			this.distance = -1f;
			this.layerMask = -1;
			this.space = Space.Self;
		}
	}
}
