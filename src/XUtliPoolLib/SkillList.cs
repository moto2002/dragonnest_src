using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SkillList : CVSReader
	{
		public class RowData
		{
			public string SkillScript;

			public int SkillLevel;

			public string ScriptName;

			public Seq2ListRef<float> PhysicalRatio;

			public Seq2ListRef<float> PhysicalFixed;

			public Seq2ListRef<int> DefenceSlotReduce;

			public int[] AddBuffPoint;

			public Seq3ListRef<int> BuffID;

			public int HpMaxLimit;

			public int UnlockLevel;

			public int[] LevelupCost;

			public int[] UpReqRoleLevel;

			public string CurrentLevelDescription;

			public string NextLevelDescription;

			public string Icon;

			public Seq2ListRef<float> MagicRatio;

			public Seq2ListRef<float> MagicFixed;

			public int Element;

			public int Profession;

			public int SkillType;

			public int IncreaseSuperArmor;

			public float[] DecreaseSuperArmor;

			public int IsBasicSkill;

			public Seq2Ref<float> CostMP;

			public Seq2ListRef<float> TipsRatio;

			public Seq2ListRef<float> TipsFixed;

			public string PreSkill;

			public int XPostion;

			public int YPostion;

			public Seq4ListRef<float> StartBuffID;

			public Seq3ListRef<int> PassiveAttribute;

			public int LevelupCostType;

			public int[] UpReqGuildLevel;

			public Seq3Ref<int> AuraBuffID;

			public int HpMinLimit;

			public Seq2Ref<float> CDRatio;

			public Seq2Ref<float> PvPCDRatio;

			public int SuperArmorMax;

			public int SuperArmorMin;

			public uint XEntityStatisticsID;

			public int PvPIncreaseSuperArmor;

			public float[] PvPDecreaseSuperArmor;

			public Seq2ListRef<float> PvPRatio;

			public Seq2ListRef<float> PvPFixed;

			public int ResetSkillTo;

			public float InitCD;

			public float PvPInitCD;

			public int[] StudyLevelCost;

			public Seq2ListRef<float> PvPMagicRatio;

			public Seq2ListRef<float> PvPMagicFixed;

			public string PreviewScript;

			public uint InitGuildSkillMax;

			public string Atlas;

			public uint[] Flag;

			public int PreSkillPoint;

			public string SuperIndureAttack;

			public string SuperIndureDefense;

			public string ExSkillScript;

			public int UnchangableCD;

			public float EnmityRatio;

			public int EnmityExtValue;

			public Seq2ListRef<float> PercentDamage;

			public string LinkedSkill;

			public int LinkType;
		}

		public List<SkillList.RowData> Table = new List<SkillList.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"SkillScript",
				"SkillLevel",
				"ScriptName",
				"PhysicalRatio",
				"PhysicalFixed",
				"DefenceSlotReduce",
				"AddBuffPoint",
				"BuffID",
				"HpMaxLimit",
				"UnlockLevel",
				"LevelupCost",
				"UpReqRoleLevel",
				"CurrentLevelDescription",
				"NextLevelDescription",
				"Icon",
				"MagicRatio",
				"MagicFixed",
				"Element",
				"Profession",
				"SkillType",
				"IncreaseSuperArmor",
				"DecreaseSuperArmor",
				"IsBasicSkill",
				"CostMP",
				"TipsRatio",
				"TipsFixed",
				"PreSkill",
				"XPostion",
				"YPostion",
				"StartBuffID",
				"PassiveAttribute",
				"LevelupCostType",
				"UpReqGuildLevel",
				"AuraBuffID",
				"HpMinLimit",
				"CDRatio",
				"PvPCDRatio",
				"SuperArmorMax",
				"SuperArmorMin",
				"XEntityStatisticsID",
				"PvPIncreaseSuperArmor",
				"PvPDecreaseSuperArmor",
				"PvPRatio",
				"PvPFixed",
				"ResetSkillTo",
				"InitCD",
				"PvPInitCD",
				"StudyLevelCost",
				"PvPMagicRatio",
				"PvPMagicFixed",
				"PreviewScript",
				"InitGuildSkillMax",
				"Atlas",
				"Flag",
				"PreSkillPoint",
				"SuperIndureAttack",
				"SuperIndureDefense",
				"ExSkillScript",
				"UnchangableCD",
				"EnmityRatio",
				"EnmityExtValue",
				"PercentDamage",
				"LinkedSkill",
				"LinkType"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SkillList.RowData rowData = new SkillList.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.SkillScript))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.SkillLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.ScriptName))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[3]], ref rowData.PhysicalRatio, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[4]], ref rowData.PhysicalFixed, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[5]], ref rowData.DefenceSlotReduce, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.AddBuffPoint))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[7]], ref rowData.BuffID, CVSReader.intParse, "3I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.HpMaxLimit))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.UnlockLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.LevelupCost))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.UpReqRoleLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.CurrentLevelDescription))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.NextLevelDescription))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.Icon))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[15]], ref rowData.MagicRatio, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[16]], ref rowData.MagicFixed, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[17]], ref rowData.Element))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[18]], ref rowData.Profession))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[19]], ref rowData.SkillType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[20]], ref rowData.IncreaseSuperArmor))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[21]], ref rowData.DecreaseSuperArmor))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[22]], ref rowData.IsBasicSkill))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[23]], ref rowData.CostMP, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[24]], ref rowData.TipsRatio, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[25]], ref rowData.TipsFixed, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[26]], ref rowData.PreSkill))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[27]], ref rowData.XPostion))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[28]], ref rowData.YPostion))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[29]], ref rowData.StartBuffID, CVSReader.floatParse, "4F"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[30]], ref rowData.PassiveAttribute, CVSReader.intParse, "3I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[31]], ref rowData.LevelupCostType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[32]], ref rowData.UpReqGuildLevel))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[33]], ref rowData.AuraBuffID, CVSReader.intParse, "3I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[34]], ref rowData.HpMinLimit))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[35]], ref rowData.CDRatio, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[36]], ref rowData.PvPCDRatio, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[37]], ref rowData.SuperArmorMax))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[38]], ref rowData.SuperArmorMin))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[39]], ref rowData.XEntityStatisticsID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[40]], ref rowData.PvPIncreaseSuperArmor))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[41]], ref rowData.PvPDecreaseSuperArmor))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[42]], ref rowData.PvPRatio, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[43]], ref rowData.PvPFixed, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[44]], ref rowData.ResetSkillTo))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[45]], ref rowData.InitCD))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[46]], ref rowData.PvPInitCD))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[47]], ref rowData.StudyLevelCost))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[48]], ref rowData.PvPMagicRatio, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[49]], ref rowData.PvPMagicFixed, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[50]], ref rowData.PreviewScript))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[51]], ref rowData.InitGuildSkillMax))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[52]], ref rowData.Atlas))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[53]], ref rowData.Flag))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[54]], ref rowData.PreSkillPoint))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[55]], ref rowData.SuperIndureAttack))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[56]], ref rowData.SuperIndureDefense))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[57]], ref rowData.ExSkillScript))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[58]], ref rowData.UnchangableCD))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[59]], ref rowData.EnmityRatio))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[60]], ref rowData.EnmityExtValue))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[61]], ref rowData.PercentDamage, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[62]], ref rowData.LinkedSkill))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[63]], ref rowData.LinkType))
			{
				return false;
			}
			this.Table.Add(rowData);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<string>(writer, Fields[this.ColMap[0]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.WriteSeqList<float>(writer, Fields[this.ColMap[3]], CVSReader.floatParse, 2, "F");
			base.WriteSeqList<float>(writer, Fields[this.ColMap[4]], CVSReader.floatParse, 2, "F");
			base.WriteSeqList<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse, 2, "I");
			base.WriteArray<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse, 3, "I");
			base.Write<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[11]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[12]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[13]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[14]], CVSReader.stringParse);
			base.WriteSeqList<float>(writer, Fields[this.ColMap[15]], CVSReader.floatParse, 2, "F");
			base.WriteSeqList<float>(writer, Fields[this.ColMap[16]], CVSReader.floatParse, 2, "F");
			base.Write<int>(writer, Fields[this.ColMap[17]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[18]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[19]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[20]], CVSReader.intParse);
			base.WriteArray<float>(writer, Fields[this.ColMap[21]], CVSReader.floatParse);
			base.Write<int>(writer, Fields[this.ColMap[22]], CVSReader.intParse);
			base.WriteSeq<float>(writer, Fields[this.ColMap[23]], CVSReader.floatParse, 2, "F");
			base.WriteSeqList<float>(writer, Fields[this.ColMap[24]], CVSReader.floatParse, 2, "F");
			base.WriteSeqList<float>(writer, Fields[this.ColMap[25]], CVSReader.floatParse, 2, "F");
			base.Write<string>(writer, Fields[this.ColMap[26]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[27]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[28]], CVSReader.intParse);
			base.WriteSeqList<float>(writer, Fields[this.ColMap[29]], CVSReader.floatParse, 4, "F");
			base.WriteSeqList<int>(writer, Fields[this.ColMap[30]], CVSReader.intParse, 3, "I");
			base.Write<int>(writer, Fields[this.ColMap[31]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[32]], CVSReader.intParse);
			base.WriteSeq<int>(writer, Fields[this.ColMap[33]], CVSReader.intParse, 3, "I");
			base.Write<int>(writer, Fields[this.ColMap[34]], CVSReader.intParse);
			base.WriteSeq<float>(writer, Fields[this.ColMap[35]], CVSReader.floatParse, 2, "F");
			base.WriteSeq<float>(writer, Fields[this.ColMap[36]], CVSReader.floatParse, 2, "F");
			base.Write<int>(writer, Fields[this.ColMap[37]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[38]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[39]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[40]], CVSReader.intParse);
			base.WriteArray<float>(writer, Fields[this.ColMap[41]], CVSReader.floatParse);
			base.WriteSeqList<float>(writer, Fields[this.ColMap[42]], CVSReader.floatParse, 2, "F");
			base.WriteSeqList<float>(writer, Fields[this.ColMap[43]], CVSReader.floatParse, 2, "F");
			base.Write<int>(writer, Fields[this.ColMap[44]], CVSReader.intParse);
			base.Write<float>(writer, Fields[this.ColMap[45]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[46]], CVSReader.floatParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[47]], CVSReader.intParse);
			base.WriteSeqList<float>(writer, Fields[this.ColMap[48]], CVSReader.floatParse, 2, "F");
			base.WriteSeqList<float>(writer, Fields[this.ColMap[49]], CVSReader.floatParse, 2, "F");
			base.Write<string>(writer, Fields[this.ColMap[50]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[51]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[52]], CVSReader.stringParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[53]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[54]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[55]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[56]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[57]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[58]], CVSReader.intParse);
			base.Write<float>(writer, Fields[this.ColMap[59]], CVSReader.floatParse);
			base.Write<int>(writer, Fields[this.ColMap[60]], CVSReader.intParse);
			base.WriteSeqList<float>(writer, Fields[this.ColMap[61]], CVSReader.floatParse, 2, "F");
			base.Write<string>(writer, Fields[this.ColMap[62]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[63]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SkillList.RowData rowData = new SkillList.RowData();
			base.Read<string>(reader, ref rowData.SkillScript, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.SkillLevel, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.ScriptName, CVSReader.stringParse);
			this.columnno = 2;
			base.ReadSeqList<float>(reader, ref rowData.PhysicalRatio, CVSReader.floatParse);
			this.columnno = 3;
			base.ReadSeqList<float>(reader, ref rowData.PhysicalFixed, CVSReader.floatParse);
			this.columnno = 4;
			base.ReadSeqList<int>(reader, ref rowData.DefenceSlotReduce, CVSReader.intParse);
			this.columnno = 5;
			base.ReadArray<int>(reader, ref rowData.AddBuffPoint, CVSReader.intParse);
			this.columnno = 6;
			base.ReadSeqList<int>(reader, ref rowData.BuffID, CVSReader.intParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.HpMaxLimit, CVSReader.intParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.UnlockLevel, CVSReader.intParse);
			this.columnno = 9;
			base.ReadArray<int>(reader, ref rowData.LevelupCost, CVSReader.intParse);
			this.columnno = 10;
			base.ReadArray<int>(reader, ref rowData.UpReqRoleLevel, CVSReader.intParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.CurrentLevelDescription, CVSReader.stringParse);
			this.columnno = 12;
			base.Read<string>(reader, ref rowData.NextLevelDescription, CVSReader.stringParse);
			this.columnno = 13;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 14;
			base.ReadSeqList<float>(reader, ref rowData.MagicRatio, CVSReader.floatParse);
			this.columnno = 15;
			base.ReadSeqList<float>(reader, ref rowData.MagicFixed, CVSReader.floatParse);
			this.columnno = 16;
			base.Read<int>(reader, ref rowData.Element, CVSReader.intParse);
			this.columnno = 17;
			base.Read<int>(reader, ref rowData.Profession, CVSReader.intParse);
			this.columnno = 18;
			base.Read<int>(reader, ref rowData.SkillType, CVSReader.intParse);
			this.columnno = 19;
			base.Read<int>(reader, ref rowData.IncreaseSuperArmor, CVSReader.intParse);
			this.columnno = 20;
			base.ReadArray<float>(reader, ref rowData.DecreaseSuperArmor, CVSReader.floatParse);
			this.columnno = 21;
			base.Read<int>(reader, ref rowData.IsBasicSkill, CVSReader.intParse);
			this.columnno = 22;
			base.ReadSeq<float>(reader, ref rowData.CostMP, CVSReader.floatParse);
			this.columnno = 23;
			base.ReadSeqList<float>(reader, ref rowData.TipsRatio, CVSReader.floatParse);
			this.columnno = 24;
			base.ReadSeqList<float>(reader, ref rowData.TipsFixed, CVSReader.floatParse);
			this.columnno = 25;
			base.Read<string>(reader, ref rowData.PreSkill, CVSReader.stringParse);
			this.columnno = 26;
			base.Read<int>(reader, ref rowData.XPostion, CVSReader.intParse);
			this.columnno = 27;
			base.Read<int>(reader, ref rowData.YPostion, CVSReader.intParse);
			this.columnno = 28;
			base.ReadSeqList<float>(reader, ref rowData.StartBuffID, CVSReader.floatParse);
			this.columnno = 29;
			base.ReadSeqList<int>(reader, ref rowData.PassiveAttribute, CVSReader.intParse);
			this.columnno = 30;
			base.Read<int>(reader, ref rowData.LevelupCostType, CVSReader.intParse);
			this.columnno = 31;
			base.ReadArray<int>(reader, ref rowData.UpReqGuildLevel, CVSReader.intParse);
			this.columnno = 32;
			base.ReadSeq<int>(reader, ref rowData.AuraBuffID, CVSReader.intParse);
			this.columnno = 33;
			base.Read<int>(reader, ref rowData.HpMinLimit, CVSReader.intParse);
			this.columnno = 34;
			base.ReadSeq<float>(reader, ref rowData.CDRatio, CVSReader.floatParse);
			this.columnno = 35;
			base.ReadSeq<float>(reader, ref rowData.PvPCDRatio, CVSReader.floatParse);
			this.columnno = 36;
			base.Read<int>(reader, ref rowData.SuperArmorMax, CVSReader.intParse);
			this.columnno = 37;
			base.Read<int>(reader, ref rowData.SuperArmorMin, CVSReader.intParse);
			this.columnno = 38;
			base.Read<uint>(reader, ref rowData.XEntityStatisticsID, CVSReader.uintParse);
			this.columnno = 39;
			base.Read<int>(reader, ref rowData.PvPIncreaseSuperArmor, CVSReader.intParse);
			this.columnno = 40;
			base.ReadArray<float>(reader, ref rowData.PvPDecreaseSuperArmor, CVSReader.floatParse);
			this.columnno = 41;
			base.ReadSeqList<float>(reader, ref rowData.PvPRatio, CVSReader.floatParse);
			this.columnno = 42;
			base.ReadSeqList<float>(reader, ref rowData.PvPFixed, CVSReader.floatParse);
			this.columnno = 43;
			base.Read<int>(reader, ref rowData.ResetSkillTo, CVSReader.intParse);
			this.columnno = 44;
			base.Read<float>(reader, ref rowData.InitCD, CVSReader.floatParse);
			this.columnno = 45;
			base.Read<float>(reader, ref rowData.PvPInitCD, CVSReader.floatParse);
			this.columnno = 46;
			base.ReadArray<int>(reader, ref rowData.StudyLevelCost, CVSReader.intParse);
			this.columnno = 47;
			base.ReadSeqList<float>(reader, ref rowData.PvPMagicRatio, CVSReader.floatParse);
			this.columnno = 48;
			base.ReadSeqList<float>(reader, ref rowData.PvPMagicFixed, CVSReader.floatParse);
			this.columnno = 49;
			base.Read<string>(reader, ref rowData.PreviewScript, CVSReader.stringParse);
			this.columnno = 50;
			base.Read<uint>(reader, ref rowData.InitGuildSkillMax, CVSReader.uintParse);
			this.columnno = 51;
			base.Read<string>(reader, ref rowData.Atlas, CVSReader.stringParse);
			this.columnno = 52;
			base.ReadArray<uint>(reader, ref rowData.Flag, CVSReader.uintParse);
			this.columnno = 53;
			base.Read<int>(reader, ref rowData.PreSkillPoint, CVSReader.intParse);
			this.columnno = 54;
			base.Read<string>(reader, ref rowData.SuperIndureAttack, CVSReader.stringParse);
			this.columnno = 55;
			base.Read<string>(reader, ref rowData.SuperIndureDefense, CVSReader.stringParse);
			this.columnno = 56;
			base.Read<string>(reader, ref rowData.ExSkillScript, CVSReader.stringParse);
			this.columnno = 57;
			base.Read<int>(reader, ref rowData.UnchangableCD, CVSReader.intParse);
			this.columnno = 58;
			base.Read<float>(reader, ref rowData.EnmityRatio, CVSReader.floatParse);
			this.columnno = 59;
			base.Read<int>(reader, ref rowData.EnmityExtValue, CVSReader.intParse);
			this.columnno = 60;
			base.ReadSeqList<float>(reader, ref rowData.PercentDamage, CVSReader.floatParse);
			this.columnno = 61;
			base.Read<string>(reader, ref rowData.LinkedSkill, CVSReader.stringParse);
			this.columnno = 62;
			base.Read<int>(reader, ref rowData.LinkType, CVSReader.intParse);
			this.columnno = 63;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
