using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class FindTargetByDistance : BehaviorDesigner.Runtime.Tasks.Action
{
	public SharedFloat mAIArgDistance;

	public bool mAIArgFilterImmortal;

	public float mAIArgAngle;

	public float mAIArgDelta;

	public int mAIArgTargetType;

	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().FindTargetByDistance(this.transform.gameObject, this.mAIArgDistance.Value, this.mAIArgFilterImmortal, this.mAIArgAngle, this.mAIArgDelta, this.mAIArgTargetType))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
