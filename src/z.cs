using System;
using System.Collections.Generic;
using UnityEngine;

internal class z
{
	private Dictionary<int, WeakReference> a = new Dictionary<int, WeakReference>();

	public int a(GameObject A_0)
	{
		int instanceID = A_0.GetInstanceID();
		if (this.a.ContainsKey(instanceID))
		{
			return instanceID;
		}
		this.a.Add(instanceID, new WeakReference(A_0));
		return instanceID;
	}

	public GameObject a(int A_0)
	{
		WeakReference weakReference = null;
		if (this.a.TryGetValue(A_0, out weakReference) && weakReference != null)
		{
			GameObject gameObject = weakReference.Target as GameObject;
			if (gameObject == null)
			{
				this.a.Remove(A_0);
			}
			return gameObject;
		}
		return null;
	}
}
