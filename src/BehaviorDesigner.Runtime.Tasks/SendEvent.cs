using System;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=121"), TaskDescription("Sends an event to the behavior tree, returns success after sending the event."), TaskIcon("{SkinColor}SendEventIcon.png")]
	public class SendEvent : Action
	{
		[Tooltip("The GameObject of the behavior tree that should have the event sent to it. If null use the current behavior")]
		public SharedGameObject targetGameObject;

		[Tooltip("The event to send")]
		public SharedString eventName;

		[Tooltip("The group of the behavior tree that the event should be sent to")]
		public SharedInt group;

		[SharedRequired, Tooltip("Optionally specify a first argument to send")]
		public SharedVariable argument1;

		[SharedRequired, Tooltip("Optionally specify a second argument to send")]
		public SharedVariable argument2;

		[SharedRequired, Tooltip("Optionally specify a third argument to send")]
		public SharedVariable argument3;

		private BehaviorTree behaviorTree;

		public override void OnStart()
		{
			BehaviorTree[] components = base.GetDefaultGameObject(this.targetGameObject.Value).GetComponents<BehaviorTree>();
			if (components.Length == 1)
			{
				this.behaviorTree = components[0];
			}
			else if (components.Length > 1)
			{
				for (int i = 0; i < components.Length; i++)
				{
					if (components[i].Group == this.group.Value)
					{
						this.behaviorTree = components[i];
						break;
					}
				}
				if (this.behaviorTree == null)
				{
					this.behaviorTree = components[0];
				}
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.argument1 == null || this.argument1.IsNone)
			{
				this.behaviorTree.SendEvent(this.eventName.Value);
			}
			else if (this.argument2 == null || this.argument2.IsNone)
			{
				this.behaviorTree.SendEvent<object>(this.eventName.Value, this.argument1.GetValue());
			}
			else if (this.argument3 == null || this.argument3.IsNone)
			{
				this.behaviorTree.SendEvent<object, object>(this.eventName.Value, this.argument1.GetValue(), this.argument2.GetValue());
			}
			else
			{
				this.behaviorTree.SendEvent<object, object, object>(this.eventName.Value, this.argument1.GetValue(), this.argument2.GetValue(), this.argument3.GetValue());
			}
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.eventName = string.Empty;
		}
	}
}
