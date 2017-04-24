using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;
using UnityEngine;

public class SelectItemTarget : BehaviorDesigner.Runtime.Tasks.Action
{
	public SharedTransform mAIArgItemTarget;

	public override TaskStatus OnUpdate()
	{
		Transform transform = AIMgrUtil.GetAIMgrInterface().SelectItemTarget(this.transform.gameObject);
		if (transform == null)
		{
			return TaskStatus.Failure;
		}
		this.mAIArgItemTarget.Value = transform;
		return TaskStatus.Success;
	}
}
