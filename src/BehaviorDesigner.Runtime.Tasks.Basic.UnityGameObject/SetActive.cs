using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject
{
	[TaskCategory("Basic/GameObject"), TaskDescription("Activates/Deactivates the GameObject. Returns Success.")]
	public class SetActive : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[Tooltip("Active state of the GameObject")]
		public SharedBool active;

		public override TaskStatus OnUpdate()
		{
			base.GetDefaultGameObject(this.targetGameObject.Value).SetActive(this.active.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.active = false;
		}
	}
}
