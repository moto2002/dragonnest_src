using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityString
{
	[TaskCategory("Basic/String"), TaskDescription("Stores the length of the string")]
	public class GetLength : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The target string")]
		public SharedString targetString;

		[RequiredField, Tooltip("The stored result")]
		public SharedInt storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = this.targetString.Value.Length;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetString = string.Empty;
			this.storeResult = 0;
		}
	}
}
