using BehaviorDesigner.Runtime.Tasks;
using System;

public class MixMonsterPos : BehaviorDesigner.Runtime.Tasks.Action
{
	public int mAIArgMixMonsterId0;

	public int mAIArgMixMonsterId1;

	public int mAIArgMixMonsterId2;

	public override TaskStatus OnUpdate()
	{
		return TaskStatus.Success;
	}
}
