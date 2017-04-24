using BehaviorDesigner.Runtime.Tasks;
using System;

public class FindTargetByHitLevel : BehaviorDesigner.Runtime.Tasks.Action
{
	public bool mAIArgFilterImmortal;

	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().FindTargetByHitLevel(this.transform.gameObject, this.mAIArgFilterImmortal))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
