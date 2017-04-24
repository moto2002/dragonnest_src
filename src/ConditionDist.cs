using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class ConditionDist : Conditional
{
	public SharedTransform mAIArgTarget;

	public SharedFloat mAIArgUpper;

	public SharedFloat mAIArgLower;

	public override TaskStatus OnUpdate()
	{
		if (this.mAIArgTarget.Value == null)
		{
			return TaskStatus.Failure;
		}
		float magnitude = (this.mAIArgTarget.Value.position - this.transform.position).magnitude;
		if (magnitude >= this.mAIArgLower.Value && magnitude <= this.mAIArgUpper.Value)
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
