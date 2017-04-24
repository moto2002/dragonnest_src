using System;
using System.Collections.Generic;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=20"), TaskDescription("Start a new behavior tree and return success after it has been started."), TaskIcon("{SkinColor}StartBehaviorTreeIcon.png")]
	public class StartBehaviorTree : Action
	{
		[Tooltip("The GameObject of the behavior tree that should be started. If null use the current behavior")]
		public SharedGameObject behaviorGameObject;

		[Tooltip("The group of the behavior tree that should be started")]
		public SharedInt group;

		[Tooltip("Should this task wait for the behavior tree to complete?")]
		public SharedBool waitForCompletion = false;

		[Tooltip("Should the variables be synchronized?")]
		public SharedBool synchronizeVariables;

		private bool behaviorComplete;

		private Behavior behavior;

		public override void OnStart()
		{
			Behavior[] components = base.GetDefaultGameObject(this.behaviorGameObject.Value).GetComponents<Behavior>();
			if (components.Length == 1)
			{
				this.behavior = components[0];
			}
			else if (components.Length > 1)
			{
				for (int i = 0; i < components.Length; i++)
				{
					if (components[i].Group == this.group.Value)
					{
						this.behavior = components[i];
						break;
					}
				}
				if (this.behavior == null)
				{
					this.behavior = components[0];
				}
			}
			if (this.behavior != null)
			{
				List<SharedVariable> allVariables = base.Owner.GetAllVariables();
				for (int j = 0; j < allVariables.Count; j++)
				{
					this.behavior.SetVariable(allVariables[j].Name, allVariables[j]);
				}
				this.behavior.EnableBehavior();
				if (this.waitForCompletion.Value)
				{
					this.behaviorComplete = false;
					this.behavior.OnBehaviorEnd += new Behavior.BehaviorHandler(this.BehaviorEnded);
				}
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.behavior == null)
			{
				return TaskStatus.Failure;
			}
			if (this.waitForCompletion.Value && !this.behaviorComplete)
			{
				return TaskStatus.Running;
			}
			return TaskStatus.Success;
		}

		private void BehaviorEnded()
		{
			this.behaviorComplete = true;
		}

		public override void OnEnd()
		{
			if (this.behavior != null && this.waitForCompletion.Value)
			{
				this.behavior.OnBehaviorEnd -= new Behavior.BehaviorHandler(this.BehaviorEnded);
			}
		}

		public override void OnReset()
		{
			this.behaviorGameObject = null;
			this.group = 0;
			this.waitForCompletion = false;
			this.synchronizeVariables = false;
		}
	}
}
