using System;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityString
{
	[TaskCategory("Basic/String"), TaskDescription("Creates a string from multiple other strings.")]
	public class BuildString : BehaviorDesigner.Runtime.Tasks.Action
	{
		[Tooltip("The array of strings")]
		public SharedString[] source;

		[RequiredField, Tooltip("The stored result")]
		public SharedString storeResult;

		public override TaskStatus OnUpdate()
		{
			for (int i = 0; i < this.source.Length; i++)
			{
				SharedString expr_0D = this.storeResult;
				expr_0D.Value += this.source[i];
			}
			return TaskStatus.Success;
		}

		public override void OnReset()
		{
			this.source = null;
			this.storeResult = null;
		}
	}
}
