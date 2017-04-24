using Dynamic;
using System;
using UnityEngine;

namespace WeTest.U3DAutomation
{
	public class U3DAutomationBehaviour : MonoBehaviour
	{
		private static bool a;

		private bool b;

		private void b()
		{
			ThirdManager.INSTANCE.Initialize();
			ThirdManager.Start();
			base.StartCoroutine(ThirdManager.HandleCommand());
		}

		private void Start()
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				Debug.Log("WTSDK can not running, if not Android.");
				return;
			}
			if (!U3DAutomationBehaviour.a)
			{
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
				this.b = true;
				U3DAutomationBehaviour.a = true;
				Debug.Log("Start Init");
				this.b();
				Debug.Log("U3DAutomation Init OK. Version = " + VersionInfo.SDK_VERSION + " UIType = " + VersionInfo.SDK_UI);
				return;
			}
			Debug.Log("U3DAutomation already init.");
		}

		private void a()
		{
			ThirdManager.HandleEvent();
			ThirdManager.FrameUpdate();
		}

		private void Update()
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			if (this.b)
			{
				this.a();
			}
		}

		public static Application.LogCallback getLogCallBack()
		{
			return CrashMonitor.getLogCallBackHandler();
		}

		private void OnApplicationPause(bool pauseStatus)
		{
			u.c("OnApplicationPause:{0}", new object[]
			{
				pauseStatus
			});
		}

		private void OnApplicationFocus(bool focusStatus)
		{
			u.c("OnApplicationFocus:{0}", new object[]
			{
				focusStatus
			});
		}

		private void OnDestroy()
		{
			u.c("Destory Wetest sdk");
		}
	}
}
