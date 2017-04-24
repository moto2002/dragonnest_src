using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject
{
	[TaskCategory("Basic/GameObject"), TaskDescription("Returns Success if the GameObject is active in the hierarchy, otherwise Failure.")]
	public class ActiveSelf : Conditional
	{
		[Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		public override TaskStatus OnUpdate()
		{
			return (!base.GetDefaultGameObject(this.targetGameObject.Value).activeSelf) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
		}
	}
}
