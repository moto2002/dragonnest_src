using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class AchievementV2Table : CVSReader
	{
		public class RowData
		{
			public int ID;

			public string Achievement;

			public int Type;

			public string Explanation;

			public int CompleteType;

			public int[] CompleteValue;

			public Seq2ListRef<int> Reward;

			public string ICON;

			public string DesignationName;

			public int GainShowIcon;

			public int SortID;
		}

		public List<AchievementV2Table.RowData> Table = new List<AchievementV2Table.RowData>();

		public AchievementV2Table.RowData GetByID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchID(key, 0, this.Table.Count - 1);
		}

		private AchievementV2Table.RowData BinarySearchID(int key, int min, int max)
		{
			AchievementV2Table.RowData rowData = this.Table[min];
			if (rowData.ID == key)
			{
				return rowData;
			}
			AchievementV2Table.RowData rowData2 = this.Table[max];
			if (rowData2.ID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			AchievementV2Table.RowData rowData3 = this.Table[num];
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

		private void AddRowID(int key, AchievementV2Table.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			AchievementV2Table.RowData rowData = this.Table[min];
			if (rowData.ID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: AchievementV2Table duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			AchievementV2Table.RowData rowData2 = this.Table[max];
			if (rowData2.ID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: AchievementV2Table duplicate id:{0}  lineno: {1}", new object[]
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
			AchievementV2Table.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: AchievementV2Table duplicate id:{0}  lineno: {1}", new object[]
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
				"Achievement",
				"Type",
				"Explanation",
				"CompleteType",
				"CompleteValue",
				"Reward",
				"ICON",
				"DesignationName",
				"GainShowIcon",
				"SortID"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			AchievementV2Table.RowData rowData = new AchievementV2Table.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Achievement))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Explanation))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.CompleteType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.CompleteValue))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[6]], ref rowData.Reward, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.ICON))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.DesignationName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.GainShowIcon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.SortID))
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
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse, 2, "I");
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[8]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			AchievementV2Table.RowData rowData = new AchievementV2Table.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Achievement, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Explanation, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.CompleteType, CVSReader.intParse);
			this.columnno = 4;
			base.ReadArray<int>(reader, ref rowData.CompleteValue, CVSReader.intParse);
			this.columnno = 5;
			base.ReadSeqList<int>(reader, ref rowData.Reward, CVSReader.intParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.ICON, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.DesignationName, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.GainShowIcon, CVSReader.intParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.SortID, CVSReader.intParse);
			this.columnno = 10;
			this.AddRowID(rowData.ID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
