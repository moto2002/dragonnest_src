using BehaviorDesigner.Runtime.Tasks;
using System;

public class StatusRotate : Conditional
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().IsRotate(this.transform.gameObject))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
