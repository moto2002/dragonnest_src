using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class CardStoreTable : CVSReader
	{
		public class RowData
		{
			public uint store;

			public uint probability;

			public string words;
		}

		public List<CardStoreTable.RowData> Table = new List<CardStoreTable.RowData>();

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"store",
				"probability",
				"words"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			CardStoreTable.RowData rowData = new CardStoreTable.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.store))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.probability))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.words))
			{
				return false;
			}
			this.Table.Add(rowData);
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
		}

		protected override void ReadLine(BinaryReader reader)
		{
			CardStoreTable.RowData rowData = new CardStoreTable.RowData();
			base.Read<uint>(reader, ref rowData.store, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.probability, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.words, CVSReader.stringParse);
			this.columnno = 2;
			this.Table.Add(rowData);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
