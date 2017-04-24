using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SuperActivityTask : CVSReader
	{
		public class RowData
		{
			public uint taskid;

			public string title;

			public uint basetask;

			public uint[] num;

			public Seq2ListRef<uint> items;

			public string icon;

			public uint type;

			public uint belong;

			public uint jump;

			public uint actid;

			public int cnt;

			public int[] arg;

			public uint tasktype;

			public uint[] taskson;

			public uint taskfather;
		}

		public List<SuperActivityTask.RowData> Table = new List<SuperActivityTask.RowData>();

		public SuperActivityTask.RowData GetBytaskid(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchtaskid(key, 0, this.Table.Count - 1);
		}

		private SuperActivityTask.RowData BinarySearchtaskid(uint key, int min, int max)
		{
			SuperActivityTask.RowData rowData = this.Table[min];
			if (rowData.taskid == key)
			{
				return rowData;
			}
			SuperActivityTask.RowData rowData2 = this.Table[max];
			if (rowData2.taskid == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			SuperActivityTask.RowData rowData3 = this.Table[num];
			if (rowData3.taskid.CompareTo(key) > 0)
			{
				return this.BinarySearchtaskid(key, min, num);
			}
			if (rowData3.taskid.CompareTo(key) < 0)
			{
				return this.BinarySearchtaskid(key, num, max);
			}
			return rowData3;
		}

		private void AddRowtaskid(uint key, SuperActivityTask.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			SuperActivityTask.RowData rowData = this.Table[min];
			if (rowData.taskid.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.taskid == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SuperActivityTask duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			SuperActivityTask.RowData rowData2 = this.Table[max];
			if (rowData2.taskid.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.taskid == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SuperActivityTask duplicate id:{0}  lineno: {1}", new object[]
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
			SuperActivityTask.RowData rowData3 = this.Table[num];
			if (rowData3.taskid.CompareTo(key) > 0)
			{
				this.AddRowtaskid(key, row, min, num);
				return;
			}
			if (rowData3.taskid.CompareTo(key) < 0)
			{
				this.AddRowtaskid(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: SuperActivityTask duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"taskid",
				"title",
				"basetask",
				"num",
				"items",
				"icon",
				"type",
				"belong",
				"jump",
				"actid",
				"cnt",
				"arg",
				"tasktype",
				"taskson",
				"taskfather"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SuperActivityTask.RowData rowData = new SuperActivityTask.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.taskid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.title))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.basetask))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.num))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[4]], ref rowData.items, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.icon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.belong))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.jump))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.actid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.cnt))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.arg))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.tasktype))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.taskson))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.taskfather))
			{
				return false;
			}
			this.AddRowtaskid(rowData.taskid, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse, 2, "U");
			base.Write<string>(writer, Fields[this.ColMap[5]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[6]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[9]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[11]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[12]], CVSReader.uintParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[13]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[14]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SuperActivityTask.RowData rowData = new SuperActivityTask.RowData();
			base.Read<uint>(reader, ref rowData.taskid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.title, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.basetask, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadArray<uint>(reader, ref rowData.num, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadSeqList<uint>(reader, ref rowData.items, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.type, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.belong, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.jump, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.actid, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.cnt, CVSReader.intParse);
			this.columnno = 10;
			base.ReadArray<int>(reader, ref rowData.arg, CVSReader.intParse);
			this.columnno = 11;
			base.Read<uint>(reader, ref rowData.tasktype, CVSReader.uintParse);
			this.columnno = 12;
			base.ReadArray<uint>(reader, ref rowData.taskson, CVSReader.uintParse);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.taskfather, CVSReader.uintParse);
			this.columnno = 14;
			this.AddRowtaskid(rowData.taskid, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
