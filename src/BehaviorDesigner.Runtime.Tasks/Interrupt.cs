using System;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=35"), TaskDescription("The interrupt task will stop all child tasks from running if it is interrupted. The interruption can be triggered by the perform interruption task. The interrupt task will keep running its child until this interruption is called. If no interruption happens and the child task completed its execution the interrupt task will return the value assigned by the child task."), TaskIcon("{SkinColor}InterruptIcon.png")]
	public class Interrupt : Decorator
	{
		private TaskStatus interruptStatus = TaskStatus.Failure;

		private TaskStatus executionStatus;

		public override bool CanExecute()
		{
			return this.executionStatus == TaskStatus.Inactive || this.executionStatus == TaskStatus.Running;
		}

		public override void OnChildExecuted(TaskStatus childStatus)
		{
			this.executionStatus = childStatus;
		}

		public void DoInterrupt(TaskStatus status)
		{
			this.interruptStatus = status;
			BehaviorManager.instance.Interrupt(base.Owner, this);
		}

		public override TaskStatus OverrideStatus()
		{
			return this.interruptStatus;
		}

		public override void OnEnd()
		{
			this.interruptStatus = TaskStatus.Failure;
			this.executionStatus = TaskStatus.Inactive;
		}
	}
}
