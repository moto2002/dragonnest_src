using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRenderer
{
	[TaskCategory("Basic/Renderer"), TaskDescription("Returns Success if the Renderer is visible, otherwise Failure.")]
	public class IsVisible : Conditional
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		private Renderer renderer;

		private GameObject prevGameObject;

		public override void OnStart()
		{
			GameObject defaultGameObject = base.GetDefaultGameObject(this.targetGameObject.Value);
			if (defaultGameObject != this.prevGameObject)
			{
				this.renderer = defaultGameObject.GetComponent<Renderer>();
				this.prevGameObject = defaultGameObject;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.renderer == null)
			{
				Debug.LogWarning("Renderer is null");
				return TaskStatus.Failure;
			}
			return (!this.renderer.isVisible) ? TaskStatus.Failure : TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
		}
	}
}
