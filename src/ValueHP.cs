using BehaviorDesigner.Runtime.Tasks;
using System;

public class ValueHP : Conditional
{
	public int mAIArgMaxPercent;

	public int mAIArgMinPercent;

	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().IsHPValue(this.transform, this.mAIArgMinPercent, this.mAIArgMaxPercent))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
