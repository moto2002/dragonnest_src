using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class ValueDistance : Conditional
{
	public SharedTransform mAIArgTarget;

	public SharedFloat mAIArgMaxDistance;

	public override TaskStatus OnUpdate()
	{
		if (this.mAIArgTarget.Value == null)
		{
			return TaskStatus.Failure;
		}
		if ((this.transform.position - this.mAIArgTarget.Value.position).magnitude <= this.mAIArgMaxDistance.Value)
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
