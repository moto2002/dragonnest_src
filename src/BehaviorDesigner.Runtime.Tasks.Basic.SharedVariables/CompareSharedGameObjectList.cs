using System;
using System.Linq;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.SharedVariables
{
	[TaskCategory("Basic/SharedVariable"), TaskDescription("Returns success if the variable value is equal to the compareTo value.")]
	public class CompareSharedGameObjectList : Conditional
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The first variable to compare")]
		public SharedGameObjectList variable;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The variable to compare to")]
		public SharedGameObjectList compareTo;

		public override TaskStatus OnUpdate()
		{
			if (this.variable.Value == null && this.compareTo.Value != null)
			{
				return TaskStatus.Failure;
			}
			if (this.variable.Value == null && this.compareTo.Value == null)
			{
				return TaskStatus.Success;
			}
			if (this.variable.Value.Count != this.compareTo.Value.Count)
			{
				return TaskStatus.Failure;
			}
			return (this.variable.Value.Except(this.compareTo.Value).Count<GameObject>() <= 0) ? TaskStatus.Success : TaskStatus.Failure;
		}

		public override void OnReset()
		{
			this.variable = null;
			this.compareTo = null;
		}
	}
}
