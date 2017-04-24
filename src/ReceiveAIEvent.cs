using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;
using UnityEngine;

public class ReceiveAIEvent : BehaviorDesigner.Runtime.Tasks.Action
{
	public bool mAIArgDeprecate;

	public AIMsgType mAIArgMsgType;

	public SharedString mAIArgMsgStr;

	public SharedInt mAIArgTypeId;

	public SharedVector3 mAIArgPos;

	public SharedInt mAIArgSkillTemplateId;

	public SharedInt mAIArgSkillId;

	public SharedFloat mAIArgFloatArg;

	public override TaskStatus OnUpdate()
	{
		string text = AIMgrUtil.GetAIMgrInterface().ReceiveAIEvent(this.transform.gameObject, (int)this.mAIArgMsgType, this.mAIArgDeprecate);
		if (text == string.Empty)
		{
			return TaskStatus.Failure;
		}
		string[] array = text.Split(new char[]
		{
			' '
		});
		this.mAIArgMsgStr.Value = array[0];
		this.mAIArgTypeId.Value = int.Parse(array[1]);
		this.mAIArgPos.Value = new Vector3(float.Parse(array[2]), float.Parse(array[3]), float.Parse(array[4]));
		this.mAIArgSkillId.Value = int.Parse(array[5]);
		return TaskStatus.Success;
	}
}
