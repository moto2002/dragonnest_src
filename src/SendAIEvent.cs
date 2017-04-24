using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class SendAIEvent : BehaviorDesigner.Runtime.Tasks.Action
{
	public AIMsgTarget mAIArgMsgTo;

	public AIMsgType mAIArgMsgType;

	public int mAIArgEntityTypeId;

	public string mAIArgMsgStr;

	public SharedVector3 mAIArgPos;

	public float mAIArgDelayTime;

	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().SendAIEvent(this.transform.gameObject, (int)this.mAIArgMsgTo, (int)this.mAIArgMsgType, this.mAIArgEntityTypeId, this.mAIArgMsgStr, this.mAIArgDelayTime, this.mAIArgPos.Value))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
