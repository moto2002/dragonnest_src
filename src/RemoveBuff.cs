using BehaviorDesigner.Runtime.Tasks;
using System;

public class RemoveBuff : BehaviorDesigner.Runtime.Tasks.Action
{
	public int mAIArgMonsterId;

	public int mAIArgBuffId;

	public override TaskStatus OnUpdate()
	{
		return TaskStatus.Success;
	}
}
