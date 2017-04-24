using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class MoveStratage : BehaviorDesigner.Runtime.Tasks.Action
{
	public SharedTransform mAIArgTarget;

	public int mAIArgStratageIndex;

	public SharedVector3 mAIArgFinalDest;

	public override TaskStatus OnUpdate()
	{
		return TaskStatus.Success;
	}
}
