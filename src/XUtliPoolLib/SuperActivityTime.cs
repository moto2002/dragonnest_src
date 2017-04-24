using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SuperActivityTime : CVSReader
	{
		public class RowData
		{
			public uint actid;

			public uint systemid;

			public uint minlevel;

			public uint starttime;

			public uint duration;

			public uint rewardtime;

			public uint pointid;

			public uint needpoint;

			public Seq2ListRef<uint> bigprize;

			public float rate;
		}

		public List<SuperActivityTime.RowData> Table = new List<SuperActivityTime.RowData>();

		public SuperActivityTime.RowData GetByactid(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchactid(key, 0, this.Table.Count - 1);
		}

		private SuperActivityTime.RowData BinarySearchactid(uint key, int min, int max)
		{
			SuperActivityTime.RowData rowData = this.Table[min];
			if (rowData.actid == key)
			{
				return rowData;
			}
			SuperActivityTime.RowData rowData2 = this.Table[max];
			if (rowData2.actid == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			SuperActivityTime.RowData rowData3 = this.Table[num];
			if (rowData3.actid.CompareTo(key) > 0)
			{
				return this.BinarySearchactid(key, min, num);
			}
			if (rowData3.actid.CompareTo(key) < 0)
			{
				return this.BinarySearchactid(key, num, max);
			}
			return rowData3;
		}

		private void AddRowactid(uint key, SuperActivityTime.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			SuperActivityTime.RowData rowData = this.Table[min];
			if (rowData.actid.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.actid == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SuperActivityTime duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			SuperActivityTime.RowData rowData2 = this.Table[max];
			if (rowData2.actid.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.actid == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SuperActivityTime duplicate id:{0}  lineno: {1}", new object[]
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
			SuperActivityTime.RowData rowData3 = this.Table[num];
			if (rowData3.actid.CompareTo(key) > 0)
			{
				this.AddRowactid(key, row, min, num);
				return;
			}
			if (rowData3.actid.CompareTo(key) < 0)
			{
				this.AddRowactid(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: SuperActivityTime duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"actid",
				"systemid",
				"minlevel",
				"starttime",
				"duration",
				"rewardtime",
				"pointid",
				"needpoint",
				"bigprize",
				"rate"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SuperActivityTime.RowData rowData = new SuperActivityTime.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.actid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.systemid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.minlevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.starttime))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.duration))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.rewardtime))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.pointid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.needpoint))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[8]], ref rowData.bigprize, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.rate))
			{
				return false;
			}
			this.AddRowactid(rowData.actid, rowData, 0, this.Table.Count - 1);
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
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse, 2, "U");
			base.Write<float>(writer, Fields[this.ColMap[9]], CVSReader.floatParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SuperActivityTime.RowData rowData = new SuperActivityTime.RowData();
			base.Read<uint>(reader, ref rowData.actid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.systemid, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.minlevel, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.starttime, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.duration, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.rewardtime, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.pointid, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.needpoint, CVSReader.uintParse);
			this.columnno = 7;
			base.ReadSeqList<uint>(reader, ref rowData.bigprize, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<float>(reader, ref rowData.rate, CVSReader.floatParse);
			this.columnno = 9;
			this.AddRowactid(rowData.actid, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
