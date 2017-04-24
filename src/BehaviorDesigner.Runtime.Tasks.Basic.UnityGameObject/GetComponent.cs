using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject
{
	[TaskCategory("Basic/GameObject"), TaskDescription("Returns the component of Type type if the game object has one attached, null if it doesn't. Returns Success.")]
	public class GetComponent : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[Tooltip("The type of component")]
		public SharedString type;

		[RequiredField, Tooltip("The component")]
		public SharedObject storeValue;

		public override TaskStatus OnUpdate()
		{
			this.storeValue.Value = base.GetDefaultGameObject(this.targetGameObject.Value).GetComponent(this.type.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.type.Value = string.Empty;
			this.storeValue.Value = null;
		}
	}
}
