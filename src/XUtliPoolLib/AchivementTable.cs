using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class AchivementTable : CVSReader
	{
		public class RowData
		{
			public int AchievementID;

			public int AchievementType;

			public string AchievementName;

			public string AchievementIcon;

			public int AchievementLevel;

			public Seq2ListRef<int> AchievementItem;

			public int AchievementParam;

			public string AchievementDescription;

			public int AchievementCategory;

			public int AchievementActiveDays;

			public int AchievementFetchDays;

			public int ShowAchivementTip;
		}

		public List<AchivementTable.RowData> Table = new List<AchivementTable.RowData>();

		public AchivementTable.RowData GetByAchievementID(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchAchievementID(key, 0, this.Table.Count - 1);
		}

		private AchivementTable.RowData BinarySearchAchievementID(int key, int min, int max)
		{
			AchivementTable.RowData rowData = this.Table[min];
			if (rowData.AchievementID == key)
			{
				return rowData;
			}
			AchivementTable.RowData rowData2 = this.Table[max];
			if (rowData2.AchievementID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			AchivementTable.RowData rowData3 = this.Table[num];
			if (rowData3.AchievementID.CompareTo(key) > 0)
			{
				return this.BinarySearchAchievementID(key, min, num);
			}
			if (rowData3.AchievementID.CompareTo(key) < 0)
			{
				return this.BinarySearchAchievementID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowAchievementID(int key, AchivementTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			AchivementTable.RowData rowData = this.Table[min];
			if (rowData.AchievementID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.AchievementID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: AchivementTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			AchivementTable.RowData rowData2 = this.Table[max];
			if (rowData2.AchievementID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.AchievementID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: AchivementTable duplicate id:{0}  lineno: {1}", new object[]
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
			AchivementTable.RowData rowData3 = this.Table[num];
			if (rowData3.AchievementID.CompareTo(key) > 0)
			{
				this.AddRowAchievementID(key, row, min, num);
				return;
			}
			if (rowData3.AchievementID.CompareTo(key) < 0)
			{
				this.AddRowAchievementID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: AchivementTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"AchievementID",
				"AchievementType",
				"AchievementName",
				"AchievementIcon",
				"AchievementLevel",
				"AchievementItem",
				"AchievementParam",
				"AchievementDescription",
				"AchievementCategory",
				"AchievementActiveDays",
				"AchievementFetchDays",
				"ShowAchivementTip"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			AchivementTable.RowData rowData = new AchivementTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.AchievementID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.AchievementType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.AchievementName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.AchievementIcon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.AchievementLevel))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[5]], ref rowData.AchievementItem, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.AchievementParam))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.AchievementDescription))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.AchievementCategory))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.AchievementActiveDays))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.AchievementFetchDays))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.ShowAchivementTip))
			{
				return false;
			}
			this.AddRowAchievementID(rowData.AchievementID, rowData, 0, this.Table.Count - 1);
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[11]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			AchivementTable.RowData rowData = new AchivementTable.RowData();
			base.Read<int>(reader, ref rowData.AchievementID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.AchievementType, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.AchievementName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.AchievementIcon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.AchievementLevel, CVSReader.intParse);
			this.columnno = 4;
			base.ReadSeqList<int>(reader, ref rowData.AchievementItem, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.AchievementParam, CVSReader.intParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.AchievementDescription, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.AchievementCategory, CVSReader.intParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.AchievementActiveDays, CVSReader.intParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.AchievementFetchDays, CVSReader.intParse);
			this.columnno = 10;
			base.Read<int>(reader, ref rowData.ShowAchivementTip, CVSReader.intParse);
			this.columnno = 11;
			this.AddRowAchievementID(rowData.AchievementID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
