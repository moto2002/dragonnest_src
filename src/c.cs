using System;
using System.Collections.Generic;
using UnityEngine;
using WeTest.U3DAutomation;

internal class c : s
{
	public string e(GameObject A_0)
	{
		if (A_0 == null)
		{
			return null;
		}
		try
		{
			string text = x.e(A_0);
			if (text != null)
			{
				string result = text;
				return result;
			}
		}
		catch (Exception)
		{
		}
		GUIText component = A_0.GetComponent<GUIText>();
		if (component != null)
		{
			return component.text;
		}
		return null;
	}

	public List<string> b(GameObject A_0)
	{
		if (A_0 == null)
		{
			return null;
		}
		List<string> list = x.d(A_0);
		GUIText[] componentsInChildren = A_0.GetComponentsInChildren<GUIText>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i] != null)
			{
				list.Add(componentsInChildren[i].text);
			}
		}
		return list;
	}

	public string a(GameObject A_0)
	{
		if (A_0 == null)
		{
			return null;
		}
		string text = x.c(A_0);
		if (text != null)
		{
			return text;
		}
		SpriteRenderer component = A_0.GetComponent<SpriteRenderer>();
		if (component != null && component.sprite != null)
		{
			return component.sprite.name;
		}
		return null;
	}

	public List<string> c(GameObject A_0)
	{
		if (A_0 == null)
		{
			return null;
		}
		List<string> list = x.b(A_0);
		SpriteRenderer[] componentsInChildren = A_0.GetComponentsInChildren<SpriteRenderer>();
		if (componentsInChildren != null)
		{
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i] != null && componentsInChildren[i].sprite != null)
				{
					list.Add(componentsInChildren[i].sprite.name);
				}
			}
		}
		return list;
	}

	public Rectangle d(GameObject A_0)
	{
		if (A_0 == null)
		{
			return null;
		}
		Camera camera = base.h(A_0);
		if (camera == null)
		{
			return null;
		}
		Rectangle rectangle = base.c(camera, A_0);
		if (rectangle == null)
		{
			rectangle = x.a(camera, A_0);
		}
		if (rectangle == null)
		{
			rectangle = base.b(camera, A_0);
		}
		if (rectangle == null)
		{
			return null;
		}
		u.d(string.Concat(new object[]
		{
			"GetBound gameobject =",
			A_0.name,
			"  rc.x=",
			rectangle.x,
			", rc.y=",
			rectangle.y,
			", wight = ",
			rectangle.width,
			", height=",
			rectangle.height
		}));
		float num = 0f;
		float num2 = 0f;
		if (CoordinateTool.GetCurrenScreenScale(ref num, ref num2))
		{
			rectangle.x *= num;
			rectangle.y *= num2;
			rectangle.width *= num;
			rectangle.height *= num2;
			u.d(string.Concat(new object[]
			{
				"GetBound() after scale : rc.x=",
				rectangle.x,
				", rc.y=",
				rectangle.y,
				", wight = ",
				rectangle.width,
				", height=",
				rectangle.height
			}));
		}
		return rectangle;
	}

	public string a(GameObject A_0, string A_1)
	{
		u.c(("SetInputTxt" + A_0 == null) ? "" : ((A_0.name + " set txt content " + A_1 == null) ? "" : A_1));
		if (A_0 == null || A_1 == null)
		{
			return null;
		}
		string result = this.e(A_0);
		x.a(A_0, A_1);
		return result;
	}

	public List<GameObject> a(Point A_0)
	{
		List<GameObject> list = new List<GameObject>();
		try
		{
			GameObject gameObject = x.b(A_0);
			if (gameObject != null)
			{
				list.Add(gameObject);
			}
		}
		catch (Exception ex)
		{
			u.c(ex.Message + "\n" + ex.StackTrace);
		}
		return list;
	}

	public List<InteractElement> a()
	{
		List<UINode> list = x.a();
		List<InteractElement> list2 = new List<InteractElement>();
		foreach (UINode current in list)
		{
			GameObject gameobject = current.gameobject;
			Rectangle bound = current.bound;
			InteractElement interactElement = new InteractElement();
			interactElement.nodetype = AutoTravelNodeType.BUTTON;
			string name = global::g.b(gameobject);
			interactElement.name = name;
			interactElement.instanceid = gameobject.GetInstanceID();
			interactElement.bound.x = bound.x;
			interactElement.bound.y = bound.y;
			interactElement.bound.fWidth = bound.width;
			interactElement.bound.fHeight = bound.height;
			list2.Add(interactElement);
			GameObjectManager.INSTANCE.AddGameObject(gameobject);
		}
		return list2;
	}
}
