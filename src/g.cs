using System;
using System.Text;
using System.Xml;
using UnityEngine;
using WeTest.U3DAutomation;

internal class g
{
	public static bool c(GameObject A_0)
	{
		return A_0.activeInHierarchy && !(A_0.transform.root != A_0.transform);
	}

	public static string b(GameObject A_0)
	{
		string text = null;
		while (A_0.transform.root != A_0.transform)
		{
			if (text == null)
			{
				text = A_0.name;
			}
			else
			{
				text = A_0.name + "/" + text;
			}
			A_0 = A_0.transform.parent.gameObject;
		}
		if (text == null)
		{
			return "/" + A_0.name;
		}
		return "/" + A_0.name + "/" + text;
	}

	public static string a(GameObject A_0)
	{
		if (A_0 == null)
		{
			return "";
		}
		Component[] components = A_0.GetComponents<Component>();
		if (components == null)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		Component[] array = components;
		for (int i = 0; i < array.Length; i++)
		{
			Component component = array[i];
			if (!(component == null) && !(component is Transform))
			{
				if (stringBuilder.Length != 0)
				{
					stringBuilder.Append("|");
				}
				stringBuilder.Append(component.GetType().Name);
			}
		}
		return stringBuilder.ToString();
	}

	public static string a()
	{
		XmlDocument xmlDocument = new XmlDocument();
		XmlElement xmlElement = xmlDocument.CreateElement("AbstractRoot");
		xmlDocument.AppendChild(xmlElement);
		xmlElement.SetAttribute("id", "0");
		string result;
		try
		{
			Transform[] rootTransforms = GameObjectManager.INSTANCE.GetRootTransforms();
			Transform[] array = rootTransforms;
			for (int i = 0; i < array.Length; i++)
			{
				Transform transform = array[i];
				if (transform.gameObject.activeInHierarchy)
				{
					xmlElement.AppendChild(g.a(transform, null, xmlDocument));
				}
			}
			string innerXml = xmlDocument.InnerXml;
			result = innerXml;
		}
		catch (Exception ex)
		{
			u.b("DumpTree error message:" + ex.Message + "\n" + ex.StackTrace);
			throw ex;
		}
		return result;
	}

	private static XmlElement a(Transform A_0, GameObject[] A_1, XmlDocument A_2)
	{
		c c = new c();
		XmlElement xmlElement = A_2.CreateElement("GameObject");
		xmlElement.SetAttribute("name", A_0.gameObject.name);
		xmlElement.SetAttribute("components", g.a(A_0.gameObject));
		xmlElement.SetAttribute("id", A_0.gameObject.GetInstanceID().ToString());
		string text = c.e(A_0.gameObject);
		if (text != null)
		{
			xmlElement.SetAttribute("txt", text);
		}
		text = c.a(A_0.gameObject);
		if (text != null)
		{
			xmlElement.SetAttribute("img", text);
		}
		if (!c.f(A_0.gameObject))
		{
			xmlElement.SetAttribute("visible", "false");
		}
		if (A_1 != null && g.a(A_0.gameObject, A_1))
		{
			xmlElement.SetAttribute("sel", "true");
		}
		for (int i = 0; i < A_0.childCount; i++)
		{
			Transform child = A_0.GetChild(i);
			if (child.gameObject.activeInHierarchy)
			{
				xmlElement.AppendChild(g.a(child, A_1, A_2));
			}
		}
		return xmlElement;
	}

	private static bool a(GameObject A_0, GameObject[] A_1)
	{
		for (int i = 0; i < A_1.Length; i++)
		{
			GameObject gameObject = A_1[i];
			if (gameObject.GetInstanceID() == A_0.GetInstanceID())
			{
				return true;
			}
		}
		return false;
	}
}
