using BehaviorDesigner.Runtime.Tasks;
using System;

public class DoSelectRandomTarget : BehaviorDesigner.Runtime.Tasks.Action
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().DoSelectRandomTarget(this.transform.gameObject))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
