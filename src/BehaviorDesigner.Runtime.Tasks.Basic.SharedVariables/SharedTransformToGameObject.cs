using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Gets the GameObject from the Transform component. Returns Success.")]
	public class SharedTransformToGameObject : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The Transform component")]
		public SharedTransform sharedTransform;

		[RequiredField, Tooltip("The GameObject to set")]
		public SharedGameObject sharedGameObject;

		public override TaskStatus OnUpdate()
		{
			if (this.sharedTransform.Value == null)
			{
				return TaskStatus.Failure;
			}
			this.sharedGameObject.Value = this.sharedTransform.Value.gameObject;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.sharedTransform = null;
			this.sharedGameObject = null;
		}
	}
}
