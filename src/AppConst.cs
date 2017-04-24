using System;
using UnityEngine;

public class AppConst
{
	public const bool UsePbc = true;

	public const bool UseLpeg = true;

	public const bool UsePbLua = true;

	public const bool UseCJson = true;

	public const bool UseSproto = true;

	public const bool AutoWrapMode = true;

	public static string uLuaPath
	{
		get
		{
			return Application.dataPath + "/uLua/";
		}
	}
}
