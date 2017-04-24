using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=22"), TaskDescription("Wait a specified amount of time. The task will return running until the task is done waiting. It will return success after the wait time has elapsed."), TaskIcon("{SkinColor}WaitIcon.png")]
	public class Wait : Action
	{
		[Tooltip("The amount of time to wait")]
		public SharedFloat waitTime = 1f;

		[Tooltip("Should the wait be randomized?")]
		public SharedBool randomWait = false;

		[Tooltip("The minimum wait time if random wait is enabled")]
		public SharedFloat randomWaitMin = 1f;

		[Tooltip("The maximum wait time if random wait is enabled")]
		public SharedFloat randomWaitMax = 1f;

		private float waitDuration;

		private float startTime;

		private float pauseTime;

		public override void OnStart()
		{
			this.startTime = Time.time;
			if (this.randomWait.Value)
			{
				this.waitDuration = UnityEngine.Random.Range(this.randomWaitMin.Value, this.randomWaitMax.Value);
			}
			else
			{
				this.waitDuration = this.waitTime.Value;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (this.startTime + this.waitDuration < Time.time)
			{
				return TaskStatus.Success;
			}
			return TaskStatus.Running;
		}

		public override void OnPause(bool paused)
		{
			if (paused)
			{
				this.pauseTime = Time.time;
			}
			else
			{
				this.startTime += Time.time - this.pauseTime;
			}
		}

		public override void OnReset()
		{
			this.waitTime = 1f;
			this.randomWait = false;
			this.randomWaitMin = 1f;
			this.randomWaitMax = 1f;
		}
	}
}
