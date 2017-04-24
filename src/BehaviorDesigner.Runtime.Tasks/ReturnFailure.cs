using System;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=38"), TaskDescription("The return failure task will always return failure except when the child task is running."), TaskIcon("{SkinColor}ReturnFailureIcon.png")]
	public class ReturnFailure : Decorator
	{
		private TaskStatus executionStatus;

		public override bool CanExecute()
		{
			return this.executionStatus == TaskStatus.Inactive || this.executionStatus == TaskStatus.Running;
		}

		public override void OnChildExecuted(TaskStatus childStatus)
		{
			this.executionStatus = childStatus;
		}

		public override TaskStatus Decorate(TaskStatus status)
		{
			if (status == TaskStatus.Success)
			{
				return TaskStatus.Failure;
			}
			return status;
		}

		public override void OnEnd()
		{
			this.executionStatus = TaskStatus.Inactive;
		}
	}
}
