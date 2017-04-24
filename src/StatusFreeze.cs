using BehaviorDesigner.Runtime.Tasks;
using System;

public class StatusFreeze : Conditional
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().IsAtState(this.transform.gameObject, 4))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
