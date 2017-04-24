using BehaviorDesigner.Runtime.Tasks;
using System;

public class RemoveSceneBuff : BehaviorDesigner.Runtime.Tasks.Action
{
	public int mAIArgBuffId;

	public override TaskStatus OnUpdate()
	{
		return TaskStatus.Success;
	}
}
