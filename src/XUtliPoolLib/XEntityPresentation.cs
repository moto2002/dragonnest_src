using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class XEntityPresentation : CVSReader
	{
		public class RowData
		{
			public string Prefab;

			public string A;

			public string AA;

			public string AAA;

			public string AAAA;

			public string AAAAA;

			public string Ultra;

			public string[] OtherSkills;

			public string[] Hit_f;

			public string[] HitFly;

			public string Idle;

			public string Walk;

			public string Run;

			public string Death;

			public string Appear;

			public string[] Hit_l;

			public string[] Hit_r;

			public uint PresentID;

			public string[] HitCurves;

			public string AnimLocation;

			public string SkillLocation;

			public string CurveLocation;

			public string Avatar;

			public string[] DeathCurve;

			public float[] HitBackOffsetTimeScale;

			public float[] HitFlyOffsetTimeScale;

			public float Scale;

			public string BoneSuffix;

			public string Disappear;

			public bool Shadow;

			public string Dash;

			public string Freeze;

			public float[] HitBack_Recover;

			public float[] HitFly_Bounce_GetUp;

			public float BoundRadius;

			public float BoundHeight;

			public string AttackIdle;

			public string AttackWalk;

			public string AttackRun;

			public string EnterGame;

			public string[] Hit_Roll;

			public float[] HitRollOffsetTimeScale;

			public float HitRoll_Recover;

			public bool Huge;

			public string MoveFx;

			public string FreezeFx;

			public string HitFx;

			public string DeathFx;

			public string SuperArmorRecoverySkill;

			public string Feeble;

			public string FeebleFx;

			public string ArmorBroken;

			public string RecoveryFX;

			public string RecoveryHitSlowFX;

			public string RecoveryHitStopFX;

			public string FishingIdle;

			public string FishingCast;

			public string FishingPull;

			public float[] BoundRadiusOffset;

			public Seq4ListRef<float> HugeMonsterColliders;

			public float UIAvatarScale;

			public float UIAvatarAngle;

			public string FishingWait;

			public string FishingWin;

			public string FishingLose;

			public string Dance;

			public string[] AvatarPos;

			public string InheritActionOne;

			public string InheritActionTwo;

			public string Kiss;
		}

		public List<XEntityPresentation.RowData> Table = new List<XEntityPresentation.RowData>();

		public XEntityPresentation.RowData GetByPresentID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchPresentID(key, 0, this.Table.Count - 1);
		}

		private XEntityPresentation.RowData BinarySearchPresentID(uint key, int min, int max)
		{
			XEntityPresentation.RowData rowData = this.Table[min];
			if (rowData.PresentID == key)
			{
				return rowData;
			}
			XEntityPresentation.RowData rowData2 = this.Table[max];
			if (rowData2.PresentID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			XEntityPresentation.RowData rowData3 = this.Table[num];
			if (rowData3.PresentID.CompareTo(key) > 0)
			{
				return this.BinarySearchPresentID(key, min, num);
			}
			if (rowData3.PresentID.CompareTo(key) < 0)
			{
				return this.BinarySearchPresentID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowPresentID(uint key, XEntityPresentation.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			XEntityPresentation.RowData rowData = this.Table[min];
			if (rowData.PresentID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.PresentID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: XEntityPresentation duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			XEntityPresentation.RowData rowData2 = this.Table[max];
			if (rowData2.PresentID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.PresentID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: XEntityPresentation duplicate id:{0}  lineno: {1}", new object[]
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
			XEntityPresentation.RowData rowData3 = this.Table[num];
			if (rowData3.PresentID.CompareTo(key) > 0)
			{
				this.AddRowPresentID(key, row, min, num);
				return;
			}
			if (rowData3.PresentID.CompareTo(key) < 0)
			{
				this.AddRowPresentID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: XEntityPresentation duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Prefab",
				"A",
				"AA",
				"AAA",
				"AAAA",
				"AAAAA",
				"Ultra",
				"OtherSkills",
				"Hit_f",
				"HitFly",
				"Idle",
				"Walk",
				"Run",
				"Death",
				"Appear",
				"Hit_l",
				"Hit_r",
				"PresentID",
				"HitCurves",
				"AnimLocation",
				"SkillLocation",
				"CurveLocation",
				"Avatar",
				"DeathCurve",
				"HitBackOffsetTimeScale",
				"HitFlyOffsetTimeScale",
				"Scale",
				"BoneSuffix",
				"Disappear",
				"Shadow",
				"Dash",
				"Freeze",
				"HitBack_Recover",
				"HitFly_Bounce_GetUp",
				"BoundRadius",
				"BoundHeight",
				"AttackIdle",
				"AttackWalk",
				"AttackRun",
				"EnterGame",
				"Hit_Roll",
				"HitRollOffsetTimeScale",
				"HitRoll_Recover",
				"Huge",
				"MoveFx",
				"FreezeFx",
				"HitFx",
				"DeathFx",
				"SuperArmorRecoverySkill",
				"Feeble",
				"FeebleFx",
				"ArmorBroken",
				"RecoveryFX",
				"RecoveryHitSlowFX",
				"RecoveryHitStopFX",
				"FishingIdle",
				"FishingCast",
				"FishingPull",
				"BoundRadiusOffset",
				"HugeMonsterColliders",
				"UIAvatarScale",
				"UIAvatarAngle",
				"FishingWait",
				"FishingWin",
				"FishingLose",
				"Dance",
				"AvatarPos",
				"InheritActionOne",
				"InheritActionTwo",
				"Kiss"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			XEntityPresentation.RowData rowData = new XEntityPresentation.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Prefab))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.A))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.AA))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.AAA))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.AAAA))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.AAAAA))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Ultra))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.OtherSkills))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.Hit_f))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.HitFly))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.Idle))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.Walk))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.Run))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.Death))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.Appear))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[15]], ref rowData.Hit_l))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.Hit_r))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[17]], ref rowData.PresentID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[18]], ref rowData.HitCurves))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[19]], ref rowData.AnimLocation))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[20]], ref rowData.SkillLocation))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[21]], ref rowData.CurveLocation))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[22]], ref rowData.Avatar))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[23]], ref rowData.DeathCurve))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[24]], ref rowData.HitBackOffsetTimeScale))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[25]], ref rowData.HitFlyOffsetTimeScale))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[26]], ref rowData.Scale))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[27]], ref rowData.BoneSuffix))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[28]], ref rowData.Disappear))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[29]], ref rowData.Shadow))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[30]], ref rowData.Dash))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[31]], ref rowData.Freeze))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[32]], ref rowData.HitBack_Recover))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[33]], ref rowData.HitFly_Bounce_GetUp))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[34]], ref rowData.BoundRadius))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[35]], ref rowData.BoundHeight))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[36]], ref rowData.AttackIdle))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[37]], ref rowData.AttackWalk))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[38]], ref rowData.AttackRun))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[39]], ref rowData.EnterGame))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[40]], ref rowData.Hit_Roll))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[41]], ref rowData.HitRollOffsetTimeScale))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[42]], ref rowData.HitRoll_Recover))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[43]], ref rowData.Huge))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[44]], ref rowData.MoveFx))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[45]], ref rowData.FreezeFx))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[46]], ref rowData.HitFx))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[47]], ref rowData.DeathFx))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[48]], ref rowData.SuperArmorRecoverySkill))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[49]], ref rowData.Feeble))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[50]], ref rowData.FeebleFx))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[51]], ref rowData.ArmorBroken))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[52]], ref rowData.RecoveryFX))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[53]], ref rowData.RecoveryHitSlowFX))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[54]], ref rowData.RecoveryHitStopFX))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[55]], ref rowData.FishingIdle))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[56]], ref rowData.FishingCast))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[57]], ref rowData.FishingPull))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[58]], ref rowData.BoundRadiusOffset))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[59]], ref rowData.HugeMonsterColliders, CVSReader.floatParse, "4F"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[60]], ref rowData.UIAvatarScale))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[61]], ref rowData.UIAvatarAngle))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[62]], ref rowData.FishingWait))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[63]], ref rowData.FishingWin))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[64]], ref rowData.FishingLose))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[65]], ref rowData.Dance))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[66]], ref rowData.AvatarPos))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[67]], ref rowData.InheritActionOne))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[68]], ref rowData.InheritActionTwo))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[69]], ref rowData.Kiss))
			{
				return false;
			}
			this.AddRowPresentID(rowData.PresentID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<string>(writer, Fields[this.ColMap[0]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[8]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[9]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[10]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[11]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[12]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[13]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[14]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[15]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[16]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[17]], CVSReader.uintParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[18]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[19]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[20]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[21]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[22]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[23]], CVSReader.stringParse);
			base.WriteArray<float>(writer, Fields[this.ColMap[24]], CVSReader.floatParse);
			base.WriteArray<float>(writer, Fields[this.ColMap[25]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[26]], CVSReader.floatParse);
			base.Write<string>(writer, Fields[this.ColMap[27]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[28]], CVSReader.stringParse);
			base.Write(writer, false, Fields[this.ColMap[29]]);
			base.Write<string>(writer, Fields[this.ColMap[30]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[31]], CVSReader.stringParse);
			base.WriteArray<float>(writer, Fields[this.ColMap[32]], CVSReader.floatParse);
			base.WriteArray<float>(writer, Fields[this.ColMap[33]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[34]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[35]], CVSReader.floatParse);
			base.Write<string>(writer, Fields[this.ColMap[36]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[37]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[38]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[39]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[40]], CVSReader.stringParse);
			base.WriteArray<float>(writer, Fields[this.ColMap[41]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[42]], CVSReader.floatParse);
			base.Write(writer, false, Fields[this.ColMap[43]]);
			base.Write<string>(writer, Fields[this.ColMap[44]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[45]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[46]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[47]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[48]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[49]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[50]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[51]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[52]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[53]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[54]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[55]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[56]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[57]], CVSReader.stringParse);
			base.WriteArray<float>(writer, Fields[this.ColMap[58]], CVSReader.floatParse);
			base.WriteSeqList<float>(writer, Fields[this.ColMap[59]], CVSReader.floatParse, 4, "F");
			base.Write<float>(writer, Fields[this.ColMap[60]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[61]], CVSReader.floatParse);
			base.Write<string>(writer, Fields[this.ColMap[62]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[63]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[64]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[65]], CVSReader.stringParse);
			base.WriteArray<string>(writer, Fields[this.ColMap[66]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[67]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[68]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[69]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			XEntityPresentation.RowData rowData = new XEntityPresentation.RowData();
			base.Read<string>(reader, ref rowData.Prefab, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.A, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.AA, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.AAA, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.AAAA, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.AAAAA, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Ultra, CVSReader.stringParse);
			this.columnno = 6;
			base.ReadArray<string>(reader, ref rowData.OtherSkills, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadArray<string>(reader, ref rowData.Hit_f, CVSReader.stringParse);
			this.columnno = 8;
			base.ReadArray<string>(reader, ref rowData.HitFly, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.Idle, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.Walk, CVSReader.stringParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.Run, CVSReader.stringParse);
			this.columnno = 12;
			base.Read<string>(reader, ref rowData.Death, CVSReader.stringParse);
			this.columnno = 13;
			base.Read<string>(reader, ref rowData.Appear, CVSReader.stringParse);
			this.columnno = 14;
			base.ReadArray<string>(reader, ref rowData.Hit_l, CVSReader.stringParse);
			this.columnno = 15;
			base.ReadArray<string>(reader, ref rowData.Hit_r, CVSReader.stringParse);
			this.columnno = 16;
			base.Read<uint>(reader, ref rowData.PresentID, CVSReader.uintParse);
			this.columnno = 17;
			base.ReadArray<string>(reader, ref rowData.HitCurves, CVSReader.stringParse);
			this.columnno = 18;
			base.Read<string>(reader, ref rowData.AnimLocation, CVSReader.stringParse);
			this.columnno = 19;
			base.Read<string>(reader, ref rowData.SkillLocation, CVSReader.stringParse);
			this.columnno = 20;
			base.Read<string>(reader, ref rowData.CurveLocation, CVSReader.stringParse);
			this.columnno = 21;
			base.Read<string>(reader, ref rowData.Avatar, CVSReader.stringParse);
			this.columnno = 22;
			base.ReadArray<string>(reader, ref rowData.DeathCurve, CVSReader.stringParse);
			this.columnno = 23;
			base.ReadArray<float>(reader, ref rowData.HitBackOffsetTimeScale, CVSReader.floatParse);
			this.columnno = 24;
			base.ReadArray<float>(reader, ref rowData.HitFlyOffsetTimeScale, CVSReader.floatParse);
			this.columnno = 25;
			base.Read<float>(reader, ref rowData.Scale, CVSReader.floatParse);
			this.columnno = 26;
			base.Read<string>(reader, ref rowData.BoneSuffix, CVSReader.stringParse);
			this.columnno = 27;
			base.Read<string>(reader, ref rowData.Disappear, CVSReader.stringParse);
			this.columnno = 28;
			base.Read(reader, ref rowData.Shadow);
			this.columnno = 29;
			base.Read<string>(reader, ref rowData.Dash, CVSReader.stringParse);
			this.columnno = 30;
			base.Read<string>(reader, ref rowData.Freeze, CVSReader.stringParse);
			this.columnno = 31;
			base.ReadArray<float>(reader, ref rowData.HitBack_Recover, CVSReader.floatParse);
			this.columnno = 32;
			base.ReadArray<float>(reader, ref rowData.HitFly_Bounce_GetUp, CVSReader.floatParse);
			this.columnno = 33;
			base.Read<float>(reader, ref rowData.BoundRadius, CVSReader.floatParse);
			this.columnno = 34;
			base.Read<float>(reader, ref rowData.BoundHeight, CVSReader.floatParse);
			this.columnno = 35;
			base.Read<string>(reader, ref rowData.AttackIdle, CVSReader.stringParse);
			this.columnno = 36;
			base.Read<string>(reader, ref rowData.AttackWalk, CVSReader.stringParse);
			this.columnno = 37;
			base.Read<string>(reader, ref rowData.AttackRun, CVSReader.stringParse);
			this.columnno = 38;
			base.Read<string>(reader, ref rowData.EnterGame, CVSReader.stringParse);
			this.columnno = 39;
			base.ReadArray<string>(reader, ref rowData.Hit_Roll, CVSReader.stringParse);
			this.columnno = 40;
			base.ReadArray<float>(reader, ref rowData.HitRollOffsetTimeScale, CVSReader.floatParse);
			this.columnno = 41;
			base.Read<float>(reader, ref rowData.HitRoll_Recover, CVSReader.floatParse);
			this.columnno = 42;
			base.Read(reader, ref rowData.Huge);
			this.columnno = 43;
			base.Read<string>(reader, ref rowData.MoveFx, CVSReader.stringParse);
			this.columnno = 44;
			base.Read<string>(reader, ref rowData.FreezeFx, CVSReader.stringParse);
			this.columnno = 45;
			base.Read<string>(reader, ref rowData.HitFx, CVSReader.stringParse);
			this.columnno = 46;
			base.Read<string>(reader, ref rowData.DeathFx, CVSReader.stringParse);
			this.columnno = 47;
			base.Read<string>(reader, ref rowData.SuperArmorRecoverySkill, CVSReader.stringParse);
			this.columnno = 48;
			base.Read<string>(reader, ref rowData.Feeble, CVSReader.stringParse);
			this.columnno = 49;
			base.Read<string>(reader, ref rowData.FeebleFx, CVSReader.stringParse);
			this.columnno = 50;
			base.Read<string>(reader, ref rowData.ArmorBroken, CVSReader.stringParse);
			this.columnno = 51;
			base.Read<string>(reader, ref rowData.RecoveryFX, CVSReader.stringParse);
			this.columnno = 52;
			base.Read<string>(reader, ref rowData.RecoveryHitSlowFX, CVSReader.stringParse);
			this.columnno = 53;
			base.Read<string>(reader, ref rowData.RecoveryHitStopFX, CVSReader.stringParse);
			this.columnno = 54;
			base.Read<string>(reader, ref rowData.FishingIdle, CVSReader.stringParse);
			this.columnno = 55;
			base.Read<string>(reader, ref rowData.FishingCast, CVSReader.stringParse);
			this.columnno = 56;
			base.Read<string>(reader, ref rowData.FishingPull, CVSReader.stringParse);
			this.columnno = 57;
			base.ReadArray<float>(reader, ref rowData.BoundRadiusOffset, CVSReader.floatParse);
			this.columnno = 58;
			base.ReadSeqList<float>(reader, ref rowData.HugeMonsterColliders, CVSReader.floatParse);
			this.columnno = 59;
			base.Read<float>(reader, ref rowData.UIAvatarScale, CVSReader.floatParse);
			this.columnno = 60;
			base.Read<float>(reader, ref rowData.UIAvatarAngle, CVSReader.floatParse);
			this.columnno = 61;
			base.Read<string>(reader, ref rowData.FishingWait, CVSReader.stringParse);
			this.columnno = 62;
			base.Read<string>(reader, ref rowData.FishingWin, CVSReader.stringParse);
			this.columnno = 63;
			base.Read<string>(reader, ref rowData.FishingLose, CVSReader.stringParse);
			this.columnno = 64;
			base.Read<string>(reader, ref rowData.Dance, CVSReader.stringParse);
			this.columnno = 65;
			base.ReadArray<string>(reader, ref rowData.AvatarPos, CVSReader.stringParse);
			this.columnno = 66;
			base.Read<string>(reader, ref rowData.InheritActionOne, CVSReader.stringParse);
			this.columnno = 67;
			base.Read<string>(reader, ref rowData.InheritActionTwo, CVSReader.stringParse);
			this.columnno = 68;
			base.Read<string>(reader, ref rowData.Kiss, CVSReader.stringParse);
			this.columnno = 69;
			this.AddRowPresentID(rowData.PresentID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
