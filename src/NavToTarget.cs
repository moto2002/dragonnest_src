using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;
using UnityEngine;

public class NavToTarget : BehaviorDesigner.Runtime.Tasks.Action
{
	public SharedTransform mAIArgTarget;

	public SharedTransform mAIArgNavTarget;

	public SharedVector3 mAIArgNavPos;

	public override TaskStatus OnUpdate()
	{
		if (this.mAIArgTarget.GetValue() == null)
		{
			if (this.mAIArgNavTarget.GetValue() == null)
			{
				if (false || this.mAIArgNavPos.Value == Vector3.zero)
				{
					return TaskStatus.Failure;
				}
				if (AIMgrUtil.GetAIMgrInterface().ActionNav(this.transform.gameObject, this.mAIArgNavPos.Value))
				{
					return TaskStatus.Success;
				}
				return TaskStatus.Failure;
			}
			else
			{
				if (AIMgrUtil.GetAIMgrInterface().NavToTarget(this.transform.gameObject, this.mAIArgNavTarget.Value.gameObject))
				{
					return TaskStatus.Success;
				}
				return TaskStatus.Failure;
			}
		}
		else
		{
			if (AIMgrUtil.GetAIMgrInterface().NavToTarget(this.transform.gameObject, this.mAIArgTarget.Value.gameObject))
			{
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}
	}
}
