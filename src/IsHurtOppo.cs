using BehaviorDesigner.Runtime.Tasks;
using System;

public class IsHurtOppo : Conditional
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().IsHurtOppo(this.transform))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
