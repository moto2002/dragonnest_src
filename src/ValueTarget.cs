using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class ValueTarget : Conditional
{
	public SharedTransform mAIArgTarget;

	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().IsValid(this.mAIArgTarget.Value))
		{
			return TaskStatus.Success;
		}
		AIMgrUtil.GetAIMgrInterface().ClearTarget(this.transform);
		return TaskStatus.Failure;
	}
}
