using BehaviorDesigner.Runtime.Tasks;
using System;

public class CallScript : BehaviorDesigner.Runtime.Tasks.Action
{
	public string mAIArgFuncName;

	public float mAIArgDelayTime;

	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().CallScript(this.transform.gameObject, this.mAIArgFuncName, this.mAIArgDelayTime))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
