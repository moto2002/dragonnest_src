using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class ConditionPlayerNum : Conditional
{
	public int mAIArgPlayerBaseProf;

	public int mAIArgPlayerDetailProf;

	public SharedInt mAIArgNum;

	public override TaskStatus OnUpdate()
	{
		int playerProf = AIMgrUtil.GetAIMgrInterface().GetPlayerProf();
		if (this.mAIArgPlayerBaseProf == 0 && this.mAIArgPlayerDetailProf == 0)
		{
			this.mAIArgNum.Value = 1;
		}
		else
		{
			if (this.mAIArgPlayerBaseProf != 0 && playerProf % 10 == this.mAIArgPlayerBaseProf)
			{
				this.mAIArgNum.Value = 1;
			}
			if (this.mAIArgPlayerDetailProf != 0 && playerProf == this.mAIArgPlayerDetailProf)
			{
				this.mAIArgNum.Value = 1;
			}
		}
		return TaskStatus.Success;
	}
}
