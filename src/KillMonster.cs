using BehaviorDesigner.Runtime.Tasks;
using System;

public class KillMonster : BehaviorDesigner.Runtime.Tasks.Action
{
	public int mAIArgMonsterId;

	public float mAIArgDelayTime;

	public override TaskStatus OnUpdate()
	{
		return TaskStatus.Success;
	}
}
