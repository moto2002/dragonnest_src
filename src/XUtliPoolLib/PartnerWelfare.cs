using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PartnerWelfare : CVSReader
	{
		public class RowData
		{
			public uint Id;

			public string TittleTxt;

			public string ContentTxt;

			public string Pic;
		}

		public List<PartnerWelfare.RowData> Table = new List<PartnerWelfare.RowData>();

		public PartnerWelfare.RowData GetById(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchId(key, 0, this.Table.Count - 1);
		}

		private PartnerWelfare.RowData BinarySearchId(uint key, int min, int max)
		{
			PartnerWelfare.RowData rowData = this.Table[min];
			if (rowData.Id == key)
			{
				return rowData;
			}
			PartnerWelfare.RowData rowData2 = this.Table[max];
			if (rowData2.Id == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			PartnerWelfare.RowData rowData3 = this.Table[num];
			if (rowData3.Id.CompareTo(key) > 0)
			{
				return this.BinarySearchId(key, min, num);
			}
			if (rowData3.Id.CompareTo(key) < 0)
			{
				return this.BinarySearchId(key, num, max);
			}
			return rowData3;
		}

		private void AddRowId(uint key, PartnerWelfare.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			PartnerWelfare.RowData rowData = this.Table[min];
			if (rowData.Id.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.Id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PartnerWelfare duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			PartnerWelfare.RowData rowData2 = this.Table[max];
			if (rowData2.Id.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.Id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PartnerWelfare duplicate id:{0}  lineno: {1}", new object[]
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
			PartnerWelfare.RowData rowData3 = this.Table[num];
			if (rowData3.Id.CompareTo(key) > 0)
			{
				this.AddRowId(key, row, min, num);
				return;
			}
			if (rowData3.Id.CompareTo(key) < 0)
			{
				this.AddRowId(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: PartnerWelfare duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"Id",
				"TittleTxt",
				"ContentTxt",
				"Pic"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PartnerWelfare.RowData rowData = new PartnerWelfare.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.Id))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.TittleTxt))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.ContentTxt))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Pic))
			{
				return false;
			}
			this.AddRowId(rowData.Id, rowData, 0, this.Table.Count - 1);
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PartnerWelfare.RowData rowData = new PartnerWelfare.RowData();
			base.Read<uint>(reader, ref rowData.Id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.TittleTxt, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.ContentTxt, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Pic, CVSReader.stringParse);
			this.columnno = 3;
			this.AddRowId(rowData.Id, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
