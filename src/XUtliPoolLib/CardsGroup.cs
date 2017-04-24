using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class CardsGroup : CVSReader
	{
		public class RowData
		{
			public uint GroupId;

			public uint TeamId;

			public uint[] FireCondition;

			public string TeamName;

			public Seq2ListRef<uint> FireProperty_1;

			public Seq2ListRef<uint> FireProperty_2;
		}

		public List<CardsGroup.RowData> Table = new List<CardsGroup.RowData>();

		public CardsGroup.RowData GetByTeamId(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchTeamId(key, 0, this.Table.Count - 1);
		}

		private CardsGroup.RowData BinarySearchTeamId(uint key, int min, int max)
		{
			CardsGroup.RowData rowData = this.Table[min];
			if (rowData.TeamId == key)
			{
				return rowData;
			}
			CardsGroup.RowData rowData2 = this.Table[max];
			if (rowData2.TeamId == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			CardsGroup.RowData rowData3 = this.Table[num];
			if (rowData3.TeamId.CompareTo(key) > 0)
			{
				return this.BinarySearchTeamId(key, min, num);
			}
			if (rowData3.TeamId.CompareTo(key) < 0)
			{
				return this.BinarySearchTeamId(key, num, max);
			}
			return rowData3;
		}

		private void AddRowTeamId(uint key, CardsGroup.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			CardsGroup.RowData rowData = this.Table[min];
			if (rowData.TeamId.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.TeamId == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: CardsGroup duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			CardsGroup.RowData rowData2 = this.Table[max];
			if (rowData2.TeamId.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.TeamId == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: CardsGroup duplicate id:{0}  lineno: {1}", new object[]
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
			CardsGroup.RowData rowData3 = this.Table[num];
			if (rowData3.TeamId.CompareTo(key) > 0)
			{
				this.AddRowTeamId(key, row, min, num);
				return;
			}
			if (rowData3.TeamId.CompareTo(key) < 0)
			{
				this.AddRowTeamId(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: CardsGroup duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"GroupId",
				"TeamId",
				"FireCondition",
				"TeamName",
				"FireProperty_1",
				"FireProperty_2"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			CardsGroup.RowData rowData = new CardsGroup.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.GroupId))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.TeamId))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.FireCondition))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.TeamName))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[4]], ref rowData.FireProperty_1, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[5]], ref rowData.FireProperty_2, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			this.AddRowTeamId(rowData.TeamId, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			CardsGroup.RowData rowData = new CardsGroup.RowData();
			base.Read<uint>(reader, ref rowData.GroupId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.TeamId, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadArray<uint>(reader, ref rowData.FireCondition, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.TeamName, CVSReader.stringParse);
			this.columnno = 3;
			base.ReadSeqList<uint>(reader, ref rowData.FireProperty_1, CVSReader.uintParse);
			this.columnno = 4;
			base.ReadSeqList<uint>(reader, ref rowData.FireProperty_2, CVSReader.uintParse);
			this.columnno = 5;
			this.AddRowTeamId(rowData.TeamId, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
