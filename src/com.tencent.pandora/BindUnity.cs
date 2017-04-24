using System;

namespace com.tencent.pandora
{
	[LuaBinder(0)]
	public class BindUnity
	{
		public static Action<IntPtr>[] GetBindList()
		{
			return new Action<IntPtr>[]
			{
				new Action<IntPtr>(Lua_UnityEngine_Events_UnityEventBase.reg),
				new Action<IntPtr>(Lua_UnityEngine_Events_UnityEvent.reg),
				new Action<IntPtr>(Lua_UnityEngine_Object.reg),
				new Action<IntPtr>(Lua_UnityEngine_GameObject.reg),
				new Action<IntPtr>(Lua_UnityEngine_AssetBundle.reg),
				new Action<IntPtr>(Lua_UnityEngine_SystemInfo.reg),
				new Action<IntPtr>(Lua_UnityEngine_Event.reg),
				new Action<IntPtr>(Lua_UnityEngine_Vector2.reg),
				new Action<IntPtr>(Lua_UnityEngine_Vector3.reg),
				new Action<IntPtr>(Lua_UnityEngine_Color.reg),
				new Action<IntPtr>(Lua_UnityEngine_Color32.reg),
				new Action<IntPtr>(Lua_UnityEngine_Quaternion.reg),
				new Action<IntPtr>(Lua_UnityEngine_Vector4.reg),
				new Action<IntPtr>(Lua_UnityEngine_Component.reg),
				new Action<IntPtr>(Lua_UnityEngine_ParticleSystem.reg),
				new Action<IntPtr>(Lua_UnityEngine_Material.reg),
				new Action<IntPtr>(Lua_UnityEngine_Application.reg),
				new Action<IntPtr>(Lua_UnityEngine_Behaviour.reg),
				new Action<IntPtr>(Lua_UnityEngine_MonoBehaviour.reg),
				new Action<IntPtr>(Lua_UnityEngine_Transform.reg),
				new Action<IntPtr>(Lua_UnityEngine_Time.reg),
				new Action<IntPtr>(Lua_UnityEngine_Random.reg)
			};
		}
	}
}
