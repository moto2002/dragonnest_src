using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using WeTest.U3DAutomation;

internal class s
{
	[CompilerGenerated]
	private static Comparison<Camera> a;

	public Camera h(GameObject A_0)
	{
		Camera[] allCameras = Camera.allCameras;
		List<Camera> list = new List<Camera>();
		for (int i = 0; i < allCameras.Length; i++)
		{
			if ((allCameras[i].cullingMask & 1 << A_0.layer) == 1 << A_0.layer)
			{
				list.Add(allCameras[i]);
			}
		}
		List<Camera> arg_62_0 = list;
		if (s.a == null)
		{
			s.a = new Comparison<Camera>(s.a);
		}
		arg_62_0.Sort(s.a);
		for (int j = 0; j < list.Count; j++)
		{
			if (!(list[j] == null) && list[j].gameObject.activeInHierarchy)
			{
				return list[j];
			}
		}
		return null;
	}

	public Camera b()
	{
		return Camera.main;
	}

	public Rectangle a(Camera A_0, GameObject A_1)
	{
		Renderer component = A_1.GetComponent<Renderer>();
		if (component != null)
		{
			return CoordinateTool.WorldBoundsToScreenRect(A_0, component.bounds);
		}
		return null;
	}

	public Rectangle c(Camera A_0, GameObject A_1)
	{
		Collider component = A_1.GetComponent<Collider>();
		if (A_1.activeInHierarchy && component != null && component.enabled)
		{
			return CoordinateTool.WorldBoundsToScreenRect(A_0, component.bounds);
		}
		return null;
	}

	public Rectangle d(Camera A_0, GameObject A_1)
	{
		MeshFilter component = A_1.GetComponent<MeshFilter>();
		if (component != null && component.sharedMesh != null)
		{
			Mesh sharedMesh = component.sharedMesh;
			return CoordinateTool.WorldBoundsToScreenRect(A_0, sharedMesh.bounds);
		}
		return null;
	}

	public Rectangle b(Camera A_0, GameObject A_1)
	{
		Rectangle result;
		if ((result = this.a(A_0, A_1)) != null)
		{
			return result;
		}
		if ((result = this.c(A_0, A_1)) != null)
		{
			return result;
		}
		if ((result = this.d(A_0, A_1)) != null)
		{
			return result;
		}
		return null;
	}

	public bool f(GameObject A_0)
	{
		return A_0.activeSelf && A_0.hideFlags == HideFlags.None;
	}

	private WorldBound a(Vector3 A_0, Vector3 A_1)
	{
		return new WorldBound
		{
			centerX = A_0.x,
			centerY = A_0.y,
			centerZ = A_0.z,
			extentsX = A_1.x,
			extentsY = A_1.y,
			extentsZ = A_1.z,
			existed = true
		};
	}

	public WorldBound g(GameObject A_0)
	{
		Vector3 a_ = default(Vector3);
		Vector3 a_2 = default(Vector3);
		Renderer component = A_0.GetComponent<Renderer>();
		if (component != null)
		{
			a_ = component.bounds.center;
			a_2 = component.bounds.extents;
			return this.a(a_, a_2);
		}
		MeshFilter component2 = A_0.GetComponent<MeshFilter>();
		if (component2 != null && component2.sharedMesh != null)
		{
			Mesh sharedMesh = component2.sharedMesh;
			a_ = sharedMesh.bounds.center;
			a_2 = sharedMesh.bounds.extents;
			return this.a(a_, a_2);
		}
		Collider component3 = A_0.GetComponent<Collider>();
		if (A_0.activeInHierarchy && component3 != null && component3.enabled)
		{
			a_ = component3.bounds.center;
			a_2 = component3.bounds.extents;
			return this.a(a_, a_2);
		}
		return new WorldBound
		{
			existed = false
		};
	}

	[CompilerGenerated]
	private static int a(Camera A_0, Camera A_1)
	{
		return (int)(A_1.depth - A_0.depth);
	}
}
