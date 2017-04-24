using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=110"), TaskCategory("Physics"), TaskDescription("Returns success when a 2D collision starts.")]
	public class HasEnteredCollision2D : Conditional
	{
		[Tooltip("The tag of the GameObject to check for a collision against")]
		public SharedString tag = string.Empty;

		[Tooltip("The object that started the collision")]
		public SharedGameObject collidedGameObject;

		private bool enteredCollision;

		public override TaskStatus OnUpdate()
		{
			return (!this.enteredCollision) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnEnd()
		{
			this.enteredCollision = false;
		}

		public override void OnCollisionEnter2D(Collision2D collision)
		{
			if (string.IsNullOrEmpty(this.tag.Value) || this.tag.Value.Equals(collision.gameObject.tag))
			{
				this.collidedGameObject.Value = collision.gameObject;
				this.enteredCollision = true;
			}
		}

		public override void OnReset()
		{
			this.tag = string.Empty;
			this.collidedGameObject = null;
		}
	}
}
