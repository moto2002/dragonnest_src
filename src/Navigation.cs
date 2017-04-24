using BehaviorDesigner.Runtime.Tasks;
using System;

public class Navigation : BehaviorDesigner.Runtime.Tasks.Action
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().UpdateNavigation(this.transform.gameObject))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
