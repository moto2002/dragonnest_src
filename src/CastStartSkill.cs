using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class CastStartSkill : BehaviorDesigner.Runtime.Tasks.Action
{
	public SharedTransform mAIArgTarget;

	public override TaskStatus OnUpdate()
	{
		return TaskStatus.Failure;
	}
}
