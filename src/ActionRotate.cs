using BehaviorDesigner.Runtime.Tasks;
using System;

public class ActionRotate : BehaviorDesigner.Runtime.Tasks.Action
{
	public float mAIArgRotDegree;

	public float mAIArgRotSpeed;

	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().ActionRotate(this.transform.gameObject, this.mAIArgRotDegree, this.mAIArgRotSpeed))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
