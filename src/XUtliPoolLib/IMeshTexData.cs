using System;
using UnityEngine;

namespace XUtliPoolLib
{
	public interface IMeshTexData
	{
		Mesh mesh
		{
			get;
		}

		Texture2D tex
		{
			get;
		}

		string offset
		{
			get;
		}
	}
}
