using BehaviorDesigner.Runtime.Tasks;
using System;

public class ValueFP : Conditional
{
	public int mAIArgMaxFP;

	public int mAIArgMinFP;

	public override TaskStatus OnUpdate()
	{
		return TaskStatus.Success;
	}
}
