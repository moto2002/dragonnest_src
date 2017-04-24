using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class ConditionMonsterNum : Conditional
{
	public SharedInt mAIArgNum;

	public int mAIArgMonsterId;

	public override TaskStatus OnUpdate()
	{
		return TaskStatus.Success;
	}
}
