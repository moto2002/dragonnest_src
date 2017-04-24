using System;
using UILib;
using UnityEngine;

public class XRadarMap : MonoBehaviour, IXRadarMap
{
	public Vector3[] m_vertices;

	public Vector2[] m_uv;

	public Color[] m_color;

	public Vector3[] m_normals;

	public int[] m_triangles;

	private Mesh m_mesh;

	private MeshFilter m_meshFilter;

	private bool m_reposition = true;

	private float m_verticeValue = 1f;

	public bool repositionNow
	{
		set
		{
			this.m_reposition = value;
		}
	}

	private void Awake()
	{
		this.m_mesh = new Mesh();
		this.m_meshFilter = base.GetComponent<MeshFilter>();
		this.m_vertices = new Vector3[]
		{
			new Vector3(0f, 0f, 0f),
			new Vector3(1f, 0f, 0f),
			new Vector3(0f, 1f, 0f),
			new Vector3(1f, 1f, 0f)
		};
		this.m_uv = new Vector2[]
		{
			new Vector2(0f, 0f),
			new Vector2(1f, 0f),
			new Vector2(0f, 1f),
			new Vector2(1f, 1f)
		};
		this.m_triangles = new int[]
		{
			0,
			1,
			2,
			1,
			3,
			2
		};
	}

	public void SetSite(int pos, float value)
	{
		switch (pos)
		{
		case 0:
			this.SetBottomSite(value);
			break;
		case 1:
			this.SetRightSite(value);
			break;
		case 2:
			this.SetLeftSite(value);
			break;
		case 3:
			this.SetUpSite(value);
			break;
		}
		this.repositionNow = true;
	}

	private void SetLeftSite(float value)
	{
		value *= 0.25f;
		this.m_vertices[2].y = 0.75f + value;
		this.m_vertices[2].x = 0.25f - value;
	}

	private void SetBottomSite(float value)
	{
		value *= 0.25f;
		this.m_vertices[0].x = 0.25f - value;
		this.m_vertices[0].y = 0.25f - value;
	}

	private void SetRightSite(float value)
	{
		value *= 0.25f;
		this.m_vertices[1].x = 0.75f + value;
		this.m_vertices[1].y = 0.25f - value;
	}

	private void SetUpSite(float value)
	{
		value *= 0.25f;
		this.m_vertices[3].x = 0.75f + value;
		this.m_vertices[3].y = 0.75f + value;
	}

	private void Update()
	{
		if (!this.m_reposition)
		{
			return;
		}
		this.Reposition();
	}

	[ContextMenu("Execute")]
	private void Reposition()
	{
		this.m_reposition = false;
		this.m_mesh.Clear();
		this.m_mesh.vertices = this.m_vertices;
		this.m_mesh.uv = this.m_uv;
		this.m_mesh.colors = this.m_color;
		this.m_mesh.normals = this.m_normals;
		this.m_mesh.triangles = this.m_triangles;
		this.m_mesh.RecalculateNormals();
		this.m_meshFilter.mesh = this.m_mesh;
	}

	public void Refresh()
	{
		this.repositionNow = true;
	}
}
