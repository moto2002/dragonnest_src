using System;
using UnityEngine;

namespace WeTest.U3DAutomation
{
	public class UINode
	{
		private GameObject a;

		private Point b;

		private Rectangle c;

		public GameObject gameobject
		{
			get
			{
				return this.a;
			}
		}

		public Point point
		{
			get
			{
				return this.b;
			}
		}

		public Rectangle bound
		{
			get
			{
				return this.c;
			}
		}

		public UINode(GameObject gameobject, Point pt)
		{
			this.a = gameobject;
			this.b = pt;
		}

		public UINode(GameObject gameobject, Rectangle bound)
		{
			this.a = gameobject;
			this.c = bound;
		}
	}
}
