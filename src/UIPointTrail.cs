using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/UI/NGUI PointTrail"), ExecuteInEditMode]
public class UIPointTrail : UIWidget
{
	public class KeyPoint
	{
		public Vector3 point;

		public float enqueueTime;

		public float size;

		public bool mainPoint;
	}

	public static UIPointTrail current;

	[HideInInspector, SerializeField]
	private Material mMat;

	[HideInInspector, SerializeField]
	private float mPointTime;

	[HideInInspector, SerializeField]
	private int mMaxSize = 64;

	[NonSerialized]
	protected List<Queue<UIPointTrail.KeyPoint>> mKeyQueues = new List<Queue<UIPointTrail.KeyPoint>>();

	private Queue<UIPointTrail.KeyPoint> mCurrentQueue;

	protected Rect mUV = default(Rect);

	public int mSampleRate = 6;

	private bool mNewQueue;

	private UIPointTrail.KeyPoint mLastPoint;

	public override Material material
	{
		get
		{
			return this.mMat;
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		UIPointTrail.current = this;
		this.mNewQueue = true;
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (this.mKeyQueues.Count > 0)
		{
			foreach (Queue<UIPointTrail.KeyPoint> queue in this.mKeyQueues)
			{
				this.UpdateQueue(queue);
			}
			this.mChanged = true;
		}
	}

	protected void UpdateQueue(Queue<UIPointTrail.KeyPoint> queue)
	{
		if (queue.Count <= 0)
		{
			return;
		}
		UIPointTrail.KeyPoint keyPoint = queue.Peek();
		float time = RealTime.time;
		while (keyPoint != null && time - keyPoint.enqueueTime > this.mPointTime)
		{
			queue.Dequeue();
			if (queue.Count > 0)
			{
				keyPoint = queue.Peek();
			}
			else
			{
				keyPoint = null;
			}
		}
		int num = 0;
		foreach (UIPointTrail.KeyPoint keyPoint2 in queue)
		{
			keyPoint2.size = (float)(num + 1) / (float)queue.Count;
			num++;
		}
	}

	public void AddPoint(Vector3 pos, float time)
	{
		UIPointTrail.KeyPoint keyPoint = new UIPointTrail.KeyPoint();
		keyPoint.point = pos;
		keyPoint.enqueueTime = time;
		keyPoint.size = 1f;
		keyPoint.mainPoint = true;
		if (this.mNewQueue)
		{
			this.GetEmptyQueue();
			this.mNewQueue = false;
		}
		if (this.mCurrentQueue != null)
		{
			if (this.mCurrentQueue.Count > 0 && this.mLastPoint != null)
			{
				UIPointTrail.KeyPoint keyPoint2 = this.mLastPoint;
				float num = Vector3.Distance(keyPoint2.point, keyPoint.point);
				if (keyPoint2 != null && num > 1f && num < 50f)
				{
					UIPointTrail.KeyPoint keyPoint3 = new UIPointTrail.KeyPoint();
					keyPoint3.point = (keyPoint2.point + keyPoint.point) / 2f;
					keyPoint3.enqueueTime = (keyPoint2.enqueueTime + keyPoint.enqueueTime) / 2f;
					keyPoint3.size = (keyPoint2.size + keyPoint.size) / 2f;
					keyPoint3.mainPoint = false;
					this.mCurrentQueue.Enqueue(keyPoint3);
				}
			}
			this.mLastPoint = keyPoint;
			this.mCurrentQueue.Enqueue(keyPoint);
		}
	}

	protected void GetEmptyQueue()
	{
		bool flag = false;
		foreach (Queue<UIPointTrail.KeyPoint> queue in this.mKeyQueues)
		{
			if (queue.Count == 0)
			{
				flag = true;
				this.mCurrentQueue = queue;
			}
		}
		if (!flag)
		{
			Queue<UIPointTrail.KeyPoint> item = new Queue<UIPointTrail.KeyPoint>();
			this.mKeyQueues.Add(item);
			this.mCurrentQueue = item;
		}
	}

	public void SetNewQueue()
	{
		this.mNewQueue = true;
	}

	public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
		foreach (Queue<UIPointTrail.KeyPoint> queue in this.mKeyQueues)
		{
			if (queue.Count > 0)
			{
				this.QueueOnFill(queue, verts, uvs, cols);
			}
		}
	}

	public void QueueOnFill(Queue<UIPointTrail.KeyPoint> queue, BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
		foreach (UIPointTrail.KeyPoint keyPoint in queue)
		{
			Vector3 a = keyPoint.point;
			UIRoot uIRoot = NGUITools.FindInParents<UIRoot>(base.cachedTransform);
			a *= uIRoot.GetPixelSizeAdjustment(Screen.height);
			float size = keyPoint.size;
			verts.Add(new Vector3(a.x - size * (float)this.mMaxSize / 2f, a.y - size * (float)this.mMaxSize / 2f));
			verts.Add(new Vector3(a.x - size * (float)this.mMaxSize / 2f, a.y + size * (float)this.mMaxSize / 2f));
			verts.Add(new Vector3(a.x + size * (float)this.mMaxSize / 2f, a.y + size * (float)this.mMaxSize / 2f));
			verts.Add(new Vector3(a.x + size * (float)this.mMaxSize / 2f, a.y - size * (float)this.mMaxSize / 2f));
			uvs.Add(new Vector2(0f, 0f));
			uvs.Add(new Vector2(0f, 1f));
			uvs.Add(new Vector2(1f, 1f));
			uvs.Add(new Vector2(1f, 0f));
			Color color = base.color;
			cols.Add(color);
			cols.Add(color);
			cols.Add(color);
			cols.Add(color);
		}
	}
}
