using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class ExpeditionTable : CVSReader
	{
		public class RowData
		{
			public int DNExpeditionID;

			public string DNExpeditionName;

			public uint[] ViewableDropList;

			public int RequiredLevel;

			public int PlayerNumber;

			public uint[] RandomSceneIDs;

			public int GuildLevel;

			public int Type;

			public Seq2ListRef<int> OpenTime;

			public int PlayerLeastNumber;

			public int Category;

			public double RobotLifePercent;

			public uint DisplayLevel;

			public uint DisplayPPT;

			public uint RobotLookupID;

			public int fastmatch;

			public int FMARobotTime;

			public Seq2ListRef<int> CostItem;

			public uint LevelSealType;

			public int CanHelp;

			public bool AutoRefuse;

			public int AutoSelectPriority;

			public double RobotAtkPercent;

			public Seq3ListRef<uint> CostType;

			public int CostCountType;

			public uint PreReadyScene;

			public uint LevelSealTeamCost;

			public Seq2Ref<uint> ServerOpenTime;

			public uint KickLeaderTime;

			public int SortID;

			public Seq2Ref<uint> UseTicket;

			public Seq2Ref<uint> Stars;
		}

		public List<ExpeditionTable.RowData> Table = new List<ExpeditionTable.RowData>();

		public ExpeditionTable.RowData GetByDNExpeditionID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchDNExpeditionID(key, 0, this.Table.Count - 1);
		}

		private ExpeditionTable.RowData BinarySearchDNExpeditionID(int key, int min, int max)
		{
			ExpeditionTable.RowData rowData = this.Table[min];
			if (rowData.DNExpeditionID == key)
			{
				return rowData;
			}
			ExpeditionTable.RowData rowData2 = this.Table[max];
			if (rowData2.DNExpeditionID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			ExpeditionTable.RowData rowData3 = this.Table[num];
			if (rowData3.DNExpeditionID.CompareTo(key) > 0)
			{
				return this.BinarySearchDNExpeditionID(key, min, num);
			}
			if (rowData3.DNExpeditionID.CompareTo(key) < 0)
			{
				return this.BinarySearchDNExpeditionID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowDNExpeditionID(int key, ExpeditionTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			ExpeditionTable.RowData rowData = this.Table[min];
			if (rowData.DNExpeditionID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.DNExpeditionID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ExpeditionTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			ExpeditionTable.RowData rowData2 = this.Table[max];
			if (rowData2.DNExpeditionID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.DNExpeditionID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: ExpeditionTable duplicate id:{0}  lineno: {1}", new object[]
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
			ExpeditionTable.RowData rowData3 = this.Table[num];
			if (rowData3.DNExpeditionID.CompareTo(key) > 0)
			{
				this.AddRowDNExpeditionID(key, row, min, num);
				return;
			}
			if (rowData3.DNExpeditionID.CompareTo(key) < 0)
			{
				this.AddRowDNExpeditionID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: ExpeditionTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"DNExpeditionID",
				"DNExpeditionName",
				"ViewableDropList",
				"RequiredLevel",
				"PlayerNumber",
				"RandomSceneIDs",
				"GuildLevel",
				"Type",
				"OpenTime",
				"PlayerLeastNumber",
				"Category",
				"RobotLifePercent",
				"DisplayLevel",
				"DisplayPPT",
				"RobotLookupID",
				"fastmatch",
				"FMARobotTime",
				"CostItem",
				"LevelSealType",
				"CanHelp",
				"AutoRefuse",
				"AutoSelectPriority",
				"RobotAtkPercent",
				"CostType",
				"CostCountType",
				"PreReadyScene",
				"LevelSealTeamCost",
				"ServerOpenTime",
				"KickLeaderTime",
				"SortID",
				"UseTicket",
				"Stars"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			ExpeditionTable.RowData rowData = new ExpeditionTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.DNExpeditionID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.DNExpeditionName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.ViewableDropList))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.RequiredLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.PlayerNumber))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.RandomSceneIDs))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.GuildLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[8]], ref rowData.OpenTime, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.PlayerLeastNumber))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.Category))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.RobotLifePercent))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.DisplayLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.DisplayPPT))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.RobotLookupID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[15]], ref rowData.fastmatch))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.FMARobotTime))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[17]], ref rowData.CostItem, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[18]], ref rowData.LevelSealType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[19]], ref rowData.CanHelp))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[20]], ref rowData.AutoRefuse))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[21]], ref rowData.AutoSelectPriority))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[22]], ref rowData.RobotAtkPercent))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[23]], ref rowData.CostType, CVSReader.uintParse, "3U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[24]], ref rowData.CostCountType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[25]], ref rowData.PreReadyScene))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[26]], ref rowData.LevelSealTeamCost))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[27]], ref rowData.ServerOpenTime, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[28]], ref rowData.KickLeaderTime))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[29]], ref rowData.SortID))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[30]], ref rowData.UseTicket, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[31]], ref rowData.Stars, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			this.AddRowDNExpeditionID(rowData.DNExpeditionID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse);
			base.Write<double>(writer, Fields[this.ColMap[11]], CVSReader.doubleParse);
			base.Write<uint>(writer, Fields[this.ColMap[12]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[13]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[14]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[15]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[16]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[17]], CVSReader.intParse, 2, "I");
			base.Write<uint>(writer, Fields[this.ColMap[18]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[19]], CVSReader.intParse);
			base.Write(writer, false, Fields[this.ColMap[20]]);
			base.Write<int>(writer, Fields[this.ColMap[21]], CVSReader.intParse);
			base.Write<double>(writer, Fields[this.ColMap[22]], CVSReader.doubleParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[23]], CVSReader.uintParse, 3, "U");
			base.Write<int>(writer, Fields[this.ColMap[24]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[25]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[26]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[27]], CVSReader.uintParse, 2, "U");
			base.Write<uint>(writer, Fields[this.ColMap[28]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[29]], CVSReader.intParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[30]], CVSReader.uintParse, 2, "U");
			base.WriteSeq<uint>(writer, Fields[this.ColMap[31]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			ExpeditionTable.RowData rowData = new ExpeditionTable.RowData();
			base.Read<int>(reader, ref rowData.DNExpeditionID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.DNExpeditionName, CVSReader.stringParse);
			this.columnno = 1;
			base.ReadArray<uint>(reader, ref rowData.ViewableDropList, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.RequiredLevel, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.PlayerNumber, CVSReader.intParse);
			this.columnno = 4;
			base.ReadArray<uint>(reader, ref rowData.RandomSceneIDs, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.GuildLevel, CVSReader.intParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 7;
			base.ReadSeqList<int>(reader, ref rowData.OpenTime, CVSReader.intParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.PlayerLeastNumber, CVSReader.intParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.Category, CVSReader.intParse);
			this.columnno = 10;
			base.Read<double>(reader, ref rowData.RobotLifePercent, CVSReader.doubleParse);
			this.columnno = 11;
			base.Read<uint>(reader, ref rowData.DisplayLevel, CVSReader.uintParse);
			this.columnno = 12;
			base.Read<uint>(reader, ref rowData.DisplayPPT, CVSReader.uintParse);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.RobotLookupID, CVSReader.uintParse);
			this.columnno = 14;
			base.Read<int>(reader, ref rowData.fastmatch, CVSReader.intParse);
			this.columnno = 15;
			base.Read<int>(reader, ref rowData.FMARobotTime, CVSReader.intParse);
			this.columnno = 16;
			base.ReadSeqList<int>(reader, ref rowData.CostItem, CVSReader.intParse);
			this.columnno = 17;
			base.Read<uint>(reader, ref rowData.LevelSealType, CVSReader.uintParse);
			this.columnno = 18;
			base.Read<int>(reader, ref rowData.CanHelp, CVSReader.intParse);
			this.columnno = 19;
			base.Read(reader, ref rowData.AutoRefuse);
			this.columnno = 20;
			base.Read<int>(reader, ref rowData.AutoSelectPriority, CVSReader.intParse);
			this.columnno = 21;
			base.Read<double>(reader, ref rowData.RobotAtkPercent, CVSReader.doubleParse);
			this.columnno = 22;
			base.ReadSeqList<uint>(reader, ref rowData.CostType, CVSReader.uintParse);
			this.columnno = 23;
			base.Read<int>(reader, ref rowData.CostCountType, CVSReader.intParse);
			this.columnno = 24;
			base.Read<uint>(reader, ref rowData.PreReadyScene, CVSReader.uintParse);
			this.columnno = 25;
			base.Read<uint>(reader, ref rowData.LevelSealTeamCost, CVSReader.uintParse);
			this.columnno = 26;
			base.ReadSeq<uint>(reader, ref rowData.ServerOpenTime, CVSReader.uintParse);
			this.columnno = 27;
			base.Read<uint>(reader, ref rowData.KickLeaderTime, CVSReader.uintParse);
			this.columnno = 28;
			base.Read<int>(reader, ref rowData.SortID, CVSReader.intParse);
			this.columnno = 29;
			base.ReadSeq<uint>(reader, ref rowData.UseTicket, CVSReader.uintParse);
			this.columnno = 30;
			base.ReadSeq<uint>(reader, ref rowData.Stars, CVSReader.uintParse);
			this.columnno = 31;
			this.AddRowDNExpeditionID(rowData.DNExpeditionID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
