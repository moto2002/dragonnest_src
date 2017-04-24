using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class IBShop : CVSReader
	{
		public class RowData
		{
			public uint id;

			public uint type;

			public string name;

			public uint itemid;

			public uint discount;

			public uint viplevel;

			public bool bind;

			public uint levelshow;

			public uint levelbuy;

			public uint buycount;

			public uint refreshtype;

			public uint currencytype;

			public uint currencycount;

			public Seq2ListRef<string> limittime;

			public uint opensystemtime;

			public uint newproduct;

			public int sortid;

			public uint ischeckpaymember;

			public string activitytime;

			public uint[] activitycount;

			public Seq2Ref<uint> level;
		}

		public List<IBShop.RowData> Table = new List<IBShop.RowData>();

		public IBShop.RowData GetByid(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchid(key, 0, this.Table.Count - 1);
		}

		private IBShop.RowData BinarySearchid(uint key, int min, int max)
		{
			IBShop.RowData rowData = this.Table[min];
			if (rowData.id == key)
			{
				return rowData;
			}
			IBShop.RowData rowData2 = this.Table[max];
			if (rowData2.id == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			IBShop.RowData rowData3 = this.Table[num];
			if (rowData3.id.CompareTo(key) > 0)
			{
				return this.BinarySearchid(key, min, num);
			}
			if (rowData3.id.CompareTo(key) < 0)
			{
				return this.BinarySearchid(key, num, max);
			}
			return rowData3;
		}

		private void AddRowid(uint key, IBShop.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			IBShop.RowData rowData = this.Table[min];
			if (rowData.id.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: IBShop duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			IBShop.RowData rowData2 = this.Table[max];
			if (rowData2.id.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: IBShop duplicate id:{0}  lineno: {1}", new object[]
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
			IBShop.RowData rowData3 = this.Table[num];
			if (rowData3.id.CompareTo(key) > 0)
			{
				this.AddRowid(key, row, min, num);
				return;
			}
			if (rowData3.id.CompareTo(key) < 0)
			{
				this.AddRowid(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: IBShop duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"id",
				"type",
				"name",
				"itemid",
				"discount",
				"viplevel",
				"bind",
				"levelshow",
				"levelbuy",
				"buycount",
				"refreshtype",
				"currencytype",
				"currencycount",
				"limittime",
				"opensystemtime",
				"newproduct",
				"sortid",
				"ischeckpaymember",
				"activitytime",
				"activitycount",
				"level"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			IBShop.RowData rowData = new IBShop.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.id))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.type))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.itemid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.discount))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.viplevel))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.bind))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.levelshow))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.levelbuy))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.buycount))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.refreshtype))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[11]], ref rowData.currencytype))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.currencycount))
			{
				return false;
			}
			if (!base.Parse<string>(Fields[this.ColMap[13]], ref rowData.limittime, CVSReader.stringParse, "2S"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.opensystemtime))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[15]], ref rowData.newproduct))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.sortid))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[17]], ref rowData.ischeckpaymember))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[18]], ref rowData.activitytime))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[19]], ref rowData.activitycount))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[20]], ref rowData.level, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			this.AddRowid(rowData.id, rowData, 0, this.Table.Count - 1);
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.Write(writer, false, Fields[this.ColMap[6]]);
			base.Write<uint>(writer, Fields[this.ColMap[7]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[8]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[9]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[10]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[11]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[12]], CVSReader.uintParse);
			base.WriteSeqList<string>(writer, Fields[this.ColMap[13]], CVSReader.stringParse, 2, "S");
			base.Write<uint>(writer, Fields[this.ColMap[14]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[15]], CVSReader.uintParse);
			base.Write<int>(writer, Fields[this.ColMap[16]], CVSReader.intParse);
			base.Write<uint>(writer, Fields[this.ColMap[17]], CVSReader.uintParse);
			base.Write<string>(writer, Fields[this.ColMap[18]], CVSReader.stringParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[19]], CVSReader.uintParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[20]], CVSReader.uintParse, 2, "U");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			IBShop.RowData rowData = new IBShop.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.type, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.discount, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.viplevel, CVSReader.uintParse);
			this.columnno = 5;
			base.Read(reader, ref rowData.bind);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.levelshow, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.levelbuy, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.buycount, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.refreshtype, CVSReader.uintParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.currencytype, CVSReader.uintParse);
			this.columnno = 11;
			base.Read<uint>(reader, ref rowData.currencycount, CVSReader.uintParse);
			this.columnno = 12;
			base.ReadSeqList<string>(reader, ref rowData.limittime, CVSReader.stringParse);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.opensystemtime, CVSReader.uintParse);
			this.columnno = 14;
			base.Read<uint>(reader, ref rowData.newproduct, CVSReader.uintParse);
			this.columnno = 15;
			base.Read<int>(reader, ref rowData.sortid, CVSReader.intParse);
			this.columnno = 16;
			base.Read<uint>(reader, ref rowData.ischeckpaymember, CVSReader.uintParse);
			this.columnno = 17;
			base.Read<string>(reader, ref rowData.activitytime, CVSReader.stringParse);
			this.columnno = 18;
			base.ReadArray<uint>(reader, ref rowData.activitycount, CVSReader.uintParse);
			this.columnno = 19;
			base.ReadSeq<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 20;
			this.AddRowid(rowData.id, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
