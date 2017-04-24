using BehaviorDesigner.Runtime.Tasks;
using System;

public class StatusBehit : Conditional
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().IsAtState(this.transform.gameObject, 5))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
