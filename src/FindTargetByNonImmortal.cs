using BehaviorDesigner.Runtime.Tasks;
using System;

public class FindTargetByNonImmortal : BehaviorDesigner.Runtime.Tasks.Action
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().FindTargetByNonImmortal(this.transform.gameObject))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
