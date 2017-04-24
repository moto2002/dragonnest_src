using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject
{
	[TaskCategory("Basic/GameObject"), TaskDescription("Finds a GameObject by tag. Returns Success.")]
	public class FindGameObjectsWithTag : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The tag of the GameObject to find")]
		public SharedString tag;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The objects found by name")]
		public SharedGameObjectList storeValue;

		public override TaskStatus OnUpdate()
		{
			GameObject[] array = GameObject.FindGameObjectsWithTag(this.tag.Value);
			for (int i = 0; i < array.Length; i++)
			{
				this.storeValue.Value.Add(array[i]);
			}
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.tag.Value = null;
			this.storeValue.Value = null;
		}
	}
}
