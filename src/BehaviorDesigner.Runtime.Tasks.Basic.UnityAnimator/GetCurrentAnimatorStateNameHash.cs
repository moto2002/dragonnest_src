using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimator
{
	[TaskCategory("Basic/Animator"), TaskDescription("Gets the current state hash. Returns Success.")]
	public class GetCurrentAnimatorStateNameHash : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The layer to operate on")]
		public SharedInt layerIndex;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The current state hash")]
		public SharedInt storeValue;

		private Animator animator;

		private GameObject prevGameObject;

		public override void OnStart()
		{
			GameObject defaultGameObject = base.GetDefaultGameObject(this.targetGameObject.Value);
			if (defaultGameObject != this.prevGameObject)
			{
				this.animator = defaultGameObject.GetComponent<Animator>();
				this.prevGameObject = defaultGameObject;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.animator == null)
			{
				return TaskStatus.Failure;
			}
			this.storeValue.Value = this.animator.GetCurrentAnimatorStateInfo(this.layerIndex.Value).nameHash;
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.layerIndex = 0;
			this.storeValue = 0;
		}
	}
}
