using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{
	public class SpectateLevelRewardConfig : CVSReader
	{
		public class RowData
		{
			public int SceneType;

			public int[] DataConfig;
		}

		public List<SpectateLevelRewardConfig.RowData> Table = new List<SpectateLevelRewardConfig.RowData>();

		public SpectateLevelRewardConfig.RowData GetBySceneType(int key)
		{
			if (this.Table.Count == 0)
			{
				return null;
			}
			return this.BinarySearchSceneType(key, 0, this.Table.Count - 1);
		}

		private SpectateLevelRewardConfig.RowData BinarySearchSceneType(int key, int min, int max)
		{
			SpectateLevelRewardConfig.RowData rowData = this.Table[min];
			if (rowData.SceneType == key)
			{
				return rowData;
			}
			SpectateLevelRewardConfig.RowData rowData2 = this.Table[max];
			if (rowData2.SceneType == key)
			{
				return rowData2;
			}
			if (max - min <= 1)
			{
				return null;
			}
			int num = min + (max - min) / 2;
			SpectateLevelRewardConfig.RowData rowData3 = this.Table[num];
			if (rowData3.SceneType.CompareTo(key) > 0)
			{
				return this.BinarySearchSceneType(key, min, num);
			}
			if (rowData3.SceneType.CompareTo(key) < 0)
			{
				return this.BinarySearchSceneType(key, num, max);
			}
			return rowData3;
		}

		private void AddRowSceneType(int key, SpectateLevelRewardConfig.RowData row, int min, int max)
		{
			if (this.Table.Count == 0)
			{
				this.Table.Add(row);
				return;
			}
			SpectateLevelRewardConfig.RowData rowData = this.Table[min];
			if (rowData.SceneType.CompareTo(key) > 0)
			{
				this.Table.Insert(min, row);
				return;
			}
			if (rowData.SceneType == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SpectateLevelRewardConfig duplicate id:{0}  lineno: {1}", new object[]
				{
					key,
					this.lineno
				});
				return;
			}
			SpectateLevelRewardConfig.RowData rowData2 = this.Table[max];
			if (rowData2.SceneType.CompareTo(key) < 0)
			{
				this.Table.Insert(max + 1, row);
				return;
			}
			if (rowData2.SceneType == key)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Table: SpectateLevelRewardConfig duplicate id:{0}  lineno: {1}", new object[]
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
			SpectateLevelRewardConfig.RowData rowData3 = this.Table[num];
			if (rowData3.SceneType.CompareTo(key) > 0)
			{
				this.AddRowSceneType(key, row, min, num);
				return;
			}
			if (rowData3.SceneType.CompareTo(key) < 0)
			{
				this.AddRowSceneType(key, row, num, max);
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog2("Table: SpectateLevelRewardConfig duplicate id:{0}  lineno: {1}", new object[]
			{
				key,
				this.lineno
			});
		}

		protected override bool OnHeaderLine(string[] Fields)
		{
			string[] colHeaders = new string[]
			{
				"SceneType",
				"DataConfig"
			};
			return base.MapColHeader(colHeaders, Fields);
		}

		protected override bool OnLine(string[] Fields)
		{
			SpectateLevelRewardConfig.RowData rowData = new SpectateLevelRewardConfig.RowData();
			if (!base.Parse(Fields[this.ColMap[0]], ref rowData.SceneType))
			{
				return false;
			}
			if (!base.Parse(Fields[this.ColMap[1]], ref rowData.DataConfig))
			{
				return false;
			}
			this.AddRowSceneType(rowData.SceneType, rowData, 0, this.Table.Count - 1);
			return true;
		}

		protected override bool OnCommentLine(string[] Fields)
		{
			return true;
		}

		protected override void WriteLine(string[] Fields, BinaryWriter writer)
		{
			base.Write<int>(writer, Fields[this.ColMap[0]], CVSReader.intParse);
			base.WriteArray<int>(writer, Fields[this.ColMap[1]], CVSReader.intParse);
		}

		protected override void ReadLine(BinaryReader reader)
		{
			SpectateLevelRewardConfig.RowData rowData = new SpectateLevelRewardConfig.RowData();
			base.Read<int>(reader, ref rowData.SceneType, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<int>(reader, ref rowData.DataConfig, CVSReader.intParse);
			this.columnno = 1;
			this.AddRowSceneType(rowData.SceneType, rowData, 0, this.Table.Count - 1);
			this.columnno = -1;
		}

		protected override void OnClear()
		{
			this.Table.Clear();
		}
	}
}
