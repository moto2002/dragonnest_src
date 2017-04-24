using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimator
{
	[TaskCategory("Basic/Animator"), TaskDescription("Sets the look at weight. Returns success immediately after.")]
	public class SetLookAtWeight : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("(0-1) the global weight of the LookAt, multiplier for other parameters.")]
		public SharedFloat weight;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("(0-1) determines how much the body is involved in the LookAt.")]
		public float bodyWeight;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("(0-1) determines how much the head is involved in the LookAt.")]
		public float headWeight = 1f;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("(0-1) determines how much the eyes are involved in the LookAt.")]
		public float eyesWeight;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("(0-1) 0.0 means the character is completely unrestrained in motion, 1.0 means he's completely clamped (look at becomes impossible), and 0.5 means he'll be able to move on half of the possible range (180 degrees).")]
		public float clampWeight = 0.5f;

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
			this.animator.SetLookAtWeight(this.weight.Value, this.bodyWeight, this.headWeight, this.eyesWeight, this.clampWeight);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.weight = 0f;
			this.bodyWeight = 0f;
			this.headWeight = 1f;
			this.eyesWeight = 0f;
			this.clampWeight = 0.5f;
		}
	}
}
