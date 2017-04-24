using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class PhysicalAttack : BehaviorDesigner.Runtime.Tasks.Action
{
	public SharedTransform mAIArgTarget;

	public override TaskStatus OnUpdate()
	{
		if (this.mAIArgTarget.Value == null)
		{
			return TaskStatus.Failure;
		}
		if (AIMgrUtil.GetAIMgrInterface().TryCastPhysicalSkill(this.transform.gameObject, this.mAIArgTarget.Value.gameObject))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
