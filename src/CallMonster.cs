using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;
using UnityEngine;
using XUtliPoolLib;

public class CallMonster : BehaviorDesigner.Runtime.Tasks.Action
{
	public SharedFloat mAIArgDist;

	public SharedFloat mAIArgAngle;

	public int mAIArgMonsterId;

	public int mAIArgCopyMonsterId;

	public int mAIArgMaxMonsterNum;

	public float mAIArgLifeTime;

	public float mAIArgDelayTime;

	public SharedVector3 mAIArgPos;

	public int mAIArgBornType;

	public Vector3 mAIArgPos1;

	public Vector3 mAIArgPos2;

	public Vector3 mAIArgPos3;

	public Vector3 mAIArgPos4;

	public Vector3 mAIArgFinalPos;

	public bool mAIArgForcePlace;

	public float mAIArgDeltaArg;

	public float mAIArgHPPercent;

	public override TaskStatus OnUpdate()
	{
		CallMonsterData callMonsterData = new CallMonsterData();
		callMonsterData.mAIArgDist = this.mAIArgDist.Value;
		callMonsterData.mAIArgAngle = this.mAIArgAngle.Value;
		callMonsterData.mAIArgMonsterId = this.mAIArgMonsterId;
		callMonsterData.mAIArgCopyMonsterId = this.mAIArgCopyMonsterId;
		callMonsterData.mAIArgLifeTime = this.mAIArgLifeTime;
		callMonsterData.mAIArgDelayTime = this.mAIArgDelayTime;
		callMonsterData.mAIArgPos = this.mAIArgPos.Value;
		callMonsterData.mAIArgBornType = this.mAIArgBornType;
		callMonsterData.mAIArgPos1 = this.mAIArgPos1;
		callMonsterData.mAIArgPos2 = this.mAIArgPos2;
		callMonsterData.mAIArgPos3 = this.mAIArgPos3;
		callMonsterData.mAIArgPos4 = this.mAIArgPos4;
		callMonsterData.mAIArgFinalPos = this.mAIArgFinalPos;
		callMonsterData.mAIArgForcePlace = this.mAIArgForcePlace;
		callMonsterData.mAIArgDeltaArg = this.mAIArgDeltaArg;
		callMonsterData.mAIArgHPPercent = this.mAIArgHPPercent;
		if (AIMgrUtil.GetAIMgrInterface().CallMonster(this.transform.gameObject, callMonsterData))
		{
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
