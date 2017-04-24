using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityString
{
	[TaskCategory("Basic/String"), TaskDescription("Sets the variable string to the value string.")]
	public class SetString : BehaviorDesigner.Runtime.Tasks.Action
	{
		[RequiredField, Tooltip("The target string")]
		public SharedString variable;

		[Tooltip("The value string")]
		public SharedString value;

		public override TaskStatus OnUpdate()
		{
			this.variable.Value = this.value.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.variable = string.Empty;
			this.value = string.Empty;
		}
	}
}
