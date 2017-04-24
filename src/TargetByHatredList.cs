using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class TargetByHatredList : BehaviorDesigner.Runtime.Tasks.Action
{
	public SharedFloat mAIArgDistance;

	public bool mAIArgFilterImmortal;

	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().FindTargetByHartedList(this.transform.gameObject, this.mAIArgFilterImmortal))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
