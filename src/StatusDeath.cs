using BehaviorDesigner.Runtime.Tasks;
using System;

public class StatusDeath : Conditional
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().IsAtState(this.transform.gameObject, 6))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
