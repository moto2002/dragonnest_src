using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityRenderer
{
	[TaskCategory("Basic/Renderer"), TaskDescription("Sets the material on the Renderer.")]
	public class SetMaterial : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The material to set")]
		public SharedMaterial material;

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
			this.renderer.material = this.material.Value;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.material = null;
		}
	}
}
