using BehaviorDesigner.Runtime.Tasks;
using System;

public class StatusMove : Conditional
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().IsAtState(this.transform.gameObject, 1))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
