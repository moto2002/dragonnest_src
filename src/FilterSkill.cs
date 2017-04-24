using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;
using XUtliPoolLib;

public class FilterSkill : BehaviorDesigner.Runtime.Tasks.Action
{
	public SharedTransform mAIArgTarget;

	public bool mAIArgUseMP;

	public bool mAIArgUseName;

	public bool mAIArgUseHP;

	public bool mAIArgUseCoolDown;

	public bool mAIArgUseAttackField;

	public bool mAIArgUseCombo;

	public bool mAIArgUseInstall;

	public ComboSkillType mAIArgSkillType;

	public string mAIArgSkillName;

	public bool mAIArgDetectAllPlayInAttackField;

	public int mAIArgMaxSkillNum;

	public override TaskStatus OnUpdate()
	{
		FilterSkillArg filterSkillArg = new FilterSkillArg();
		filterSkillArg.mAIArgTarget = this.mAIArgTarget.Value;
		filterSkillArg.mAIArgUseMP = this.mAIArgUseMP;
		filterSkillArg.mAIArgUseName = this.mAIArgUseName;
		filterSkillArg.mAIArgUseHP = this.mAIArgUseHP;
		filterSkillArg.mAIArgUseCoolDown = this.mAIArgUseCoolDown;
		filterSkillArg.mAIArgUseAttackField = this.mAIArgUseAttackField;
		filterSkillArg.mAIArgUseCombo = this.mAIArgUseCombo;
		filterSkillArg.mAIArgUseInstall = this.mAIArgUseInstall;
		filterSkillArg.mAIArgSkillType = (int)this.mAIArgSkillType;
		filterSkillArg.mAIArgSkillName = this.mAIArgSkillName;
		filterSkillArg.mAIArgDetectAllPlayInAttackField = this.mAIArgDetectAllPlayInAttackField;
		filterSkillArg.mAIArgMaxSkillNum = this.mAIArgMaxSkillNum;
		if (AIMgrUtil.GetAIMgrInterface().SelectSkill(this.transform.gameObject, filterSkillArg))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
