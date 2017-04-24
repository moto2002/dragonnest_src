using System;
using System.Collections.Generic;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=29"), TaskDescription("Similar to the selector task, the priority selector task will return success as soon as a child task returns success. Instead of running the tasks sequentially from left to right within the tree, the priority selector will ask the task what its priority is to determine the order. The higher priority tasks have a higher chance at being run first."), TaskIcon("{SkinColor}PrioritySelectorIcon.png")]
	public class PrioritySelector : Composite
	{
		private int currentChildIndex;

		private TaskStatus executionStatus;

		private List<int> childrenExecutionOrder = new List<int>();

		public override void OnStart()
		{
			this.childrenExecutionOrder.Clear();
			for (int i = 0; i < this.children.Count; i++)
			{
				float priority = this.children[i].GetPriority();
				int index = this.childrenExecutionOrder.Count;
				for (int j = 0; j < this.childrenExecutionOrder.Count; j++)
				{
					if (this.children[this.childrenExecutionOrder[j]].GetPriority() < priority)
					{
						index = j;
						break;
					}
				}
				this.childrenExecutionOrder.Insert(index, i);
			}
		}

		public override int CurrentChildIndex()
		{
			return this.childrenExecutionOrder[this.currentChildIndex];
		}

		public override bool CanExecute()
		{
			return this.currentChildIndex < this.children.Count && this.executionStatus != TaskStatus.Success;
		}

		public override void OnChildExecuted(TaskStatus childStatus)
		{
			this.currentChildIndex++;
			this.executionStatus = childStatus;
		}

		public override void OnConditionalAbort(int childIndex)
		{
			this.currentChildIndex = childIndex;
			this.executionStatus = TaskStatus.Inactive;
		}

		public override void OnEnd()
		{
			this.executionStatus = TaskStatus.Inactive;
			this.currentChildIndex = 0;
		}
	}
}
