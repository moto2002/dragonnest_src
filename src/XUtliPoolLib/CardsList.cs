using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class CardsList : CVSReader
	{
		public class RowData
		{
			public uint CardId;

			public string CardName;

			public uint GroupId;

			public string Description;

			public uint Avatar;

			public uint MapID;
		}

		public List<CardsList.RowData> Table = new List<CardsList.RowData>();

		public CardsList.RowData GetByCardId(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchCardId(key, 0, this.Table.Count - 1);
		}

		private CardsList.RowData BinarySearchCardId(uint key, int min, int max)
		{
			CardsList.RowData rowData = this.Table[min];
			if (rowData.CardId == key)
			{
				return rowData;
			}
			CardsList.RowData rowData2 = this.Table[max];
			if (rowData2.CardId == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			CardsList.RowData rowData3 = this.Table[num];
			if (rowData3.CardId.CompareTo(key) > 0)
			{
				return this.BinarySearchCardId(key, min, num);
			}
			if (rowData3.CardId.CompareTo(key) < 0)
			{
				return this.BinarySearchCardId(key, num, max);
			}
			return rowData3;
		}

		private void AddRowCardId(uint key, CardsList.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			CardsList.RowData rowData = this.Table[min];
			if (rowData.CardId.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.CardId == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: CardsList duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			CardsList.RowData rowData2 = this.Table[max];
			if (rowData2.CardId.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.CardId == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: CardsList duplicate id:{0}  lineno: {1}", new object[]
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
			CardsList.RowData rowData3 = this.Table[num];
			if (rowData3.CardId.CompareTo(key) > 0)
			{
				this.AddRowCardId(key, row, min, num);
				return;
			}
			if (rowData3.CardId.CompareTo(key) < 0)
			{
				this.AddRowCardId(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: CardsList duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"CardId",
				"CardName",
				"GroupId",
				"Description",
				"Avatar",
				"MapID"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			CardsList.RowData rowData = new CardsList.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.CardId))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.CardName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.GroupId))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Description))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.Avatar))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.MapID))
			{
				return false;
			}
			this.AddRowCardId(rowData.CardId, rowData, 0, this.Table.Count - 1);
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
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			CardsList.RowData rowData = new CardsList.RowData();
			base.Read<uint>(reader, ref rowData.CardId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.CardName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.GroupId, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.Avatar, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.MapID, CVSReader.uintParse);
			this.columnno = 5;
			this.AddRowCardId(rowData.CardId, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
