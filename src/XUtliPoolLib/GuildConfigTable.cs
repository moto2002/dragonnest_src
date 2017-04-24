using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class GuildConfigTable : CVSReader
	{
		public class RowData
		{
			public int GuildLevel;

			public uint GuildExpNeed;

			public int GuildNumber;

			public int PokerTimes;

			public int PokerReplaceTimes;

			public int GuildSign;

			public int GuildWelfare;

			public int GuildStore;

			public int GuildSkill;

			public int GuildStage;

			public uint GuildPokerTimes;

			public uint AllGuildSign;

			public uint AllGuildStage;

			public uint GuildDragon;

			public uint GuildWar;

			public int GuildActivity;

			public int PresidentNum;

			public int VicePresidentNum;

			public int OfficialNum;

			public int EliteMemberNum;

			public Seq2ListRef<int> GuildCheckInBonus;

			public uint StudySkillTimes;

			public Seq2ListRef<int> GuildChallengeReward;

			public int GuildArena;

			public Seq3ListRef<uint> GuildChallengeGExp;

			public Seq2ListRef<uint> GuildChallengeSolo;

			public int GuildChallenge;

			public int GuildJokerMatch;

			public int GuildSalay;

			public int GuildMine;

			public int GuildTerritory;
		}

		public List<GuildConfigTable.RowData> Table = new List<GuildConfigTable.RowData>();

		public GuildConfigTable.RowData GetByGuildLevel(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchGuildLevel(key, 0, this.Table.Count - 1);
		}

		private GuildConfigTable.RowData BinarySearchGuildLevel(int key, int min, int max)
		{
			GuildConfigTable.RowData rowData = this.Table[min];
			if (rowData.GuildLevel == key)
			{
				return rowData;
			}
			GuildConfigTable.RowData rowData2 = this.Table[max];
			if (rowData2.GuildLevel == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			GuildConfigTable.RowData rowData3 = this.Table[num];
			if (rowData3.GuildLevel.CompareTo(key) > 0)
			{
				return this.BinarySearchGuildLevel(key, min, num);
			}
			if (rowData3.GuildLevel.CompareTo(key) < 0)
			{
				return this.BinarySearchGuildLevel(key, num, max);
			}
			return rowData3;
		}

		private void AddRowGuildLevel(int key, GuildConfigTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			GuildConfigTable.RowData rowData = this.Table[min];
			if (rowData.GuildLevel.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.GuildLevel == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildConfigTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			GuildConfigTable.RowData rowData2 = this.Table[max];
			if (rowData2.GuildLevel.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.GuildLevel == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildConfigTable duplicate id:{0}  lineno: {1}", new object[]
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
			GuildConfigTable.RowData rowData3 = this.Table[num];
			if (rowData3.GuildLevel.CompareTo(key) > 0)
			{
				this.AddRowGuildLevel(key, row, min, num);
				return;
			}
			if (rowData3.GuildLevel.CompareTo(key) < 0)
			{
				this.AddRowGuildLevel(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: GuildConfigTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"GuildLevel",
				"GuildExpNeed",
				"GuildNumber",
				"PokerTimes",
				"PokerReplaceTimes",
				"GuildSign",
				"GuildWelfare",
				"GuildStore",
				"GuildSkill",
				"GuildStage",
				"GuildPokerTimes",
				"AllGuildSign",
				"AllGuildStage",
				"GuildDragon",
				"GuildWar",
				"GuildActivity",
				"PresidentNum",
				"VicePresidentNum",
				"OfficialNum",
				"EliteMemberNum",
				"GuildCheckInBonus",
				"StudySkillTimes",
				"GuildChallengeReward",
				"GuildArena",
				"GuildChallengeGExp",
				"GuildChallengeSolo",
				"GuildChallenge",
				"GuildJokerMatch",
				"GuildSalay",
				"GuildMine",
				"GuildTerritory"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			GuildConfigTable.RowData rowData = new GuildConfigTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.GuildLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.GuildExpNeed))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.GuildNumber))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.PokerTimes))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.PokerReplaceTimes))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.GuildSign))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.GuildWelfare))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.GuildStore))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.GuildSkill))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.GuildStage))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.GuildPokerTimes))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.AllGuildSign))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.AllGuildStage))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.GuildDragon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.GuildWar))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[15]], ref rowData.GuildActivity))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.PresidentNum))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[17]], ref rowData.VicePresidentNum))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[18]], ref rowData.OfficialNum))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[19]], ref rowData.EliteMemberNum))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[20]], ref rowData.GuildCheckInBonus, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[21]], ref rowData.StudySkillTimes))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[22]], ref rowData.GuildChallengeReward, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[23]], ref rowData.GuildArena))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[24]], ref rowData.GuildChallengeGExp, CVSReader.uintParse, "3U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[25]], ref rowData.GuildChallengeSolo, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[26]], ref rowData.GuildChallenge))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[27]], ref rowData.GuildJokerMatch))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[28]], ref rowData.GuildSalay))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[29]], ref rowData.GuildMine))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[30]], ref rowData.GuildTerritory))
			{
				return false;
			}
			this.AddRowGuildLevel(rowData.GuildLevel, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[10]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[11]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[12]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[13]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[14]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[15]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[16]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[17]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[18]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[19]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[20]], CVSReader.intParse, 2, "I");
			base.Write<uint>(writer, Fields[this.ColMap[21]], CVSReader.uintParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[22]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[23]], CVSReader.intParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[24]], CVSReader.uintParse, 3, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[25]], CVSReader.uintParse, 2, "U");
			base.Write<int>(writer, Fields[this.ColMap[26]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[27]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[28]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[29]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[30]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			GuildConfigTable.RowData rowData = new GuildConfigTable.RowData();
			base.Read<int>(reader, ref rowData.GuildLevel, CVSReader.intParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.GuildExpNeed, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.GuildNumber, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.PokerTimes, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.PokerReplaceTimes, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.GuildSign, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.GuildWelfare, CVSReader.intParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.GuildStore, CVSReader.intParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.GuildSkill, CVSReader.intParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.GuildStage, CVSReader.intParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.GuildPokerTimes, CVSReader.uintParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.AllGuildSign, CVSReader.uintParse);
			this.columnno = 11;
			base.Read<uint>(reader, ref rowData.AllGuildStage, CVSReader.uintParse);
			this.columnno = 12;
			base.Read<uint>(reader, ref rowData.GuildDragon, CVSReader.uintParse);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.GuildWar, CVSReader.uintParse);
			this.columnno = 14;
			base.Read<int>(reader, ref rowData.GuildActivity, CVSReader.intParse);
			this.columnno = 15;
			base.Read<int>(reader, ref rowData.PresidentNum, CVSReader.intParse);
			this.columnno = 16;
			base.Read<int>(reader, ref rowData.VicePresidentNum, CVSReader.intParse);
			this.columnno = 17;
			base.Read<int>(reader, ref rowData.OfficialNum, CVSReader.intParse);
			this.columnno = 18;
			base.Read<int>(reader, ref rowData.EliteMemberNum, CVSReader.intParse);
			this.columnno = 19;
			base.ReadSeqList<int>(reader, ref rowData.GuildCheckInBonus, CVSReader.intParse);
			this.columnno = 20;
			base.Read<uint>(reader, ref rowData.StudySkillTimes, CVSReader.uintParse);
			this.columnno = 21;
			base.ReadSeqList<int>(reader, ref rowData.GuildChallengeReward, CVSReader.intParse);
			this.columnno = 22;
			base.Read<int>(reader, ref rowData.GuildArena, CVSReader.intParse);
			this.columnno = 23;
			base.ReadSeqList<uint>(reader, ref rowData.GuildChallengeGExp, CVSReader.uintParse);
			this.columnno = 24;
			base.ReadSeqList<uint>(reader, ref rowData.GuildChallengeSolo, CVSReader.uintParse);
			this.columnno = 25;
			base.Read<int>(reader, ref rowData.GuildChallenge, CVSReader.intParse);
			this.columnno = 26;
			base.Read<int>(reader, ref rowData.GuildJokerMatch, CVSReader.intParse);
			this.columnno = 27;
			base.Read<int>(reader, ref rowData.GuildSalay, CVSReader.intParse);
			this.columnno = 28;
			base.Read<int>(reader, ref rowData.GuildMine, CVSReader.intParse);
			this.columnno = 29;
			base.Read<int>(reader, ref rowData.GuildTerritory, CVSReader.intParse);
			this.columnno = 30;
			this.AddRowGuildLevel(rowData.GuildLevel, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
