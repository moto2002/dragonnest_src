using System;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=28"), TaskDescription("Similar to the selector task, the parallel selector task will return success as soon as a child task returns success. The difference is that the parallel task will run all of its children tasks simultaneously versus running each task one at a time. If one tasks returns success the parallel selector task will end all of the child tasks and return success. If every child task returns failure then the parallel selector task will return failure."), TaskIcon("{SkinColor}ParallelSelectorIcon.png")]
	public class ParallelSelector : Composite
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

		public override void OnConditionalAbort(int childIndex)
		{
			this.currentChildIndex = 0;
			for (int i = 0; i < this.executionStatus.Length; i++)
			{
				this.executionStatus[i] = TaskStatus.Inactive;
			}
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
				else if (this.executionStatus[i] == TaskStatus.Success)
				{
					return TaskStatus.Success;
				}
			}
			return (!flag) ? TaskStatus.Running : TaskStatus.Failure;
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
