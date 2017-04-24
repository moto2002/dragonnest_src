using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityPhysics2D
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=118"), TaskCategory("Basic/Physics2D"), TaskDescription("Returns success if there is any collider intersecting the line between start and end")]
	public class Linecast : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The starting position of the linecast.")]
		private SharedVector2 startPosition;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The ending position of the linecast.")]
		private SharedVector2 endPosition;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Selectively ignore colliders.")]
		public LayerMask layerMask = -1;

		public override TaskStatus OnUpdate()
		{
			return (!Physics2D.Linecast(this.startPosition.Value, this.endPosition.Value, this.layerMask)) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.startPosition = Vector2.zero;
			this.endPosition = Vector2.zero;
			this.layerMask = -1;
		}
	}
}
