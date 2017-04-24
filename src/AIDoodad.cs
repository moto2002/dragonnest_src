using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class AIDoodad : BehaviorDesigner.Runtime.Tasks.Action
{
	public SharedInt mAIArgDoodadId;

	public SharedInt mAIArgWaveId;

	public SharedVector3 mAIArgDoodadPos;

	public float mAIArgRandomPos;

	public float mAIArgDelayTime;

	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().AIDoodad(this.transform.gameObject, this.mAIArgDoodadId.Value, this.mAIArgWaveId.Value, this.mAIArgDoodadPos.Value, this.mAIArgRandomPos, this.mAIArgDelayTime))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
