using System;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=66"), TaskDescription("Restarts a behavior tree, returns success after it has been restarted."), TaskIcon("{SkinColor}RestartBehaviorTreeIcon.png")]
	public class RestartBehaviorTree : Action
	{
		[Tooltip("The GameObject of the behavior tree that should be restarted. If null use the current behavior")]
		public SharedGameObject behaviorGameObject;

		[Tooltip("The group of the behavior tree that should be restarted")]
		public SharedInt group;

		private Behavior behavior;

		public override void OnAwake()
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
			this.behavior.DisableBehavior();
			this.behavior.EnableBehavior();
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.behavior = null;
		}
	}
}
