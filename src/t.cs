using System;
using System.Collections.Generic;
using System.Threading;
using WeTest.U3DAutomation;

internal class t
{
	private static t a = new t();

	private BlockQueue<q> b = new BlockQueue<q>();

	private Queue<TouchEvent> c = new Queue<TouchEvent>();

	private Thread d;

	private bool e;

	private t()
	{
	}

	public static t b()
	{
		return t.a;
	}

	public void e()
	{
		try
		{
			if (this.d == null)
			{
				this.e = true;
				this.d = new Thread(new ThreadStart(this.a));
				this.d.Start();
			}
		}
		catch (Exception ex)
		{
			u.c(ex.Message);
		}
	}

	public void c()
	{
		this.e = false;
	}

	private void a()
	{
		while (this.e)
		{
			try
			{
				q q = this.b.Dequeue();
				if (q.b != null)
				{
					for (int i = 0; i < q.b.Length; i++)
					{
						TouchEvent touchEvent = q.b[i];
						this.a(touchEvent);
						if (touchEvent.sleeptime > 0)
						{
							Thread.Sleep(touchEvent.sleeptime);
						}
					}
				}
				if (q.a != null)
				{
					o.a(q.a);
				}
			}
			catch (Exception ex)
			{
				u.a(ex.Message + "\n" + ex.StackTrace);
			}
		}
	}

	public List<TouchEvent> d()
	{
		List<TouchEvent> result;
		lock (this.c)
		{
			if (this.c.Count == 0)
			{
				result = null;
			}
			else
			{
				List<TouchEvent> list = new List<TouchEvent>();
				while (this.c.Count > 0)
				{
					list.Add(this.c.Dequeue());
				}
				result = list;
			}
		}
		return result;
	}

	public void a(q A_0)
	{
		this.b.Enqueue(A_0);
	}

	private void a(TouchEvent A_0)
	{
		lock (this.c)
		{
			this.c.Enqueue(A_0);
		}
	}
}
