using BehaviorDesigner.Runtime.Tasks;
using System;
using UnityEngine;

public class RandomEntityPos : BehaviorDesigner.Runtime.Tasks.Action
{
	public int mAIArgTemplateId;

	public float mAIArgRadius;

	public Vector3 mAIArgCenterPos;

	public Vector3 mAIArgFinalPos;

	public int mAIArgNearPlayerTemplateId;

	public override TaskStatus OnUpdate()
	{
		return base.OnUpdate();
	}
}
