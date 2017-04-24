using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;
using UnityEngine;
using XUtliPoolLib;

public class SetDest : BehaviorDesigner.Runtime.Tasks.Action
{
	public SharedVector3 mAIArgFinalDest;

	public SharedTransform mAIArgTarget;

	public SharedTransform mAIArgNav;

	public SharedVector3 mAIArgBornPos;

	public SharedInt mAIArgTickCount;

	public float mAIArgRandomMax;

	public float mAIArgAdjustAngle;

	public SharedFloat mAIArgAdjustLength;

	public AdjustDirection mAIArgAdjustDir;

	public SetDestWay mAIArgSetDestType;

	private Vector3 _pos_vec;

	public override void OnAwake()
	{
		base.OnAwake();
		this._pos_vec = new Vector3(1f, 0f, 1f);
	}

	public override TaskStatus OnUpdate()
	{
		switch (this.mAIArgSetDestType)
		{
		case SetDestWay.Target:
			if (this.mAIArgTarget.Value == null)
			{
				return TaskStatus.Failure;
			}
			this.mAIArgFinalDest.Value = this.mAIArgTarget.Value.position;
			break;
		case SetDestWay.BornPos:
			this.mAIArgFinalDest.Value = this.mAIArgBornPos.Value;
			break;
		case SetDestWay.NavPos:
			if (this.mAIArgNav.Value == null)
			{
				return TaskStatus.Failure;
			}
			this.mAIArgFinalDest.Value = this.mAIArgNav.Value.position;
			break;
		}
		if (this.mAIArgAdjustLength.Value != 0f)
		{
			Vector3 point = Vector3.zero;
			if (this.mAIArgAdjustDir == AdjustDirection.TargetDir)
			{
				point = this.transform.position - this.mAIArgFinalDest.Value;
			}
			else if (this.mAIArgAdjustDir == AdjustDirection.TargetFace && this.mAIArgTarget.Value != null)
			{
				point = this.mAIArgTarget.Value.forward.normalized;
			}
			else if (this.mAIArgAdjustDir == AdjustDirection.SelfFace)
			{
				point = this.transform.forward.normalized;
			}
			int value = this.mAIArgTickCount.Value;
			Vector3 vector = Quaternion.Euler(new Vector3(0f, (float)(value % 2) * this.mAIArgAdjustAngle * 2f - this.mAIArgAdjustAngle, 0f)) * point;
			Vector3 vector2 = this.mAIArgFinalDest.Value + vector.normalized * this.mAIArgAdjustLength.Value;
			if (!AIMgrUtil.GetAIMgrInterface().IsPointInMap(vector2))
			{
				for (int i = 0; i < 18; i++)
				{
					float num = this.mAIArgAdjustAngle + (float)(i * 10);
					vector = Quaternion.Euler(new Vector3(0f, (float)(value % 2) * num * 2f - num, 0f)) * point;
					vector2 = this.mAIArgFinalDest.Value + vector.normalized * this.mAIArgAdjustLength.Value;
					if (AIMgrUtil.GetAIMgrInterface().IsPointInMap(vector2))
					{
						break;
					}
					num = this.mAIArgAdjustAngle - (float)(i * 10);
					vector = Quaternion.Euler(new Vector3(0f, (float)(value % 2) * num * 2f - num, 0f)) * point;
					vector2 = this.mAIArgFinalDest.Value + vector.normalized * this.mAIArgAdjustLength.Value;
					if (AIMgrUtil.GetAIMgrInterface().IsPointInMap(vector2))
					{
						break;
					}
				}
			}
			this.mAIArgFinalDest.Value = vector2;
		}
		if (this.mAIArgRandomMax > 0f)
		{
			this._pos_vec.x = XSingleton<XCommon>.singleton.RandomFloat(-0.5f, 0.5f);
			this._pos_vec.z = XSingleton<XCommon>.singleton.RandomFloat(-0.5f, 0.5f);
			this.mAIArgFinalDest.Value += this.mAIArgRandomMax * this._pos_vec.normalized;
		}
		return TaskStatus.Success;
	}
}
