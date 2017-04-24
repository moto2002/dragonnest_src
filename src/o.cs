using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using WeTest.U3DAutomation;

internal class o
{
	public static readonly int a = 27019;

	public static readonly int b = 5;

	private static Thread c;

	private static int d = 0;

	private static bool e = false;

	private static Socket f;

	private static Queue<j> g = new Queue<j>();

	private static BlockQueue<j> h = new BlockQueue<j>();

	private static bool a(int A_0, int A_1)
	{
		IPEndPoint localEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), A_0);
		o.f = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		try
		{
			o.f.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
			o.f.Bind(localEP);
			o.f.Listen(A_1);
			u.c("Server Start");
			o.f.BeginAccept(new AsyncCallback(o.c), o.f);
			return true;
		}
		catch (Exception arg)
		{
			u.b("Exception" + arg);
		}
		return false;
	}

	private static void e()
	{
		IPAddress[] hostAddresses = Dns.GetHostAddresses("127.0.0.1");
		Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		socket.Connect(hostAddresses[0], o.a);
		string s = JsonParser.b(new j
		{
			e = Cmd.EXIT,
			f = ResponseStatus.SUCCESS
		});
		byte[] bytes = Encoding.ASCII.GetBytes(s);
		byte[] array = new byte[bytes.Length + 4];
		byte[] bytes2 = BitConverter.GetBytes(bytes.Length);
		Buffer.BlockCopy(bytes2, 0, array, 0, 4);
		Buffer.BlockCopy(bytes, 0, array, 4, bytes.Length);
		try
		{
			socket.Send(array);
		}
		catch (Exception ex)
		{
			u.c(ex.ToString());
		}
		finally
		{
			socket.Close();
		}
	}

	private static void d()
	{
		u.c("Start RecvThread");
		while (!o.e)
		{
			try
			{
				if (o.a(o.a, o.b))
				{
					break;
				}
				u.c("Try to close pre game");
				o.e();
				Thread.Sleep(50);
			}
			catch (Exception ex)
			{
				u.b(ex.Message + " " + ex.StackTrace);
			}
		}
	}

	private static void c()
	{
		while (!o.e || o.h.Count != 0)
		{
			j j = o.h.Dequeue();
			try
			{
				string a_ = JsonParser.b(j);
				o.a(j.a, a_);
			}
			catch (Exception ex)
			{
				u.b(ex.Message + " " + ex.StackTrace);
				try
				{
					o.a(j.a, string.Concat(new string[]
					{
						"{\"status\":3,\"cmd\":0,\"data\":\"JsonParser.WrapResponse Exception: ",
						ex.Message,
						" ",
						ex.StackTrace,
						"\"}"
					}));
					Debug.Log(ex.Message + " " + ex.StackTrace);
					j.a.Close();
				}
				catch (Exception ex2)
				{
					u.b(ex2.Message + " " + ex2.StackTrace);
				}
			}
		}
	}

	public static void c(IAsyncResult A_0)
	{
		Socket socket = (Socket)A_0.AsyncState;
		u.c("Accept one Client " + ++o.d);
		Socket socket2 = socket.EndAccept(A_0);
		l l = new l();
		l.b = socket2;
		socket2.BeginReceive(l.c, 0, 1024, SocketFlags.None, new AsyncCallback(o.b), l);
		socket.BeginAccept(new AsyncCallback(o.c), socket);
	}

	public static void b(IAsyncResult A_0)
	{
		string arg_05_0 = string.Empty;
		l l = (l)A_0.AsyncState;
		Socket socket = l.b;
		try
		{
			SocketError socketError;
			int num = socket.EndReceive(A_0, out socketError);
			if (num > 0)
			{
				if (l.f == 0)
				{
					byte[] array = new byte[4];
					Buffer.BlockCopy(l.c, 0, array, 0, 4);
					l.f = BitConverter.ToInt32(array, 0);
					u.c(string.Concat(new object[]
					{
						"byte[0]: ",
						array[0],
						" byte[1]: ",
						array[1],
						"byte[2]: ",
						array[2],
						" byte[3]: ",
						array[3]
					}));
					u.c("receive data length = " + l.f);
					byte[] array2 = new byte[num - 4];
					Buffer.BlockCopy(l.c, 4, array2, 0, num - 4);
					l.d.Append(Encoding.UTF8.GetString(array2, 0, num - 4));
					l.e = num - 4;
				}
				else
				{
					byte[] array3 = new byte[num];
					Buffer.BlockCopy(l.c, 0, array3, 0, num);
					l.d.Append(Encoding.UTF8.GetString(array3, 0, num));
					l.e += num;
				}
				if (l.e >= l.f)
				{
					o.a(l);
					l l2 = new l();
					l2.b = socket;
					socket.BeginReceive(l2.c, 0, 1024, SocketFlags.None, new AsyncCallback(o.b), l2);
				}
				else
				{
					socket.BeginReceive(l.c, 0, 1024, SocketFlags.None, new AsyncCallback(o.b), l);
				}
			}
			else
			{
				u.a("Recv socket error,error code = " + socketError);
				o.a(socket);
			}
		}
		catch (Exception ex)
		{
			u.a(ex.Message + " " + ex.StackTrace);
		}
	}

	private static void a(Socket A_0, string A_1)
	{
		byte[] bytes = Encoding.ASCII.GetBytes(A_1);
		byte[] array = new byte[bytes.Length + 4];
		byte[] bytes2 = BitConverter.GetBytes(bytes.Length);
		Buffer.BlockCopy(bytes2, 0, array, 0, 4);
		Buffer.BlockCopy(bytes, 0, array, 4, bytes.Length);
		try
		{
			A_0.BeginSend(array, 0, array.Length, SocketFlags.None, new AsyncCallback(o.a), A_0);
		}
		catch (Exception ex)
		{
			u.c(ex.ToString());
			if (A_0 == m.a().n)
			{
				m.a().m = false;
				u.c("Maybe Recorder stops----");
			}
			o.a(A_0);
		}
	}

	private static void a(IAsyncResult A_0)
	{
		try
		{
			Socket socket = (Socket)A_0.AsyncState;
			SocketError socketError;
			int num = socket.EndSend(A_0, out socketError);
			u.c("Sent bytes to client = " + num);
			if (socketError != SocketError.Success)
			{
				if (socket == m.a().n)
				{
					m.a().m = false;
					u.c("Maybe Recorder stops");
				}
				o.a(socket);
			}
			else
			{
				u.c("Network " + socketError);
			}
		}
		catch (Exception ex)
		{
			Debug.Log(ex.ToString());
		}
	}

	private static void a(Cmd A_0)
	{
		if (A_0 == Cmd.EXIT)
		{
			u.a("Recv exit command");
			o.a(o.f);
			Environment.Exit(0);
		}
	}

	private static void a(l A_0)
	{
		string text = A_0.d.ToString();
		u.d(string.Concat(new object[]
		{
			"parse Receive length = ",
			A_0.e,
			",receive content = ",
			text
		}));
		try
		{
			long num = DateTime.Now.Ticks / 10000L;
			JsonData jsonData = JsonMapper.ToObject(text);
			Cmd a_ = (Cmd)((int)jsonData["cmd"]);
			o.a(a_);
			JsonData obj = jsonData["value"];
			string text2 = JsonMapper.ToJson(obj);
			j j = new j(a_, A_0.b);
			j.c = text2;
			JsonParser.a(j);
			u.d("Enqueue commmand : " + j.e);
			o.b(j);
			u.a(string.Concat(new object[]
			{
				"Enqueue commmand :",
				j.e,
				" end,use time ",
				(DateTime.Now.Ticks / 10000L - num) / 1000L
			}));
		}
		catch (Exception ex)
		{
			o.a(A_0.b);
			u.a(ex.Message + " " + ex.StackTrace);
		}
	}

	public static void a(Socket A_0)
	{
		try
		{
			if (A_0 != null)
			{
				A_0.Close();
			}
		}
		catch (Exception ex)
		{
			u.b(ex.Message + " " + ex.StackTrace);
		}
	}

	public static j b()
	{
		j result;
		lock (o.g)
		{
			if (o.g.Count == 0)
			{
				result = null;
			}
			else
			{
				result = o.g.Dequeue();
			}
		}
		return result;
	}

	public static void b(j A_0)
	{
		lock (o.g)
		{
			o.g.Enqueue(A_0);
		}
	}

	public static void a(j A_0)
	{
		o.h.Enqueue(A_0);
	}

	public static void a()
	{
		try
		{
			Debug.Log("Start server thread");
			o.d();
			if (o.c == null)
			{
				o.c = new Thread(new ThreadStart(o.c));
				o.c.Start();
			}
		}
		catch (Exception ex)
		{
			u.c(ex.Message);
		}
	}
}
