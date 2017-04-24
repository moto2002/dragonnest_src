using BehaviorDesigner.Runtime.Tasks;
using System;

public class DoSelectFarthest : BehaviorDesigner.Runtime.Tasks.Action
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().DoSelectFarthest(this.transform.gameObject))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
