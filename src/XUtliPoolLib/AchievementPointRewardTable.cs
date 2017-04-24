using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class AchievementPointRewardTable : CVSReader
	{
		public class RowData
		{
			public int ID;

			public int Point;

			public Seq2ListRef<int> Reward;
		}

		public List<AchievementPointRewardTable.RowData> Table = new List<AchievementPointRewardTable.RowData>();

		public AchievementPointRewardTable.RowData GetByID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchID(key, 0, this.Table.Count - 1);
		}

		private AchievementPointRewardTable.RowData BinarySearchID(int key, int min, int max)
		{
			AchievementPointRewardTable.RowData rowData = this.Table[min];
			if (rowData.ID == key)
			{
				return rowData;
			}
			AchievementPointRewardTable.RowData rowData2 = this.Table[max];
			if (rowData2.ID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			AchievementPointRewardTable.RowData rowData3 = this.Table[num];
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

		private void AddRowID(int key, AchievementPointRewardTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			AchievementPointRewardTable.RowData rowData = this.Table[min];
			if (rowData.ID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: AchievementPointRewardTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			AchievementPointRewardTable.RowData rowData2 = this.Table[max];
			if (rowData2.ID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: AchievementPointRewardTable duplicate id:{0}  lineno: {1}", new object[]
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
			AchievementPointRewardTable.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: AchievementPointRewardTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ID",
				"Point",
				"Reward"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			AchievementPointRewardTable.RowData rowData = new AchievementPointRewardTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Point))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[2]], ref rowData.Reward, CVSReader.intParse, "2I"))
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
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse, 2, "I");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			AchievementPointRewardTable.RowData rowData = new AchievementPointRewardTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Point, CVSReader.intParse);
			this.columnno = 1;
			base.ReadSeqList<int>(reader, ref rowData.Reward, CVSReader.intParse);
			this.columnno = 2;
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
