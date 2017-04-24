using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class IsTargetImmortal : Conditional
{
	public SharedTransform mAIArgTarget;

	public override TaskStatus OnUpdate()
	{
		if (this.mAIArgTarget.Value == null)
		{
			return TaskStatus.Failure;
		}
		if (AIMgrUtil.GetAIMgrInterface().IsTargetImmortal(this.mAIArgTarget.Value.gameObject))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
