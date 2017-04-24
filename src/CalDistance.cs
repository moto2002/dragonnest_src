using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class CalDistance : BehaviorDesigner.Runtime.Tasks.Action
{
	public SharedTransform mAIArgObject;

	public SharedFloat mAIArgDistance;

	public SharedVector3 mAIArgDestPoint;

	public override TaskStatus OnUpdate()
	{
		if (this.mAIArgObject.Value != null)
		{
			this.mAIArgDistance.Value = (this.transform.position - this.mAIArgObject.Value.position).magnitude;
		}
		else
		{
			this.mAIArgDistance.Value = (this.transform.position - this.mAIArgDestPoint.Value).magnitude;
		}
		return TaskStatus.Success;
	}
}
