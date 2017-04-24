using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject
{
	[TaskCategory("Basic/GameObject"), TaskDescription("Sets the GameObject tag. Returns Success.")]
	public class SetTag : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[Tooltip("The GameObject tag")]
		public SharedString tag;

		public override TaskStatus OnUpdate()
		{
			base.GetDefaultGameObject(this.targetGameObject.Value).tag = this.tag.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.tag = string.Empty;
		}
	}
}
