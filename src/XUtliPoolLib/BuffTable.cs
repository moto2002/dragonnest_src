using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class BuffTable : CVSReader
	{
		public class RowData
		{
			public int BuffID;

			public int BuffLevel;

			public int BuffSubType;

			public float BuffDuration;

			public Seq3ListRef<float> BuffChangeAttribute;

			public float BuffRate;

			public int[] BuffState;

			public int BuffMergeType;

			public int TargetType;

			public string BuffIcon;

			public Seq3ListRef<int> BuffDOT;

			public string BuffFx;

			public string BuffDoodadFx;

			public string BuffName;

			public Seq3Ref<double> LifeAddAttack;

			public int BuffTriggerCond;

			public float BuffTriggerRate;

			public string[] BuffTriggerParam;

			public Seq2ListRef<int> BuffTriggerBuff;

			public double CostModify;

			public double CoolDownModify;

			public double BuffTriggerCD;

			public Seq2ListRef<int> AuraAddBuffID;

			public bool BuffIsVisible;

			public string BuffEffectFx;

			public float[] AuraParams;

			public Seq2ListRef<double> DamageReduce;

			public bool DontShowText;

			public int[] EffectGroup;

			public Seq2ListRef<int> BuffDOTValueFromCaster;

			public Seq2Ref<double> ChangeDamage;

			public int BuffClearType;

			public int[] ClearTypes;

			public float DamageReflection;

			public uint MobID;

			public Seq2Ref<float> BuffHP;

			public uint StackMaxCount;

			public int ChangeFightGroup;

			public uint BuffTriggerCount;

			public double LifeSteal;

			public Seq3ListRef<string> ReduceSkillCD;

			public int StateParam;

			public bool IsGlobalTrigger;

			public uint[] Tags;

			public string BuffSpriteFx;

			public string MiniMapIcon;

			public string BuffTriggerSkill;

			public Seq2ListRef<string> ChangeSkillDamage;

			public int[] SceneEffect;

			public Seq2ListRef<double> TargetLifeAddAttack;

			public int AIEvent;
		}

		public List<BuffTable.RowData> Table = new List<BuffTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"BuffID",
				"BuffLevel",
				"BuffSubType",
				"BuffDuration",
				"BuffChangeAttribute",
				"BuffRate",
				"BuffState",
				"BuffMergeType",
				"TargetType",
				"BuffIcon",
				"BuffDOT",
				"BuffFx",
				"BuffDoodadFx",
				"BuffName",
				"LifeAddAttack",
				"BuffTriggerCond",
				"BuffTriggerRate",
				"BuffTriggerParam",
				"BuffTriggerBuff",
				"CostModify",
				"CoolDownModify",
				"BuffTriggerCD",
				"AuraAddBuffID",
				"BuffIsVisible",
				"BuffEffectFx",
				"AuraParams",
				"DamageReduce",
				"DontShowText",
				"EffectGroup",
				"BuffDOTValueFromCaster",
				"ChangeDamage",
				"BuffClearType",
				"ClearTypes",
				"DamageReflection",
				"MobID",
				"BuffHP",
				"StackMaxCount",
				"ChangeFightGroup",
				"BuffTriggerCount",
				"LifeSteal",
				"ReduceSkillCD",
				"StateParam",
				"IsGlobalTrigger",
				"Tags",
				"BuffSpriteFx",
				"MiniMapIcon",
				"BuffTriggerSkill",
				"ChangeSkillDamage",
				"SceneEffect",
				"TargetLifeAddAttack",
				"AIEvent"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			BuffTable.RowData rowData = new BuffTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.BuffID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.BuffLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.BuffSubType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.BuffDuration))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[4]], ref rowData.BuffChangeAttribute, CVSReader.floatParse, "3F"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.BuffRate))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.BuffState))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.BuffMergeType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.TargetType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.BuffIcon))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[10]], ref rowData.BuffDOT, CVSReader.intParse, "3I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.BuffFx))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.BuffDoodadFx))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.BuffName))
			{
				return false;
			}
			if (!base.Parse<double>(Fields[this.ColMap[14]], ref rowData.LifeAddAttack, CVSReader.doubleParse, "3D"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[15]], ref rowData.BuffTriggerCond))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.BuffTriggerRate))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[17]], ref rowData.BuffTriggerParam))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[18]], ref rowData.BuffTriggerBuff, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[19]], ref rowData.CostModify))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[20]], ref rowData.CoolDownModify))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[21]], ref rowData.BuffTriggerCD))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[22]], ref rowData.AuraAddBuffID, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[23]], ref rowData.BuffIsVisible))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[24]], ref rowData.BuffEffectFx))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[25]], ref rowData.AuraParams))
			{
				return false;
			}
			if (!base.Parse<double>(Fields[this.ColMap[26]], ref rowData.DamageReduce, CVSReader.doubleParse, "2D"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[27]], ref rowData.DontShowText))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[28]], ref rowData.EffectGroup))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[29]], ref rowData.BuffDOTValueFromCaster, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse<double>(Fields[this.ColMap[30]], ref rowData.ChangeDamage, CVSReader.doubleParse, "2D"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[31]], ref rowData.BuffClearType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[32]], ref rowData.ClearTypes))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[33]], ref rowData.DamageReflection))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[34]], ref rowData.MobID))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[35]], ref rowData.BuffHP, CVSReader.floatParse, "2F"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[36]], ref rowData.StackMaxCount))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[37]], ref rowData.ChangeFightGroup))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[38]], ref rowData.BuffTriggerCount))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[39]], ref rowData.LifeSteal))
			{
				return false;
			}
			if (!base.Parse<string>(Fields[this.ColMap[40]], ref rowData.ReduceSkillCD, CVSReader.stringParse, "3S"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[41]], ref rowData.StateParam))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[42]], ref rowData.IsGlobalTrigger))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[43]], ref rowData.Tags))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[44]], ref rowData.BuffSpriteFx))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[45]], ref rowData.MiniMapIcon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[46]], ref rowData.BuffTriggerSkill))
			{
				return false;
			}
			if (!base.Parse<string>(Fields[this.ColMap[47]], ref rowData.ChangeSkillDamage, CVSReader.stringParse, "2S"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[48]], ref rowData.SceneEffect))
			{
				return false;
			}
			if (!base.Parse<double>(Fields[this.ColMap[49]], ref rowData.TargetLifeAddAttack, CVSReader.doubleParse, "2D"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[50]], ref rowData.AIEvent))
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
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<float>(writer, Fields[this.ColMap[3]], CVSReader.floatParse);
			base.WriteSeqList<float>(writer, Fields[this.ColMap[4]], CVSReader.floatParse, 3, "F");
			base.Write<float>(writer, Fields[this.ColMap[5]], CVSReader.floatParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[9]], CVSReader.stringParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse, 3, "I");
			base.Write<string>(writer, Fields[this.ColMap[11]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[12]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[13]], CVSReader.stringParse);
			base.WriteSeq<double>(writer, Fields[this.ColMap[14]], CVSReader.doubleParse, 3, "D");
			base.Write<int>(writer, Fields[this.ColMap[15]], CVSReader.intParse);
			base.Write<float>(writer, Fields[this.ColMap[16]], CVSReader.floatParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[17]], CVSReader.stringParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[18]], CVSReader.intParse, 2, "I");
			base.Write<double>(writer, Fields[this.ColMap[19]], CVSReader.doubleParse);
			base.Write<double>(writer, Fields[this.ColMap[20]], CVSReader.doubleParse);
			base.Write<double>(writer, Fields[this.ColMap[21]], CVSReader.doubleParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[22]], CVSReader.intParse, 2, "I");
			base.Write(writer, false, Fields[this.ColMap[23]]);
			base.Write<string>(writer, Fields[this.ColMap[24]], CVSReader.stringParse);
			base.WriteArray<float>(writer, Fields[this.ColMap[25]], CVSReader.floatParse);
			base.WriteSeqList<double>(writer, Fields[this.ColMap[26]], CVSReader.doubleParse, 2, "D");
			base.Write(writer, false, Fields[this.ColMap[27]]);
			base.WriteArray<int>(writer, Fields[this.ColMap[28]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[29]], CVSReader.intParse, 2, "I");
			base.WriteSeq<double>(writer, Fields[this.ColMap[30]], CVSReader.doubleParse, 2, "D");
			base.Write<int>(writer, Fields[this.ColMap[31]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[32]], CVSReader.intParse);
			base.Write<float>(writer, Fields[this.ColMap[33]], CVSReader.floatParse);
			base.Write<uint>(writer, Fields[this.ColMap[34]], CVSReader.uintParse);
			base.WriteSeq<float>(writer, Fields[this.ColMap[35]], CVSReader.floatParse, 2, "F");
			base.Write<uint>(writer, Fields[this.ColMap[36]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[37]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[38]], CVSReader.uintParse);
			base.Write<double>(writer, Fields[this.ColMap[39]], CVSReader.doubleParse);
			base.WriteSeqList<string>(writer, Fields[this.ColMap[40]], CVSReader.stringParse, 3, "S");
			base.Write<int>(writer, Fields[this.ColMap[41]], CVSReader.intParse);
			base.Write(writer, false, Fields[this.ColMap[42]]);
			base.WriteArray<uint>(writer, Fields[this.ColMap[43]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[44]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[45]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[46]], CVSReader.stringParse);
			base.WriteSeqList<string>(writer, Fields[this.ColMap[47]], CVSReader.stringParse, 2, "S");
			base.WriteArray<int>(writer, Fields[this.ColMap[48]], CVSReader.intParse);
			base.WriteSeqList<double>(writer, Fields[this.ColMap[49]], CVSReader.doubleParse, 2, "D");
			base.Write<int>(writer, Fields[this.ColMap[50]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			BuffTable.RowData rowData = new BuffTable.RowData();
			base.Read<int>(reader, ref rowData.BuffID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.BuffLevel, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.BuffSubType, CVSReader.intParse);
			this.columnno = 2;
			base.Read<float>(reader, ref rowData.BuffDuration, CVSReader.floatParse);
			this.columnno = 3;
			base.ReadSeqList<float>(reader, ref rowData.BuffChangeAttribute, CVSReader.floatParse);
			this.columnno = 4;
			base.Read<float>(reader, ref rowData.BuffRate, CVSReader.floatParse);
			this.columnno = 5;
			base.ReadArray<int>(reader, ref rowData.BuffState, CVSReader.intParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.BuffMergeType, CVSReader.intParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.TargetType, CVSReader.intParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.BuffIcon, CVSReader.stringParse);
			this.columnno = 9;
			base.ReadSeqList<int>(reader, ref rowData.BuffDOT, CVSReader.intParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.BuffFx, CVSReader.stringParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.BuffDoodadFx, CVSReader.stringParse);
			this.columnno = 12;
			base.Read<string>(reader, ref rowData.BuffName, CVSReader.stringParse);
			this.columnno = 13;
			base.ReadSeq<double>(reader, ref rowData.LifeAddAttack, CVSReader.doubleParse);
			this.columnno = 14;
			base.Read<int>(reader, ref rowData.BuffTriggerCond, CVSReader.intParse);
			this.columnno = 15;
			base.Read<float>(reader, ref rowData.BuffTriggerRate, CVSReader.floatParse);
			this.columnno = 16;
			base.ReadArray<string>(reader, ref rowData.BuffTriggerParam, CVSReader.stringParse);
			this.columnno = 17;
			base.ReadSeqList<int>(reader, ref rowData.BuffTriggerBuff, CVSReader.intParse);
			this.columnno = 18;
			base.Read<double>(reader, ref rowData.CostModify, CVSReader.doubleParse);
			this.columnno = 19;
			base.Read<double>(reader, ref rowData.CoolDownModify, CVSReader.doubleParse);
			this.columnno = 20;
			base.Read<double>(reader, ref rowData.BuffTriggerCD, CVSReader.doubleParse);
			this.columnno = 21;
			base.ReadSeqList<int>(reader, ref rowData.AuraAddBuffID, CVSReader.intParse);
			this.columnno = 22;
			base.Read(reader, ref rowData.BuffIsVisible);
			this.columnno = 23;
			base.Read<string>(reader, ref rowData.BuffEffectFx, CVSReader.stringParse);
			this.columnno = 24;
			base.ReadArray<float>(reader, ref rowData.AuraParams, CVSReader.floatParse);
			this.columnno = 25;
			base.ReadSeqList<double>(reader, ref rowData.DamageReduce, CVSReader.doubleParse);
			this.columnno = 26;
			base.Read(reader, ref rowData.DontShowText);
			this.columnno = 27;
			base.ReadArray<int>(reader, ref rowData.EffectGroup, CVSReader.intParse);
			this.columnno = 28;
			base.ReadSeqList<int>(reader, ref rowData.BuffDOTValueFromCaster, CVSReader.intParse);
			this.columnno = 29;
			base.ReadSeq<double>(reader, ref rowData.ChangeDamage, CVSReader.doubleParse);
			this.columnno = 30;
			base.Read<int>(reader, ref rowData.BuffClearType, CVSReader.intParse);
			this.columnno = 31;
			base.ReadArray<int>(reader, ref rowData.ClearTypes, CVSReader.intParse);
			this.columnno = 32;
			base.Read<float>(reader, ref rowData.DamageReflection, CVSReader.floatParse);
			this.columnno = 33;
			base.Read<uint>(reader, ref rowData.MobID, CVSReader.uintParse);
			this.columnno = 34;
			base.ReadSeq<float>(reader, ref rowData.BuffHP, CVSReader.floatParse);
			this.columnno = 35;
			base.Read<uint>(reader, ref rowData.StackMaxCount, CVSReader.uintParse);
			this.columnno = 36;
			base.Read<int>(reader, ref rowData.ChangeFightGroup, CVSReader.intParse);
			this.columnno = 37;
			base.Read<uint>(reader, ref rowData.BuffTriggerCount, CVSReader.uintParse);
			this.columnno = 38;
			base.Read<double>(reader, ref rowData.LifeSteal, CVSReader.doubleParse);
			this.columnno = 39;
			base.ReadSeqList<string>(reader, ref rowData.ReduceSkillCD, CVSReader.stringParse);
			this.columnno = 40;
			base.Read<int>(reader, ref rowData.StateParam, CVSReader.intParse);
			this.columnno = 41;
			base.Read(reader, ref rowData.IsGlobalTrigger);
			this.columnno = 42;
			base.ReadArray<uint>(reader, ref rowData.Tags, CVSReader.uintParse);
			this.columnno = 43;
			base.Read<string>(reader, ref rowData.BuffSpriteFx, CVSReader.stringParse);
			this.columnno = 44;
			base.Read<string>(reader, ref rowData.MiniMapIcon, CVSReader.stringParse);
			this.columnno = 45;
			base.Read<string>(reader, ref rowData.BuffTriggerSkill, CVSReader.stringParse);
			this.columnno = 46;
			base.ReadSeqList<string>(reader, ref rowData.ChangeSkillDamage, CVSReader.stringParse);
			this.columnno = 47;
			base.ReadArray<int>(reader, ref rowData.SceneEffect, CVSReader.intParse);
			this.columnno = 48;
			base.ReadSeqList<double>(reader, ref rowData.TargetLifeAddAttack, CVSReader.doubleParse);
			this.columnno = 49;
			base.Read<int>(reader, ref rowData.AIEvent, CVSReader.intParse);
			this.columnno = 50;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
