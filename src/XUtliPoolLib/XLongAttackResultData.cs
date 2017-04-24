using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XLongAttackResultData
	{
		[SerializeField]
		public XResultBulletType Type;

		[DefaultValue(true), SerializeField]
		public bool WithCollision;

		[DefaultValue(false), SerializeField]
		public bool Follow;

		[DefaultValue(0f), SerializeField]
		public float Lifetime;

		[DefaultValue(0f), SerializeField]
		public float Velocity;

		[DefaultValue(0f), SerializeField]
		public float Radius;

		[SerializeField]
		public string Prefab;

		[DefaultValue(true), SerializeField]
		public bool TriggerOnce;

		[DefaultValue(false), SerializeField]
		public bool TriggerAtEnd;

		[DefaultValue(0), SerializeField]
		public int FireAngle;

		[SerializeField]
		public string HitGround_Fx;

		[DefaultValue(0f), SerializeField]
		public float HitGroundFx_LifeTime;

		[SerializeField]
		public string End_Fx;

		[DefaultValue(0f), SerializeField]
		public float EndFx_LifeTime;

		[DefaultValue(true), SerializeField]
		public bool EndFx_Ground;

		[SerializeField]
		public string Audio;

		[SerializeField]
		public AudioChannel Audio_Channel = AudioChannel.Skill;

		[SerializeField]
		public string End_Audio;

		[SerializeField]
		public AudioChannel End_Audio_Channel = AudioChannel.Skill;

		[DefaultValue(true), SerializeField]
		public bool FlyWithTerrain;

		[DefaultValue(true), SerializeField]
		public bool AimTargetCenter;

		[DefaultValue(0f), SerializeField]
		public float At_X;

		[DefaultValue(0f), SerializeField]
		public float At_Y;

		[DefaultValue(0f), SerializeField]
		public float At_Z;

		[DefaultValue(0f), SerializeField]
		public float Refine_Cycle;

		[DefaultValue(0), SerializeField]
		public int Refine_Count;

		public XLongAttackResultData()
		{
			this.WithCollision = true;
			this.TriggerOnce = true;
			this.EndFx_Ground = true;
			this.FlyWithTerrain = true;
			this.AimTargetCenter = true;
		}
	}
}
