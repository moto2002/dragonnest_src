using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;
using UnityEngine;

public class SelectMoveTargetById : BehaviorDesigner.Runtime.Tasks.Action
{
	public SharedTransform mAIArgMoveTarget;

	public int mAIArgObjectId;

	public override TaskStatus OnUpdate()
	{
		Transform transform = AIMgrUtil.GetAIMgrInterface().SelectMoveTargetById(this.transform.gameObject, this.mAIArgObjectId);
		if (transform == null)
		{
			return TaskStatus.Failure;
		}
		this.mAIArgMoveTarget.Value = transform;
		return TaskStatus.Success;
	}
}
