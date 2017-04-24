using BehaviorDesigner.Runtime.Tasks;
using System;

public class ValueMP : Conditional
{
	public int mAIArgMaxPercent;

	public int mAIArgMinPercent;

	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().IsMPValue(this.transform, this.mAIArgMinPercent, this.mAIArgMaxPercent))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
