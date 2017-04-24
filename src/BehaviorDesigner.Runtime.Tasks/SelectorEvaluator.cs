using System;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=109"), TaskDescription("The selector evaluator is a selector task which reevaluates its children every tick. It will run the lowest priority child which returns a task status of running. This is done each tick. If a higher priority child is running and the next frame a lower priority child wants to run it will interrupt the higher priority child. The selector evaluator will return success as soon as the first child returns success otherwise it will keep trying higher priority children. This task mimics the conditional abort functionality except the child tasks don't always have to be conditional tasks."), TaskIcon("{SkinColor}SelectorEvaluatorIcon.png")]
	public class SelectorEvaluator : Composite
	{
		private int currentChildIndex;

		private TaskStatus executionStatus;

		private int storedCurrentChildIndex = -1;

		private TaskStatus storedExecutionStatus;

		public override int CurrentChildIndex()
		{
			return this.currentChildIndex;
		}

		public override void OnChildStarted(int childIndex)
		{
			this.currentChildIndex++;
			this.executionStatus = TaskStatus.Running;
		}

		public override bool CanExecute()
		{
			if (this.executionStatus == TaskStatus.Success || this.executionStatus == TaskStatus.Running)
			{
				return false;
			}
			if (this.storedCurrentChildIndex != -1)
			{
				return this.currentChildIndex < this.storedCurrentChildIndex - 1;
			}
			return this.currentChildIndex < this.children.Count;
		}

		public override void OnChildExecuted(int childIndex, TaskStatus childStatus)
		{
			if (childStatus != TaskStatus.Inactive && childStatus != TaskStatus.Running)
			{
				this.executionStatus = childStatus;
			}
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

		public override TaskStatus OverrideStatus(TaskStatus status)
		{
			return this.executionStatus;
		}

		public override bool CanRunParallelChildren()
		{
			return true;
		}

		public override bool CanReevaluate()
		{
			return true;
		}

		public override bool OnReevaluationStarted()
		{
			if (this.executionStatus == TaskStatus.Inactive)
			{
				return false;
			}
			this.storedCurrentChildIndex = this.currentChildIndex;
			this.storedExecutionStatus = this.executionStatus;
			this.currentChildIndex = 0;
			this.executionStatus = TaskStatus.Inactive;
			return true;
		}

		public override void OnReevaluationEnded(TaskStatus status)
		{
			if (this.executionStatus != TaskStatus.Failure && this.executionStatus != TaskStatus.Inactive)
			{
				BehaviorManager.instance.Interrupt(base.Owner, this.children[this.storedCurrentChildIndex - 1], this);
			}
			else
			{
				this.currentChildIndex = this.storedCurrentChildIndex;
				this.executionStatus = this.storedExecutionStatus;
			}
			this.storedCurrentChildIndex = -1;
			this.storedExecutionStatus = TaskStatus.Inactive;
		}
	}
}
