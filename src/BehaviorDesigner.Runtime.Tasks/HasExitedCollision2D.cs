using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=110"), TaskCategory("Physics"), TaskDescription("Returns success when a 2D collision ends.")]
	public class HasExitedCollision2D : Conditional
	{
		[Tooltip("The tag of the GameObject to check for a collision against")]
		public SharedString tag = string.Empty;

		[Tooltip("The object that exited the collision")]
		public SharedGameObject collidedGameObject;

		private bool exitedCollision;

		public override TaskStatus OnUpdate()
		{
			return (!this.exitedCollision) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnEnd()
		{
			this.exitedCollision = false;
		}

		public override void OnCollisionExit2D(Collision2D collision)
		{
			if (string.IsNullOrEmpty(this.tag.Value) || this.tag.Value.Equals(collision.gameObject.tag))
			{
				this.collidedGameObject.Value = collision.gameObject;
				this.exitedCollision = true;
			}
		}

		public override void OnReset()
		{
			this.tag = string.Empty;
			this.collidedGameObject = null;
		}
	}
}
