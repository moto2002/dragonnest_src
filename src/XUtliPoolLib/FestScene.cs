using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class FestScene : CVSReader
	{
		public class RowData
		{
			public uint id;

			public Seq3Ref<uint> openTime;

			public uint keepTime;

			public Seq3ListRef<uint> SceneData;

			public string PicPath;

			public uint[] RewardList;
		}

		public List<FestScene.RowData> Table = new List<FestScene.RowData>();

		public FestScene.RowData GetByid(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchid(key, 0, this.Table.Count - 1);
		}

		private FestScene.RowData BinarySearchid(uint key, int min, int max)
		{
			FestScene.RowData rowData = this.Table[min];
			if (rowData.id == key)
			{
				return rowData;
			}
			FestScene.RowData rowData2 = this.Table[max];
			if (rowData2.id == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			FestScene.RowData rowData3 = this.Table[num];
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

		private void AddRowid(uint key, FestScene.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			FestScene.RowData rowData = this.Table[min];
			if (rowData.id.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: FestScene duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			FestScene.RowData rowData2 = this.Table[max];
			if (rowData2.id.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.id == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: FestScene duplicate id:{0}  lineno: {1}", new object[]
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
			FestScene.RowData rowData3 = this.Table[num];
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
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: FestScene duplicate id:{0}  lineno: {1}", new object[]
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
				"openTime",
				"keepTime",
				"SceneData",
				"PicPath",
				"RewardList"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			FestScene.RowData rowData = new FestScene.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.id))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[1]], ref rowData.openTime, CVSReader.uintParse, "3U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.keepTime))
			{
				return false;
			}
			if (!base.Parse<uint>(Fields[this.ColMap[3]], ref rowData.SceneData, CVSReader.uintParse, "3U"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.PicPath))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.RewardList))
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
			base.WriteSeq<uint>(writer, Fields[this.ColMap[1]], CVSReader.uintParse, 3, "U");
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.WriteSeqList<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse, 3, "U");
			base.Write<string>(writer, Fields[this.ColMap[4]], CVSReader.stringParse);
			base.WriteArray<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			FestScene.RowData rowData = new FestScene.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeq<uint>(reader, ref rowData.openTime, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.keepTime, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadSeqList<uint>(reader, ref rowData.SceneData, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.PicPath, CVSReader.stringParse);
			this.columnno = 4;
			base.ReadArray<uint>(reader, ref rowData.RewardList, CVSReader.uintParse);
			this.columnno = 5;
			this.AddRowid(rowData.id, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
