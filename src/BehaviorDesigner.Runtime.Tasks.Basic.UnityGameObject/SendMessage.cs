using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject
{
	[TaskCategory("Basic/GameObject"), TaskDescription("Sends a message to the target GameObject. Returns Success.")]
	public class SendMessage : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[Tooltip("The message to send")]
		public SharedString message;

		[Tooltip("The value to send")]
		public SharedGenericVariable value;

		public override TaskStatus OnUpdate()
		{
			if (this.value.Value != null)
			{
				base.GetDefaultGameObject(this.targetGameObject.Value).SendMessage(this.message.Value, this.value.Value.value.GetValue());
			}
			else
			{
				base.GetDefaultGameObject(this.targetGameObject.Value).SendMessage(this.message.Value);
			}
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.message = string.Empty;
		}
	}
}
