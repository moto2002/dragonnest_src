using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class XEntityStatistics : CVSReader
	{
		public class RowData
		{
			public string Name;

			public uint PresentID;

			public float WalkSpeed;

			public float RunSpeed;

			public float[] FloatHeight;

			public float RotateSpeed;

			public float MaxHP;

			public float AttackProb;

			public float Sight;

			public int Type;

			public uint ID;

			public Seq2ListRef<int> InBornBuff;

			public float AttackBase;

			public bool IsWander;

			public bool Block;

			public float AIStartTime;

			public float AIActionGap;

			public uint FashionTemplate;

			public int MaxSuperArmor;

			public bool IsFixedInCD;

			public uint HpSection;

			public bool EndShow;

			public bool Highlight;

			public float MagicAttackBase;

			public int UseMyMesh;

			public Seq2Ref<uint> ExtraReward;

			public float FightTogetherDis;

			public int aihit;

			public double SuperArmorRecoveryValue;

			public double SuperArmorRecoveryMax;

			public Seq2Ref<int> SuperArmorBrokenBuff;

			public bool WeakStatus;

			public int InitEnmity;

			public bool AlwaysHpBar;

			public string AiBehavior;

			public int Fightgroup;

			public bool SoloShow;

			public bool UsingGeneralCutscene;

			public bool HideName;

			public float AttackSpeed;

			public float ratioleft;

			public float ratioright;

			public float ratioidle;

			public float ratiodistance;

			public float ratioskill;

			public float ratioexp;

			public float SkillCD;

			public bool BeLocked;

			public Seq4ListRef<float> navigation;

			public int IsNavPingpong;

			public bool HideInMiniMap;

			public uint Fov;

			public Seq2ListRef<uint> Access;

			public int SummonGroup;

			public bool SameBillBoard;
		}

		public List<XEntityStatistics.RowData> Table = new List<XEntityStatistics.RowData>();

		public XEntityStatistics.RowData GetByID(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchID(key, 0, this.Table.Count - 1);
		}

		private XEntityStatistics.RowData BinarySearchID(uint key, int min, int max)
		{
			XEntityStatistics.RowData rowData = this.Table[min];
			if (rowData.ID == key)
			{
				return rowData;
			}
			XEntityStatistics.RowData rowData2 = this.Table[max];
			if (rowData2.ID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			XEntityStatistics.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				return this.BinarySearchID(key, min, num);
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				return this.BinarySearchID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowID(uint key, XEntityStatistics.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			XEntityStatistics.RowData rowData = this.Table[min];
			if (rowData.ID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: XEntityStatistics duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			XEntityStatistics.RowData rowData2 = this.Table[max];
			if (rowData2.ID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: XEntityStatistics duplicate id:{0}  lineno: {1}", new object[]
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
			XEntityStatistics.RowData rowData3 = this.Table[num];
			if (rowData3.ID.CompareTo(key) > 0)
			{
				this.AddRowID(key, row, min, num);
				return;
			}
			if (rowData3.ID.CompareTo(key) < 0)
			{
				this.AddRowID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: XEntityStatistics duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Name",
				"PresentID",
				"WalkSpeed",
				"RunSpeed",
				"FloatHeight",
				"RotateSpeed",
				"MaxHP",
				"AttackProb",
				"Sight",
				"Type",
				"ID",
				"InBornBuff",
				"AttackBase",
				"IsWander",
				"Block",
				"AIStartTime",
				"AIActionGap",
				"FashionTemplate",
				"MaxSuperArmor",
				"IsFixedInCD",
				"HpSection",
				"EndShow",
				"Highlight",
				"MagicAttackBase",
				"UseMyMesh",
				"ExtraReward",
				"FightTogetherDis",
				"aihit",
				"SuperArmorRecoveryValue",
				"SuperArmorRecoveryMax",
				"SuperArmorBrokenBuff",
				"WeakStatus",
				"InitEnmity",
				"AlwaysHpBar",
				"AiBehavior",
				"Fightgroup",
				"SoloShow",
				"UsingGeneralCutscene",
				"HideName",
				"AttackSpeed",
				"ratioleft",
				"ratioright",
				"ratioidle",
				"ratiodistance",
				"ratioskill",
				"ratioexp",
				"SkillCD",
				"BeLocked",
				"navigation",
				"IsNavPingpong",
				"HideInMiniMap",
				"Fov",
				"Access",
				"SummonGroup",
				"SameBillBoard"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			XEntityStatistics.RowData rowData = new XEntityStatistics.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.PresentID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.WalkSpeed))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.RunSpeed))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.FloatHeight))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.RotateSpeed))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.MaxHP))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.AttackProb))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.Sight))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[11]], ref rowData.InBornBuff, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.AttackBase))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.IsWander))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.Block))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[15]], ref rowData.AIStartTime))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.AIActionGap))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[17]], ref rowData.FashionTemplate))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[18]], ref rowData.MaxSuperArmor))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[19]], ref rowData.IsFixedInCD))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[20]], ref rowData.HpSection))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[21]], ref rowData.EndShow))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[22]], ref rowData.Highlight))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[23]], ref rowData.MagicAttackBase))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[24]], ref rowData.UseMyMesh))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[25]], ref rowData.ExtraReward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[26]], ref rowData.FightTogetherDis))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[27]], ref rowData.aihit))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[28]], ref rowData.SuperArmorRecoveryValue))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[29]], ref rowData.SuperArmorRecoveryMax))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[30]], ref rowData.SuperArmorBrokenBuff, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[31]], ref rowData.WeakStatus))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[32]], ref rowData.InitEnmity))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[33]], ref rowData.AlwaysHpBar))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[34]], ref rowData.AiBehavior))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[35]], ref rowData.Fightgroup))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[36]], ref rowData.SoloShow))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[37]], ref rowData.UsingGeneralCutscene))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[38]], ref rowData.HideName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[39]], ref rowData.AttackSpeed))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[40]], ref rowData.ratioleft))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[41]], ref rowData.ratioright))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[42]], ref rowData.ratioidle))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[43]], ref rowData.ratiodistance))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[44]], ref rowData.ratioskill))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[45]], ref rowData.ratioexp))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[46]], ref rowData.SkillCD))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[47]], ref rowData.BeLocked))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[48]], ref rowData.navigation, CVSReader.floatParse, "4F"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[49]], ref rowData.IsNavPingpong))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[50]], ref rowData.HideInMiniMap))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[51]], ref rowData.Fov))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[52]], ref rowData.Access, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[53]], ref rowData.SummonGroup))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[54]], ref rowData.SameBillBoard))
			{
				return false;
			}
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<string>(writer, Fields[this.ColMap[0]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
			base.Write<float>(writer, Fields[this.ColMap[2]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[3]], CVSReader.floatParse);
			base.WriteArray<float>(writer, Fields[this.ColMap[4]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[5]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[6]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[7]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[8]], CVSReader.floatParse);
			base.Write<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[10]], CVSReader.uintParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[11]], CVSReader.intParse, 2, "I");
			base.Write<float>(writer, Fields[this.ColMap[12]], CVSReader.floatParse);
			base.Write(writer, false, Fields[this.ColMap[13]]);
			base.Write(writer, false, Fields[this.ColMap[14]]);
			base.Write<float>(writer, Fields[this.ColMap[15]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[16]], CVSReader.floatParse);
			base.Write<uint>(writer, Fields[this.ColMap[17]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[18]], CVSReader.intParse);
			base.Write(writer, false, Fields[this.ColMap[19]]);
			base.Write<uint>(writer, Fields[this.ColMap[20]], CVSReader.uintParse);
			base.Write(writer, false, Fields[this.ColMap[21]]);
			base.Write(writer, false, Fields[this.ColMap[22]]);
			base.Write<float>(writer, Fields[this.ColMap[23]], CVSReader.floatParse);
			base.Write<int>(writer, Fields[this.ColMap[24]], CVSReader.intParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[25]], CVSReader.uintParse, 2, "U");
			base.Write<float>(writer, Fields[this.ColMap[26]], CVSReader.floatParse);
			base.Write<int>(writer, Fields[this.ColMap[27]], CVSReader.intParse);
			base.Write<double>(writer, Fields[this.ColMap[28]], CVSReader.doubleParse);
			base.Write<double>(writer, Fields[this.ColMap[29]], CVSReader.doubleParse);
			base.WriteSeq<int>(writer, Fields[this.ColMap[30]], CVSReader.intParse, 2, "I");
			base.Write(writer, false, Fields[this.ColMap[31]]);
			base.Write<int>(writer, Fields[this.ColMap[32]], CVSReader.intParse);
			base.Write(writer, false, Fields[this.ColMap[33]]);
			base.Write<string>(writer, Fields[this.ColMap[34]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[35]], CVSReader.intParse);
			base.Write(writer, false, Fields[this.ColMap[36]]);
			base.Write(writer, false, Fields[this.ColMap[37]]);
			base.Write(writer, false, Fields[this.ColMap[38]]);
			base.Write<float>(writer, Fields[this.ColMap[39]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[40]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[41]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[42]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[43]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[44]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[45]], CVSReader.floatParse);
			base.Write<float>(writer, Fields[this.ColMap[46]], CVSReader.floatParse);
			base.Write(writer, false, Fields[this.ColMap[47]]);
			base.WriteSeqList<float>(writer, Fields[this.ColMap[48]], CVSReader.floatParse, 4, "F");
			base.Write<int>(writer, Fields[this.ColMap[49]], CVSReader.intParse);
			base.Write(writer, false, Fields[this.ColMap[50]]);
			base.Write<uint>(writer, Fields[this.ColMap[51]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[52]], CVSReader.uintParse, 2, "U");
			base.Write<int>(writer, Fields[this.ColMap[53]], CVSReader.intParse);
			base.Write(writer, false, Fields[this.ColMap[54]]);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			XEntityStatistics.RowData rowData = new XEntityStatistics.RowData();
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.PresentID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<float>(reader, ref rowData.WalkSpeed, CVSReader.floatParse);
			this.columnno = 2;
			base.Read<float>(reader, ref rowData.RunSpeed, CVSReader.floatParse);
			this.columnno = 3;
			base.ReadArray<float>(reader, ref rowData.FloatHeight, CVSReader.floatParse);
			this.columnno = 4;
			base.Read<float>(reader, ref rowData.RotateSpeed, CVSReader.floatParse);
			this.columnno = 5;
			base.Read<float>(reader, ref rowData.MaxHP, CVSReader.floatParse);
			this.columnno = 6;
			base.Read<float>(reader, ref rowData.AttackProb, CVSReader.floatParse);
			this.columnno = 7;
			base.Read<float>(reader, ref rowData.Sight, CVSReader.floatParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 10;
			base.ReadSeqList<int>(reader, ref rowData.InBornBuff, CVSReader.intParse);
			this.columnno = 11;
			base.Read<float>(reader, ref rowData.AttackBase, CVSReader.floatParse);
			this.columnno = 12;
			base.Read(reader, ref rowData.IsWander);
			this.columnno = 13;
			base.Read(reader, ref rowData.Block);
			this.columnno = 14;
			base.Read<float>(reader, ref rowData.AIStartTime, CVSReader.floatParse);
			this.columnno = 15;
			base.Read<float>(reader, ref rowData.AIActionGap, CVSReader.floatParse);
			this.columnno = 16;
			base.Read<uint>(reader, ref rowData.FashionTemplate, CVSReader.uintParse);
			this.columnno = 17;
			base.Read<int>(reader, ref rowData.MaxSuperArmor, CVSReader.intParse);
			this.columnno = 18;
			base.Read(reader, ref rowData.IsFixedInCD);
			this.columnno = 19;
			base.Read<uint>(reader, ref rowData.HpSection, CVSReader.uintParse);
			this.columnno = 20;
			base.Read(reader, ref rowData.EndShow);
			this.columnno = 21;
			base.Read(reader, ref rowData.Highlight);
			this.columnno = 22;
			base.Read<float>(reader, ref rowData.MagicAttackBase, CVSReader.floatParse);
			this.columnno = 23;
			base.Read<int>(reader, ref rowData.UseMyMesh, CVSReader.intParse);
			this.columnno = 24;
			base.ReadSeq<uint>(reader, ref rowData.ExtraReward, CVSReader.uintParse);
			this.columnno = 25;
			base.Read<float>(reader, ref rowData.FightTogetherDis, CVSReader.floatParse);
			this.columnno = 26;
			base.Read<int>(reader, ref rowData.aihit, CVSReader.intParse);
			this.columnno = 27;
			base.Read<double>(reader, ref rowData.SuperArmorRecoveryValue, CVSReader.doubleParse);
			this.columnno = 28;
			base.Read<double>(reader, ref rowData.SuperArmorRecoveryMax, CVSReader.doubleParse);
			this.columnno = 29;
			base.ReadSeq<int>(reader, ref rowData.SuperArmorBrokenBuff, CVSReader.intParse);
			this.columnno = 30;
			base.Read(reader, ref rowData.WeakStatus);
			this.columnno = 31;
			base.Read<int>(reader, ref rowData.InitEnmity, CVSReader.intParse);
			this.columnno = 32;
			base.Read(reader, ref rowData.AlwaysHpBar);
			this.columnno = 33;
			base.Read<string>(reader, ref rowData.AiBehavior, CVSReader.stringParse);
			this.columnno = 34;
			base.Read<int>(reader, ref rowData.Fightgroup, CVSReader.intParse);
			this.columnno = 35;
			base.Read(reader, ref rowData.SoloShow);
			this.columnno = 36;
			base.Read(reader, ref rowData.UsingGeneralCutscene);
			this.columnno = 37;
			base.Read(reader, ref rowData.HideName);
			this.columnno = 38;
			base.Read<float>(reader, ref rowData.AttackSpeed, CVSReader.floatParse);
			this.columnno = 39;
			base.Read<float>(reader, ref rowData.ratioleft, CVSReader.floatParse);
			this.columnno = 40;
			base.Read<float>(reader, ref rowData.ratioright, CVSReader.floatParse);
			this.columnno = 41;
			base.Read<float>(reader, ref rowData.ratioidle, CVSReader.floatParse);
			this.columnno = 42;
			base.Read<float>(reader, ref rowData.ratiodistance, CVSReader.floatParse);
			this.columnno = 43;
			base.Read<float>(reader, ref rowData.ratioskill, CVSReader.floatParse);
			this.columnno = 44;
			base.Read<float>(reader, ref rowData.ratioexp, CVSReader.floatParse);
			this.columnno = 45;
			base.Read<float>(reader, ref rowData.SkillCD, CVSReader.floatParse);
			this.columnno = 46;
			base.Read(reader, ref rowData.BeLocked);
			this.columnno = 47;
			base.ReadSeqList<float>(reader, ref rowData.navigation, CVSReader.floatParse);
			this.columnno = 48;
			base.Read<int>(reader, ref rowData.IsNavPingpong, CVSReader.intParse);
			this.columnno = 49;
			base.Read(reader, ref rowData.HideInMiniMap);
			this.columnno = 50;
			base.Read<uint>(reader, ref rowData.Fov, CVSReader.uintParse);
			this.columnno = 51;
			base.ReadSeqList<uint>(reader, ref rowData.Access, CVSReader.uintParse);
			this.columnno = 52;
			base.Read<int>(reader, ref rowData.SummonGroup, CVSReader.intParse);
			this.columnno = 53;
			base.Read(reader, ref rowData.SameBillBoard);
			this.columnno = 54;
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
