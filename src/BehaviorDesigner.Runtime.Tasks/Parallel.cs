using System;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=27"), TaskDescription("Similar to the sequence task, the parallel task will run each child task until a child task returns failure. The difference is that the parallel task will run all of its children tasks simultaneously versus running each task one at a time. Like the sequence class, the parallel task will return success once all of its children tasks have return success. If one tasks returns failure the parallel task will end all of the child tasks and return failure."), TaskIcon("{SkinColor}ParallelIcon.png")]
	public class Parallel : Composite
	{
		private int currentChildIndex;

		private TaskStatus[] executionStatus;

		public override void OnAwake()
		{
			this.executionStatus = new TaskStatus[this.children.Count];
		}

		public override void OnChildStarted(int childIndex)
		{
			this.currentChildIndex++;
			this.executionStatus[childIndex] = TaskStatus.Running;
		}

		public override bool CanRunParallelChildren()
		{
			return true;
		}

		public override int CurrentChildIndex()
		{
			return this.currentChildIndex;
		}

		public override bool CanExecute()
		{
			return this.currentChildIndex < this.children.Count;
		}

		public override void OnChildExecuted(int childIndex, TaskStatus childStatus)
		{
			this.executionStatus[childIndex] = childStatus;
		}

		public override TaskStatus OverrideStatus(TaskStatus status)
		{
			bool flag = true;
			for (int i = 0; i < this.executionStatus.Length; i++)
			{
				if (this.executionStatus[i] == TaskStatus.Running)
				{
					flag = false;
				}
				else if (this.executionStatus[i] == TaskStatus.Failure)
				{
					return TaskStatus.Failure;
				}
			}
			return (!flag) ? TaskStatus.Running : TaskStatus.Success;
		}

		public override void OnConditionalAbort(int childIndex)
		{
			this.currentChildIndex = 0;
			for (int i = 0; i < this.executionStatus.Length; i++)
			{
				this.executionStatus[i] = TaskStatus.Inactive;
			}
		}

		public override void OnEnd()
		{
			for (int i = 0; i < this.executionStatus.Length; i++)
			{
				this.executionStatus[i] = TaskStatus.Inactive;
			}
			this.currentChildIndex = 0;
		}
	}
}
