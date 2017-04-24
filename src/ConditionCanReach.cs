using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class ConditionCanReach : BehaviorDesigner.Runtime.Tasks.Action
{
	public SharedInt mAIArgTemplateid;

	public SharedVector3 mAIArgDestPos;

	public override TaskStatus OnUpdate()
	{
		return TaskStatus.Success;
	}
}
