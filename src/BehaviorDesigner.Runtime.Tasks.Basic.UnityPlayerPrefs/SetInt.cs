using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityPlayerPrefs
{
	[TaskCategory("Basic/PlayerPrefs"), TaskDescription("Sets the value with the specified key from the PlayerPrefs.")]
	public class SetInt : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The key to store")]
		public SharedString key;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The value to set")]
		public SharedInt value;

		public override TaskStatus OnUpdate()
		{
			PlayerPrefs.SetInt(this.key.Value, this.value.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.key = string.Empty;
			this.value = 0;
		}
	}
}
