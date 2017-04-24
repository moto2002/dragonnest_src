using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class MentorCompleteRewardTable : CVSReader
	{
		public class RowData
		{
			public int Type;

			public Seq2ListRef<int> MasterReward;

			public Seq2ListRef<int> StudentReward;
		}

		public List<MentorCompleteRewardTable.RowData> Table = new List<MentorCompleteRewardTable.RowData>();

		public MentorCompleteRewardTable.RowData GetByType(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchType(key, 0, this.Table.Count - 1);
		}

		private MentorCompleteRewardTable.RowData BinarySearchType(int key, int min, int max)
		{
			MentorCompleteRewardTable.RowData rowData = this.Table[min];
			if (rowData.Type == key)
			{
				return rowData;
			}
			MentorCompleteRewardTable.RowData rowData2 = this.Table[max];
			if (rowData2.Type == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			MentorCompleteRewardTable.RowData rowData3 = this.Table[num];
			if (rowData3.Type.CompareTo(key) > 0)
			{
				return this.BinarySearchType(key, min, num);
			}
			if (rowData3.Type.CompareTo(key) < 0)
			{
				return this.BinarySearchType(key, num, max);
			}
			return rowData3;
		}

		private void AddRowType(int key, MentorCompleteRewardTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			MentorCompleteRewardTable.RowData rowData = this.Table[min];
			if (rowData.Type.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.Type == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: MentorCompleteRewardTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			MentorCompleteRewardTable.RowData rowData2 = this.Table[max];
			if (rowData2.Type.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.Type == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: MentorCompleteRewardTable duplicate id:{0}  lineno: {1}", new object[]
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
			MentorCompleteRewardTable.RowData rowData3 = this.Table[num];
			if (rowData3.Type.CompareTo(key) > 0)
			{
				this.AddRowType(key, row, min, num);
				return;
			}
			if (rowData3.Type.CompareTo(key) < 0)
			{
				this.AddRowType(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: MentorCompleteRewardTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Type",
				"MasterReward",
				"StudentReward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			MentorCompleteRewardTable.RowData rowData = new MentorCompleteRewardTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[1]], ref rowData.MasterReward, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[2]], ref rowData.StudentReward, CVSReader.intParse, "2I"))
			{
				return false;
			}
			this.AddRowType(rowData.Type, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse, 2, "I");
			base.WriteSeqList<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse, 2, "I");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			MentorCompleteRewardTable.RowData rowData = new MentorCompleteRewardTable.RowData();
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 0;
			base.ReadSeqList<int>(reader, ref rowData.MasterReward, CVSReader.intParse);
			this.columnno = 1;
			base.ReadSeqList<int>(reader, ref rowData.StudentReward, CVSReader.intParse);
			this.columnno = 2;
			this.AddRowType(rowData.Type, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
