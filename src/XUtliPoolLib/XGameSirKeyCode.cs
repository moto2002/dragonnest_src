using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	public class XGameSirKeyCode
	{
		public static string BTN_A = "A";

		public static string BTN_B = "B";

		public static string BTN_X = "X";

		public static string BTN_Y = "Y";

		public static string BTN_L1 = "L1";

		public static string BTN_L2 = "L2";

		public static string BTN_R1 = "R1";

		public static string BTN_R2 = "R2";

		public static string AXIS_RTRIGGER = "TRIGGERL";

		public static string AXIS_LTRIGGER = "TRIGGERR";

		public static string DPAD_UP = "DPAD_UP";

		public static string DPAD_DOWN = "DPAD_DOWN";

		public static string DPAD_LEFT = "DPAD_LEFT";

		public static string DPAD_RIGHT = "DPAD_RIGHT";

		public static string AXIS_HAT_X = "HAT_X";

		public static string AXIS_HAT_Y = "HAT_Y";

		public static string AXIS_X = "L3D_X";

		public static string AXIS_Y = "L3D_Y";

		public static string BTN_THUMBL = "THUMB_L";

		public static string AXIS_Z = "R3D_Z";

		public static string AXIS_RZ = "R3D_RZ";

		public static string BTN_THUMBR = "THUMB_R";

		public static string BTN_SELECT = "SELECT";

		public static string BTN_START = "START";

		public static int SKILL_SIZE = 10;

		private static List<string>[] _skillMap;

		public static List<string>[] SkillMap
		{
			get
			{
				if (XGameSirKeyCode._skillMap == null)
				{
					XGameSirKeyCode._skillMap = new List<string>[XGameSirKeyCode.SKILL_SIZE];
					XGameSirKeyCode._skillMap[0] = new List<string>
					{
						XGameSirKeyCode.BTN_L2
					};
					XGameSirKeyCode._skillMap[1] = new List<string>
					{
						XGameSirKeyCode.BTN_L1
					};
					XGameSirKeyCode._skillMap[2] = new List<string>
					{
						XGameSirKeyCode.BTN_A
					};
					XGameSirKeyCode._skillMap[3] = new List<string>
					{
						XGameSirKeyCode.BTN_B
					};
					XGameSirKeyCode._skillMap[4] = new List<string>
					{
						XGameSirKeyCode.BTN_X
					};
					XGameSirKeyCode._skillMap[5] = new List<string>
					{
						XGameSirKeyCode.BTN_Y
					};
					XGameSirKeyCode._skillMap[6] = new List<string>
					{
						XGameSirKeyCode.BTN_L2,
						XGameSirKeyCode.BTN_A
					};
					XGameSirKeyCode._skillMap[7] = new List<string>
					{
						XGameSirKeyCode.BTN_L2,
						XGameSirKeyCode.BTN_B
					};
					XGameSirKeyCode._skillMap[8] = new List<string>
					{
						XGameSirKeyCode.DPAD_LEFT
					};
					XGameSirKeyCode._skillMap[9] = new List<string>
					{
						XGameSirKeyCode.DPAD_RIGHT
					};
				}
				return XGameSirKeyCode._skillMap;
			}
		}
	}
}
