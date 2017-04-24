using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SceneTable : CVSReader
	{
		public class RowData
		{
			public int id;

			public int type;

			public string configFile;

			public Seq3ListRef<float> StartPos;

			public float[] StartRot;

			public string sceneFile;

			public int syncMode;

			public string BlockFilePath;

			public int[] UIPos;

			public int Exp;

			public int Money;

			public bool IsBoss;

			public int Chapter;

			public string Comment;

			public int RecommendPower;

			public int[] Drop1;

			public int[] Drop2;

			public int[] Drop3;

			public int[] Drop4;

			public int[] Drop5;

			public int RequiredLevel;

			public string UIIcon;

			public int FirstDownExp;

			public int[] FirstDownDrop;

			public int FirstDownMoney;

			public int[] ViewableDropList;

			public string BossAvatar;

			public Seq2ListRef<int> FatigueCost;

			public string EndCutScene;

			public float EndCutSceneTime;

			public uint GoldDropID;

			public uint SilverDropID;

			public uint CopperDropID;

			public Seq2ListRef<int> WinCondition;

			public Seq2ListRef<int> LoseCondition;

			public int DayLimit;

			public bool CanDrawBox;

			public bool HasFlyOut;

			public uint DayLimitGroupID;

			public string DynamicScene;

			public bool IsStaticScene;

			public Seq2Ref<uint> ReviveTime;

			public bool CanPause;

			public int[] OperationSettings;

			public string BossIcon;

			public int CoolDown;

			public string BGM;

			public bool ShowUp;

			public Seq2ListRef<uint> FirstSSS;

			public int[] PreScene;

			public int SceneChest;

			public int[] BoxUIPos;

			public int LineRoleCount;

			public string[] LoadingTips;

			public string[] LoadingPic;

			public bool SceneCanNavi;

			public int RandomTaskType;

			public int[] RandomTaskSpecify;

			public bool UseSupplement;

			public float HurtCoef;

			public string MiniMap;

			public int[] MiniMapSize;

			public int MiniMapRotation;

			public int PreTask;

			public bool SwitchToSelf;

			public string SceneAI;

			public bool ShowAutoFight;

			public float PPTCoff;

			public float GuildExpBounus;

			public string FailText;

			public int WinDelayTime;

			public string RecommendHint;

			public uint TeamInfoDefaultTab;

			public uint CombatType;

			public int SweepNeedPPT;

			public uint ReviveNumb;

			public Seq2ListRef<uint> ReviveCost;

			public bool CanRevive;

			public uint DiamondDropID;

			public Seq2ListRef<uint> SBox;

			public Seq2ListRef<uint> SSBox;

			public Seq2ListRef<uint> SSSBox;

			public int[] TimeCounter;

			public bool HasComboBuff;

			public bool DisplayPet;

			public int AutoReturn;

			public uint StoryDriver;

			public uint MinPassTime;

			public Seq2ListRef<uint> ReviveMoneyCost;

			public Seq2ListRef<uint> ReviveBuff;

			public string LeaveSceneTip;

			public string ReviveBuffTip;

			public Seq2ListRef<uint> ExpSealReward;

			public bool ShowSkill;

			public string WinConditionTips;

			public float DelayTransfer;

			public Seq2ListRef<uint> Buff;

			public Seq2Ref<double> DPS;

			public float[] StartFace;

			public bool IsCanQuit;

			public uint CanVIPRevive;

			public bool ShowNormalAttack;

			public bool HideTeamIndicate;

			public string BattleExplainTips;

			public int[] ShieldSight;

			public string ScenePath;

			public string EnvSet;

			public float SpecifiedTargetLocatedRange;

			public int[] SpactivityActiveDrop;
		}

		public List<SceneTable.RowData> Table = new List<SceneTable.RowData>();

		public SceneTable.RowData GetBySceneID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchSceneID(key, 0, this.Table.Count - 1);
		}

		private SceneTable.RowData BinarySearchSceneID(int key, int min, int max)
		{
			SceneTable.RowData rowData = this.Table[min];
			if (rowData.id == key)
			{
				return rowData;
			}
			SceneTable.RowData rowData2 = this.Table[max];
			if (rowData2.id == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			SceneTable.RowData rowData3 = this.Table[num];
			if (rowData3.id.CompareTo(key) > 0)
			{
				return this.BinarySearchSceneID(key, min, num);
			}
			if (rowData3.id.CompareTo(key) < 0)
			{
				return this.BinarySearchSceneID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowSceneID(int key, SceneTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			SceneTable.RowData rowData = this.Table[min];
			if (rowData.id.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SceneTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			SceneTable.RowData rowData2 = this.Table[max];
			if (rowData2.id.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SceneTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			if (max - min <= 1)
			{
				this.Table.Insert(min + 1, row);
				return;
			}
			int num = min + (max - min) / 2;
			SceneTable.RowData rowData3 = this.Table[num];
			if (rowData3.id.CompareTo(key) > 0)
			{
				this.AddRowSceneID(key, row, min, num);
				return;
			}
			if (rowData3.id.CompareTo(key) < 0)
			{
				this.AddRowSceneID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: SceneTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"SceneID",
				"SceneType",
				"SceneFile",
				"StartPos",
				"StartRot",
				"UnitySceneFile",
				"SyncMode",
				"BlockFilePath",
				"UIPos",
				"Exp",
				"Money",
				"IsBoss",
				"Chapter",
				"Comment",
				"RecommendPower",
				"Drop1",
				"Drop2",
				"Drop3",
				"Drop4",
				"Drop5",
				"RequiredLevel",
				"UIIcon",
				"FirstDownExp",
				"FirstDownDrop",
				"FirstDownMoney",
				"ViewableDropList",
				"BossAvatar",
				"FatigueCost",
				"EndCutScene",
				"EndCutSceneTime",
				"GoldDropID",
				"SilverDropID",
				"CopperDropID",
				"WinCondition",
				"LoseCondition",
				"DayLimit",
				"CanDrawBox",
				"HasFlyOut",
				"DayLimitGroupID",
				"DynamicScene",
				"IsStaticScene",
				"ReviveTime",
				"CanPause",
				"OperationSettings",
				"BossIcon",
				"CoolDown",
				"BGM",
				"ShowUp",
				"FirstSSS",
				"PreScene",
				"SceneChest",
				"BoxUIPos",
				"LineRoleCount",
				"LoadingTips",
				"LoadingPic",
				"SceneCanNavi",
				"RandomTaskType",
				"RandomTaskSpecify",
				"UseSupplement",
				"HurtCoef",
				"MiniMap",
				"MiniMapSize",
				"MiniMapRotation",
				"PreTask",
				"SwitchToSelf",
				"SceneAI",
				"ShowAutoFight",
				"PPTCoff",
				"GuildExpBounus",
				"FailText",
				"WinDelayTime",
				"RecommendHint",
				"TeamInfoDefaultTab",
				"CombatType",
				"SweepNeedPPT",
				"ReviveNumb",
				"ReviveCost",
				"CanRevive",
				"DiamondDropID",
				"SBox",
				"SSBox",
				"SSSBox",
				"TimeCounter",
				"HasComboBuff",
				"DisplayPet",
				"AutoReturn",
				"StoryDriver",
				"MinPassTime",
				"ReviveMoneyCost",
				"ReviveBuff",
				"LeaveSceneTip",
				"ReviveBuffTip",
				"ExpSealReward",
				"ShowSkill",
				"WinConditionTips",
				"DelayTransfer",
				"Buff",
				"DPS",
				"StartFace",
				"IsCanQuit",
				"CanVIPRevive",
				"ShowNormalAttack",
				"HideTeamIndicate",
				"BattleExplainTips",
				"ShieldSight",
				"ScenePath",
				"EnvSet",
				"SpecifiedTargetLocatedRange",
				"SpactivityActiveDrop"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SceneTable.RowData rowData = new SceneTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.id))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.configFile))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[3]], ref rowData.StartPos, CVSReader.floatParse, "3F"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.StartRot))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.sceneFile))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.syncMode))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.BlockFilePath))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.UIPos))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.Exp))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.Money))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.IsBoss))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.Chapter))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.Comment))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.RecommendPower))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[15]], ref rowData.Drop1))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.Drop2))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[17]], ref rowData.Drop3))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[18]], ref rowData.Drop4))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[19]], ref rowData.Drop5))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[20]], ref rowData.RequiredLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[21]], ref rowData.UIIcon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[22]], ref rowData.FirstDownExp))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[23]], ref rowData.FirstDownDrop))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[24]], ref rowData.FirstDownMoney))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[25]], ref rowData.ViewableDropList))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[26]], ref rowData.BossAvatar))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[27]], ref rowData.FatigueCost, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[28]], ref rowData.EndCutScene))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[29]], ref rowData.EndCutSceneTime))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[30]], ref rowData.GoldDropID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[31]], ref rowData.SilverDropID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[32]], ref rowData.CopperDropID))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[33]], ref rowData.WinCondition, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[34]], ref rowData.LoseCondition, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[35]], ref rowData.DayLimit))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[36]], ref rowData.CanDrawBox))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[37]], ref rowData.HasFlyOut))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[38]], ref rowData.DayLimitGroupID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[39]], ref rowData.DynamicScene))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[40]], ref rowData.IsStaticScene))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[41]], ref rowData.ReviveTime, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[42]], ref rowData.CanPause))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[43]], ref rowData.OperationSettings))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[44]], ref rowData.BossIcon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[45]], ref rowData.CoolDown))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[46]], ref rowData.BGM))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[47]], ref rowData.ShowUp))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[48]], ref rowData.FirstSSS, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[49]], ref rowData.PreScene))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[50]], ref rowData.SceneChest))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[51]], ref rowData.BoxUIPos))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[52]], ref rowData.LineRoleCount))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[53]], ref rowData.LoadingTips))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[54]], ref rowData.LoadingPic))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[55]], ref rowData.SceneCanNavi))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[56]], ref rowData.RandomTaskType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[57]], ref rowData.RandomTaskSpecify))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[58]], ref rowData.UseSupplement))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[59]], ref rowData.HurtCoef))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[60]], ref rowData.MiniMap))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[61]], ref rowData.MiniMapSize))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[62]], ref rowData.MiniMapRotation))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[63]], ref rowData.PreTask))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[64]], ref rowData.SwitchToSelf))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[65]], ref rowData.SceneAI))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[66]], ref rowData.ShowAutoFight))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[67]], ref rowData.PPTCoff))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[68]], ref rowData.GuildExpBounus))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[69]], ref rowData.FailText))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[70]], ref rowData.WinDelayTime))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[71]], ref rowData.RecommendHint))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[72]], ref rowData.TeamInfoDefaultTab))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[73]], ref rowData.CombatType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[74]], ref rowData.SweepNeedPPT))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[75]], ref rowData.ReviveNumb))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[76]], ref rowData.ReviveCost, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[77]], ref rowData.CanRevive))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[78]], ref rowData.DiamondDropID))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[79]], ref rowData.SBox, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[80]], ref rowData.SSBox, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[81]], ref rowData.SSSBox, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[82]], ref rowData.TimeCounter))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[83]], ref rowData.HasComboBuff))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[84]], ref rowData.DisplayPet))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[85]], ref rowData.AutoReturn))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[86]], ref rowData.StoryDriver))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[87]], ref rowData.MinPassTime))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[88]], ref rowData.ReviveMoneyCost, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[89]], ref rowData.ReviveBuff, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[90]], ref rowData.LeaveSceneTip))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[91]], ref rowData.ReviveBuffTip))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[92]], ref rowData.ExpSealReward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[93]], ref rowData.ShowSkill))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[94]], ref rowData.WinConditionTips))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[95]], ref rowData.DelayTransfer))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[96]], ref rowData.Buff, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<double>(Fields[this.ColMap[97]], ref rowData.DPS, CVSReader.doubleParse, "2D"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[98]], ref rowData.StartFace))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[99]], ref rowData.IsCanQuit))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[100]], ref rowData.CanVIPRevive))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[101]], ref rowData.ShowNormalAttack))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[102]], ref rowData.HideTeamIndicate))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[103]], ref rowData.BattleExplainTips))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[104]], ref rowData.ShieldSight))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[105]], ref rowData.ScenePath))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[106]], ref rowData.EnvSet))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[107]], ref rowData.SpecifiedTargetLocatedRange))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[108]], ref rowData.SpactivityActiveDrop))
			{
				return false;
			}
			this.AddRowSceneID(rowData.id, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.WriteSeqList<float>(writer, Fields[this.ColMap[3]], CVSReader.floatParse, 3, "F");
			base.WriteArray<float>(writer, Fields[this.ColMap[4]], CVSReader.floatParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse);
			base.Write(writer, false, Fields[this.ColMap[11]]);
			base.Write<int>(writer, Fields[this.ColMap[12]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[13]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[14]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[15]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[16]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[17]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[18]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[19]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[20]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[21]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[22]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[23]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[24]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[25]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[26]], CVSReader.stringParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[27]], CVSReader.intParse, 2, "I");
			base.Write<string>(writer, Fields[this.ColMap[28]], CVSReader.stringParse);
			base.Write<float>(writer, Fields[this.ColMap[29]], CVSReader.floatParse);
			base.Write<uint>(writer, Fields[this.ColMap[30]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[31]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[32]], CVSReader.uintParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[33]], CVSReader.intParse, 2, "I");
			base.WriteSeqList<int>(writer, Fields[this.ColMap[34]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[35]], CVSReader.intParse);
			base.Write(writer, false, Fields[this.ColMap[36]]);
			base.Write(writer, false, Fields[this.ColMap[37]]);
			base.Write<uint>(writer, Fields[this.ColMap[38]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[39]], CVSReader.stringParse);
			base.Write(writer, false, Fields[this.ColMap[40]]);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[41]], CVSReader.uintParse, 2, "U");
			base.Write(writer, false, Fields[this.ColMap[42]]);
			base.WriteArray<int>(writer, Fields[this.ColMap[43]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[44]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[45]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[46]], CVSReader.stringParse);
			base.Write(writer, false, Fields[this.ColMap[47]]);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[48]], CVSReader.uintParse, 2, "U");
			base.WriteArray<int>(writer, Fields[this.ColMap[49]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[50]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[51]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[52]], CVSReader.intParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[53]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[54]], CVSReader.stringParse);
			base.Write(writer, false, Fields[this.ColMap[55]]);
			base.Write<int>(writer, Fields[this.ColMap[56]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[57]], CVSReader.intParse);
			base.Write(writer, false, Fields[this.ColMap[58]]);
			base.Write<float>(writer, Fields[this.ColMap[59]], CVSReader.floatParse);
			base.Write<string>(writer, Fields[this.ColMap[60]], CVSReader.stringParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[61]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[62]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[63]], CVSReader.intParse);
			base.Write(writer, false, Fields[this.ColMap[64]]);
			base.Write<string>(writer, Fields[this.ColMap[65]], CVSReader.stringParse);
			base.Write(writer, false, Fields[this.ColMap[66]]);
			base.Write<float>(writer, Fields[this.ColMap[67]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[68]], CVSReader.floatParse);
			base.Write<string>(writer, Fields[this.ColMap[69]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[70]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[71]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[72]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[73]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[74]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[75]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[76]], CVSReader.uintParse, 2, "U");
			base.Write(writer, false, Fields[this.ColMap[77]]);
			base.Write<uint>(writer, Fields[this.ColMap[78]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[79]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[80]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[81]], CVSReader.uintParse, 2, "U");
			base.WriteArray<int>(writer, Fields[this.ColMap[82]], CVSReader.intParse);
			base.Write(writer, false, Fields[this.ColMap[83]]);
			base.Write(writer, false, Fields[this.ColMap[84]]);
			base.Write<int>(writer, Fields[this.ColMap[85]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[86]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[87]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[88]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[89]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[90]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[91]], CVSReader.stringParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[92]], CVSReader.uintParse, 2, "U");
			base.Write(writer, false, Fields[this.ColMap[93]]);
			base.Write<string>(writer, Fields[this.ColMap[94]], CVSReader.stringParse);
			base.Write<float>(writer, Fields[this.ColMap[95]], CVSReader.floatParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[96]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<double>(writer, Fields[this.ColMap[97]], CVSReader.doubleParse, 2, "D");
			base.WriteArray<float>(writer, Fields[this.ColMap[98]], CVSReader.floatParse);
			base.Write(writer, false, Fields[this.ColMap[99]]);
			base.Write<uint>(writer, Fields[this.ColMap[100]], CVSReader.uintParse);
			base.Write(writer, false, Fields[this.ColMap[101]]);
			base.Write(writer, false, Fields[this.ColMap[102]]);
			base.Write<string>(writer, Fields[this.ColMap[103]], CVSReader.stringParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[104]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[105]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[106]], CVSReader.stringParse);
			base.Write<float>(writer, Fields[this.ColMap[107]], CVSReader.floatParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[108]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SceneTable.RowData rowData = new SceneTable.RowData();
			base.Read<int>(reader, ref rowData.id, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.type, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.configFile, CVSReader.stringParse);
			this.columnno = 2;
			base.ReadSeqList<float>(reader, ref rowData.StartPos, CVSReader.floatParse);
			this.columnno = 3;
			base.ReadArray<float>(reader, ref rowData.StartRot, CVSReader.floatParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.sceneFile, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.syncMode, CVSReader.intParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.BlockFilePath, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadArray<int>(reader, ref rowData.UIPos, CVSReader.intParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.Exp, CVSReader.intParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.Money, CVSReader.intParse);
			this.columnno = 10;
			base.Read(reader, ref rowData.IsBoss);
			this.columnno = 11;
			base.Read<int>(reader, ref rowData.Chapter, CVSReader.intParse);
			this.columnno = 12;
			base.Read<string>(reader, ref rowData.Comment, CVSReader.stringParse);
			this.columnno = 13;
			base.Read<int>(reader, ref rowData.RecommendPower, CVSReader.intParse);
			this.columnno = 14;
			base.ReadArray<int>(reader, ref rowData.Drop1, CVSReader.intParse);
			this.columnno = 15;
			base.ReadArray<int>(reader, ref rowData.Drop2, CVSReader.intParse);
			this.columnno = 16;
			base.ReadArray<int>(reader, ref rowData.Drop3, CVSReader.intParse);
			this.columnno = 17;
			base.ReadArray<int>(reader, ref rowData.Drop4, CVSReader.intParse);
			this.columnno = 18;
			base.ReadArray<int>(reader, ref rowData.Drop5, CVSReader.intParse);
			this.columnno = 19;
			base.Read<int>(reader, ref rowData.RequiredLevel, CVSReader.intParse);
			this.columnno = 20;
			base.Read<string>(reader, ref rowData.UIIcon, CVSReader.stringParse);
			this.columnno = 21;
			base.Read<int>(reader, ref rowData.FirstDownExp, CVSReader.intParse);
			this.columnno = 22;
			base.ReadArray<int>(reader, ref rowData.FirstDownDrop, CVSReader.intParse);
			this.columnno = 23;
			base.Read<int>(reader, ref rowData.FirstDownMoney, CVSReader.intParse);
			this.columnno = 24;
			base.ReadArray<int>(reader, ref rowData.ViewableDropList, CVSReader.intParse);
			this.columnno = 25;
			base.Read<string>(reader, ref rowData.BossAvatar, CVSReader.stringParse);
			this.columnno = 26;
			base.ReadSeqList<int>(reader, ref rowData.FatigueCost, CVSReader.intParse);
			this.columnno = 27;
			base.Read<string>(reader, ref rowData.EndCutScene, CVSReader.stringParse);
			this.columnno = 28;
			base.Read<float>(reader, ref rowData.EndCutSceneTime, CVSReader.floatParse);
			this.columnno = 29;
			base.Read<uint>(reader, ref rowData.GoldDropID, CVSReader.uintParse);
			this.columnno = 30;
			base.Read<uint>(reader, ref rowData.SilverDropID, CVSReader.uintParse);
			this.columnno = 31;
			base.Read<uint>(reader, ref rowData.CopperDropID, CVSReader.uintParse);
			this.columnno = 32;
			base.ReadSeqList<int>(reader, ref rowData.WinCondition, CVSReader.intParse);
			this.columnno = 33;
			base.ReadSeqList<int>(reader, ref rowData.LoseCondition, CVSReader.intParse);
			this.columnno = 34;
			base.Read<int>(reader, ref rowData.DayLimit, CVSReader.intParse);
			this.columnno = 35;
			base.Read(reader, ref rowData.CanDrawBox);
			this.columnno = 36;
			base.Read(reader, ref rowData.HasFlyOut);
			this.columnno = 37;
			base.Read<uint>(reader, ref rowData.DayLimitGroupID, CVSReader.uintParse);
			this.columnno = 38;
			base.Read<string>(reader, ref rowData.DynamicScene, CVSReader.stringParse);
			this.columnno = 39;
			base.Read(reader, ref rowData.IsStaticScene);
			this.columnno = 40;
			base.ReadSeq<uint>(reader, ref rowData.ReviveTime, CVSReader.uintParse);
			this.columnno = 41;
			base.Read(reader, ref rowData.CanPause);
			this.columnno = 42;
			base.ReadArray<int>(reader, ref rowData.OperationSettings, CVSReader.intParse);
			this.columnno = 43;
			base.Read<string>(reader, ref rowData.BossIcon, CVSReader.stringParse);
			this.columnno = 44;
			base.Read<int>(reader, ref rowData.CoolDown, CVSReader.intParse);
			this.columnno = 45;
			base.Read<string>(reader, ref rowData.BGM, CVSReader.stringParse);
			this.columnno = 46;
			base.Read(reader, ref rowData.ShowUp);
			this.columnno = 47;
			base.ReadSeqList<uint>(reader, ref rowData.FirstSSS, CVSReader.uintParse);
			this.columnno = 48;
			base.ReadArray<int>(reader, ref rowData.PreScene, CVSReader.intParse);
			this.columnno = 49;
			base.Read<int>(reader, ref rowData.SceneChest, CVSReader.intParse);
			this.columnno = 50;
			base.ReadArray<int>(reader, ref rowData.BoxUIPos, CVSReader.intParse);
			this.columnno = 51;
			base.Read<int>(reader, ref rowData.LineRoleCount, CVSReader.intParse);
			this.columnno = 52;
			base.ReadArray<string>(reader, ref rowData.LoadingTips, CVSReader.stringParse);
			this.columnno = 53;
			base.ReadArray<string>(reader, ref rowData.LoadingPic, CVSReader.stringParse);
			this.columnno = 54;
			base.Read(reader, ref rowData.SceneCanNavi);
			this.columnno = 55;
			base.Read<int>(reader, ref rowData.RandomTaskType, CVSReader.intParse);
			this.columnno = 56;
			base.ReadArray<int>(reader, ref rowData.RandomTaskSpecify, CVSReader.intParse);
			this.columnno = 57;
			base.Read(reader, ref rowData.UseSupplement);
			this.columnno = 58;
			base.Read<float>(reader, ref rowData.HurtCoef, CVSReader.floatParse);
			this.columnno = 59;
			base.Read<string>(reader, ref rowData.MiniMap, CVSReader.stringParse);
			this.columnno = 60;
			base.ReadArray<int>(reader, ref rowData.MiniMapSize, CVSReader.intParse);
			this.columnno = 61;
			base.Read<int>(reader, ref rowData.MiniMapRotation, CVSReader.intParse);
			this.columnno = 62;
			base.Read<int>(reader, ref rowData.PreTask, CVSReader.intParse);
			this.columnno = 63;
			base.Read(reader, ref rowData.SwitchToSelf);
			this.columnno = 64;
			base.Read<string>(reader, ref rowData.SceneAI, CVSReader.stringParse);
			this.columnno = 65;
			base.Read(reader, ref rowData.ShowAutoFight);
			this.columnno = 66;
			base.Read<float>(reader, ref rowData.PPTCoff, CVSReader.floatParse);
			this.columnno = 67;
			base.Read<float>(reader, ref rowData.GuildExpBounus, CVSReader.floatParse);
			this.columnno = 68;
			base.Read<string>(reader, ref rowData.FailText, CVSReader.stringParse);
			this.columnno = 69;
			base.Read<int>(reader, ref rowData.WinDelayTime, CVSReader.intParse);
			this.columnno = 70;
			base.Read<string>(reader, ref rowData.RecommendHint, CVSReader.stringParse);
			this.columnno = 71;
			base.Read<uint>(reader, ref rowData.TeamInfoDefaultTab, CVSReader.uintParse);
			this.columnno = 72;
			base.Read<uint>(reader, ref rowData.CombatType, CVSReader.uintParse);
			this.columnno = 73;
			base.Read<int>(reader, ref rowData.SweepNeedPPT, CVSReader.intParse);
			this.columnno = 74;
			base.Read<uint>(reader, ref rowData.ReviveNumb, CVSReader.uintParse);
			this.columnno = 75;
			base.ReadSeqList<uint>(reader, ref rowData.ReviveCost, CVSReader.uintParse);
			this.columnno = 76;
			base.Read(reader, ref rowData.CanRevive);
			this.columnno = 77;
			base.Read<uint>(reader, ref rowData.DiamondDropID, CVSReader.uintParse);
			this.columnno = 78;
			base.ReadSeqList<uint>(reader, ref rowData.SBox, CVSReader.uintParse);
			this.columnno = 79;
			base.ReadSeqList<uint>(reader, ref rowData.SSBox, CVSReader.uintParse);
			this.columnno = 80;
			base.ReadSeqList<uint>(reader, ref rowData.SSSBox, CVSReader.uintParse);
			this.columnno = 81;
			base.ReadArray<int>(reader, ref rowData.TimeCounter, CVSReader.intParse);
			this.columnno = 82;
			base.Read(reader, ref rowData.HasComboBuff);
			this.columnno = 83;
			base.Read(reader, ref rowData.DisplayPet);
			this.columnno = 84;
			base.Read<int>(reader, ref rowData.AutoReturn, CVSReader.intParse);
			this.columnno = 85;
			base.Read<uint>(reader, ref rowData.StoryDriver, CVSReader.uintParse);
			this.columnno = 86;
			base.Read<uint>(reader, ref rowData.MinPassTime, CVSReader.uintParse);
			this.columnno = 87;
			base.ReadSeqList<uint>(reader, ref rowData.ReviveMoneyCost, CVSReader.uintParse);
			this.columnno = 88;
			base.ReadSeqList<uint>(reader, ref rowData.ReviveBuff, CVSReader.uintParse);
			this.columnno = 89;
			base.Read<string>(reader, ref rowData.LeaveSceneTip, CVSReader.stringParse);
			this.columnno = 90;
			base.Read<string>(reader, ref rowData.ReviveBuffTip, CVSReader.stringParse);
			this.columnno = 91;
			base.ReadSeqList<uint>(reader, ref rowData.ExpSealReward, CVSReader.uintParse);
			this.columnno = 92;
			base.Read(reader, ref rowData.ShowSkill);
			this.columnno = 93;
			base.Read<string>(reader, ref rowData.WinConditionTips, CVSReader.stringParse);
			this.columnno = 94;
			base.Read<float>(reader, ref rowData.DelayTransfer, CVSReader.floatParse);
			this.columnno = 95;
			base.ReadSeqList<uint>(reader, ref rowData.Buff, CVSReader.uintParse);
			this.columnno = 96;
			base.ReadSeq<double>(reader, ref rowData.DPS, CVSReader.doubleParse);
			this.columnno = 97;
			base.ReadArray<float>(reader, ref rowData.StartFace, CVSReader.floatParse);
			this.columnno = 98;
			base.Read(reader, ref rowData.IsCanQuit);
			this.columnno = 99;
			base.Read<uint>(reader, ref rowData.CanVIPRevive, CVSReader.uintParse);
			this.columnno = 100;
			base.Read(reader, ref rowData.ShowNormalAttack);
			this.columnno = 101;
			base.Read(reader, ref rowData.HideTeamIndicate);
			this.columnno = 102;
			base.Read<string>(reader, ref rowData.BattleExplainTips, CVSReader.stringParse);
			this.columnno = 103;
			base.ReadArray<int>(reader, ref rowData.ShieldSight, CVSReader.intParse);
			this.columnno = 104;
			base.Read<string>(reader, ref rowData.ScenePath, CVSReader.stringParse);
			this.columnno = 105;
			base.Read<string>(reader, ref rowData.EnvSet, CVSReader.stringParse);
			this.columnno = 106;
			base.Read<float>(reader, ref rowData.SpecifiedTargetLocatedRange, CVSReader.floatParse);
			this.columnno = 107;
			base.ReadArray<int>(reader, ref rowData.SpactivityActiveDrop, CVSReader.intParse);
			this.columnno = 108;
			this.AddRowSceneID(rowData.id, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
