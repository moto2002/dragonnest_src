using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Gets the Transform from the GameObject. Returns Success.")]
	public class SharedGameObjectToTransform : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject to get the Transform of")]
		public SharedGameObject sharedGameObject;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The Transform to set")]
		public SharedTransform sharedTransform;

		public override TaskStatus OnUpdate()
		{
			if (this.sharedGameObject.Value == null)
			{
				return TaskStatus.Failure;
			}
			this.sharedTransform.Value = this.sharedGameObject.Value.GetComponent<Transform>();
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.sharedGameObject = null;
			this.sharedTransform = null;
		}
	}
}
