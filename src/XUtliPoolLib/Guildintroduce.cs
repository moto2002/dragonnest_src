using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class Guildintroduce : CVSReader
	{
		public class RowData
		{
			public string HelpName;

			public string Logo;

			public string Title;

			public string Desc;
		}

		public List<Guildintroduce.RowData> Table = new List<Guildintroduce.RowData>();

		public Guildintroduce.RowData GetByHelpName(string key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchHelpName(key, 0, this.Table.Count - 1);
		}

		private Guildintroduce.RowData BinarySearchHelpName(string key, int min, int max)
		{
			Guildintroduce.RowData rowData = this.Table[min];
			if (rowData.HelpName == key)
			{
				return rowData;
			}
			Guildintroduce.RowData rowData2 = this.Table[max];
			if (rowData2.HelpName == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			Guildintroduce.RowData rowData3 = this.Table[num];
			if (rowData3.HelpName.CompareTo(key) > 0)
			{
				return this.BinarySearchHelpName(key, min, num);
			}
			if (rowData3.HelpName.CompareTo(key) < 0)
			{
				return this.BinarySearchHelpName(key, num, max);
			}
			return rowData3;
		}

		private void AddRowHelpName(string key, Guildintroduce.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			Guildintroduce.RowData rowData = this.Table[min];
			if (rowData.HelpName.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.HelpName == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: Guildintroduce duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			Guildintroduce.RowData rowData2 = this.Table[max];
			if (rowData2.HelpName.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.HelpName == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: Guildintroduce duplicate id:{0}  lineno: {1}", new object[]
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
			Guildintroduce.RowData rowData3 = this.Table[num];
			if (rowData3.HelpName.CompareTo(key) > 0)
			{
				this.AddRowHelpName(key, row, min, num);
				return;
			}
			if (rowData3.HelpName.CompareTo(key) < 0)
			{
				this.AddRowHelpName(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: Guildintroduce duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"HelpName",
				"Logo",
				"Title",
				"Desc"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			Guildintroduce.RowData rowData = new Guildintroduce.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.HelpName))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.Logo))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Title))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.Desc))
			{
				return false;
			}
			this.AddRowHelpName(rowData.HelpName, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<string>(writer, Fields[this.ColMap[0]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[1]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[2]], CVSReader.stringParse);
			base.Write<string>(writer, Fields[this.ColMap[3]], CVSReader.stringParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			Guildintroduce.RowData rowData = new Guildintroduce.RowData();
			base.Read<string>(reader, ref rowData.HelpName, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Logo, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Title, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 3;
			this.AddRowHelpName(rowData.HelpName, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
