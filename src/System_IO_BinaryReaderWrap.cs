using LuaInterface;
using System;
using System.IO;
using System.Text;

public class System_IO_BinaryReaderWrap
{
	private static Type classType = typeof(BinaryReader);

	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Close", new LuaCSFunction(System_IO_BinaryReaderWrap.Close)),
			new LuaMethod("PeekChar", new LuaCSFunction(System_IO_BinaryReaderWrap.PeekChar)),
			new LuaMethod("Read", new LuaCSFunction(System_IO_BinaryReaderWrap.Read)),
			new LuaMethod("ReadBoolean", new LuaCSFunction(System_IO_BinaryReaderWrap.ReadBoolean)),
			new LuaMethod("ReadByte", new LuaCSFunction(System_IO_BinaryReaderWrap.ReadByte)),
			new LuaMethod("ReadBytes", new LuaCSFunction(System_IO_BinaryReaderWrap.ReadBytes)),
			new LuaMethod("ReadChar", new LuaCSFunction(System_IO_BinaryReaderWrap.ReadChar)),
			new LuaMethod("ReadChars", new LuaCSFunction(System_IO_BinaryReaderWrap.ReadChars)),
			new LuaMethod("ReadDecimal", new LuaCSFunction(System_IO_BinaryReaderWrap.ReadDecimal)),
			new LuaMethod("ReadDouble", new LuaCSFunction(System_IO_BinaryReaderWrap.ReadDouble)),
			new LuaMethod("ReadInt16", new LuaCSFunction(System_IO_BinaryReaderWrap.ReadInt16)),
			new LuaMethod("ReadInt32", new LuaCSFunction(System_IO_BinaryReaderWrap.ReadInt32)),
			new LuaMethod("ReadInt64", new LuaCSFunction(System_IO_BinaryReaderWrap.ReadInt64)),
			new LuaMethod("ReadSByte", new LuaCSFunction(System_IO_BinaryReaderWrap.ReadSByte)),
			new LuaMethod("ReadString", new LuaCSFunction(System_IO_BinaryReaderWrap.ReadString)),
			new LuaMethod("ReadSingle", new LuaCSFunction(System_IO_BinaryReaderWrap.ReadSingle)),
			new LuaMethod("ReadUInt16", new LuaCSFunction(System_IO_BinaryReaderWrap.ReadUInt16)),
			new LuaMethod("ReadUInt32", new LuaCSFunction(System_IO_BinaryReaderWrap.ReadUInt32)),
			new LuaMethod("ReadUInt64", new LuaCSFunction(System_IO_BinaryReaderWrap.ReadUInt64)),
			new LuaMethod("New", new LuaCSFunction(System_IO_BinaryReaderWrap._CreateSystem_IO_BinaryReader)),
			new LuaMethod("GetClassType", new LuaCSFunction(System_IO_BinaryReaderWrap.GetClassType))
		};
		LuaField[] fields = new LuaField[]
		{
			new LuaField("BaseStream", new LuaCSFunction(System_IO_BinaryReaderWrap.get_BaseStream), null)
		};
		LuaScriptMgr.RegisterLib(L, "System.IO.BinaryReader", typeof(BinaryReader), regs, fields, typeof(object));
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateSystem_IO_BinaryReader(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			Stream input = (Stream)LuaScriptMgr.GetNetObject(L, 1, typeof(Stream));
			BinaryReader o = new BinaryReader(input);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		if (num == 2)
		{
			Stream input2 = (Stream)LuaScriptMgr.GetNetObject(L, 1, typeof(Stream));
			Encoding encoding = (Encoding)LuaScriptMgr.GetNetObject(L, 2, typeof(Encoding));
			BinaryReader o2 = new BinaryReader(input2, encoding);
			LuaScriptMgr.PushObject(L, o2);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: System.IO.BinaryReader.New");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, System_IO_BinaryReaderWrap.classType);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_BaseStream(IntPtr L)
	{
		object luaObject = LuaScriptMgr.GetLuaObject(L, 1);
		BinaryReader binaryReader = (BinaryReader)luaObject;
		if (binaryReader == null)
		{
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name BaseStream");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index BaseStream on a nil value");
			}
		}
		LuaScriptMgr.PushObject(L, binaryReader.BaseStream);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Close(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader binaryReader = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
		binaryReader.Close();
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PeekChar(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader binaryReader = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
		int d = binaryReader.PeekChar();
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Read(IntPtr L)
	{
		int num = LuaDLL.lua_gettop(L);
		if (num == 1)
		{
			BinaryReader binaryReader = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
			int d = binaryReader.Read();
			LuaScriptMgr.Push(L, d);
			return 1;
		}
		if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(BinaryReader), typeof(char[]), typeof(int), typeof(int)))
		{
			BinaryReader binaryReader2 = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
			char[] arrayNumber = LuaScriptMgr.GetArrayNumber<char>(L, 2);
			int index = (int)LuaDLL.lua_tonumber(L, 3);
			int count = (int)LuaDLL.lua_tonumber(L, 4);
			int d2 = binaryReader2.Read(arrayNumber, index, count);
			LuaScriptMgr.Push(L, d2);
			return 1;
		}
		if (num == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(BinaryReader), typeof(byte[]), typeof(int), typeof(int)))
		{
			BinaryReader binaryReader3 = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
			byte[] arrayNumber2 = LuaScriptMgr.GetArrayNumber<byte>(L, 2);
			int index2 = (int)LuaDLL.lua_tonumber(L, 3);
			int count2 = (int)LuaDLL.lua_tonumber(L, 4);
			int d3 = binaryReader3.Read(arrayNumber2, index2, count2);
			LuaScriptMgr.Push(L, d3);
			return 1;
		}
		LuaDLL.luaL_error(L, "invalid arguments to method: System.IO.BinaryReader.Read");
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadBoolean(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader binaryReader = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
		bool b = binaryReader.ReadBoolean();
		LuaScriptMgr.Push(L, b);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadByte(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader binaryReader = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
		byte d = binaryReader.ReadByte();
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadBytes(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		BinaryReader binaryReader = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
		int count = (int)LuaScriptMgr.GetNumber(L, 2);
		byte[] o = binaryReader.ReadBytes(count);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadChar(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader binaryReader = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
		char d = binaryReader.ReadChar();
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadChars(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		BinaryReader binaryReader = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
		int count = (int)LuaScriptMgr.GetNumber(L, 2);
		char[] o = binaryReader.ReadChars(count);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadDecimal(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader binaryReader = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
		decimal num = binaryReader.ReadDecimal();
		LuaScriptMgr.PushValue(L, num);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadDouble(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader binaryReader = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
		double d = binaryReader.ReadDouble();
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadInt16(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader binaryReader = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
		short d = binaryReader.ReadInt16();
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadInt32(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader binaryReader = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
		int d = binaryReader.ReadInt32();
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadInt64(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader binaryReader = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
		long d = binaryReader.ReadInt64();
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadSByte(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader binaryReader = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
		sbyte d = binaryReader.ReadSByte();
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader binaryReader = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
		string str = binaryReader.ReadString();
		LuaScriptMgr.Push(L, str);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadSingle(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader binaryReader = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
		float d = binaryReader.ReadSingle();
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadUInt16(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader binaryReader = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
		ushort d = binaryReader.ReadUInt16();
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadUInt32(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader binaryReader = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
		uint d = binaryReader.ReadUInt32();
		LuaScriptMgr.Push(L, d);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadUInt64(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		BinaryReader binaryReader = (BinaryReader)LuaScriptMgr.GetNetObjectSelf(L, 1, "System.IO.BinaryReader");
		ulong d = binaryReader.ReadUInt64();
		LuaScriptMgr.Push(L, d);
		return 1;
	}
}
