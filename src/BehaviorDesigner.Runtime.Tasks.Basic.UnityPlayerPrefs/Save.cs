using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityPlayerPrefs
{
	[TaskCategory("Basic/PlayerPrefs"), TaskDescription("Saves the PlayerPrefs.")]
	public class Save : BehaviorDesigner.Runtime.Tasks.Action
	{
		public override TaskStatus OnUpdate()
		{
			PlayerPrefs.Save();
			return TaskStatus.Success;
		}
	}
}
