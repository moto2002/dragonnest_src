using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class Horse : CVSReader
	{
		public class RowData
		{
			public uint sceneid;

			public Seq3Ref<float> CenterPos;

			public uint Laps;

			public uint CollisionWallTime;

			public uint FinalWallIndex;

			public uint SprintWallIndex;

			public Seq3Ref<float> FinalPos;
		}

		public List<Horse.RowData> Table = new List<Horse.RowData>();

		public Horse.RowData GetBysceneid(uint key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchsceneid(key, 0, this.Table.Count - 1);
		}

		private Horse.RowData BinarySearchsceneid(uint key, int min, int max)
		{
			Horse.RowData rowData = this.Table[min];
			if (rowData.sceneid == key)
			{
				return rowData;
			}
			Horse.RowData rowData2 = this.Table[max];
			if (rowData2.sceneid == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			Horse.RowData rowData3 = this.Table[num];
			if (rowData3.sceneid.CompareTo(key) > 0)
			{
				return this.BinarySearchsceneid(key, min, num);
			}
			if (rowData3.sceneid.CompareTo(key) < 0)
			{
				return this.BinarySearchsceneid(key, num, max);
			}
			return rowData3;
		}

		private void AddRowsceneid(uint key, Horse.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			Horse.RowData rowData = this.Table[min];
			if (rowData.sceneid.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.sceneid == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: Horse duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			Horse.RowData rowData2 = this.Table[max];
			if (rowData2.sceneid.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.sceneid == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: Horse duplicate id:{0}  lineno: {1}", new object[]
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
			Horse.RowData rowData3 = this.Table[num];
			if (rowData3.sceneid.CompareTo(key) > 0)
			{
				this.AddRowsceneid(key, row, min, num);
				return;
			}
			if (rowData3.sceneid.CompareTo(key) < 0)
			{
				this.AddRowsceneid(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: Horse duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"sceneid",
				"CenterPos",
				"Laps",
				"CollisionWallTime",
				"FinalWallIndex",
				"SprintWallIndex",
				"FinalPos"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			Horse.RowData rowData = new Horse.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.sceneid))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[1]], ref rowData.CenterPos, CVSReader.floatParse, "3F"))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[2]], ref rowData.Laps))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[3]], ref rowData.CollisionWallTime))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[4]], ref rowData.FinalWallIndex))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[5]], ref rowData.SprintWallIndex))
			{
				return false;
			}
			if (!base.Parse<float>(Fields[this.ColMap[6]], ref rowData.FinalPos, CVSReader.floatParse, "3F"))
			{
				return false;
			}
			this.AddRowsceneid(rowData.sceneid, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<uint>(writer, Fields[this.ColMap[0]], CVSReader.uintParse);
			base.WriteSeq<float>(writer, Fields[this.ColMap[1]], CVSReader.floatParse, 3, "F");
			base.Write<uint>(writer, Fields[this.ColMap[2]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[3]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[4]], CVSReader.uintParse);
			base.Write<uint>(writer, Fields[this.ColMap[5]], CVSReader.uintParse);
			base.WriteSeq<float>(writer, Fields[this.ColMap[6]], CVSReader.floatParse, 3, "F");
		}

		protected override void ReadLine(BinaryReader reader)
		{
			Horse.RowData rowData = new Horse.RowData();
			base.Read<uint>(reader, ref rowData.sceneid, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadSeq<float>(reader, ref rowData.CenterPos, CVSReader.floatParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.Laps, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.CollisionWallTime, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.FinalWallIndex, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.SprintWallIndex, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadSeq<float>(reader, ref rowData.FinalPos, CVSReader.floatParse);
			this.columnno = 6;
			this.AddRowsceneid(rowData.sceneid, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
