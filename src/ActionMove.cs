using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;
using UnityEngine;

public class ActionMove : BehaviorDesigner.Runtime.Tasks.Action
{
	public SharedVector3 mAIArgMoveDir;

	public SharedVector3 mAIArgMoveDest;

	public SharedFloat mAIArgMoveSpeed;

	public override TaskStatus OnUpdate()
	{
		if ((this.mAIArgMoveDest.Value - this.transform.position).magnitude <= 0.01f)
		{
			return TaskStatus.Failure;
		}
		if (this.mAIArgMoveDir.Value == Vector3.zero)
		{
			this.mAIArgMoveDir.Value = (this.mAIArgMoveDest.Value - this.transform.position).normalized;
			this.mAIArgMoveDir.Value.Set(this.mAIArgMoveDir.Value.x, 0f, this.mAIArgMoveDir.Value.z);
		}
		if (this.mAIArgMoveDest.Value == Vector3.zero)
		{
			this.mAIArgMoveDest.Value = this.transform.position + this.mAIArgMoveDir.Value.normalized * 50f;
		}
		if (AIMgrUtil.GetAIMgrInterface().ActionMove(this.transform.gameObject, this.mAIArgMoveDir.Value, this.mAIArgMoveDest.Value, this.mAIArgMoveSpeed.Value))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
