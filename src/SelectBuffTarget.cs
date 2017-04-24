using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;
using UnityEngine;

public class SelectBuffTarget : BehaviorDesigner.Runtime.Tasks.Action
{
	public SharedTransform mAIArgBuffTarget;

	public override TaskStatus OnUpdate()
	{
		Transform transform = AIMgrUtil.GetAIMgrInterface().SelectBuffTarget(this.transform.gameObject);
		if (transform == null)
		{
			return TaskStatus.Failure;
		}
		this.mAIArgBuffTarget.Value = transform;
		return TaskStatus.Success;
	}
}
