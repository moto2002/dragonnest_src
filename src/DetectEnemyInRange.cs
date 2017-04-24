using BehaviorDesigner.Runtime.Tasks;
using System;

public class DetectEnemyInRange : BehaviorDesigner.Runtime.Tasks.Action
{
	public int mAIArgRangeType;

	public float mAIArgRadius;

	public float mAIArgAngle;

	public float mAIArgLength;

	public float mAIArgWidth;

	public float mAIArgOffsetLength;

	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().DetectEnemyInRange(this.transform.gameObject, this.mAIArgRangeType, this.mAIArgRadius, this.mAIArgAngle, this.mAIArgLength, this.mAIArgWidth, this.mAIArgOffsetLength))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
