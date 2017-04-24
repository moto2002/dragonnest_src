using System;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=26"), TaskDescription("The selector task is similar to an \"or\" operation. It will return success as soon as one of its child tasks return success. If a child task returns failure then it will sequentially run the next task. If no child task returns success then it will return failure."), TaskIcon("{SkinColor}SelectorIcon.png")]
	public class Selector : Composite
	{
		private int currentChildIndex;

		private TaskStatus executionStatus;

		public override int CurrentChildIndex()
		{
			return this.currentChildIndex;
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
