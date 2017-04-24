using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class GetEntityPos : BehaviorDesigner.Runtime.Tasks.Action
{
	public int mAIArgIsPlayer;

	public int mAIArgTemplateId;

	public SharedVector3 mAIArgStorePos;

	public override TaskStatus OnUpdate()
	{
		return base.OnUpdate();
	}
}
