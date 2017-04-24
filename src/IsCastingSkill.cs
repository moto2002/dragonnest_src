using BehaviorDesigner.Runtime.Tasks;
using System;

public class IsCastingSkill : Conditional
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().IsCastSkill(this.transform.gameObject))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
