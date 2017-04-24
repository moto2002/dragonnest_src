using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject
{
	[TaskCategory("Basic/GameObject"), TaskDescription("Finds a GameObject by tag. Returns Success.")]
	public class FindWithTag : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The tag of the GameObject to find")]
		public SharedString tag;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The object found by name")]
		public SharedGameObject storeValue;

		public override TaskStatus OnUpdate()
		{
			this.storeValue.Value = GameObject.FindWithTag(this.tag.Value);
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.tag.Value = null;
			this.storeValue.Value = null;
		}
	}
}
