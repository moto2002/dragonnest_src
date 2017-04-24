using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class QAConditionTable : CVSReader
	{
		public class RowData
		{
			public int QAType;

			public int StartLevel;

			public int EndLevel;

			public int Count;

			public int CoolDown;

			public int MinPlayerNum;

			public int MaxPlayerNum;

			public Seq2ListRef<uint> Reward;

			public Seq2ListRef<uint> ExtraReward;

			public int PrepareTime;

			public Seq2ListRef<uint> LevelSection;
		}

		public List<QAConditionTable.RowData> Table = new List<QAConditionTable.RowData>();

		public QAConditionTable.RowData GetByQAType(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchQAType(key, 0, this.Table.Count - 1);
		}

		private QAConditionTable.RowData BinarySearchQAType(int key, int min, int max)
		{
			QAConditionTable.RowData rowData = this.Table[min];
			if (rowData.QAType == key)
			{
				return rowData;
			}
			QAConditionTable.RowData rowData2 = this.Table[max];
			if (rowData2.QAType == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			QAConditionTable.RowData rowData3 = this.Table[num];
			if (rowData3.QAType.CompareTo(key) > 0)
			{
				return this.BinarySearchQAType(key, min, num);
			}
			if (rowData3.QAType.CompareTo(key) < 0)
			{
				return this.BinarySearchQAType(key, num, max);
			}
			return rowData3;
		}

		private void AddRowQAType(int key, QAConditionTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			QAConditionTable.RowData rowData = this.Table[min];
			if (rowData.QAType.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.QAType == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: QAConditionTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			QAConditionTable.RowData rowData2 = this.Table[max];
			if (rowData2.QAType.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.QAType == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: QAConditionTable duplicate id:{0}  lineno: {1}", new object[]
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
			QAConditionTable.RowData rowData3 = this.Table[num];
			if (rowData3.QAType.CompareTo(key) > 0)
			{
				this.AddRowQAType(key, row, min, num);
				return;
			}
			if (rowData3.QAType.CompareTo(key) < 0)
			{
				this.AddRowQAType(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: QAConditionTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"QAType",
				"StartLevel",
				"EndLevel",
				"Count",
				"CoolDown",
				"MinPlayerNum",
				"MaxPlayerNum",
				"Reward",
				"ExtraReward",
				"PrepareTime",
				"LevelSection"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			QAConditionTable.RowData rowData = new QAConditionTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.QAType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.StartLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.EndLevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Count))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.CoolDown))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.MinPlayerNum))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.MaxPlayerNum))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[7]], ref rowData.Reward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[8]], ref rowData.ExtraReward, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.PrepareTime))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[10]], ref rowData.LevelSection, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			this.AddRowQAType(rowData.QAType, rowData, 0, this.Table.Count - 1);
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
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse, 2, "U");
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse, 2, "U");
			base.Write<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[10]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			QAConditionTable.RowData rowData = new QAConditionTable.RowData();
			base.Read<int>(reader, ref rowData.QAType, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.StartLevel, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.EndLevel, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.Count, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.CoolDown, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.MinPlayerNum, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.MaxPlayerNum, CVSReader.intParse);
			this.columnno = 6;
			base.ReadSeqList<uint>(reader, ref rowData.Reward, CVSReader.uintParse);
			this.columnno = 7;
			base.ReadSeqList<uint>(reader, ref rowData.ExtraReward, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.PrepareTime, CVSReader.intParse);
			this.columnno = 9;
			base.ReadSeqList<uint>(reader, ref rowData.LevelSection, CVSReader.uintParse);
			this.columnno = 10;
			this.AddRowQAType(rowData.QAType, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
