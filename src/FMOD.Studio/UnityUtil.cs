using System;
using UnityEngine;

namespace FMOD.Studio
{
	public static class UnityUtil
	{
		public static VECTOR toFMODVector(this Vector3 vec)
		{
			VECTOR result;
			result.x = vec.x;
			result.y = vec.y;
			result.z = vec.z;
			return result;
		}

		public static ATTRIBUTES_3D to3DAttributes(this Vector3 pos)
		{
			return new ATTRIBUTES_3D
			{
				forward = Vector3.forward.toFMODVector(),
				up = Vector3.up.toFMODVector(),
				position = pos.toFMODVector()
			};
		}

		public static ATTRIBUTES_3D to3DAttributes(GameObject go, Rigidbody rigidbody = null)
		{
			ATTRIBUTES_3D result = default(ATTRIBUTES_3D);
			result.forward = go.transform.forward.toFMODVector();
			result.up = go.transform.up.toFMODVector();
			result.position = go.transform.position.toFMODVector();
			if (rigidbody)
			{
				result.velocity = rigidbody.velocity.toFMODVector();
			}
			return result;
		}

		public static void Log(string msg)
		{
		}

		public static void LogWarning(string msg)
		{
			UnityEngine.Debug.LogWarning(msg);
		}

		public static void LogError(string msg)
		{
			UnityEngine.Debug.LogError(msg);
		}

		public static bool ForceLoadLowLevelBinary()
		{
			AndroidJavaObject androidJavaObject = null;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
			{
				androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			}
			UnityEngine.Debug.Log("FMOD ANDROID AUDIOTRACK: " + ((androidJavaObject != null) ? "VALID ACTIVITY!" : "ERROR NO ACTIVITY"));
			using (AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("org.fmod.FMOD"))
			{
				if (androidJavaClass2 != null)
				{
					UnityEngine.Debug.Log("FMOD ANDROID AUDIOTRACK: assigning activity to fmod java");
					androidJavaClass2.CallStatic("init", new object[]
					{
						androidJavaObject
					});
				}
				else
				{
					UnityEngine.Debug.Log("FMOD ANDROID AUDIOTRACK: ERROR NO FMOD JAVA");
				}
			}
			UnityUtil.Log("loading binaries: fmodstudio and fmod");
			AndroidJavaClass androidJavaClass3 = new AndroidJavaClass("java.lang.System");
			androidJavaClass3.CallStatic("loadLibrary", new object[]
			{
				"fmod"
			});
			androidJavaClass3.CallStatic("loadLibrary", new object[]
			{
				"fmodstudio"
			});
			UnityUtil.Log("Attempting to call Memory_GetStats");
			int num;
			int num2;
			if (!UnityUtil.ERRCHECK(Memory.GetStats(out num, out num2)))
			{
				UnityUtil.LogError("Memory_GetStats returned an error");
				return false;
			}
			UnityUtil.Log("Calling Memory_GetStats succeeded!");
			return true;
		}

		public static bool ERRCHECK(RESULT result)
		{
			return result == RESULT.OK;
		}
	}
}
