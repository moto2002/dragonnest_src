using System;

namespace WeTest.U3DAutomation
{
	internal class JsonParser
	{
		public static string b(j A_0)
		{
			Cmd e = A_0.e;
			Response response = new Response();
			response.cmd = (int)e;
			response.status = A_0.f;
			response.data = A_0.b;
			string result = null;
			try
			{
				result = JsonMapper.ToJson(response);
			}
			catch (Exception ex)
			{
				u.a(ex.Message + " " + ex.StackTrace);
				response.status = ResponseStatus.SUCCESS;
				response.data = null;
				result = JsonMapper.ToJson(response);
			}
			return result;
		}

		public static T Deserialization<T>(j cmd)
		{
			return JsonMapper.ToObject<T>(cmd.c);
		}

		public static bool a(j A_0)
		{
			if (A_0 != null)
			{
				Cmd arg_09_0 = A_0.e;
				Cmd e = A_0.e;
				if (e == Cmd.HANDLE_TOUCH_EVENTS)
				{
					TouchEvent[] d = JsonParser.Deserialization<TouchEvent[]>(A_0);
					A_0.d = d;
				}
				else
				{
					A_0.d = null;
				}
				return true;
			}
			return false;
		}
	}
}
