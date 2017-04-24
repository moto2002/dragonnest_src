using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class TeamTowerRewardTable : CVSReader
	{
		public class RowData
		{
			public int TowerHardLevel;

			public int TowerFloor;

			public Seq2ListRef<int> Reward;

			public string Name;

			public int DragonCoinFindBackCost;

			public int GoldCoinCost;

			public Seq2ListRef<int> GoldCoinFindBackItem;

			public int SceneID;

			public Seq2ListRef<int> FirstPassReward;

			public int preward;
		}

		public List<TeamTowerRewardTable.RowData> Table = new List<TeamTowerRewardTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"TowerHardLevel",
				"TowerFloor",
				"Reward",
				"Name",
				"DragonCoinFindBackCost",
				"GoldCoinCost",
				"GoldCoinFindBackItem",
				"SceneID",
				"FirstPassReward",
				"preward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			TeamTowerRewardTable.RowData rowData = new TeamTowerRewardTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.TowerHardLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.TowerFloor))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[2]], ref rowData.Reward, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.DragonCoinFindBackCost))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.GoldCoinCost))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[6]], ref rowData.GoldCoinFindBackItem, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.SceneID))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[8]], ref rowData.FirstPassReward, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.preward))
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
			base.WriteSeqList<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse, 2, "I");
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			TeamTowerRewardTable.RowData rowData = new TeamTowerRewardTable.RowData();
			base.Read<int>(reader, ref rowData.TowerHardLevel, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.TowerFloor, CVSReader.intParse);
			this.columnno = 1;
			base.ReadSeqList<int>(reader, ref rowData.Reward, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.DragonCoinFindBackCost, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.GoldCoinCost, CVSReader.intParse);
			this.columnno = 5;
			base.ReadSeqList<int>(reader, ref rowData.GoldCoinFindBackItem, CVSReader.intParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.SceneID, CVSReader.intParse);
			this.columnno = 7;
			base.ReadSeqList<int>(reader, ref rowData.FirstPassReward, CVSReader.intParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.preward, CVSReader.intParse);
			this.columnno = 9;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
