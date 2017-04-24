using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Math
{
	[TaskCategory("Basic/Math"), TaskDescription("Sets a random float value")]
	public class RandomFloat : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The minimum amount")]
		public SharedFloat min;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The maximum amount")]
		public SharedFloat max;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Is the maximum value inclusive?")]
		public bool inclusive;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The variable to store the result")]
		public SharedFloat storeResult;

		public override TaskStatus OnUpdate()
		{
			if (this.inclusive)
			{
				this.storeResult.Value = UnityEngine.Random.Range(this.min.Value, this.max.Value + 1f);
			}
			else
			{
				this.storeResult.Value = UnityEngine.Random.Range(this.min.Value, this.max.Value);
			}
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.min.Value = 0f;
			this.max.Value = 0f;
			this.inclusive = false;
			this.storeResult.Value = 0f;
		}
	}
}
