using System;
using UnityEngine;
using XUtliPoolLib;

public class XMeshTexData : MonoBehaviour, IMeshTexData
{
	[SerializeField]
	public Mesh _mesh;

	[SerializeField]
	public Texture2D _tex;

	[SerializeField]
	public string _offset;

	public Mesh mesh
	{
		get
		{
			return this._mesh;
		}
	}

	public Texture2D tex
	{
		get
		{
			return this._tex;
		}
	}

	public string offset
	{
		get
		{
			return this._offset;
		}
	}
}
