using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject
{
	[TaskCategory("Basic/GameObject"), TaskDescription("Returns Success if tags match, otherwise Failure.")]
	public class CompareTag : Conditional
	{
		[Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[Tooltip("The tag to compare against")]
		public SharedString tag;

		public override TaskStatus OnUpdate()
		{
			return (!base.GetDefaultGameObject(this.targetGameObject.Value).CompareTag(this.tag.Value)) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.tag = string.Empty;
		}
	}
}
