using System;

namespace com.tencent.pandora
{
	[LuaBinder(3)]
	public class BindCustom
	{
		public static Action<IntPtr>[] GetBindList()
		{
			return new Action<IntPtr>[]
			{
				new Action<IntPtr>(Lua_System_Collections_Generic_List_1_int.reg),
				new Action<IntPtr>(Lua_System_Collections_Generic_Dictionary_2_int_string.reg),
				new Action<IntPtr>(Lua_System_String.reg),
				new Action<IntPtr>(Lua_com_tencent_pandora_CSharpInterface.reg),
				new Action<IntPtr>(Lua_com_tencent_pandora_Logger.reg),
				new Action<IntPtr>(Lua_UIButtonColor.reg),
				new Action<IntPtr>(Lua_UIButton.reg),
				new Action<IntPtr>(Lua_UIDragScrollView.reg),
				new Action<IntPtr>(Lua_UIEventTrigger.reg),
				new Action<IntPtr>(Lua_UIGrid.reg),
				new Action<IntPtr>(Lua_UIImageButton.reg),
				new Action<IntPtr>(Lua_UIKeyBinding.reg),
				new Action<IntPtr>(Lua_UIPlayAnimation.reg),
				new Action<IntPtr>(Lua_UIPlaySound.reg),
				new Action<IntPtr>(Lua_UIPlayTween.reg),
				new Action<IntPtr>(Lua_UIPopupList.reg),
				new Action<IntPtr>(Lua_UIProgressBar.reg),
				new Action<IntPtr>(Lua_UISlider.reg),
				new Action<IntPtr>(Lua_UIScrollBar.reg),
				new Action<IntPtr>(Lua_UIScrollView.reg),
				new Action<IntPtr>(Lua_UIToggle.reg),
				new Action<IntPtr>(Lua_UIWrapContent.reg),
				new Action<IntPtr>(Lua_AnimatedAlpha.reg),
				new Action<IntPtr>(Lua_AnimatedColor.reg),
				new Action<IntPtr>(Lua_UITweener.reg),
				new Action<IntPtr>(Lua_TweenAlpha.reg),
				new Action<IntPtr>(Lua_TweenColor.reg),
				new Action<IntPtr>(Lua_TweenHeight.reg),
				new Action<IntPtr>(Lua_TweenPosition.reg),
				new Action<IntPtr>(Lua_TweenRotation.reg),
				new Action<IntPtr>(Lua_TweenScale.reg),
				new Action<IntPtr>(Lua_TweenTransform.reg),
				new Action<IntPtr>(Lua_TweenWidth.reg),
				new Action<IntPtr>(Lua_UIAnchor.reg),
				new Action<IntPtr>(Lua_UIAtlas.reg),
				new Action<IntPtr>(Lua_UIFont.reg),
				new Action<IntPtr>(Lua_UIInput.reg),
				new Action<IntPtr>(Lua_UIRect.reg),
				new Action<IntPtr>(Lua_UIWidget.reg),
				new Action<IntPtr>(Lua_UILabel.reg),
				new Action<IntPtr>(Lua_UIPanel.reg),
				new Action<IntPtr>(Lua_UIRoot.reg),
				new Action<IntPtr>(Lua_UISprite.reg),
				new Action<IntPtr>(Lua_UISpriteAnimation.reg),
				new Action<IntPtr>(Lua_UISpriteData.reg),
				new Action<IntPtr>(Lua_UIStretch.reg),
				new Action<IntPtr>(Lua_UITexture.reg),
				new Action<IntPtr>(Lua_EventDelegate.reg),
				new Action<IntPtr>(Lua_UIEventListener.reg)
			};
		}
	}
}
