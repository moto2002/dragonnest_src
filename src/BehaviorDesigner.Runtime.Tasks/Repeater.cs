using System;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=37"), TaskDescription("The repeater task will repeat execution of its child task until the child task has been run a specified number of times. It has the option of continuing to execute the child task even if the child task returns a failure."), TaskIcon("{SkinColor}RepeaterIcon.png")]
	public class Repeater : Decorator
	{
		[Tooltip("The number of times to repeat the execution of its child task")]
		public SharedInt count = 1;

		[Tooltip("Allows the repeater to repeat forever")]
		public SharedBool repeatForever;

		[Tooltip("Should the task return if the child task returns a failure")]
		public SharedBool endOnFailure;

		private int executionCount;

		private TaskStatus executionStatus;

		public override bool CanExecute()
		{
			return (this.repeatForever.Value || this.executionCount < this.count.Value) && (!this.endOnFailure.Value || (this.endOnFailure.Value && this.executionStatus != TaskStatus.Failure));
		}

		public override void OnChildExecuted(TaskStatus childStatus)
		{
			this.executionCount++;
			this.executionStatus = childStatus;
		}

		public override void OnEnd()
		{
			this.executionCount = 0;
			this.executionStatus = TaskStatus.Inactive;
		}

		public override void OnReset()
		{
			this.count = 0;
			this.endOnFailure = true;
		}
	}
}
