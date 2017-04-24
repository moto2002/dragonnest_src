using BehaviorDesigner.Runtime.Tasks;
using System;

public class IsOppoCastingSkill : Conditional
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().IsOppoCastingSkill(this.transform))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
