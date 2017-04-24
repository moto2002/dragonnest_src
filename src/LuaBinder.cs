using System;
using System.Collections.Generic;

public static class LuaBinder
{
	public static List<string> wrapList = new List<string>();

	public static void Bind(IntPtr L, string type = null)
	{
		if (type == null || LuaBinder.wrapList.Contains(type))
		{
			return;
		}
		LuaBinder.wrapList.Add(type);
		type += "Wrap";
		string text = type;
		switch (text)
		{
		case "AnimationBlendModeWrap":
			AnimationBlendModeWrap.Register(L);
			break;
		case "AnimationClipWrap":
			AnimationClipWrap.Register(L);
			break;
		case "AnimationStateWrap":
			AnimationStateWrap.Register(L);
			break;
		case "AnimationWrap":
			AnimationWrap.Register(L);
			break;
		case "AppConstWrap":
			AppConstWrap.Register(L);
			break;
		case "ApplicationWrap":
			ApplicationWrap.Register(L);
			break;
		case "AssetBundleWrap":
			AssetBundleWrap.Register(L);
			break;
		case "AsyncOperationWrap":
			AsyncOperationWrap.Register(L);
			break;
		case "BehaviourWrap":
			BehaviourWrap.Register(L);
			break;
		case "BlendWeightsWrap":
			BlendWeightsWrap.Register(L);
			break;
		case "BoxColliderWrap":
			BoxColliderWrap.Register(L);
			break;
		case "CameraWrap":
			CameraWrap.Register(L);
			break;
		case "CharacterControllerWrap":
			CharacterControllerWrap.Register(L);
			break;
		case "ColliderWrap":
			ColliderWrap.Register(L);
			break;
		case "ComponentWrap":
			ComponentWrap.Register(L);
			break;
		case "DebuggerWrap":
			DebuggerWrap.Register(L);
			break;
		case "DelegateFactoryWrap":
			DelegateFactoryWrap.Register(L);
			break;
		case "DelegateWrap":
			DelegateWrap.Register(L);
			break;
		case "DelManagerWrap":
			DelManagerWrap.Register(L);
			break;
		case "EnumWrap":
			EnumWrap.Register(L);
			break;
		case "EventDelegateWrap":
			EventDelegateWrap.Register(L);
			break;
		case "GameObjectWrap":
			GameObjectWrap.Register(L);
			break;
		case "HotfixManagerWrap":
			HotfixManagerWrap.Register(L);
			break;
		case "HotfixWrap":
			HotfixWrap.Register(L);
			break;
		case "IEnumeratorWrap":
			IEnumeratorWrap.Register(L);
			break;
		case "InputWrap":
			InputWrap.Register(L);
			break;
		case "KeyCodeWrap":
			KeyCodeWrap.Register(L);
			break;
		case "LocalizationWrap":
			LocalizationWrap.Register(L);
			break;
		case "LuaDlgWrap":
			LuaDlgWrap.Register(L);
			break;
		case "LuaEngineWrap":
			LuaEngineWrap.Register(L);
			break;
		case "LuaEnumTypeWrap":
			LuaEnumTypeWrap.Register(L);
			break;
		case "LuaGameInfoWrap":
			LuaGameInfoWrap.Register(L);
			break;
		case "LuaStringBufferWrap":
			LuaStringBufferWrap.Register(L);
			break;
		case "LuaUIManagerWrap":
			LuaUIManagerWrap.Register(L);
			break;
		case "MaterialWrap":
			MaterialWrap.Register(L);
			break;
		case "MeshColliderWrap":
			MeshColliderWrap.Register(L);
			break;
		case "MeshRendererWrap":
			MeshRendererWrap.Register(L);
			break;
		case "MonoBehaviourWrap":
			MonoBehaviourWrap.Register(L);
			break;
		case "NGUIToolsWrap":
			NGUIToolsWrap.Register(L);
			break;
		case "ObjectWrap":
			ObjectWrap.Register(L);
			break;
		case "ParticleSystemWrap":
			ParticleSystemWrap.Register(L);
			break;
		case "PhysicsWrap":
			PhysicsWrap.Register(L);
			break;
		case "PrivateExtensionsWrap":
			PrivateExtensionsWrap.Register(L);
			break;
		case "PublicExtensionsWrap":
			PublicExtensionsWrap.Register(L);
			break;
		case "RendererWrap":
			RendererWrap.Register(L);
			break;
		case "RenderSettingsWrap":
			RenderSettingsWrap.Register(L);
			break;
		case "RenderTextureWrap":
			RenderTextureWrap.Register(L);
			break;
		case "ScreenWrap":
			ScreenWrap.Register(L);
			break;
		case "SkinnedMeshRendererWrap":
			SkinnedMeshRendererWrap.Register(L);
			break;
		case "SleepTimeoutWrap":
			SleepTimeoutWrap.Register(L);
			break;
		case "SphereColliderWrap":
			SphereColliderWrap.Register(L);
			break;
		case "stringWrap":
			stringWrap.Register(L);
			break;
		case "System_IO_BinaryReaderWrap":
			System_IO_BinaryReaderWrap.Register(L);
			break;
		case "System_ObjectWrap":
			System_ObjectWrap.Register(L);
			break;
		case "TestProtolWrap":
			TestProtolWrap.Register(L);
			break;
		case "TextureWrap":
			TextureWrap.Register(L);
			break;
		case "TimeWrap":
			TimeWrap.Register(L);
			break;
		case "TouchPhaseWrap":
			TouchPhaseWrap.Register(L);
			break;
		case "TransformWrap":
			TransformWrap.Register(L);
			break;
		case "TweenPositionWrap":
			TweenPositionWrap.Register(L);
			break;
		case "TweenRotationWrap":
			TweenRotationWrap.Register(L);
			break;
		case "TweenScaleWrap":
			TweenScaleWrap.Register(L);
			break;
		case "TweenWidthWrap":
			TweenWidthWrap.Register(L);
			break;
		case "TypeWrap":
			TypeWrap.Register(L);
			break;
		case "UIAtlasWrap":
			UIAtlasWrap.Register(L);
			break;
		case "UIButtonColorWrap":
			UIButtonColorWrap.Register(L);
			break;
		case "UIButtonWrap":
			UIButtonWrap.Register(L);
			break;
		case "UICameraWrap":
			UICameraWrap.Register(L);
			break;
		case "UICenterOnChildWrap":
			UICenterOnChildWrap.Register(L);
			break;
		case "UIDummyWrap":
			UIDummyWrap.Register(L);
			break;
		case "UIEventListenerWrap":
			UIEventListenerWrap.Register(L);
			break;
		case "UIGridWrap":
			UIGridWrap.Register(L);
			break;
		case "UIInputWrap":
			UIInputWrap.Register(L);
			break;
		case "UILabelWrap":
			UILabelWrap.Register(L);
			break;
		case "UIPlayTweenWrap":
			UIPlayTweenWrap.Register(L);
			break;
		case "UIProgressBarWrap":
			UIProgressBarWrap.Register(L);
			break;
		case "UIRectWrap":
			UIRectWrap.Register(L);
			break;
		case "UIScrollViewWrap":
			UIScrollViewWrap.Register(L);
			break;
		case "UISliderWrap":
			UISliderWrap.Register(L);
			break;
		case "UISpriteWrap":
			UISpriteWrap.Register(L);
			break;
		case "UITableWrap":
			UITableWrap.Register(L);
			break;
		case "UITextureWrap":
			UITextureWrap.Register(L);
			break;
		case "UIToggleWrap":
			UIToggleWrap.Register(L);
			break;
		case "UITweenerWrap":
			UITweenerWrap.Register(L);
			break;
		case "UIWidgetContainerWrap":
			UIWidgetContainerWrap.Register(L);
			break;
		case "UIWidgetWrap":
			UIWidgetWrap.Register(L);
			break;
		case "UtilWrap":
			UtilWrap.Register(L);
			break;
		case "WWWWrap":
			WWWWrap.Register(L);
			break;
		case "XUtliPoolLib_XLuaLongWrap":
			XUtliPoolLib_XLuaLongWrap.Register(L);
			break;
		}
	}
}
