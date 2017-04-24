using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class TargetQTEState : Conditional
{
	public SharedTransform mAIArgTarget;

	public XQTEState mAIArgQTEState;

	public override TaskStatus OnUpdate()
	{
		if (this.mAIArgTarget.Value == null)
		{
			return TaskStatus.Failure;
		}
		if (AIMgrUtil.GetAIMgrInterface().HasQTE(this.mAIArgTarget.Value.gameObject, (int)this.mAIArgQTEState))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
