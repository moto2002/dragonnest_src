using BehaviorDesigner.Runtime.Tasks;
using System;

public class SelectTargetBySkillCircle : BehaviorDesigner.Runtime.Tasks.Action
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().SelectTargetBySkillCircle(this.transform.gameObject))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
