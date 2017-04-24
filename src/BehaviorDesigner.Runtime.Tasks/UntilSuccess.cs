using System;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=42"), TaskDescription("The until success task will keep executing its child task until the child task returns success."), TaskIcon("{SkinColor}UntilSuccessIcon.png")]
	public class UntilSuccess : Decorator
	{
		private TaskStatus executionStatus;

		public override bool CanExecute()
		{
			return this.executionStatus == TaskStatus.Failure || this.executionStatus == TaskStatus.Inactive;
		}

		public override void OnChildExecuted(TaskStatus childStatus)
		{
			this.executionStatus = childStatus;
		}

		public override void OnEnd()
		{
			this.executionStatus = TaskStatus.Inactive;
		}
	}
}
