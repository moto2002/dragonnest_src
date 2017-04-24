using BehaviorDesigner.Runtime.Tasks;
using System;

public class IsWander : Conditional
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().IsWander(this.transform))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
