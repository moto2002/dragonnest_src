using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityString
{
	[TaskCategory("Basic/String"), TaskDescription("Stores a string with the specified format.")]
	public class Format : BehaviorDesigner.Runtime.Tasks.Action
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The format of the string")]
		public SharedString format;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Any variables to appear in the string")]
		public SharedGenericVariable[] variables;

		[RequiredField, BehaviorDesigner.Runtime.Tasks.Tooltip("The result of the format")]
		public SharedString storeResult;

		private object[] variableValues;

		public override void OnAwake()
		{
			this.variableValues = new object[this.variables.Length];
		}

		public override TaskStatus OnUpdate()
		{
			for (int i = 0; i < this.variableValues.Length; i++)
			{
				this.variableValues[i] = this.variables[i].Value.value.GetValue();
			}
			try
			{
				this.storeResult.Value = string.Format(this.format.Value, this.variableValues);
			}
			catch (Exception ex)
			{
				Debug.LogError(ex.Message);
				return TaskStatus.Failure;
			}
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.format = string.Empty;
			this.variables = null;
			this.storeResult = null;
		}
	}
}
