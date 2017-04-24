using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityBehaviour
{
	[TaskCategory("Basic/Behaviour"), TaskDescription("Enables/Disables the object. Returns Success.")]
	public class SetIsEnabled : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The Object to use")]
		public SharedObject specifiedObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The enabled/disabled state")]
		public SharedBool enabled;

		public override TaskStatus OnUpdate()
		{
			if (this.specifiedObject == null && !(this.specifiedObject.Value is Behaviour))
			{
				Debug.LogWarning("SpecifiedObject is null or not a subclass of UnityEngine.Behaviour");
				return TaskStatus.Failure;
			}
			(this.specifiedObject.Value as Behaviour).enabled = this.enabled.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			if (this.specifiedObject != null)
			{
				this.specifiedObject.Value = null;
			}
			this.enabled = false;
		}
	}
}
