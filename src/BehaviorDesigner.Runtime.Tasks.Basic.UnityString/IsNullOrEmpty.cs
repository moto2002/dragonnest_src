using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityString
{
	[TaskCategory("Basic/String"), TaskDescription("Returns success if the string is null or empty")]
	public class IsNullOrEmpty : Conditional
	{
		[Tooltip("The target string")]
		public SharedString targetString;

		public override TaskStatus OnUpdate()
		{
			return (!string.IsNullOrEmpty(this.targetString.Value)) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetString = string.Empty;
		}
	}
}
