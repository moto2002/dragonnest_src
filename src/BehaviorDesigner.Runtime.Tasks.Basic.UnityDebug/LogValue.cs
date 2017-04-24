using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityDebug
{
	[TaskCategory("Basic/Debug"), TaskDescription("Log a variable value.")]
	public class LogValue : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The variable to output")]
		public SharedGenericVariable variable;

		public override TaskStatus OnUpdate()
		{
			Debug.Log(this.variable.Value.value.GetValue());
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.variable = null;
		}
	}
}
