using System;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=36"), TaskDescription("The inverter task will invert the return value of the child task after it has finished executing. If the child returns success, the inverter task will return failure. If the child returns failure, the inverter task will return success."), TaskIcon("{SkinColor}InverterIcon.png")]
	public class Inverter : Decorator
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
			if (status == TaskStatus.Failure)
			{
				return TaskStatus.Success;
			}
			return status;
		}

		public override void OnEnd()
		{
			this.executionStatus = TaskStatus.Inactive;
		}
	}
}
