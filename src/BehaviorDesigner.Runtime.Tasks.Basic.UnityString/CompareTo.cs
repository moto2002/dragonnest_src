using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityString
{
	[TaskCategory("Basic/String"), TaskDescription("Compares the first string to the second string. Returns an int which indicates whether the first string precedes, matches, or follows the second string.")]
	public class CompareTo : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The string to compare")]
		public SharedString firstString;

		[Tooltip("The string to compare to")]
		public SharedString secondString;

		[RequiredField, Tooltip("The stored result")]
		public SharedInt storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = this.firstString.Value.CompareTo(this.secondString.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.firstString = string.Empty;
			this.secondString = string.Empty;
			this.storeResult = 0;
		}
	}
}
