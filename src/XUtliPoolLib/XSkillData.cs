using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	[Serializable]
	public class XSkillData
	{
		public static readonly string[] Skills = new string[]
		{
			"XJAComboSkill",
			"XArtsSkill",
			"XUltraSkill",
			"XCombinedSkill"
		};

		public static readonly string[] JA_Command = new string[]
		{
			"ToSkill",
			"ToJA_1_0",
			"ToJA_2_0",
			"ToJA_3_0",
			"ToJA_4_0",
			"ToJA_0_1",
			"ToJA_0_2",
			"ToJA_1_1",
			"ToJA_1_2",
			"ToJA_2_1",
			"ToJA_2_2",
			"ToJA_3_1",
			"ToJA_3_2",
			"ToJA_4_1",
			"ToJA_4_2",
			"ToJA_QTE"
		};

		public static readonly string[] Combined_Command = new string[]
		{
			"ToPhase",
			"ToPhase1",
			"ToPhase2",
			"ToPhase3",
			"ToPhase4",
			"ToPhase5",
			"ToPhase6",
			"ToPhase7",
			"ToPhase8",
			"ToPhase9"
		};

		public static readonly string[] JaOverrideMap = new string[]
		{
			"A",
			"AA",
			"AAA",
			"AAAA",
			"AAAAA",
			"AB",
			"ABB",
			"AAB",
			"AABB",
			"AAAB",
			"AAABB",
			"AAAAB",
			"AAAABB",
			"AAAAAB",
			"AAAAABB",
			"QTE"
		};

		public static readonly string[] CombinedOverrideMap = new string[]
		{
			"Phase0",
			"Phase1",
			"Phase2",
			"Phase3",
			"Phase4",
			"Phase5",
			"Phase6",
			"Phase7",
			"Phase8",
			"Phase9"
		};

		public static readonly string[] MultipleAttackOverrideMap = new string[]
		{
			"Forward",
			"RightForward",
			"Right",
			"RightBack",
			"LeftForward",
			"Left",
			"LeftBack",
			"Back"
		};

		[SerializeField]
		public string Name;

		[DefaultValue(1), SerializeField]
		public int TypeToken;

		[SerializeField]
		public string ClipName;

		[DefaultValue(0), SerializeField]
		public int SkillPosition;

		[DefaultValue(false), SerializeField]
		public bool IgnoreCollision;

		[DefaultValue(true), SerializeField]
		public bool NeedTarget;

		[DefaultValue(false), SerializeField]
		public bool ForCombinedOnly;

		[DefaultValue(false), SerializeField]
		public bool MultipleAttackSupported;

		[DefaultValue(0.75f), SerializeField]
		public float BackTowardsDecline;

		[SerializeField]
		public string PVP_Script_Name;

		[SerializeField]
		public List<XResultData> Result;

		[SerializeField]
		public List<XChargeData> Charge;

		[SerializeField]
		public List<XJAData> Ja;

		[SerializeField]
		public List<XHitData> Hit;

		[SerializeField]
		public List<XManipulationData> Manipulation;

		[SerializeField]
		public List<XFxData> Fx;

		[SerializeField]
		public List<XAudioData> Audio;

		[SerializeField]
		public List<XCameraEffectData> CameraEffect;

		[SerializeField]
		public List<XWarningData> Warning;

		[SerializeField]
		public List<XCombinedData> Combined;

		[SerializeField]
		public List<XMobUnitData> Mob;

		[SerializeField]
		public XScriptData Script;

		[SerializeField]
		public XLogicalData Logical;

		[SerializeField]
		public XCameraMotionData CameraMotion;

		[SerializeField]
		public XCameraPostEffectData CameraPostEffect;

		[SerializeField]
		public XCastChain Chain;

		[DefaultValue(1f), SerializeField]
		public float CoolDown;

		[DefaultValue(0f), SerializeField]
		public float Time;

		[DefaultValue(0f), SerializeField]
		public float Cast_Range_Upper;

		[DefaultValue(0f), SerializeField]
		public float Cast_Range_Lower;

		[DefaultValue(0f), SerializeField]
		public float Cast_Scope;

		[DefaultValue(0f), SerializeField]
		public float Cast_Scope_Shift;

		[DefaultValue(1f), SerializeField]
		public float CameraTurnBack;

		public XSkillData()
		{
			this.TypeToken = 1;
			this.NeedTarget = true;
			this.BackTowardsDecline = 0.75f;
			this.CameraTurnBack = 1f;
			this.CoolDown = 1f;
		}

		public static void PreLoadSkillForTemp(string skillprefix, string name)
		{
			XSkillData data = XSingleton<XResourceLoaderMgr>.singleton.GetData<XSkillData>(skillprefix + name);
			if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
			{
				XSkillData.PreLoadSkillRes(data, 1);
			}
		}

		public static void PreLoadSkillRes(XSkillData data, int count)
		{
			if (!string.IsNullOrEmpty(data.ClipName))
			{
				XSingleton<XResourceLoaderMgr>.singleton.GetAnimation(data.ClipName, true);
			}
			if (data.Fx != null)
			{
				for (int i = 0; i < data.Fx.Count; i++)
				{
					XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(data.Fx[i].Fx, count, ECreateHideType.DisableParticleRenderer);
				}
			}
		}

		public static void PreLoadSkillResEx(XSkillData data, int count)
		{
			if (!string.IsNullOrEmpty(data.ClipName))
			{
				XSingleton<XResourceLoaderMgr>.singleton.GetAnimation(data.ClipName, true);
			}
			if (data.Fx != null)
			{
				for (int i = 0; i < data.Fx.Count; i++)
				{
					XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(data.Fx[i].Fx, count, ECreateHideType.DisableParticleRenderer);
				}
			}
			if (data.Hit != null && data.Hit.Count > 0)
			{
				XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(data.Hit[0].Fx, 1, ECreateHideType.DisableParticleRenderer);
			}
			if (data.Warning != null)
			{
				for (int j = 0; j < data.Warning.Count; j++)
				{
					XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(data.Warning[j].Fx, count, ECreateHideType.DisableParticleRenderer);
				}
			}
			if (data.Result != null)
			{
				for (int k = 0; k < data.Result.Count; k++)
				{
					if (data.Result[k].LongAttackEffect)
					{
						XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(data.Result[k].LongAttackData.End_Fx, count, ECreateHideType.DisableParticleRenderer);
						XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(data.Result[k].LongAttackData.Prefab, count, ECreateHideType.DisableParticleRenderer);
					}
				}
			}
			if (data.Charge != null)
			{
				for (int l = 0; l < data.Charge.Count; l++)
				{
					if (data.Charge[l].Using_Curve)
					{
						XSingleton<XResourceLoaderMgr>.singleton.GetCurve(data.Charge[l].Curve_Forward);
						XSingleton<XResourceLoaderMgr>.singleton.GetCurve(data.Charge[l].Curve_Side);
						if (data.Charge[l].Using_Up)
						{
							XSingleton<XResourceLoaderMgr>.singleton.GetCurve(data.Charge[l].Curve_Up);
						}
					}
				}
			}
			if (data.CameraMotion != null && !string.IsNullOrEmpty(data.CameraMotion.Motion))
			{
				XSingleton<XResourceLoaderMgr>.singleton.GetAnimation(data.CameraMotion.Motion, true);
			}
		}
	}
}
