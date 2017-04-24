using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Returns success if the variable value is equal to the compareTo value.")]
	public class CompareSharedString : Conditional
	{
		[Tooltip("The first variable to compare")]
		public SharedString variable;

		[Tooltip("The variable to compare to")]
		public SharedString compareTo;

		public override TaskStatus OnUpdate()
		{
			return (!this.variable.Value.Equals(this.compareTo.Value)) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.variable = string.Empty;
			this.compareTo = string.Empty;
		}
	}
}
