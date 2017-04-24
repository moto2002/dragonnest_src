using System;
using System.Collections.Generic;
using System.Text;

namespace XUtliPoolLib
{
	public class XStringFormatHelper
	{
		public static readonly char EscapedSeparator = '\u001f';

		public static readonly char[] Separator = new char[]
		{
			XStringFormatHelper.EscapedSeparator
		};

		private static readonly char _cSeparator = '|';

		private static readonly char _cLeftBracket = '[';

		private static readonly char _EscapedLeftBracket = '\u0002';

		private static readonly char _cRightBracket = ']';

		private static readonly char _EscapedRightBracket = '\u0003';

		private static readonly string _strSeparator = "|" + XStringFormatHelper._cSeparator;

		private static readonly string _strLeftBracket = "|" + XStringFormatHelper._cLeftBracket;

		private static readonly string _strRightBracket = "|" + XStringFormatHelper._cRightBracket;

		private static readonly string _strEscapedSeparator = string.Concat(XStringFormatHelper.EscapedSeparator);

		private static readonly string _strEscapedLeftBracket = string.Concat(XStringFormatHelper._EscapedLeftBracket);

		private static readonly string _strEscapedRightBracket = string.Concat(XStringFormatHelper._EscapedRightBracket);

		private static StringBuilder _SB = new StringBuilder();

		public static string FormatImage(string atlas, string sprite)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedLeftBracket).Append("im=").Append(atlas).Append(XStringFormatHelper.EscapedSeparator).Append(sprite).Append(XStringFormatHelper._EscapedRightBracket);
			return XStringFormatHelper._SB.ToString();
		}

		public static string FormatAnimation(string atlas, string sprite, int frameRate)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedLeftBracket).Append("an=").Append(atlas).Append(XStringFormatHelper.EscapedSeparator).Append(sprite).Append(XStringFormatHelper.EscapedSeparator).Append(frameRate.ToString()).Append(XStringFormatHelper._EscapedRightBracket);
			return XStringFormatHelper._SB.ToString();
		}

		public static string FormatGuild(string name, ulong uid)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedLeftBracket).Append("gd=").Append(name).Append(XStringFormatHelper.EscapedSeparator).Append(uid).Append(XStringFormatHelper._EscapedRightBracket);
			return XStringFormatHelper._SB.ToString();
		}

		public static string FormatTeam(string name, int teamid, uint expid)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedLeftBracket).Append("tm=").Append(name).Append(XStringFormatHelper.EscapedSeparator).Append(teamid).Append(XStringFormatHelper.EscapedSeparator).Append(expid).Append(XStringFormatHelper._EscapedRightBracket);
			return XStringFormatHelper._SB.ToString();
		}

		public static string FormatItem(string name, string itemquality, ulong uid)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedLeftBracket).Append("it=").Append(name).Append(XStringFormatHelper.EscapedSeparator).Append(itemquality).Append(XStringFormatHelper.EscapedSeparator).Append(uid).Append(XStringFormatHelper._EscapedRightBracket);
			return XStringFormatHelper._SB.ToString();
		}

		public static string FormatName(string name, ulong uid, string color = "00ffff")
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedLeftBracket).Append("nm=").Append(name).Append(XStringFormatHelper.EscapedSeparator).Append(color).Append(XStringFormatHelper.EscapedSeparator).Append(uid).Append(XStringFormatHelper._EscapedRightBracket);
			return XStringFormatHelper._SB.ToString();
		}

		public static string FormatPk(string name, ulong uid)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedLeftBracket).Append("pk=").Append(name).Append(XStringFormatHelper.EscapedSeparator).Append(uid).Append(XStringFormatHelper._EscapedRightBracket);
			return XStringFormatHelper._SB.ToString();
		}

		public static string FormatSpeactate(string name, int liveid, int type)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedLeftBracket).Append("sp=").Append(name).Append(XStringFormatHelper.EscapedSeparator).Append(liveid).Append(XStringFormatHelper.EscapedSeparator).Append(type).Append(XStringFormatHelper._EscapedRightBracket);
			return XStringFormatHelper._SB.ToString();
		}

		public static string FormatUI(string name, ulong uid, List<ulong> paramList = null)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedLeftBracket).Append("ui=").Append(name).Append(XStringFormatHelper.EscapedSeparator).Append(uid);
			if (paramList != null)
			{
				for (int i = 0; i < paramList.Count; i++)
				{
					XStringFormatHelper._SB.Append(XStringFormatHelper.EscapedSeparator).Append(paramList[i]);
				}
			}
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedRightBracket);
			return XStringFormatHelper._SB.ToString();
		}

		private static void _ResetSB()
		{
			XStringFormatHelper._SB.Remove(0, XStringFormatHelper._SB.Length);
		}

		public static string Escape(string s)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(s);
			XStringFormatHelper._Escape();
			return XStringFormatHelper._SB.ToString();
		}

		private static void _Escape()
		{
			XStringFormatHelper._SB.Replace(XStringFormatHelper._strSeparator, XStringFormatHelper._strEscapedSeparator);
			XStringFormatHelper._SB.Replace(XStringFormatHelper._strLeftBracket, XStringFormatHelper._strEscapedLeftBracket);
			XStringFormatHelper._SB.Replace(XStringFormatHelper._strRightBracket, XStringFormatHelper._strEscapedRightBracket);
		}

		public static string UnEscape(string s)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(s);
			XStringFormatHelper._UnEscape();
			return XStringFormatHelper._SB.ToString();
		}

		private static void _UnEscape()
		{
			XStringFormatHelper._SB.Replace(XStringFormatHelper._strEscapedSeparator, XStringFormatHelper._strSeparator);
			XStringFormatHelper._SB.Replace(XStringFormatHelper._strEscapedLeftBracket, XStringFormatHelper._strLeftBracket);
			XStringFormatHelper._SB.Replace(XStringFormatHelper._strEscapedRightBracket, XStringFormatHelper._strRightBracket);
		}
	}
}
