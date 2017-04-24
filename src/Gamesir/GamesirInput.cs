using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamesir
{
	public class GamesirInput
	{
		private static bool debug = false;

		private static GamesirInput _instance;

		private static int mode = 2;

		private static bool[] isGamesirPad = new bool[4];

		private static bool[] isGamesirPadChecked = new bool[4];

		private static object lockObject = new object();

		private static object lockCurrent = new object();

		private AndroidJavaObject current;

		private AndroidJavaObject gamesirUnityInput;

		private AndroidJavaObject inputInterceptor;

		public Dictionary<string, int> androidKeyMap = new Dictionary<string, int>();

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

		private Dictionary<string, int> keystatus = new Dictionary<string, int>();

		public static GamesirInput Instance()
		{
			if (GamesirInput._instance == null)
			{
				GamesirInput._instance = new GamesirInput();
				GamesirInput._instance.preInitXiaoji();
				GamesirInput._instance.keystatus.Add(GamesirInput.BTN_A, 0);
				GamesirInput._instance.keystatus.Add(GamesirInput.BTN_B, 0);
				GamesirInput._instance.keystatus.Add(GamesirInput.BTN_X, 0);
				GamesirInput._instance.keystatus.Add(GamesirInput.BTN_Y, 0);
				GamesirInput._instance.keystatus.Add(GamesirInput.BTN_L1, 0);
				GamesirInput._instance.keystatus.Add(GamesirInput.BTN_R1, 0);
				GamesirInput._instance.keystatus.Add(GamesirInput.BTN_L2, 0);
				GamesirInput._instance.keystatus.Add(GamesirInput.BTN_R2, 0);
				GamesirInput._instance.keystatus.Add(GamesirInput.BTN_THUMBL, 0);
				GamesirInput._instance.keystatus.Add(GamesirInput.BTN_THUMBR, 0);
				GamesirInput._instance.keystatus.Add(GamesirInput.DPAD_LEFT, 0);
				GamesirInput._instance.keystatus.Add(GamesirInput.DPAD_RIGHT, 0);
				GamesirInput._instance.keystatus.Add(GamesirInput.DPAD_DOWN, 0);
				GamesirInput._instance.keystatus.Add(GamesirInput.DPAD_UP, 0);
				GamesirInput._instance.keystatus.Add(GamesirInput.BTN_SELECT, 0);
				GamesirInput._instance.keystatus.Add(GamesirInput.BTN_START, 0);
			}
			return GamesirInput._instance;
		}

		private void preInitXiaoji()
		{
			if (Application.isEditor)
			{
				return;
			}
			this.gamesirUnityInput = new AndroidJavaObject("com.xj.gamesir.sdk.InputStatusManager", new object[0]);
			this.inputInterceptor = this.gamesirUnityInput.CallStatic<AndroidJavaObject>("CreateInputInterceptor", new object[]
			{
				this.Current()
			});
			GamesirInput.mode = this.GetPackageNameSupportMode();
			this.LogInfo("<>initialise() GetPackageNameSupportMode = " + GamesirInput.mode);
			this.androidKeyMap.Add(GamesirInput.BTN_A, 64);
			this.androidKeyMap.Add(GamesirInput.BTN_B, 128);
			this.androidKeyMap.Add(GamesirInput.BTN_X, 256);
			this.androidKeyMap.Add(GamesirInput.BTN_Y, 512);
			this.androidKeyMap.Add(GamesirInput.BTN_L1, 1024);
			this.androidKeyMap.Add(GamesirInput.BTN_R1, 2048);
			this.androidKeyMap.Add(GamesirInput.BTN_L2, 4096);
			this.androidKeyMap.Add(GamesirInput.BTN_R2, 8192);
			this.androidKeyMap.Add(GamesirInput.BTN_THUMBL, 16384);
			this.androidKeyMap.Add(GamesirInput.BTN_THUMBR, 32768);
			this.androidKeyMap.Add(GamesirInput.DPAD_LEFT, 4);
			this.androidKeyMap.Add(GamesirInput.DPAD_RIGHT, 8);
			this.androidKeyMap.Add(GamesirInput.DPAD_DOWN, 2);
			this.androidKeyMap.Add(GamesirInput.DPAD_UP, 1);
			this.androidKeyMap.Add(GamesirInput.BTN_SELECT, 16);
			this.androidKeyMap.Add(GamesirInput.BTN_START, 32);
		}

		public void SetIconLocation(IconLocation iconLocation)
		{
			if (Application.isEditor)
			{
				return;
			}
			this.inputInterceptor.Call("setIconLocation", new object[]
			{
				(int)iconLocation
			});
			this.LogInfo("<>SetIconLocation()");
		}

		public void setHiddenConnectIcon(bool hidden)
		{
			if (Application.isEditor)
			{
				return;
			}
			if (hidden)
			{
				this.inputInterceptor.Call("setHiddenConnectIcon", new object[0]);
			}
			else
			{
				this.inputInterceptor.Call("setDisplayConnectIcon", new object[0]);
			}
			this.LogInfo("<>setHiddenConnectIcon()");
		}

		public void onStart()
		{
			if (Application.isEditor)
			{
				return;
			}
			this.gamesirUnityInput.CallStatic("OnStart", new object[0]);
			this.LogInfo("<>onStart()");
		}

		public void SetDebug(bool debug)
		{
			GamesirInput.debug = debug;
			this.gamesirUnityInput.CallStatic("SetDebug", new object[]
			{
				debug
			});
		}

		public void OnDestory()
		{
			if (Application.isEditor)
			{
				return;
			}
			this.gamesirUnityInput.CallStatic("OnDestory", new object[0]);
			this.LogInfo("<> OnDestory()");
		}

		public void OnQuit()
		{
			if (Application.isEditor)
			{
				return;
			}
			this.inputInterceptor.Call("stopFolatWindow", new object[]
			{
				this.Current()
			});
			this.DisConnectSpp();
			this.LogInfo("OnQuit()");
		}

		public void OpenConnectDialog()
		{
			if (Application.isEditor)
			{
				return;
			}
			this.inputInterceptor.Call("openConnectDialog", new object[0]);
			this.LogInfo("<>OpenConnectDialog()");
		}

		public void CloseConnectDialog()
		{
			if (Application.isEditor)
			{
				return;
			}
			this.inputInterceptor.Call("closeConnectDialog", new object[0]);
			this.LogInfo("<>CloseConnectDialog()");
		}

		public void AutoConnectToGCM()
		{
			if (Application.isEditor)
			{
				return;
			}
			this.LogInfo("<>AutoConnectToGCM()");
			new AndroidJavaClass("com.xj.gamesir.sdk.bluetooth.BluetoothInstance").CallStatic<AndroidJavaObject>("getInstance", new object[0]).Call("autoConnectToBLE", new object[]
			{
				this.Current()
			});
		}

		public void DisConnectGCM()
		{
			if (Application.isEditor)
			{
				return;
			}
			this.LogInfo("<>disConnectGCM()");
			new AndroidJavaClass("com.xj.gamesir.sdk.bluetooth.BluetoothInstance").CallStatic<AndroidJavaObject>("getInstance", new object[0]).Call("disConnectBLE", new object[]
			{
				this.Current()
			});
		}

		public bool isGCMConnected()
		{
			if (Application.isEditor)
			{
				return false;
			}
			int gameSirState = this.GetGameSirState();
			return gameSirState == 3;
		}

		public void AutoConnectToSPP()
		{
			if (Application.isEditor)
			{
				return;
			}
			this.LogInfo("<>AutoConnectToSPP()");
			new AndroidJavaClass("com.xj.gamesir.sdk.bluetooth.BluetoothInstance").CallStatic<AndroidJavaObject>("getInstance", new object[0]).Call("autoConnectToSPP", new object[]
			{
				this.Current()
			});
		}

		public void AutoConnectToHID()
		{
			if (Application.isEditor)
			{
				return;
			}
			this.LogInfo("<>AutoConnectToHID()");
			new AndroidJavaClass("com.xj.gamesir.sdk.bluetooth.BluetoothInstance").CallStatic<AndroidJavaObject>("getInstance", new object[0]).Call("autoConnectToHID", new object[]
			{
				this.Current()
			});
		}

		public void DisConnectHID()
		{
			if (Application.isEditor)
			{
				return;
			}
			this.LogInfo("<>DisConnectHID()");
			new AndroidJavaClass("com.xj.gamesir.sdk.bluetooth.BluetoothInstance").CallStatic<AndroidJavaObject>("getInstance", new object[0]).Call("disConnectHID", new object[]
			{
				this.Current()
			});
		}

		public void DisConnectSpp()
		{
			if (Application.isEditor)
			{
				return;
			}
			this.LogInfo("<>DisConnectSpp()");
			new AndroidJavaClass("com.xj.gamesir.sdk.bluetooth.BluetoothInstance").CallStatic<AndroidJavaObject>("getInstance", new object[0]).Call("disConnectSPP", new object[]
			{
				this.Current()
			});
		}

		private AndroidJavaObject Current()
		{
			if (Application.isEditor)
			{
				return null;
			}
			object obj = GamesirInput.lockCurrent;
			AndroidJavaObject result;
			lock (obj)
			{
				if (this.current == null)
				{
					this.current = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
					if (GamesirInput.debug)
					{
						Debug.LogError("<> new AndroidJavaClass Current ");
					}
					result = this.current;
				}
				else
				{
					result = this.current;
				}
			}
			return result;
		}

		private int GetPackageNameSupportMode()
		{
			if (Application.isEditor)
			{
				return 0;
			}
			return this.gamesirUnityInput.CallStatic<int>("getPackageNameSupportMode", new object[0]);
		}

		private bool CheckIsGamesir(int index, object context, string name)
		{
			if (Application.isEditor)
			{
				return false;
			}
			object obj = GamesirInput.lockObject;
			bool result;
			lock (obj)
			{
				if (!GamesirInput.isGamesirPadChecked[index % 4])
				{
					GamesirInput.isGamesirPad[index % 4] = this.gamesirUnityInput.CallStatic<bool>("CheckIsGamesir", new object[]
					{
						context,
						name
					});
					GamesirInput.isGamesirPadChecked[index % 4] = true;
					result = GamesirInput.isGamesirPad[index % 4];
				}
				else
				{
					result = GamesirInput.isGamesirPad[index % 4];
				}
			}
			return result;
		}

		public int GetGameSirState()
		{
			if (Application.isEditor)
			{
				return 0;
			}
			return this.gamesirUnityInput.CallStatic<int>("GameSirConnected", new object[0]);
		}

		private bool HandleButton(string buttonName, GamepadNumber index)
		{
			if (Application.isEditor)
			{
				return false;
			}
			if (buttonName == GamesirInput.DPAD_UP || buttonName == GamesirInput.DPAD_DOWN)
			{
				float axis = this.GetAxis(GamesirInput.AXIS_HAT_Y);
				return (buttonName == GamesirInput.DPAD_UP && axis < -0.5f) || (buttonName == GamesirInput.DPAD_DOWN && axis > 0.5f);
			}
			if (buttonName == GamesirInput.DPAD_LEFT || buttonName == GamesirInput.DPAD_RIGHT)
			{
				float axis2 = this.GetAxis(GamesirInput.AXIS_HAT_X);
				return (buttonName == GamesirInput.DPAD_LEFT && axis2 < -0.5f) || (buttonName == GamesirInput.DPAD_RIGHT && axis2 > 0.5f);
			}
			int num = this.androidKeyMap[buttonName];
			if (GamesirInput.mode == 0)
			{
				if (Input.GetJoystickNames().Length > 0)
				{
					try
					{
						bool result = Input.GetButton(string.Concat(new object[]
						{
							"Gamesir_BTN_",
							buttonName,
							"_",
							index
						})) || this.gamesirUnityInput.CallStatic<bool>("GetButton", new object[]
						{
							num,
							(int)index
						});
						return result;
					}
					catch
					{
						bool result = false;
						return result;
					}
				}
				return this.gamesirUnityInput.CallStatic<bool>("GetButton", new object[]
				{
					num,
					(int)index
				});
			}
			if (GamesirInput.mode == 1)
			{
				return false;
			}
			if (GamesirInput.mode == 2)
			{
				if (Input.GetJoystickNames().Length > 0)
				{
					try
					{
						bool result;
						if (this.CheckIsGamesir(index - GamepadNumber.First, this.Current(), Input.GetJoystickNames()[index - GamepadNumber.First]))
						{
							result = (Input.GetButton(string.Concat(new object[]
							{
								"Gamesir_BTN_",
								buttonName,
								"_",
								index
							})) || this.gamesirUnityInput.CallStatic<bool>("GetButton", new object[]
							{
								num,
								(int)index
							}));
							return result;
						}
						result = false;
						return result;
					}
					catch
					{
						bool result = false;
						return result;
					}
				}
				return this.gamesirUnityInput.CallStatic<bool>("GetButton", new object[]
				{
					num,
					(int)index
				});
			}
			return false;
		}

		private float HandleAxis(string axisName, GamepadNumber index)
		{
			if (Application.isEditor)
			{
				return 0f;
			}
			if (GamesirInput.mode == 0)
			{
				if (Input.GetJoystickNames().Length > 0)
				{
					try
					{
						float result;
						if (Input.GetAxis(string.Concat(new object[]
						{
							"Gamesir_",
							axisName,
							"_",
							index
						})) != 0f)
						{
							result = Input.GetAxis(string.Concat(new object[]
							{
								"Gamesir_",
								axisName,
								"_",
								index
							}));
							return result;
						}
						result = this.gamesirUnityInput.CallStatic<float>("GetAxis", new object[]
						{
							axisName,
							(int)index
						});
						return result;
					}
					catch
					{
						float result = 0f;
						return result;
					}
				}
				return this.gamesirUnityInput.CallStatic<float>("GetAxis", new object[]
				{
					axisName,
					(int)index
				});
			}
			if (GamesirInput.mode == 1)
			{
				return 0f;
			}
			if (GamesirInput.mode == 2)
			{
				if (Input.GetJoystickNames().Length > 0)
				{
					try
					{
						float result;
						if (!this.CheckIsGamesir(index - GamepadNumber.First, this.Current(), Input.GetJoystickNames()[index - GamepadNumber.First]))
						{
							result = 0f;
							return result;
						}
						if (Input.GetAxis(string.Concat(new object[]
						{
							"Gamesir_",
							axisName,
							"_",
							index
						})) != 0f)
						{
							result = Input.GetAxis(string.Concat(new object[]
							{
								"Gamesir_",
								axisName,
								"_",
								index
							}));
							return result;
						}
						result = this.gamesirUnityInput.CallStatic<float>("GetAxis", new object[]
						{
							axisName,
							(int)index
						});
						return result;
					}
					catch
					{
						float result = 0f;
						return result;
					}
				}
				return this.gamesirUnityInput.CallStatic<float>("GetAxis", new object[]
				{
					axisName,
					(int)index
				});
			}
			return 0f;
		}

		private void LogInfo(string logStr)
		{
			if (GamesirInput.debug)
			{
				Debug.Log(logStr);
			}
		}

		private void LogError(string logStr)
		{
			if (GamesirInput.debug)
			{
				Debug.LogError(logStr);
			}
		}

		public void EnableLog()
		{
			GamesirInput.debug = true;
		}

		public void DisableLog()
		{
			GamesirInput.debug = false;
		}

		public bool GetButton(string keyname)
		{
			return this.HandleButton(keyname, GamepadNumber.First);
		}

		public float GetAxis(string keyname)
		{
			return this.HandleAxis(keyname, GamepadNumber.First);
		}

		public bool GetButton(string keyname, GamepadNumber index)
		{
			return this.HandleButton(keyname, index);
		}

		public float GetAxis(string keyname, GamepadNumber index)
		{
			return this.HandleAxis(keyname, index);
		}

		public void OnRefreshKeys()
		{
			List<string> list = new List<string>();
			list.AddRange(this.keystatus.Keys);
			foreach (string text in list)
			{
				bool button = this.GetButton(text);
				if (button)
				{
					int num = this.keystatus[text];
					if (num >= 0)
					{
						this.keystatus[text] = this.keystatus[text] + 1;
					}
					else
					{
						this.keystatus[text] = 1;
					}
				}
				else if (this.keystatus[text] != 0)
				{
					int num2 = this.keystatus[text];
					if (num2 < 0)
					{
						this.keystatus[text] = this.keystatus[text] - 1;
					}
					else
					{
						this.keystatus[text] = -1;
					}
				}
			}
		}

		public bool GetButtonDown(string button)
		{
			return this.keystatus[button] == 1;
		}

		public bool GetButtonUp(string button)
		{
			return this.keystatus[button] == -1;
		}
	}
}
