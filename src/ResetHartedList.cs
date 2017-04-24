using BehaviorDesigner.Runtime.Tasks;
using System;

public class ResetHartedList : BehaviorDesigner.Runtime.Tasks.Action
{
	public override TaskStatus OnUpdate()
	{
		AIMgrUtil.GetAIMgrInterface().ResetHartedList(this.transform.gameObject);
		return TaskStatus.Success;
	}
}
