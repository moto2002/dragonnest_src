using System;

namespace Assets.SDK.JoyyouInput
{
	public class Joystick
	{
		public enum KeyState
		{
			UP,
			DOWN
		}

		public struct JoyAngle
		{
			public float x;

			public float y;
		}

		private static Joystick.JoyAngle left_joy;

		private static Joystick.JoyAngle right_joy;

		public static Joystick.KeyState KeyA
		{
			get;
			private set;
		}

		public static Joystick.KeyState KeyB
		{
			get;
			private set;
		}

		public static Joystick.KeyState KeyX
		{
			get;
			private set;
		}

		public static Joystick.KeyState KeyY
		{
			get;
			private set;
		}

		public static Joystick.KeyState KeyBack
		{
			get;
			private set;
		}

		public static Joystick.KeyState KeyStart
		{
			get;
			private set;
		}

		public static Joystick.KeyState KeyL1
		{
			get;
			private set;
		}

		public static float KeyL2
		{
			get;
			private set;
		}

		public static Joystick.KeyState KeyR1
		{
			get;
			private set;
		}

		public static float KeyR2
		{
			get;
			private set;
		}

		public static Joystick.KeyState KeyHome
		{
			get;
			private set;
		}

		public static Joystick.KeyState KeyHelp
		{
			get;
			private set;
		}

		public static Joystick.KeyState KeyDirectionLeft
		{
			get;
			private set;
		}

		public static Joystick.KeyState KeyDirectionRight
		{
			get;
			private set;
		}

		public static Joystick.KeyState KeyDirectionUp
		{
			get;
			private set;
		}

		public static Joystick.KeyState KeyDirectionDown
		{
			get;
			private set;
		}

		public static Joystick.KeyState KeyOK
		{
			get;
			private set;
		}

		public static Joystick.KeyState KeyJL
		{
			get;
			private set;
		}

		public static Joystick.KeyState KeyJR
		{
			get;
			private set;
		}

		public static Joystick.KeyState KeyMenu
		{
			get;
			private set;
		}

		public static Joystick.JoyAngle JoyLeft
		{
			get
			{
				return Joystick.left_joy;
			}
		}

		public static Joystick.JoyAngle JoyRight
		{
			get
			{
				return Joystick.right_joy;
			}
		}

		static Joystick()
		{
			Joystick.left_joy = default(Joystick.JoyAngle);
			Joystick.right_joy = default(Joystick.JoyAngle);
			Joystick.Rest();
		}

		public static void Rest()
		{
			Joystick.KeyA = Joystick.KeyState.UP;
			Joystick.KeyB = Joystick.KeyState.UP;
			Joystick.KeyX = Joystick.KeyState.UP;
			Joystick.KeyY = Joystick.KeyState.UP;
			Joystick.KeyL1 = Joystick.KeyState.UP;
			Joystick.KeyL2 = 0f;
			Joystick.KeyR1 = Joystick.KeyState.UP;
			Joystick.KeyR2 = 0f;
			Joystick.KeyStart = Joystick.KeyState.UP;
			Joystick.KeyBack = Joystick.KeyState.UP;
			Joystick.KeyHome = Joystick.KeyState.UP;
			Joystick.KeyHelp = Joystick.KeyState.UP;
			Joystick.KeyDirectionLeft = Joystick.KeyState.UP;
			Joystick.KeyDirectionRight = Joystick.KeyState.UP;
			Joystick.KeyDirectionUp = Joystick.KeyState.UP;
			Joystick.KeyDirectionDown = Joystick.KeyState.UP;
			Joystick.KeyMenu = Joystick.KeyState.UP;
			Joystick.KeyOK = Joystick.KeyState.UP;
			Joystick.left_joy.x = (Joystick.left_joy.y = 0f);
			Joystick.right_joy.x = (Joystick.right_joy.y = 0f);
		}

		public void ParserPhysicMessage(string msg)
		{
			string[] array = msg.Split(new char[]
			{
				';'
			});
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string ent = array2[i];
				if (!this.ResetEvent(ent))
				{
					break;
				}
			}
		}

		private bool ResetEvent(string ent)
		{
			string[] array = ent.Split(new char[]
			{
				':'
			});
			bool result = true;
			if (array.Length == 2)
			{
				string text = array[0];
				if (text.Equals("A"))
				{
					Joystick.KeyA = (Joystick.KeyState)int.Parse(array[1]);
				}
				else if (text.Equals("B"))
				{
					Joystick.KeyB = (Joystick.KeyState)int.Parse(array[1]);
				}
				else if (text.Equals("X"))
				{
					Joystick.KeyX = (Joystick.KeyState)int.Parse(array[1]);
				}
				else if (text.Equals("Y"))
				{
					Joystick.KeyY = (Joystick.KeyState)int.Parse(array[1]);
				}
				else if (text.Equals("L1"))
				{
					Joystick.KeyL1 = (Joystick.KeyState)int.Parse(array[1]);
				}
				else if (text.Equals("L2"))
				{
					Joystick.KeyL2 = float.Parse(array[1]);
				}
				else if (text.Equals("R1"))
				{
					Joystick.KeyR1 = (Joystick.KeyState)int.Parse(array[1]);
				}
				else if (text.Equals("R2"))
				{
					Joystick.KeyR2 = float.Parse(array[1]);
				}
				else if (text.Equals("HOME"))
				{
					Joystick.KeyHome = (Joystick.KeyState)int.Parse(array[1]);
				}
				else if (text.Equals("BACK"))
				{
					Joystick.KeyBack = (Joystick.KeyState)int.Parse(array[1]);
				}
				else if (text.Equals("START"))
				{
					Joystick.KeyStart = (Joystick.KeyState)int.Parse(array[1]);
				}
				else if (text.Equals("HELP"))
				{
					Joystick.KeyHelp = (Joystick.KeyState)int.Parse(array[1]);
				}
				else if (text.Equals("UP"))
				{
					Joystick.KeyDirectionUp = (Joystick.KeyState)int.Parse(array[1]);
				}
				else if (text.Equals("DOWN"))
				{
					Joystick.KeyDirectionDown = (Joystick.KeyState)int.Parse(array[1]);
				}
				else if (text.Equals("LEFT"))
				{
					Joystick.KeyDirectionLeft = (Joystick.KeyState)int.Parse(array[1]);
				}
				else if (text.Equals("RIGHT"))
				{
					Joystick.KeyDirectionRight = (Joystick.KeyState)int.Parse(array[1]);
				}
				else if (text.Equals("OK"))
				{
					Joystick.KeyOK = (Joystick.KeyState)int.Parse(array[1]);
				}
				else if (text.Equals("JL"))
				{
					Joystick.KeyJL = (Joystick.KeyState)int.Parse(array[1]);
				}
				else if (text.Equals("JR"))
				{
					Joystick.KeyJR = (Joystick.KeyState)int.Parse(array[1]);
				}
				else if (text.Equals("MENU"))
				{
					Joystick.KeyMenu = (Joystick.KeyState)int.Parse(array[1]);
				}
				else if (text.Equals("JLXY"))
				{
					string[] array2 = array[1].Split(new char[]
					{
						','
					});
					Joystick.left_joy.x = float.Parse(array2[0]);
					Joystick.left_joy.y = float.Parse(array2[1]);
				}
				else if (text.Equals("JRXY"))
				{
					string[] array3 = array[1].Split(new char[]
					{
						','
					});
					Joystick.right_joy.x = float.Parse(array3[0]);
					Joystick.right_joy.y = float.Parse(array3[1]);
				}
			}
			else
			{
				result = false;
			}
			return result;
		}
	}
}
