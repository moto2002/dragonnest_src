using System;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=17"), TaskDescription("Perform the actual interruption. This will immediately stop the specified tasks from running and will return success or failure depending on the value of interrupt success."), TaskIcon("{SkinColor}PerformInterruptionIcon.png")]
	public class PerformInterruption : Action
	{
		[Tooltip("The list of tasks to interrupt. Can be any number of tasks")]
		public Interrupt[] interruptTasks;

		[Tooltip("When we interrupt the task should we return a task status of success?")]
		public SharedBool interruptSuccess;

		public override TaskStatus OnUpdate()
		{
			for (int i = 0; i < this.interruptTasks.Length; i++)
			{
				this.interruptTasks[i].DoInterrupt((!this.interruptSuccess.Value) ? TaskStatus.Failure : TaskStatus.Success);
			}
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.interruptTasks = null;
			this.interruptSuccess = false;
		}
	}
}
