using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class RechargeTable : CVSReader
	{
		public class RowData
		{
			public string ParamID;

			public int Price;

			public int Diamond;

			public Seq2ListRef<int> RoleLevels;

			public Seq2ListRef<int> LoginDays;

			public int SystemID;

			public string Name;

			public string ServiceCode;
		}

		public List<RechargeTable.RowData> Table = new List<RechargeTable.RowData>();

		public RechargeTable.RowData GetByParamID(string key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchParamID(key, 0, this.Table.Count - 1);
		}

		private RechargeTable.RowData BinarySearchParamID(string key, int min, int max)
		{
			RechargeTable.RowData rowData = this.Table[min];
			if (rowData.ParamID == key)
			{
				return rowData;
			}
			RechargeTable.RowData rowData2 = this.Table[max];
			if (rowData2.ParamID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			RechargeTable.RowData rowData3 = this.Table[num];
			if (rowData3.ParamID.CompareTo(key) > 0)
			{
				return this.BinarySearchParamID(key, min, num);
			}
			if (rowData3.ParamID.CompareTo(key) < 0)
			{
				return this.BinarySearchParamID(key, num, max);
			}
			return rowData3;
		}

		private void AddRowParamID(string key, RechargeTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			RechargeTable.RowData rowData = this.Table[min];
			if (rowData.ParamID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ParamID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: RechargeTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			RechargeTable.RowData rowData2 = this.Table[max];
			if (rowData2.ParamID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ParamID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: RechargeTable duplicate id:{0}  lineno: {1}", new object[]
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
			RechargeTable.RowData rowData3 = this.Table[num];
			if (rowData3.ParamID.CompareTo(key) > 0)
			{
				this.AddRowParamID(key, row, min, num);
				return;
			}
			if (rowData3.ParamID.CompareTo(key) < 0)
			{
				this.AddRowParamID(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: RechargeTable duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"ParamID",
				"Price",
				"Diamond",
				"RoleLevels",
				"LoginDays",
				"SystemID",
				"Name",
				"ServiceCode"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			RechargeTable.RowData rowData = new RechargeTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ParamID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Price))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Diamond))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[3]], ref rowData.RoleLevels, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[4]], ref rowData.LoginDays, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.SystemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[6]], ref rowData.Name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.ServiceCode))
			{
				return false;
			}
			this.AddRowParamID(rowData.ParamID, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<string>(writer, Fields[this.ColMap[0]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[2]], CVSReader.intParse);
			base.WriteSeqList<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse, 2, "I");
			base.WriteSeqList<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[6]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[7]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			RechargeTable.RowData rowData = new RechargeTable.RowData();
			base.Read<string>(reader, ref rowData.ParamID, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Price, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Diamond, CVSReader.intParse);
			this.columnno = 2;
			base.ReadSeqList<int>(reader, ref rowData.RoleLevels, CVSReader.intParse);
			this.columnno = 3;
			base.ReadSeqList<int>(reader, ref rowData.LoginDays, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.ServiceCode, CVSReader.stringParse);
			this.columnno = 7;
			this.AddRowParamID(rowData.ParamID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
