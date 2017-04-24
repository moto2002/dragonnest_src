using System;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=146"), TaskDescription("Evaluates the specified conditional task. If the conditional task returns success then the child task is run and the child status is returned. If the conditional task does not return success then the child task is not run and a failure status is immediately returned."), TaskIcon("{SkinColor}ConditionalEvaluatorIcon.png")]
	public class ConditionalEvaluator : Decorator
	{
		[Tooltip("Should the conditional task be reevaluated every tick?")]
		public SharedBool reevaluate;

		[InspectTask, Tooltip("The conditional task to evaluate")]
		public Conditional conditionalTask;

		private TaskStatus executionStatus;

		private bool checkConditionalTask = true;

		private bool conditionalTaskFailed;

		public override void OnAwake()
		{
			if (this.conditionalTask != null)
			{
				this.conditionalTask.Owner = base.Owner;
				this.conditionalTask.GameObject = this.gameObject;
				this.conditionalTask.Transform = this.transform;
				this.conditionalTask.OnAwake();
			}
		}

		public override void OnStart()
		{
			if (this.conditionalTask != null)
			{
				this.conditionalTask.OnStart();
			}
		}

		public override bool CanExecute()
		{
			if (this.checkConditionalTask)
			{
				this.checkConditionalTask = false;
				this.OnUpdate();
			}
			return !this.conditionalTaskFailed && (this.executionStatus == TaskStatus.Inactive || this.executionStatus == TaskStatus.Running);
		}

		public override bool CanReevaluate()
		{
			return this.reevaluate.Value;
		}

		public override TaskStatus OnUpdate()
		{
			TaskStatus taskStatus = this.conditionalTask.OnUpdate();
			this.conditionalTaskFailed = (this.conditionalTask == null || taskStatus == TaskStatus.Failure);
			return taskStatus;
		}

		public override void OnChildExecuted(TaskStatus childStatus)
		{
			this.executionStatus = childStatus;
		}

		public override TaskStatus OverrideStatus()
		{
			return TaskStatus.Failure;
		}

		public override TaskStatus OverrideStatus(TaskStatus status)
		{
			if (this.conditionalTaskFailed)
			{
				return TaskStatus.Failure;
			}
			return status;
		}

		public override void OnEnd()
		{
			this.executionStatus = TaskStatus.Inactive;
			this.checkConditionalTask = true;
			this.conditionalTaskFailed = false;
			if (this.conditionalTask != null)
			{
				this.conditionalTask.OnEnd();
			}
		}

		public override void OnReset()
		{
			this.conditionalTask = null;
		}
	}
}
