using BehaviorDesigner.Runtime.Tasks;
using System;

public class DetectEnimyInSight : BehaviorDesigner.Runtime.Tasks.Action
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().DetectEnimyInSight(this.transform.gameObject))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
