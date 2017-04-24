using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class QGameKitAndroidBridge : MonoBehaviour
{
	public class UserAccountCallback : AndroidJavaProxy
	{
		private QGameKit.UserAccountDelegate accountDelegate;

		public UserAccountCallback(QGameKit.UserAccountDelegate mDelegate) : base("com.tencent.qgame.livesdk.bridge.UserAccountListener")
		{
			this.accountDelegate = mDelegate;
		}

		private AndroidJavaObject getUserAccount()
		{
			QGameKit.UserAccount userAccount = this.accountDelegate();
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tencent.qgame.livesdk.webview.Account", new object[0]);
			androidJavaObject.Set<string>("openId", userAccount.id);
			androidJavaObject.Set<string>("accessToken", userAccount.token);
			androidJavaObject.Set<int>("loginType", (int)userAccount.platform);
			androidJavaObject.Set<string>("appId", userAccount.appId);
			return androidJavaObject;
		}
	}

	public class CommentReceiveCallback : AndroidJavaProxy
	{
		private QGameKit.CommentReceiveDelegate commentDelegate;

		public CommentReceiveCallback(QGameKit.CommentReceiveDelegate mDelegate) : base("com.tencent.qgame.livesdk.bridge.CommentReceiveListener")
		{
			this.commentDelegate = mDelegate;
		}

		private void onCommentReceive(AndroidJavaObject comments)
		{
			List<QGameKit.LiveComment> list = new List<QGameKit.LiveComment>();
			int num = comments.Call<int>("size", new object[0]);
			for (int i = 0; i < num; i++)
			{
				AndroidJavaObject androidJavaObject = comments.Call<AndroidJavaObject>("get", new object[]
				{
					i
				});
				QGameKit.LiveComment liveComment = new QGameKit.LiveComment();
				liveComment.type = (QGameKit.CommentType)androidJavaObject.Get<int>("msgType");
				liveComment.nick = androidJavaObject.Get<string>("nick");
				liveComment.content = androidJavaObject.Get<string>("msgContent");
				string s = androidJavaObject.Call<string>("msgTime2String", new object[0]);
				liveComment.timestamp = long.Parse(s);
				list.Add(liveComment);
			}
			this.commentDelegate(list);
		}
	}

	public class LogCallback : AndroidJavaProxy
	{
		private QGameKit.LogDelegate logDelegate;

		public LogCallback(QGameKit.LogDelegate mDelegate) : base("com.tencent.qgame.livesdk.bridge.LogListener")
		{
			this.logDelegate = mDelegate;
		}

		private void log(string msg)
		{
			this.logDelegate(msg);
		}
	}

	public class LiveStatusChangedCallback : AndroidJavaProxy
	{
		private QGameKit.LiveStatusChangedDelegate liveStatusChangedDelegate;

		private QGameKitAndroidBridge mBridge;

		public LiveStatusChangedCallback(QGameKitAndroidBridge bridge, QGameKit.LiveStatusChangedDelegate mDelegate) : base("com/tencent/qgame/live/listener/OnLiveStatusChangedListener")
		{
			this.liveStatusChangedDelegate = mDelegate;
			this.mBridge = bridge;
		}

		private void onLiveStatusChanged(int stateId)
		{
			UnityEngine.Debug.Log("Live status change to: " + stateId);
			QGameKit.LiveStatus stateById = this.mBridge.getStateById(stateId);
			switch (stateById)
			{
			case QGameKit.LiveStatus.LiveStarting:
				this.mBridge.isRunning = true;
				UnityEngine.Debug.Log("Start CaptureFrame");
				break;
			case QGameKit.LiveStatus.LivePaused:
			case QGameKit.LiveStatus.LiveStopping:
				this.mBridge.isRunning = false;
				break;
			case QGameKit.LiveStatus.Error:
				this.mBridge.isRunning = false;
				break;
			}
			this.liveStatusChangedDelegate(stateById);
		}
	}

	public class ShareDelegateCallback : AndroidJavaProxy
	{
		private QGameKit.ShareDelegate shareDelegate;

		public ShareDelegateCallback(QGameKit.ShareDelegate mDelegate) : base("com.tencent.qgame.livesdk.bridge.ShareListener")
		{
			this.shareDelegate = mDelegate;
		}

		private void share(AndroidJavaObject javaObject)
		{
			QGameKit.ShareContent shareContent = new QGameKit.ShareContent();
			shareContent.fopenId = javaObject.Get<string>("fopenId");
			shareContent.title = javaObject.Get<string>("title");
			shareContent.description = javaObject.Get<string>("description");
			shareContent.targetUrl = javaObject.Get<string>("targetUrl");
			shareContent.imageUrl = javaObject.Get<string>("imageUrl");
			this.shareDelegate(shareContent);
		}
	}

	public class ErrorCodeCallback : AndroidJavaProxy
	{
		private QGameKit.ErrorCodeListenerDelegate errorCodeDelegate;

		public ErrorCodeCallback(QGameKit.ErrorCodeListenerDelegate mDelegate) : base("com/tencent/qgame/live/listener/ErrorCodeListener")
		{
			this.errorCodeDelegate = mDelegate;
		}

		private void onResult(int errorCode, string errorMessage)
		{
			this.errorCodeDelegate(errorCode, errorMessage);
		}
	}

	public class WebViewStatusChangedCallback : AndroidJavaProxy
	{
		private QGameKit.WebViewStatusChangedDelegate webviewStatusChangedDelegate;

		public WebViewStatusChangedCallback(QGameKit.WebViewStatusChangedDelegate mDelegate) : base("com.tencent.qgame.livesdk.bridge.WebViewStatusChangedListener")
		{
			this.webviewStatusChangedDelegate = mDelegate;
		}

		private void onWebViewStatusChanged(int status)
		{
			this.webviewStatusChangedDelegate((QGameKit.WebViewStatus)status);
		}
	}

	private static string gameID;

	private static string wnsID;

	private static QGameKit.CaptureType myCaptureType;

	private int grabFrameRate = 20;

	private static QGameKit.Environment sdkEnvironmentType;

	private static QGameKitAndroidBridge singletonInstance = null;

	private static AndroidJavaObject playerActivityContext = null;

	private static IntPtr constructorMethodID = IntPtr.Zero;

	private static IntPtr setupMethodID = IntPtr.Zero;

	private static IntPtr tearDownMethodID = IntPtr.Zero;

	private static IntPtr resetMethodID = IntPtr.Zero;

	private static IntPtr startLiveBroadcastMethodID = IntPtr.Zero;

	private static IntPtr frameUpdatedMethodID = IntPtr.Zero;

	private static IntPtr stopLiveBroadcastMethodID = IntPtr.Zero;

	private static IntPtr enterLiveHallMethodID = IntPtr.Zero;

	private static IntPtr enterLiveHallInGameMethodID = IntPtr.Zero;

	private static IntPtr updateUserAccountMethodID = IntPtr.Zero;

	private static IntPtr getLiveBroadcastStatusMethodID = IntPtr.Zero;

	private static IntPtr getErrorCodeMethodID = IntPtr.Zero;

	private static IntPtr isLiveBroadcastSupportedMethodID = IntPtr.Zero;

	private static IntPtr getVersionNameMethodID = IntPtr.Zero;

	private static IntPtr showCameraMethodID = IntPtr.Zero;

	private static IntPtr hideCameraMethodID = IntPtr.Zero;

	private static IntPtr setEnvironmentTypeMethodID = IntPtr.Zero;

	private static IntPtr getLiveFrameRateMethodID = IntPtr.Zero;

	private static IntPtr doOnCreateMethodID = IntPtr.Zero;

	private static IntPtr doOnResumeMethodID = IntPtr.Zero;

	private static IntPtr doOnPauseMethodID = IntPtr.Zero;

	private static IntPtr doOnDestroyMethodID = IntPtr.Zero;

	private static IntPtr doOnBackPressedMethodID = IntPtr.Zero;

	private static IntPtr notifyUserAccountMethodID = IntPtr.Zero;

	private static IntPtr setUserAccountListenerMethodID = IntPtr.Zero;

	private static IntPtr setCommentReceiveDelegateMethodID = IntPtr.Zero;

	private static IntPtr setLogDelegateMethodID = IntPtr.Zero;

	private static IntPtr setLiveStatusChangedDelegateMethodID = IntPtr.Zero;

	private static IntPtr setShareListenerMethodID = IntPtr.Zero;

	private static IntPtr setErrorCodeDelegateMethodID = IntPtr.Zero;

	private static IntPtr setWebViewStatusChangedDelegateMethodID = IntPtr.Zero;

	private static IntPtr isSupportCameraMethodID = IntPtr.Zero;

	private static IntPtr shareLiveBroadcastMethodID = IntPtr.Zero;

	private static IntPtr isSupportLiveHallMethodID = IntPtr.Zero;

	private static IntPtr setDanmakuEnabledMethodID = IntPtr.Zero;

	private static IntPtr showDanmakuMethodID = IntPtr.Zero;

	private static IntPtr hideDanmakuMethodID = IntPtr.Zero;

	private IntPtr androidBridge = IntPtr.Zero;

	private float startTime;

	private float nextCaptureTime;

	private float frameInterval;

	private static QGameKit.UserAccountDelegate userAccountDelegate;

	public bool isRunning
	{
		get;
		private set;
	}

	public static QGameKitAndroidBridge Setup(string gameId, string wnsId, QGameKit.CaptureType captureType, QGameKit.UserAccountDelegate accountDelegate, QGameKit.Environment environmentType)
	{
		if (QGameKitAndroidBridge.singletonInstance != null)
		{
			return QGameKitAndroidBridge.singletonInstance;
		}
		QGameKitAndroidBridge.gameID = gameId;
		QGameKitAndroidBridge.wnsID = wnsId;
		QGameKitAndroidBridge.myCaptureType = captureType;
		QGameKitAndroidBridge.userAccountDelegate = accountDelegate;
		QGameKitAndroidBridge.sdkEnvironmentType = environmentType;
		GameObject gameObject = new GameObject("QGameKitAndroidBridge");
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
		QGameKitAndroidBridge.singletonInstance = gameObject.AddComponent<QGameKitAndroidBridge>();
		QGameKitAndroidBridge.singletonInstance.initSDK();
		return QGameKitAndroidBridge.singletonInstance;
	}

	private void initSDK()
	{
		IntPtr intPtr = AndroidJNI.FindClass("com/tencent/qgame/livesdk/bridge/Unity3D");
		QGameKitAndroidBridge.constructorMethodID = AndroidJNI.GetMethodID(intPtr, "<init>", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;IIII)V");
		if (QGameKitAndroidBridge.constructorMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find UnityBridge constructor.");
			return;
		}
		QGameKitAndroidBridge.setupMethodID = AndroidJNI.GetMethodID(intPtr, "setup", "(Lcom/tencent/qgame/livesdk/bridge/UserAccountListener;)Z");
		if (QGameKitAndroidBridge.setupMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find setup() method.");
			return;
		}
		QGameKitAndroidBridge.tearDownMethodID = AndroidJNI.GetMethodID(intPtr, "tearDown", "()V");
		if (QGameKitAndroidBridge.tearDownMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find tearDown() method.");
			return;
		}
		QGameKitAndroidBridge.resetMethodID = AndroidJNI.GetMethodID(intPtr, "reset", "()Z");
		if (QGameKitAndroidBridge.resetMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find reset() method.");
			return;
		}
		QGameKitAndroidBridge.startLiveBroadcastMethodID = AndroidJNI.GetMethodID(intPtr, "startLiveBroadcast", "(Ljava/lang/String;Ljava/lang/String;)Z");
		if (QGameKitAndroidBridge.startLiveBroadcastMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find startLiveBroadcast() method.");
			return;
		}
		QGameKitAndroidBridge.stopLiveBroadcastMethodID = AndroidJNI.GetMethodID(intPtr, "stopLiveBroadcast", "()Z");
		if (QGameKitAndroidBridge.stopLiveBroadcastMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find stopLiveBroadcast() method.");
			return;
		}
		QGameKitAndroidBridge.frameUpdatedMethodID = AndroidJNI.GetMethodID(intPtr, "frameUpdated", "()V");
		if (QGameKitAndroidBridge.frameUpdatedMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find frameUpdated() method.");
			return;
		}
		QGameKitAndroidBridge.enterLiveHallMethodID = AndroidJNI.GetMethodID(intPtr, "enterLiveHall", "(Landroid/content/Context;)V");
		if (QGameKitAndroidBridge.enterLiveHallMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find enterLiveHall() method.");
			return;
		}
		QGameKitAndroidBridge.enterLiveHallInGameMethodID = AndroidJNI.GetMethodID(intPtr, "enterLiveHallInGame", "(Landroid/content/Context;)V");
		if (QGameKitAndroidBridge.enterLiveHallInGameMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find enterLiveHallInGameMethodID() method.");
			return;
		}
		QGameKitAndroidBridge.updateUserAccountMethodID = AndroidJNI.GetMethodID(intPtr, "updateUserAccount", "(ILjava/lang/String;Ljava/lang/String;Ljava/lang/String;)V");
		if (QGameKitAndroidBridge.updateUserAccountMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find updateUserAccount() method.");
			return;
		}
		QGameKitAndroidBridge.getLiveBroadcastStatusMethodID = AndroidJNI.GetMethodID(intPtr, "getLiveBroadcastStatus", "()I");
		if (QGameKitAndroidBridge.getLiveBroadcastStatusMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find getLiveBroadcastStatus() method.");
			return;
		}
		QGameKitAndroidBridge.getErrorCodeMethodID = AndroidJNI.GetMethodID(intPtr, "getErrorCode", "()I");
		if (QGameKitAndroidBridge.getErrorCodeMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find getErrorCode() method.");
			return;
		}
		QGameKitAndroidBridge.setUserAccountListenerMethodID = AndroidJNI.GetMethodID(intPtr, "setUserAccountListener", "(Lcom/tencent/qgame/livesdk/bridge/UserAccountListener;)V");
		if (QGameKitAndroidBridge.setUserAccountListenerMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find setUserAccountListener() method.");
			return;
		}
		QGameKitAndroidBridge.setCommentReceiveDelegateMethodID = AndroidJNI.GetMethodID(intPtr, "setCommentReceiveListener", "(Lcom/tencent/qgame/livesdk/bridge/CommentReceiveListener;)V");
		if (QGameKitAndroidBridge.setCommentReceiveDelegateMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find setCommentReceiveListener() method.");
			return;
		}
		QGameKitAndroidBridge.setLogDelegateMethodID = AndroidJNI.GetMethodID(intPtr, "setLogListener", "(Lcom/tencent/qgame/livesdk/bridge/LogListener;)V");
		if (QGameKitAndroidBridge.setLogDelegateMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find setLogListener() method.");
			return;
		}
		QGameKitAndroidBridge.setLiveStatusChangedDelegateMethodID = AndroidJNI.GetMethodID(intPtr, "setLiveStatusChangedListener", "(Lcom/tencent/qgame/live/listener/OnLiveStatusChangedListener;)V");
		if (QGameKitAndroidBridge.setLiveStatusChangedDelegateMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find setLiveStatusChangedListener() method.");
			return;
		}
		QGameKitAndroidBridge.setShareListenerMethodID = AndroidJNI.GetMethodID(intPtr, "setShareListener", "(Lcom/tencent/qgame/livesdk/bridge/ShareListener;)V");
		if (QGameKitAndroidBridge.setShareListenerMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find setShareListener() method.");
			return;
		}
		QGameKitAndroidBridge.setErrorCodeDelegateMethodID = AndroidJNI.GetMethodID(intPtr, "setErrorCodeListener", "(Lcom/tencent/qgame/live/listener/ErrorCodeListener;)V");
		if (QGameKitAndroidBridge.setErrorCodeDelegateMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find setErrorCodeDelegateMethodID() method.");
			return;
		}
		QGameKitAndroidBridge.setWebViewStatusChangedDelegateMethodID = AndroidJNI.GetMethodID(intPtr, "setWebViewStatusChangedListener", "(Lcom/tencent/qgame/livesdk/bridge/WebViewStatusChangedListener;)V");
		if (QGameKitAndroidBridge.setWebViewStatusChangedDelegateMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find setWebViewStatusChangedListener() method.");
			return;
		}
		QGameKitAndroidBridge.isLiveBroadcastSupportedMethodID = AndroidJNI.GetMethodID(intPtr, "isLiveBroadcastSupported", "()Z");
		if (QGameKitAndroidBridge.isLiveBroadcastSupportedMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find isLiveBroadcastSupportedMethodID() method.");
			return;
		}
		QGameKitAndroidBridge.getVersionNameMethodID = AndroidJNI.GetMethodID(intPtr, "getVersionName", "()Ljava/lang/String;");
		if (QGameKitAndroidBridge.getVersionNameMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find getVersionNameMethodID() method.");
			return;
		}
		QGameKitAndroidBridge.showCameraMethodID = AndroidJNI.GetMethodID(intPtr, "showCamera", "()Z");
		if (QGameKitAndroidBridge.showCameraMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find showCameraMethodID() method.");
			return;
		}
		QGameKitAndroidBridge.hideCameraMethodID = AndroidJNI.GetMethodID(intPtr, "hideCamera", "()V");
		if (QGameKitAndroidBridge.hideCameraMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find hideCameraMethodID() method.");
			return;
		}
		QGameKitAndroidBridge.setEnvironmentTypeMethodID = AndroidJNI.GetMethodID(intPtr, "setEnvironmentType", "(I)V");
		if (QGameKitAndroidBridge.setEnvironmentTypeMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find setEnvironmentTypeMethodID() method");
			return;
		}
		QGameKitAndroidBridge.getLiveFrameRateMethodID = AndroidJNI.GetMethodID(intPtr, "getLiveFrameRate", "()I");
		if (QGameKitAndroidBridge.getLiveFrameRateMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find getLiveFrameRate() method");
			return;
		}
		QGameKitAndroidBridge.notifyUserAccountMethodID = AndroidJNI.GetMethodID(intPtr, "notifyUserAccountUpdate", "()V");
		if (QGameKitAndroidBridge.notifyUserAccountMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find notifyUserAccountMethodID() method.");
			return;
		}
		QGameKitAndroidBridge.doOnCreateMethodID = AndroidJNI.GetMethodID(intPtr, "doOnCreate", "()V");
		if (QGameKitAndroidBridge.doOnCreateMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find doOnCreate() method");
			return;
		}
		QGameKitAndroidBridge.doOnResumeMethodID = AndroidJNI.GetMethodID(intPtr, "doOnResume", "()V");
		if (QGameKitAndroidBridge.doOnResumeMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find doOnResume() method");
			return;
		}
		QGameKitAndroidBridge.doOnPauseMethodID = AndroidJNI.GetMethodID(intPtr, "doOnPause", "()V");
		if (QGameKitAndroidBridge.doOnPauseMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find doOnPause() method");
			return;
		}
		QGameKitAndroidBridge.doOnDestroyMethodID = AndroidJNI.GetMethodID(intPtr, "doOnDestroy", "()V");
		if (QGameKitAndroidBridge.doOnDestroyMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find doOnDestroy() method");
			return;
		}
		QGameKitAndroidBridge.doOnBackPressedMethodID = AndroidJNI.GetMethodID(intPtr, "doOnBackPressed", "()Z");
		if (QGameKitAndroidBridge.doOnBackPressedMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find doOnBackPressed() method");
			return;
		}
		QGameKitAndroidBridge.isSupportCameraMethodID = AndroidJNI.GetMethodID(intPtr, "isSupportCamera", "()Z");
		if (QGameKitAndroidBridge.isSupportCameraMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find isSupportCamera() method");
			return;
		}
		QGameKitAndroidBridge.shareLiveBroadcastMethodID = AndroidJNI.GetMethodID(intPtr, "shareLiveBroadcast", "()V");
		if (QGameKitAndroidBridge.shareLiveBroadcastMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find shareLiveBroadcast() method");
			return;
		}
		QGameKitAndroidBridge.isSupportLiveHallMethodID = AndroidJNI.GetMethodID(intPtr, "isSupportLiveHall", "()Z");
		if (QGameKitAndroidBridge.isSupportLiveHallMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find isSupportLiveHall() method");
			return;
		}
		QGameKitAndroidBridge.setDanmakuEnabledMethodID = AndroidJNI.GetMethodID(intPtr, "setDanmakuEnabled", "(Z)V");
		if (QGameKitAndroidBridge.setDanmakuEnabledMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find setDanmakuEnabled() method");
			return;
		}
		QGameKitAndroidBridge.showDanmakuMethodID = AndroidJNI.GetMethodID(intPtr, "showDanmaku", "()V");
		if (QGameKitAndroidBridge.showDanmakuMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find showDanmaku() method");
			return;
		}
		QGameKitAndroidBridge.hideDanmakuMethodID = AndroidJNI.GetMethodID(intPtr, "hideDanmaku", "()V");
		if (QGameKitAndroidBridge.hideDanmakuMethodID == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Can't find hideDanmaku() method");
			return;
		}
		jvalue[] args = AndroidJNIHelper.CreateJNIArgArray(new object[]
		{
			QGameKitAndroidBridge.getActivityContext(),
			QGameKitAndroidBridge.gameID,
			QGameKitAndroidBridge.wnsID,
			Screen.width,
			Screen.height,
			Convert.ToInt32(QGameKitAndroidBridge.myCaptureType),
			Convert.ToInt32(QGameKitAndroidBridge.sdkEnvironmentType)
		});
		IntPtr intPtr2 = AndroidJNI.NewObject(intPtr, QGameKitAndroidBridge.constructorMethodID, args);
		if (intPtr2 == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("--- Can't create Unity bridge object.");
			return;
		}
		this.androidBridge = AndroidJNI.NewGlobalRef(intPtr2);
		AndroidJNI.DeleteLocalRef(intPtr2);
		AndroidJNI.DeleteLocalRef(intPtr);
		UnityEngine.Debug.Log("--- grabFrameRate = " + this.grabFrameRate);
		this.frameInterval = 1f / (float)this.grabFrameRate;
		UnityEngine.Debug.Log("--- 1.0f / grabFrameRate = " + this.frameInterval);
		this.startTime = Time.time;
		this.isRunning = false;
		if (QGameKitAndroidBridge.myCaptureType == (QGameKit.CaptureType)0)
		{
			if (QGameKitAndroidBridge.userAccountDelegate != null)
			{
				this.SetUserAccountDelegate(QGameKitAndroidBridge.userAccountDelegate);
			}
			UnityEngine.Debug.Log("CaptureType is zero, give up setup");
			return;
		}
		if (this.setup())
		{
			UnityEngine.Debug.Log("Native setup success.");
		}
		else
		{
			UnityEngine.Debug.LogError("Native setup failed!");
		}
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
		if (this.isRunning)
		{
			float num = Time.time - this.startTime;
			if (num >= this.frameInterval)
			{
				this.CaptureFrame();
				this.startTime = Time.time;
			}
		}
	}

	private void SetEnvironmentType(QGameKit.Environment environmentType)
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, cann't get setEnvironemtType!");
			return;
		}
		jvalue[] args = AndroidJNIHelper.CreateJNIArgArray(new object[]
		{
			(int)environmentType
		});
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.setEnvironmentTypeMethodID, args);
	}

	public bool IsLiveBroadcastSupported()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, cann't get liveBroadcast support!");
			return false;
		}
		jvalue[] args = new jvalue[0];
		return AndroidJNI.CallBooleanMethod(this.androidBridge, QGameKitAndroidBridge.isLiveBroadcastSupportedMethodID, args);
	}

	private bool setup()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, setup failed!");
			return false;
		}
		QGameKitAndroidBridge.UserAccountCallback userAccountCallback = new QGameKitAndroidBridge.UserAccountCallback(QGameKitAndroidBridge.userAccountDelegate);
		jvalue[] args = AndroidJNIHelper.CreateJNIArgArray(new object[]
		{
			userAccountCallback
		});
		return AndroidJNI.CallBooleanMethod(this.androidBridge, QGameKitAndroidBridge.setupMethodID, args);
	}

	public void TearDown()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, tear down failed!");
			return;
		}
		jvalue[] args = new jvalue[0];
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.tearDownMethodID, args);
	}

	public bool Reset()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, reset failed!");
			return false;
		}
		jvalue[] args = new jvalue[0];
		return AndroidJNI.CallBooleanMethod(this.androidBridge, QGameKitAndroidBridge.resetMethodID, args);
	}

	public bool StartLiveBroadcast(string title, string description)
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("Start Live Broadcast failed because bridge object is null!");
			return false;
		}
		this.nextCaptureTime = 0f;
		jvalue[] array = new jvalue[2];
		array[0].l = AndroidJNI.NewStringUTF(title);
		array[1].l = AndroidJNI.NewStringUTF(description);
		if (AndroidJNI.CallBooleanMethod(this.androidBridge, QGameKitAndroidBridge.startLiveBroadcastMethodID, array))
		{
			UnityEngine.Debug.Log("Start Live Broadcast success");
			this.grabFrameRate = this.GetLiveFrameRate();
			this.frameInterval = 1f / (float)this.grabFrameRate;
			UnityEngine.Debug.Log("--- grabFrameRate = " + this.grabFrameRate);
			UnityEngine.Debug.Log("--- 1.0f / grabFrameRate = " + this.frameInterval);
			return true;
		}
		UnityEngine.Debug.LogError("Native Start Live Broadcast failed!");
		return false;
	}

	public bool StopLiveBroadcast()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, stop liveBroadcast failed!");
			return false;
		}
		jvalue[] args = new jvalue[0];
		return AndroidJNI.CallBooleanMethod(this.androidBridge, QGameKitAndroidBridge.stopLiveBroadcastMethodID, args);
	}

	public void EnterLiveHall()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, enter LiveHall failed!");
			return;
		}
		jvalue[] args = AndroidJNIHelper.CreateJNIArgArray(new object[]
		{
			QGameKitAndroidBridge.getActivityContext()
		});
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.enterLiveHallMethodID, args);
	}

	public void EnterLiveHallInGame()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, enter LiveHallInGame failed!");
			return;
		}
		jvalue[] args = AndroidJNIHelper.CreateJNIArgArray(new object[]
		{
			QGameKitAndroidBridge.getActivityContext()
		});
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.enterLiveHallInGameMethodID, args);
	}

	public void UpdateUserAccount(QGameKit.UserAccount account)
	{
		if (this.androidBridge == IntPtr.Zero || account == null)
		{
			UnityEngine.Debug.LogError("Update user account failed because bridge object or account is null!");
			return;
		}
		jvalue[] array = new jvalue[4];
		int i = 0;
		if (account.platform == QGameKit.LoginPlatform.QQ)
		{
			i = 1;
		}
		else if (account.platform == QGameKit.LoginPlatform.WeChat)
		{
			i = 2;
		}
		array[0].i = i;
		array[1].l = AndroidJNI.NewStringUTF(account.appId);
		array[2].l = AndroidJNI.NewStringUTF(account.id);
		array[3].l = AndroidJNI.NewStringUTF(account.token);
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.updateUserAccountMethodID, array);
	}

	public void UpdateUserAccount()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, UpdateUserAccount down failed!");
			return;
		}
		jvalue[] args = new jvalue[0];
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.notifyUserAccountMethodID, args);
	}

	public void CaptureFrame()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, captureFrame failed!");
			return;
		}
		base.StartCoroutine(this.CaptureScreen());
	}

	[DebuggerHidden]
	private IEnumerator CaptureScreen()
	{
		QGameKitAndroidBridge.<CaptureScreen>c__Iterator12 <CaptureScreen>c__Iterator = new QGameKitAndroidBridge.<CaptureScreen>c__Iterator12();
		<CaptureScreen>c__Iterator.<>f__this = this;
		return <CaptureScreen>c__Iterator;
	}

	private static AndroidJavaObject getActivityContext()
	{
		if (QGameKitAndroidBridge.playerActivityContext == null)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			if (androidJavaClass == null)
			{
				UnityEngine.Debug.LogError("Get UnityPlayer Class failed");
				return null;
			}
			QGameKitAndroidBridge.playerActivityContext = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			if (QGameKitAndroidBridge.playerActivityContext == null)
			{
				UnityEngine.Debug.LogError("get context failed");
				return null;
			}
		}
		return QGameKitAndroidBridge.playerActivityContext;
	}

	public void SetUserAccountDelegate(QGameKit.UserAccountDelegate accountDelegate)
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, setUserAccountDelegate failed!");
			return;
		}
		QGameKitAndroidBridge.UserAccountCallback userAccountCallback = new QGameKitAndroidBridge.UserAccountCallback(accountDelegate);
		jvalue[] args = AndroidJNIHelper.CreateJNIArgArray(new object[]
		{
			userAccountCallback
		});
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.setUserAccountListenerMethodID, args);
	}

	public QGameKit.LiveStatus GetLiveBroadcastStatus()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, cann't getLiveBroadcastStatus!");
			return QGameKit.LiveStatus.Unknown;
		}
		jvalue[] args = new jvalue[0];
		int id = AndroidJNI.CallIntMethod(this.androidBridge, QGameKitAndroidBridge.getLiveBroadcastStatusMethodID, args);
		return this.getStateById(id);
	}

	public int GetErrorCode()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, getErrorCode failed!");
			return 0;
		}
		jvalue[] args = new jvalue[0];
		return AndroidJNI.CallIntMethod(this.androidBridge, QGameKitAndroidBridge.getErrorCodeMethodID, args);
	}

	public void SetCommentReceiveDelegete(QGameKit.CommentReceiveDelegate commentDelegate)
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, setCommentReceiveDelegate failed!");
			return;
		}
		QGameKitAndroidBridge.CommentReceiveCallback commentReceiveCallback = new QGameKitAndroidBridge.CommentReceiveCallback(commentDelegate);
		jvalue[] args = AndroidJNIHelper.CreateJNIArgArray(new object[]
		{
			commentReceiveCallback
		});
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.setCommentReceiveDelegateMethodID, args);
	}

	public void SetLogDelegate(QGameKit.LogDelegate logDelegate)
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, setLogDelegate failed!");
			return;
		}
		QGameKitAndroidBridge.LogCallback logCallback = new QGameKitAndroidBridge.LogCallback(logDelegate);
		jvalue[] args = AndroidJNIHelper.CreateJNIArgArray(new object[]
		{
			logCallback
		});
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.setLogDelegateMethodID, args);
	}

	public void SetLiveStatusChangedDelegate(QGameKit.LiveStatusChangedDelegate liveDelegate)
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, setLiveStatusChangedDelegate failed!");
			return;
		}
		QGameKitAndroidBridge.LiveStatusChangedCallback liveStatusChangedCallback = new QGameKitAndroidBridge.LiveStatusChangedCallback(this, liveDelegate);
		jvalue[] args = AndroidJNIHelper.CreateJNIArgArray(new object[]
		{
			liveStatusChangedCallback
		});
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.setLiveStatusChangedDelegateMethodID, args);
	}

	public void SetShareDelegate(QGameKit.ShareDelegate shareDelegate)
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, setShareDelegate failed!");
			return;
		}
		QGameKitAndroidBridge.ShareDelegateCallback shareDelegateCallback = new QGameKitAndroidBridge.ShareDelegateCallback(shareDelegate);
		jvalue[] args = AndroidJNIHelper.CreateJNIArgArray(new object[]
		{
			shareDelegateCallback
		});
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.setShareListenerMethodID, args);
	}

	public void SetErrorCodeDelegate(QGameKit.ErrorCodeListenerDelegate errorDelegate)
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, setErrorCodeDelegate failed!");
			return;
		}
		QGameKitAndroidBridge.ErrorCodeCallback errorCodeCallback = new QGameKitAndroidBridge.ErrorCodeCallback(errorDelegate);
		jvalue[] args = AndroidJNIHelper.CreateJNIArgArray(new object[]
		{
			errorCodeCallback
		});
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.setErrorCodeDelegateMethodID, args);
	}

	public void SetWebViewStatusChangedDelegate(QGameKit.WebViewStatusChangedDelegate webviewDelegate)
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, setLiveStatusChangedDelegate failed!");
			return;
		}
		QGameKitAndroidBridge.WebViewStatusChangedCallback webViewStatusChangedCallback = new QGameKitAndroidBridge.WebViewStatusChangedCallback(webviewDelegate);
		jvalue[] args = AndroidJNIHelper.CreateJNIArgArray(new object[]
		{
			webViewStatusChangedCallback
		});
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.setWebViewStatusChangedDelegateMethodID, args);
	}

	public string GetVersionName()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, getVersionName failed!");
			return null;
		}
		jvalue[] args = new jvalue[0];
		return AndroidJNI.CallStringMethod(this.androidBridge, QGameKitAndroidBridge.getVersionNameMethodID, args);
	}

	public void ShareLiveBroadcast()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, ShareLiveBroadcast failed!");
			return;
		}
		jvalue[] args = new jvalue[0];
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.shareLiveBroadcastMethodID, args);
	}

	private int GetLiveFrameRate()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, getLiveFrameRate failed!");
			return 20;
		}
		jvalue[] args = new jvalue[0];
		return AndroidJNI.CallIntMethod(this.androidBridge, QGameKitAndroidBridge.getLiveFrameRateMethodID, args);
	}

	public bool ShowCamera()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, showCamera faile!");
			return false;
		}
		jvalue[] args = new jvalue[0];
		return AndroidJNI.CallBooleanMethod(this.androidBridge, QGameKitAndroidBridge.showCameraMethodID, args);
	}

	public void HideCamera()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, hideCamera failed!");
			return;
		}
		jvalue[] args = new jvalue[0];
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.hideCameraMethodID, args);
	}

	public void DoOnCreate()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, onCreate failed!");
			return;
		}
		jvalue[] args = new jvalue[0];
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.doOnCreateMethodID, args);
	}

	public void DoOnResume()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, onResume failed!");
			return;
		}
		jvalue[] args = new jvalue[0];
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.doOnResumeMethodID, args);
	}

	public void DoOnPause()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, onPause failed!");
			return;
		}
		jvalue[] args = new jvalue[0];
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.doOnPauseMethodID, args);
	}

	public void DoOnDestroy()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, onDestory failed!");
			return;
		}
		jvalue[] args = new jvalue[0];
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.doOnDestroyMethodID, args);
	}

	public bool DoOnBackPressed()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, onBackPressed failed!");
			return false;
		}
		jvalue[] args = new jvalue[0];
		return AndroidJNI.CallBooleanMethod(this.androidBridge, QGameKitAndroidBridge.doOnBackPressedMethodID, args);
	}

	public bool IsSupportCamera()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, IsSupportCamera failed!");
			return false;
		}
		jvalue[] args = new jvalue[0];
		return AndroidJNI.CallBooleanMethod(this.androidBridge, QGameKitAndroidBridge.isSupportCameraMethodID, args);
	}

	public bool IsSupportLiveHall()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, IsSupportLiveHall failed!");
			return false;
		}
		jvalue[] args = new jvalue[0];
		return AndroidJNI.CallBooleanMethod(this.androidBridge, QGameKitAndroidBridge.isSupportLiveHallMethodID, args);
	}

	public void SetDanmakuEnabled(bool enable)
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, setDanmakuEnabled failed!");
			return;
		}
		jvalue[] args = AndroidJNIHelper.CreateJNIArgArray(new object[]
		{
			enable
		});
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.setDanmakuEnabledMethodID, args);
	}

	public void ShowDanmaku()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, ShowDanmaku failed!");
			return;
		}
		jvalue[] args = new jvalue[0];
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.showDanmakuMethodID, args);
	}

	public void HideDanmaku()
	{
		if (this.androidBridge == IntPtr.Zero)
		{
			UnityEngine.Debug.LogError("androidBridge is null, HideDanmaku failed!");
			return;
		}
		jvalue[] args = new jvalue[0];
		AndroidJNI.CallVoidMethod(this.androidBridge, QGameKitAndroidBridge.hideDanmakuMethodID, args);
	}

	private void JavaMessage(string message)
	{
		UnityEngine.Debug.Log("message " + message);
	}

	private QGameKit.LiveStatus getStateById(int id)
	{
		switch (id)
		{
		case 1:
			return QGameKit.LiveStatus.Uninitialized;
		case 2:
			return QGameKit.LiveStatus.Prepared;
		case 3:
			return QGameKit.LiveStatus.LiveStarting;
		case 4:
			return QGameKit.LiveStatus.LiveStarted;
		case 5:
			return QGameKit.LiveStatus.LivePaused;
		case 6:
			return QGameKit.LiveStatus.LiveResume;
		case 7:
			return QGameKit.LiveStatus.LiveStopping;
		case 8:
			return QGameKit.LiveStatus.LiveStopped;
		case 9:
			return QGameKit.LiveStatus.Error;
		default:
			return QGameKit.LiveStatus.Unknown;
		}
	}
}
