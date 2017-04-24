using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Returns success if the variable value is equal to the compareTo value.")]
	public class CompareSharedInt : Conditional
	{
		[Tooltip("The first variable to compare")]
		public SharedInt variable;

		[Tooltip("The variable to compare to")]
		public SharedInt compareTo;

		public override TaskStatus OnUpdate()
		{
			return (!this.variable.Value.Equals(this.compareTo.Value)) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.variable = 0;
			this.compareTo = 0;
		}
	}
}
