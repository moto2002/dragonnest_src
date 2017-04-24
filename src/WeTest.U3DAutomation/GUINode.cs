using System;
using System.Collections.Generic;
using UnityEngine;

namespace WeTest.U3DAutomation
{
	public class GUINode
	{
		public GameObject gameObject;

		public GUINode parent;

		public List<GUINode> children;

		public int level;

		public int depth;

		public string fullPath = "";

		public GUINode()
		{
			this.gameObject = null;
			this.parent = null;
			this.children = new List<GUINode>();
		}

		public GUINode(GameObject gameObject, GUINode parent, int level)
		{
			this.gameObject = gameObject;
			this.parent = parent;
			this.level = level;
			this.children = new List<GUINode>();
		}
	}
}
