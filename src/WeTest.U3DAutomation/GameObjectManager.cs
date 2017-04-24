using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace WeTest.U3DAutomation
{
	public class GameObjectManager
	{
		private static GameObjectManager a = new GameObjectManager();

		private z b = new z();

		private c c = new c();

		public static GameObjectManager INSTANCE
		{
			get
			{
				return GameObjectManager.a;
			}
		}

		public GameObject FindGameObject(string findexpr)
		{
			return GameObject.Find(findexpr);
		}

		public int AddGameObject(GameObject obj)
		{
			if (obj == null)
			{
				return -1;
			}
			return this.b.a(obj);
		}

		public GameObject FindGameObject(int id)
		{
			return this.b.a(id);
		}

		public GameObject FindGameObjectGlobal(int id)
		{
			GameObject gameObject = this.b.a(id);
			if (gameObject != null)
			{
				return gameObject;
			}
			GameObject[] array = UnityEngine.Object.FindObjectsOfType<GameObject>();
			GameObject[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				GameObject gameObject2 = array2[i];
				if (!(gameObject2 == null) && gameObject2.GetInstanceID() == id)
				{
					return gameObject2;
				}
			}
			return null;
		}

		public Transform[] GetRootTransforms()
		{
			Transform[] array = UnityEngine.Object.FindObjectsOfType<Transform>();
			List<Transform> list = new List<Transform>();
			Transform[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				Transform transform = array2[i];
				if (!(transform == null) && g.c(transform.gameObject))
				{
					list.Add(transform);
				}
			}
			return list.ToArray();
		}

		public int GetParent(GameObject obj)
		{
			if (obj.transform == obj.transform.parent)
			{
				return this.AddGameObject(obj);
			}
			return this.AddGameObject(obj.transform.parent.gameObject);
		}

		public List<int> GetChildren(GameObject obj)
		{
			Transform transform = obj.transform;
			List<int> list = new List<int>();
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				GameObject gameObject = transform.GetChild(i).gameObject;
				if (gameObject != null)
				{
					list.Add(this.AddGameObject(gameObject));
				}
			}
			return list;
		}

		private bool a(GameObject A_0, PathNode A_1)
		{
			if (A_0 == null || !A_0.activeInHierarchy)
			{
				return false;
			}
			if (A_1.name != null && !A_1.name.Equals("*") && !A_0.name.Equals(A_1.name))
			{
				return false;
			}
			if (!string.IsNullOrEmpty(A_1.img))
			{
				List<string> list = this.c.c(A_0);
				if (!list.Contains(A_1.img))
				{
					return false;
				}
			}
			if (!string.IsNullOrEmpty(A_1.txt))
			{
				List<string> list2 = this.c.b(A_0);
				if (!list2.Contains(A_1.txt))
				{
					return false;
				}
			}
			return true;
		}

		public int ParseRootPath(List<PathNode> nodes, StringBuilder rootPath)
		{
			int count = nodes.Count;
			if (count == 0 || !nodes[0].name.Equals("/"))
			{
				return 0;
			}
			int num = 1;
			if (nodes[num].index <= 0 && string.IsNullOrEmpty(nodes[num].img) && string.IsNullOrEmpty(nodes[num].txt))
			{
				rootPath.Append("/");
				rootPath.Append(nodes[num].name);
				return num + 1;
			}
			return 1;
		}

		private void a(GameObject A_0, List<GameObject> A_1, List<PathNode> A_2, int A_3)
		{
			if (A_0 == null)
			{
				return;
			}
			if (A_2.Count == A_3)
			{
				A_1.Add(A_0);
				return;
			}
			PathNode pathNode = A_2[A_3];
			int childCount = A_0.transform.childCount;
			new List<GameObject>();
			u.d("PathNode index = {0},name={1},txt={2},img={3}", new object[]
			{
				pathNode.index,
				pathNode.name,
				pathNode.txt,
				pathNode.img
			});
			if (pathNode.index >= 0 && pathNode.index < childCount)
			{
				GameObject gameObject = A_0.transform.GetChild(pathNode.index).gameObject;
				if (this.a(gameObject, pathNode))
				{
					this.a(gameObject, A_1, A_2, A_3 + 1);
					return;
				}
			}
			else if (pathNode.index < childCount)
			{
				for (int i = 0; i < childCount; i++)
				{
					GameObject gameObject2 = A_0.transform.GetChild(i).gameObject;
					if (this.a(gameObject2, pathNode))
					{
						this.a(gameObject2, A_1, A_2, A_3 + 1);
					}
				}
			}
		}

		private void a(string A_0, List<GameObject> A_1, List<PathNode> A_2, int A_3)
		{
			u.c("Find GameObject by " + A_0);
			GameObject gameObject = GameObject.Find(A_0);
			if (gameObject == null)
			{
				return;
			}
			this.a(gameObject, A_1, A_2, A_3);
		}

		private void a(List<GameObject> A_0, List<PathNode> A_1)
		{
			if (A_1.Count == 0)
			{
				return;
			}
			GameObject[] array = UnityEngine.Object.FindObjectsOfType<GameObject>();
			PathNode pathNode = A_1[0];
			for (int i = 0; i < array.Length; i++)
			{
				GameObject gameObject = array[i];
				if (pathNode.index < 0 && this.a(gameObject, pathNode))
				{
					this.a(gameObject, A_0, A_1, 1);
				}
				else if (pathNode.index >= 0 && gameObject.transform.parent != null && gameObject.transform.parent != gameObject && gameObject.transform.parent.childCount > pathNode.index && gameObject.transform.parent.GetChild(pathNode.index).gameObject == gameObject && this.a(gameObject, pathNode))
				{
					this.a(gameObject, A_0, A_1, 1);
				}
			}
		}

		public List<GameObject> FindByPath(List<PathNode> nodes)
		{
			List<GameObject> list = new List<GameObject>();
			if (nodes == null || nodes.Count == 0)
			{
				return list;
			}
			StringBuilder stringBuilder = new StringBuilder();
			int num = this.ParseRootPath(nodes, stringBuilder);
			if (num == 0)
			{
				u.a("Search not from Root, a cost method");
				this.a(list, nodes);
			}
			else
			{
				if (num == 1)
				{
					u.a("Root Node with condition");
					return list;
				}
				u.d("Find Root Node by GameObject");
				this.a(stringBuilder.ToString(), list, nodes, 2);
			}
			return list;
		}

		public List<GameObject> FindByPath(GameObject parent, List<PathNode> nodes)
		{
			List<GameObject> list = new List<GameObject>();
			if (parent == null || nodes == null || nodes.Count == 0)
			{
				return list;
			}
			u.c("Parent Gameobject " + parent.name);
			this.a(parent, list, nodes, 0);
			return list;
		}
	}
}
