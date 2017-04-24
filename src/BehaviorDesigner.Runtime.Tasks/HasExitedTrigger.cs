using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=110"), TaskCategory("Physics"), TaskDescription("Returns success when an object exits the trigger.")]
	public class HasExitedTrigger : Conditional
	{
		[Tooltip("The tag of the GameObject to check for a trigger against")]
		public SharedString tag = string.Empty;

		[Tooltip("The object that exited the trigger")]
		public SharedGameObject otherGameObject;

		private bool exitedTrigger;

		public override TaskStatus OnUpdate()
		{
			return (!this.exitedTrigger) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnEnd()
		{
			this.exitedTrigger = false;
		}

		public override void OnTriggerExit(Collider other)
		{
			if (string.IsNullOrEmpty(this.tag.Value) || this.tag.Value.Equals(other.gameObject.tag))
			{
				this.otherGameObject.Value = other.gameObject;
				this.exitedTrigger = true;
			}
		}

		public override void OnReset()
		{
			this.tag = string.Empty;
			this.otherGameObject = null;
		}
	}
}
