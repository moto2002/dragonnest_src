using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Math
{
	[TaskCategory("Basic/Math"), TaskDescription("Lerp the float by an amount.")]
	public class Lerp : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The from value")]
		public SharedFloat fromValue;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The to value")]
		public SharedFloat toValue;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The amount to lerp")]
		public SharedFloat lerpAmount;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The lerp resut")]
		public SharedFloat storeResult;

		public override TaskStatus OnUpdate()
		{
			this.storeResult.Value = Mathf.Lerp(this.fromValue.Value, this.toValue.Value, this.lerpAmount.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.fromValue = (this.toValue = (this.lerpAmount = (this.storeResult = 0f)));
		}
	}
}
