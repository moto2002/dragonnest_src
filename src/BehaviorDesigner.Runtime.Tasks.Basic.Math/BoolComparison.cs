using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Math
{
	[TaskCategory("Basic/Math"), TaskDescription("Performs a comparison between two bools.")]
	public class BoolComparison : Conditional
	{
		[Tooltip("The first bool")]
		public SharedBool bool1;

		[Tooltip("The second bool")]
		public SharedBool bool2;

		public override TaskStatus OnUpdate()
		{
			return (this.bool1.Value != this.bool2.Value) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.bool1.Value = false;
			this.bool2.Value = false;
		}
	}
}
