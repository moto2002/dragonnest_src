using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityString
{
	[TaskCategory("Basic/String"), TaskDescription("Stores a substring of the target string")]
	public class GetSubstring : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The target string")]
		public SharedString targetString;

		[Tooltip("The start substring index")]
		public SharedInt startIndex = 0;

		[Tooltip("The length of the substring. Don't use if -1")]
		public SharedInt length = -1;

		[RequiredField, Tooltip("The stored result")]
		public SharedString storeResult;

		public override TaskStatus OnUpdate()
		{
			if (this.length.Value != -1)
			{
				this.storeResult.Value = this.targetString.Value.Substring(this.startIndex.Value, this.length.Value);
			}
			else
			{
				this.storeResult.Value = this.targetString.Value.Substring(this.startIndex.Value);
			}
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetString = string.Empty;
			this.startIndex = 0;
			this.length = -1;
			this.storeResult = string.Empty;
		}
	}
}
