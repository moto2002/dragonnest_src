using System;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=21"), TaskDescription("Pause or disable a behavior tree and return success after it has been stopped."), TaskIcon("{SkinColor}StopBehaviorTreeIcon.png")]
	public class StopBehaviorTree : Action
	{
		[Tooltip("The GameObject of the behavior tree that should be stopped. If null use the current behavior")]
		public SharedGameObject behaviorGameObject;

		[Tooltip("The group of the behavior tree that should be stopped")]
		public SharedInt group;

		[Tooltip("Should the behavior be paused or completely disabled")]
		public SharedBool pauseBehavior = false;

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
		}

		public override TaskStatus OnUpdate()
		{
			if (this.behavior == null)
			{
				return TaskStatus.Failure;
			}
			this.behavior.DisableBehavior(this.pauseBehavior.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.behaviorGameObject = null;
			this.group = 0;
			this.pauseBehavior = false;
		}
	}
}
