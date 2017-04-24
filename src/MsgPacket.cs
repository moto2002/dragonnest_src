using System;

public class MsgPacket
{
	public ushort id;

	public int seq;

	public ushort errno;

	public LuaStringBuffer data;
}
