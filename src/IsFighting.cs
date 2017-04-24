using BehaviorDesigner.Runtime.Tasks;
using System;

public class IsFighting : Conditional
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().IsFighting(this.transform))
		{
			return TaskStatus.Success;
		}
		AIMgrUtil.GetAIMgrInterface().ClearTarget(this.transform);
		return TaskStatus.Failure;
	}
}
