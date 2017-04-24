using BehaviorDesigner.Runtime.Tasks;
using System;

public class IsQTEState : Conditional
{
	public XQTEState mAIArgQTEState;

	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().HasQTE(this.transform.gameObject, (int)this.mAIArgQTEState))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
