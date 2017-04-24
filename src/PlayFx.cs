using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class PlayFx : BehaviorDesigner.Runtime.Tasks.Action
{
	public string mAIArgFxName;

	public SharedVector3 mAIArgFxPos;

	public float mAIArgDelayTime;

	public override TaskStatus OnUpdate()
	{
		return TaskStatus.Failure;
	}
}
