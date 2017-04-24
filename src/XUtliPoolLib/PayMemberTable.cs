using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class PayMemberTable : CVSReader
	{
		public class RowData
		{
			public string ParamID;

			public int ID;

			public string Name;

			public int Price;

			public int Days;

			public int DragonCoin;

			public Seq2Ref<int> Flower;

			public int ChatCount;

			public int FatigueLimit;

			public int AbyssCount;

			public int ReviveCount;

			public Seq2Ref<int> PetFeedAdd;

			public int BossRushCount;

			public int BuyGreenAgateLimit;

			public int[] CheckinDoubleDays;

			public Seq2Ref<int> SpriteFeedAdd;

			public int SuperRiskCount;

			public int SystemID;

			public string Icon;

			public string Desc;

			public string Tip;

			public int ExpireMailID;

			public string Detail;

			public string BuyNtf;

			public int[] CheckinDoubleEvenDays;

			public string ServiceCode;

			public Seq2Ref<uint> Value;

			public int ExpireSoonMailID;
		}

		public List<PayMemberTable.RowData> Table = new List<PayMemberTable.RowData>();

		public PayMemberTable.RowData GetByParamID(string key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchParamID(key, 0, this.Table.Count - 1);
		}

		private PayMemberTable.RowData BinarySearchParamID(string key, int min, int max)
		{
			PayMemberTable.RowData rowData = this.Table[min];
			if (rowData.ParamID == key)
			{
				return rowData;
			}
			PayMemberTable.RowData rowData2 = this.Table[max];
			if (rowData2.ParamID == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			PayMemberTable.RowData rowData3 = this.Table[num];
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

		private void AddRowParamID(string key, PayMemberTable.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			PayMemberTable.RowData rowData = this.Table[min];
			if (rowData.ParamID.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.ParamID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PayMemberTable duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			PayMemberTable.RowData rowData2 = this.Table[max];
			if (rowData2.ParamID.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.ParamID == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: PayMemberTable duplicate id:{0}  lineno: {1}", new object[]
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
			PayMemberTable.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: PayMemberTable duplicate id:{0}  lineno: {1}", new object[]
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
				"ID",
				"Name",
				"Price",
				"Days",
				"DragonCoin",
				"Flower",
				"ChatCount",
				"FatigueLimit",
				"AbyssCount",
				"ReviveCount",
				"PetFeedAdd",
				"BossRushCount",
				"BuyGreenAgateLimit",
				"CheckinDoubleDays",
				"SpriteFeedAdd",
				"SuperRiskCount",
				"SystemID",
				"Icon",
				"Desc",
				"Tip",
				"ExpireMailID",
				"Detail",
				"BuyNtf",
				"CheckinDoubleEvenDays",
				"ServiceCode",
				"Value",
				"ExpireSoonMailID"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			PayMemberTable.RowData rowData = new PayMemberTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.ParamID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.ID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Name))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Price))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Days))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.DragonCoin))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[6]], ref rowData.Flower, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[7]], ref rowData.ChatCount))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[8]], ref rowData.FatigueLimit))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[9]], ref rowData.AbyssCount))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[10]], ref rowData.ReviveCount))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[11]], ref rowData.PetFeedAdd, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[12]], ref rowData.BossRushCount))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[13]], ref rowData.BuyGreenAgateLimit))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[14]], ref rowData.CheckinDoubleDays))
			{
				return false;
			}
			if (!base.Parse<int>(Fields[this.ColMap[15]], ref rowData.SpriteFeedAdd, CVSReader.intParse, "2I"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[16]], ref rowData.SuperRiskCount))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[17]], ref rowData.SystemID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[18]], ref rowData.Icon))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[19]], ref rowData.Desc))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[20]], ref rowData.Tip))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[21]], ref rowData.ExpireMailID))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[22]], ref rowData.Detail))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[23]], ref rowData.BuyNtf))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[24]], ref rowData.CheckinDoubleEvenDays))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[25]], ref rowData.ServiceCode))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[26]], ref rowData.Value, CVSReader.uintParse, "2U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[27]], ref rowData.ExpireSoonMailID))
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
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[3]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[4]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[5]], CVSReader.intParse);
			base.WriteSeq<int>(writer, Fields[this.ColMap[6]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[7]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[8]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[9]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[10]], CVSReader.intParse);
			base.WriteSeq<int>(writer, Fields[this.ColMap[11]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[12]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[13]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[14]], CVSReader.intParse);
			base.WriteSeq<int>(writer, Fields[this.ColMap[15]], CVSReader.intParse, 2, "I");
			base.Write<int>(writer, Fields[this.ColMap[16]], CVSReader.intParse);
			base.Write<int>(writer, Fields[this.ColMap[17]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[18]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[19]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[20]], CVSReader.stringParse);
			base.Write<int>(writer, Fields[this.ColMap[21]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[22]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[23]], CVSReader.stringParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[24]], CVSReader.intParse);
			base.Write<string>(writer, Fields[this.ColMap[25]], CVSReader.stringParse);
			base.WriteSeq<uint>(writer, Fields[this.ColMap[26]], CVSReader.uintParse, 2, "U");
			base.Write<int>(writer, Fields[this.ColMap[27]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			PayMemberTable.RowData rowData = new PayMemberTable.RowData();
			base.Read<string>(reader, ref rowData.ParamID, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.Price, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.Days, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.DragonCoin, CVSReader.intParse);
			this.columnno = 5;
			base.ReadSeq<int>(reader, ref rowData.Flower, CVSReader.intParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.ChatCount, CVSReader.intParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.FatigueLimit, CVSReader.intParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.AbyssCount, CVSReader.intParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.ReviveCount, CVSReader.intParse);
			this.columnno = 10;
			base.ReadSeq<int>(reader, ref rowData.PetFeedAdd, CVSReader.intParse);
			this.columnno = 11;
			base.Read<int>(reader, ref rowData.BossRushCount, CVSReader.intParse);
			this.columnno = 12;
			base.Read<int>(reader, ref rowData.BuyGreenAgateLimit, CVSReader.intParse);
			this.columnno = 13;
			base.ReadArray<int>(reader, ref rowData.CheckinDoubleDays, CVSReader.intParse);
			this.columnno = 14;
			base.ReadSeq<int>(reader, ref rowData.SpriteFeedAdd, CVSReader.intParse);
			this.columnno = 15;
			base.Read<int>(reader, ref rowData.SuperRiskCount, CVSReader.intParse);
			this.columnno = 16;
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
			this.columnno = 17;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 18;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 19;
			base.Read<string>(reader, ref rowData.Tip, CVSReader.stringParse);
			this.columnno = 20;
			base.Read<int>(reader, ref rowData.ExpireMailID, CVSReader.intParse);
			this.columnno = 21;
			base.Read<string>(reader, ref rowData.Detail, CVSReader.stringParse);
			this.columnno = 22;
			base.Read<string>(reader, ref rowData.BuyNtf, CVSReader.stringParse);
			this.columnno = 23;
			base.ReadArray<int>(reader, ref rowData.CheckinDoubleEvenDays, CVSReader.intParse);
			this.columnno = 24;
			base.Read<string>(reader, ref rowData.ServiceCode, CVSReader.stringParse);
			this.columnno = 25;
			base.ReadSeq<uint>(reader, ref rowData.Value, CVSReader.uintParse);
			this.columnno = 26;
			base.Read<int>(reader, ref rowData.ExpireSoonMailID, CVSReader.intParse);
			this.columnno = 27;
			this.AddRowParamID(rowData.ParamID, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
