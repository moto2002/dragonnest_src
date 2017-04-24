using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityAnimation
{
	[TaskCategory("Basic/Animation"), TaskDescription("Plays animation without any blending. Returns Success.")]
	public class Play : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
		public SharedGameObject targetGameObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The name of the animation")]
		public SharedString animationName;

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
			if (string.IsNullOrEmpty(this.animationName.Value))
			{
				this.animation.Play();
			}
			else
			{
				this.animation.Play(this.animationName.Value, this.playMode);
			}
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.targetGameObject = null;
			this.animationName.Value = string.Empty;
			this.playMode = PlayMode.StopSameLayer;
		}
	}
}
