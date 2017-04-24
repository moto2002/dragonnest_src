using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class DoCastSkill : BehaviorDesigner.Runtime.Tasks.Action
{
	public SharedTransform mAIArgTarget;

	public override TaskStatus OnUpdate()
	{
		if (this.mAIArgTarget.Value == null)
		{
			if (AIMgrUtil.GetAIMgrInterface().DoCastSkill(this.transform.gameObject, null))
			{
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}
		else
		{
			if (AIMgrUtil.GetAIMgrInterface().DoCastSkill(this.transform.gameObject, this.mAIArgTarget.Value.gameObject))
			{
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}
	}
}
