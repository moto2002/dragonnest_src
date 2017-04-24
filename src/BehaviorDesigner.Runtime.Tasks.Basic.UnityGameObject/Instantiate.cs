using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject
{
	[TaskCategory("Basic/GameObject"), TaskDescription("Instantiates a new GameObject. Returns Success.")]
	public class Instantiate : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The position of the new GameObject")]
		public SharedVector3 position;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The rotation of the new GameObject")]
		public SharedQuaternion rotation = Quaternion.identity;

		[SharedRequired, BehaviorDesigner.Runtime.Tasks.Tooltip("The instantiated GameObject")]
		public SharedGameObject storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = (UnityEngine.Object.Instantiate(this.targetGameObject.Value, this.position.Value, this.rotation.Value) as GameObject);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.position = Vector3.zero;
			this.rotation = Quaternion.identity;
		}
	}
}
