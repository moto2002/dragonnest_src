using System;
using System.Runtime.InteropServices;
using System.Text;

namespace FMOD.Studio
{
	public class Util
	{
		public static RESULT ParseID(string idString, out Guid id)
		{
			byte[] array = new byte[16];
			RESULT result = Util.FMOD_Studio_ParseID(Encoding.UTF8.GetBytes(idString + '\0'), array);
			id = new Guid(array);
			return result;
		}

		[DllImport("fmodstudio")]
		private static extern RESULT FMOD_Studio_ParseID(byte[] idString, byte[] id);
	}
}
