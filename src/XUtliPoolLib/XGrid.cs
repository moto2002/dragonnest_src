using System;
using System.IO;
using UnityEngine;

namespace XUtliPoolLib
{
	public sealed class XGrid
	{
		public int Width;

		public int Height;

		public float XMin;

		public float ZMin;

		public float XMax;

		public float ZMax;

		public float Side;

		public int[] IdxData;

		public float[] ValueData;

		public bool LoadFile(string FileName)
		{
			Stream stream = XSingleton<XResourceLoaderMgr>.singleton.ReadText(FileName, true);
			BinaryReader binaryReader = new BinaryReader(stream);
			try
			{
				this.Height = binaryReader.ReadInt32();
				this.Width = binaryReader.ReadInt32();
				this.XMin = binaryReader.ReadSingle();
				this.ZMin = binaryReader.ReadSingle();
				this.XMax = binaryReader.ReadSingle();
				this.ZMax = binaryReader.ReadSingle();
				this.Side = binaryReader.ReadSingle();
				int num = binaryReader.ReadInt32();
				this.IdxData = new int[num];
				for (int i = 0; i < num; i++)
				{
					this.IdxData[i] = binaryReader.ReadInt32();
				}
				this.ValueData = new float[num];
				for (int j = 0; j < num; j++)
				{
					short num2 = binaryReader.ReadInt16();
					if (num2 < 0)
					{
						this.ValueData[j] = -100f;
						if (j + 1 < num)
						{
							if (num2 == -32768)
							{
								num2 = 0;
							}
							else
							{
								num2 = -num2;
							}
							this.ValueData[j + 1] = (float)num2;
							j++;
						}
					}
					else
					{
						this.ValueData[j] = (float)num2;
					}
				}
			}
			catch (EndOfStreamException ex)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("read file ", FileName, " not complete :", ex.Message, null, null);
				return false;
			}
			finally
			{
				XSingleton<XResourceLoaderMgr>.singleton.ClearStream(stream);
			}
			return true;
		}

		public bool TryGetHeight(Vector3 pos, out float y)
		{
			y = 0f;
			int num = (int)((pos.z - this.ZMin) / this.Side);
			int num2 = (int)((pos.x - this.XMin) / this.Side);
			int key = num * this.Width + num2;
			int index = this.GetIndex(key);
			if (index >= 0 && index < this.ValueData.Length)
			{
				y = this.ValueData[index] / 100f;
				return true;
			}
			return false;
		}

		public float GetHeight(Vector3 pos)
		{
			int num = (int)((pos.z - this.ZMin) / this.Side);
			int num2 = (int)((pos.x - this.XMin) / this.Side);
			int key = num * this.Width + num2;
			return this.ValueData[this.GetIndex(key)] / 100f;
		}

		private int GetIndex(int key)
		{
			int num = this.IdxData.Length;
			int i = 0;
			int num2 = num - 1;
			while (i <= num2)
			{
				int num3 = i + num2 >> 1;
				int num4 = this.IdxData[num3];
				if (key == num4)
				{
					return num3;
				}
				if (key < num4)
				{
					num2 = num3 - 1;
				}
				else if (key > num4)
				{
					i = num3 + 1;
				}
			}
			return num2;
		}

		public void Update()
		{
		}
	}
}
