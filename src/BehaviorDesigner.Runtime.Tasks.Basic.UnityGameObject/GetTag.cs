using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject
{
	[TaskCategory("Basic/GameObject"), TaskDescription("Stores the GameObject tag. Returns Success.")]
	public class GetTag : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[RequiredField, Tooltip("Active state of the GameObject")]
		public SharedString storeValue;

		public override TaskStatus OnUpdate()
		{
			this.storeValue.Value = base.GetDefaultGameObject(this.targetGameObject.Value).tag;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.storeValue = string.Empty;
		}
	}
}
