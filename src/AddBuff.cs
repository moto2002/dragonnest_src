using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class AddBuff : BehaviorDesigner.Runtime.Tasks.Action
{
	public SharedInt mAIArgMonsterId;

	public SharedInt mAIArgBuffId;

	public SharedInt mAIArgBuffId2;

	public SharedInt mAIArgAddBuffTarget;

	public SharedInt mAIArgAddBuffWay;

	public SharedInt mAIArgPlayerProfId;

	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().AddBuff(this.mAIArgMonsterId.Value, this.mAIArgBuffId.Value, this.mAIArgBuffId2.Value))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
