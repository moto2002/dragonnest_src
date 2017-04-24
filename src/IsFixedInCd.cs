using BehaviorDesigner.Runtime.Tasks;
using System;

public class IsFixedInCd : Conditional
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().IsFixedInCd(this.transform))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
