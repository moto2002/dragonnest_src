using BehaviorDesigner.Runtime.Tasks;
using System;

public class DoSelectNearest : BehaviorDesigner.Runtime.Tasks.Action
{
	public override TaskStatus OnUpdate()
	{
		if (AIMgrUtil.GetAIMgrInterface().DoSelectNearest(this.transform.gameObject))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
