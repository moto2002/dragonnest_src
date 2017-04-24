using DeJson;
using System;
using System.Collections;
using System.Text;

namespace XUtliPoolLib
{
	public class PUtil : XSingleton<PUtil>
	{
		private Deserializer _deserial;

		public Deserializer deserial
		{
			get
			{
				if (this._deserial == null)
				{
					this._deserial = new Deserializer();
				}
				return this._deserial;
			}
		}

		public T Deserialize<T>(string str)
		{
			return this.deserial.Deserialize<T>(str);
		}

		public T Deserialize<T>(object o)
		{
			return this.deserial.Deserialize<T>(o);
		}

		public string SerializeArray(IList array)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append('[');
			int num = 0;
			foreach (object current in array)
			{
				num++;
				if (num < array.Count)
				{
					stringBuilder.Append(current);
					stringBuilder.Append(',');
				}
				else
				{
					stringBuilder.Append(current);
				}
			}
			stringBuilder.Append(']');
			return stringBuilder.ToString();
		}
	}
}
