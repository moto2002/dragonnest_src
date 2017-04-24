using BehaviorDesigner.Runtime.Tasks;
using System;

public class StatusIdle : Conditional
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().IsAtState(this.transform.gameObject, 0))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
