using System;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=40"), TaskDescription("The task guard task is similar to a semaphore in multithreaded programming. The task guard task is there to ensure a limited resource is not being overused. \n\nFor example, you may place a task guard above a task that plays an animation. Elsewhere within your behavior tree you may also have another task that plays a different animation but uses the same bones for that animation. Because of this you don't want that animation to play twice at the same time. Placing a task guard will let you specify how many times a particular task can be accessed at the same time.\n\nIn the previous animation task example you would specify an access count of 1. With this setup the animation task can be only controlled by one task at a time. If the first task is playing the animation and a second task wants to control the animation as well, it will either have to wait or skip over the task completely."), TaskIcon("{SkinColor}TaskGuardIcon.png")]
	public class TaskGuard : Decorator
	{
		[Tooltip("The number of times the child tasks can be accessed by parallel tasks at once")]
		public SharedInt maxTaskAccessCount;

		[LinkedTask, Tooltip("The linked tasks that also guard a task. If the task guard is not linked against any other tasks it doesn't have much purpose. Marked as LinkedTask to ensure all tasks linked are linked to the same set of tasks")]
		public TaskGuard[] linkedTaskGuards;

		[Tooltip("If true the task will wait until the child task is available. If false then any unavailable child tasks will be skipped over")]
		public SharedBool waitUntilTaskAvailable;

		private int executingTasks;

		private bool executing;

		public override bool CanExecute()
		{
			return this.executingTasks < this.maxTaskAccessCount.Value && !this.executing;
		}

		public override void OnChildStarted()
		{
			this.executingTasks++;
			this.executing = true;
			for (int i = 0; i < this.linkedTaskGuards.Length; i++)
			{
				this.linkedTaskGuards[i].taskExecuting(true);
			}
		}

		public override TaskStatus OverrideStatus(TaskStatus status)
		{
			return (this.executing || !this.waitUntilTaskAvailable.Value) ? status : TaskStatus.Running;
		}

		public void taskExecuting(bool increase)
		{
			this.executingTasks += ((!increase) ? -1 : 1);
		}

		public override void OnEnd()
		{
			if (this.executing)
			{
				this.executingTasks--;
				for (int i = 0; i < this.linkedTaskGuards.Length; i++)
				{
					this.linkedTaskGuards[i].taskExecuting(false);
				}
				this.executing = false;
			}
		}

		public override void OnReset()
		{
			this.maxTaskAccessCount = null;
			this.linkedTaskGuards = null;
			this.waitUntilTaskAvailable = true;
		}
	}
}
