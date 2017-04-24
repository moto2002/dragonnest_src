using System;
using UnityEngine;

public class UniWebViewPlugin
{
	private static AndroidJavaClass webView;

	public static void Init(string name, int top, int left, int bottom, int right)
	{
		Debug.Log("Unity Init");
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView = new AndroidJavaClass("com.onevcat.uniwebview.AndroidPlugin");
			UniWebViewPlugin.webView.CallStatic("_UniWebViewInit", new object[]
			{
				name,
				top,
				left,
				bottom,
				right
			});
		}
	}

	public static void ChangeSize(string name, int top, int left, int bottom, int right)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewChangeSize", new object[]
			{
				name,
				top,
				left,
				bottom,
				right
			});
		}
	}

	public static void Load(string name, string url)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewLoad", new object[]
			{
				name,
				url
			});
		}
	}

	public static void LoadHTMLString(string name, string htmlString, string baseUrl)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewLoadHTMLString", new object[]
			{
				name,
				htmlString,
				baseUrl
			});
		}
	}

	public static void Reload(string name)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewReload", new object[]
			{
				name
			});
		}
	}

	public static void Stop(string name)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewStop", new object[]
			{
				name
			});
		}
	}

	public static void EvaluatingJavaScript(string name, string javaScript)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			Debug.Log("calling eval js " + javaScript);
			UniWebViewPlugin.webView.CallStatic("_UniWebViewEvaluatingJavaScript", new object[]
			{
				name,
				javaScript
			});
		}
	}

	public static void AddJavaScript(string name, string javaScript)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			Debug.Log("adding js " + javaScript);
			UniWebViewPlugin.webView.CallStatic("_UniWebViewAddJavaScript", new object[]
			{
				name,
				javaScript
			});
		}
	}

	public static void Show(string name)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewShow", new object[]
			{
				name
			});
		}
	}

	public static void Dismiss(string name)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewDismiss", new object[]
			{
				name
			});
		}
	}

	public static void CleanCache(string name)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewCleanCache", new object[]
			{
				name
			});
		}
	}

	public static void CleanCookie(string name, string key)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewCleanCookie", new object[]
			{
				name,
				key
			});
		}
	}

	public static void Destroy(string name)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewDestroy", new object[]
			{
				name
			});
		}
	}

	public static void SetSpinnerShowWhenLoading(string name, bool show)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewSetSpinnerShowWhenLoading", new object[]
			{
				name,
				show
			});
		}
	}

	public static void SetSpinnerText(string name, string text)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewSetSpinnerText", new object[]
			{
				name,
				text
			});
		}
	}

	public static void TransparentBackground(string name, bool transparent)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewTransparentBackground", new object[]
			{
				name,
				transparent
			});
		}
	}

	public static void GoBack(string name)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewGoBack", new object[]
			{
				name
			});
		}
	}

	public static void GoForward(string name)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewGoForward", new object[]
			{
				name
			});
		}
	}

	public static string GetCurrentUrl(string name)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			return UniWebViewPlugin.webView.CallStatic<string>("_UniWebViewGetCurrentUrl", new object[]
			{
				name
			});
		}
		return string.Empty;
	}

	public static void SetBackButtonEnable(string name, bool enable)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewSetBackButtonEnable", new object[]
			{
				name,
				enable
			});
		}
	}

	public static void SetBounces(string name, bool enable)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewSetBounces", new object[]
			{
				name,
				enable
			});
		}
	}

	public static void SetZoomEnable(string name, bool enable)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewSetZoomEnable", new object[]
			{
				name,
				enable
			});
		}
	}

	public static void AddUrlScheme(string name, string scheme)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewAddUrlScheme", new object[]
			{
				name,
				scheme
			});
		}
	}

	public static void RemoveUrlScheme(string name, string scheme)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewRemoveUrlScheme", new object[]
			{
				name,
				scheme
			});
		}
	}

	public static void SetUseWideViewPort(string name, bool use)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewUseWideViewPort", new object[]
			{
				name,
				use
			});
		}
	}

	public static void SetUserAgent(string userAgent)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			UniWebViewPlugin.webView.CallStatic("_UniWebViewSetUserAgent", new object[]
			{
				userAgent
			});
		}
	}

	public static string GetUserAgent(string name)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			return UniWebViewPlugin.webView.CallStatic<string>("_UniWebViewGetUserAgent", new object[]
			{
				name
			});
		}
		return string.Empty;
	}
}
