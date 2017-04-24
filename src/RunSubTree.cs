using BehaviorDesigner.Runtime.Tasks;
using System;

public class RunSubTree : BehaviorDesigner.Runtime.Tasks.Action
{
	public string mAIArgTreeName;

	public override TaskStatus OnUpdate()
	{
		AIMgrUtil.GetAIMgrInterface().RunSubTree(this.transform.gameObject, this.mAIArgTreeName);
		return TaskStatus.Success;
	}
}
