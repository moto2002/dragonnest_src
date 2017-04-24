using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimation
{
	[TaskCategory("Basic/Animation"), TaskDescription("Cross fades an animation after previous animations has finished playing. Returns Success.")]
	public class CrossFadeQueued : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The name of the animation")]
		public SharedString animationName;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The amount of time it takes to blend")]
		public float fadeLength = 0.3f;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Specifies when the animation should start playing")]
		public QueueMode queue;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The play mode of the animation")]
		public PlayMode playMode;

		private Animation animation;

		private GameObject prevGameObject;

		public override void OnStart()
		{
			GameObject defaultGameObject = base.GetDefaultGameObject(this.targetGameObject.Value);
			if (defaultGameObject != this.prevGameObject)
			{
				this.animation = defaultGameObject.GetComponent<Animation>();
				this.prevGameObject = defaultGameObject;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.animation == null)
			{
				return TaskStatus.Failure;
			}
			this.animation.CrossFadeQueued(this.animationName.Value, this.fadeLength, this.queue, this.playMode);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.animationName.Value = string.Empty;
			this.fadeLength = 0.3f;
			this.queue = QueueMode.CompleteOthers;
			this.playMode = PlayMode.StopSameLayer;
		}
	}
}
