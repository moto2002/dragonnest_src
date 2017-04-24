using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimator
{
	[TaskCategory("Basic/Animator"), TaskDescription("Plays an animator state. Returns Success.")]
	public class Play : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The name of the state")]
		public SharedString stateName;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The layer where the state is")]
		public int layer = -1;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The normalized time at which the state will play")]
		public float normalizedTime = float.NegativeInfinity;

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
				Debug.LogWarning("Animator is null");
				return TaskStatus.Failure;
			}
			this.animator.Play(this.stateName.Value, this.layer, this.normalizedTime);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.stateName = string.Empty;
			this.layer = -1;
			this.normalizedTime = float.NegativeInfinity;
		}
	}
}
