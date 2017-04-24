using BehaviorDesigner.Runtime.Tasks;
using System;

public class IsSkillChoosed : Conditional
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().IsSkillChoosed(this.transform))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
