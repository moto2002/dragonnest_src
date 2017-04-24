using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityLayerMask
{
	[TaskCategory("Basic/LayerMask"), TaskDescription("Gets the layer of a GameObject.")]
	public class GetLayer : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject to set the layer of")]
		public SharedGameObject targetGameObject;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The name of the layer to get")]
		public SharedString storeResult;

		public override TaskStatus OnUpdate()
		{
			GameObject defaultGameObject = base.GetDefaultGameObject(this.targetGameObject.Value);
			this.storeResult.Value = LayerMask.LayerToName(defaultGameObject.layer);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.storeResult = string.Empty;
		}
	}
}
