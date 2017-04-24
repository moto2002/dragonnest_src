using BehaviorDesigner.Runtime.Tasks;
using System;

public class SetExString : BehaviorDesigner.Runtime.Tasks.Action
{
	public override TaskStatus OnUpdate()
	{
		return TaskStatus.Success;
	}
}
