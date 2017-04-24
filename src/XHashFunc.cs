using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;
using XUtliPoolLib;

public class XHashFunc : BehaviorDesigner.Runtime.Tasks.Action
{
	public string mAIArgInput;

	public SharedInt mAIArgResult;

	public override TaskStatus OnUpdate()
	{
		this.mAIArgResult.Value = (int)XSingleton<XCommon>.singleton.XHash(this.mAIArgInput);
		return TaskStatus.Success;
	}
}
