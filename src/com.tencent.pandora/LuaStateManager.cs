using System;
using System.Collections.Generic;

namespace com.tencent.pandora
{
	internal class LuaStateManager
	{
		private static LuaSvr _luaSvr;

		private static bool _isInitialized;

		private static HashSet<string> _executingLuaGroupSet = new HashSet<string>();

		public static bool IsInitialized
		{
			get
			{
				return LuaStateManager._isInitialized;
			}
		}

		public static void Initialize()
		{
			LuaStateManager._luaSvr = new LuaSvr(1);
			LuaStateManager._luaSvr.init(null, new Action(LuaStateManager.OnComplete), LuaSvrFlag.LSF_EXTLIB);
		}

		private static void OnComplete()
		{
			LuaState.loaderDelegate = new LuaState.LoaderDelegate(AssetManager.GetLuaBytes);
			if (PandoraSettings.IsProductEnvironment)
			{
				LuaState.errorDelegate = new LuaState.OutputDelegate(LuaStateManager.ReportLuaError);
			}
			LuaStateManager._isInitialized = true;
			Logger.LogInfo("Lua虚拟机初始化成功");
		}

		private static void ReportLuaError(string error)
		{
			Pandora.Instance.ReportError(error, 10217593);
			Pandora.Instance.Report(error, 10217603, 2);
		}

		public static void Reset()
		{
			LuaStateManager._isInitialized = false;
			LuaStateManager._executingLuaGroupSet.Clear();
			if (LuaStateManager._luaSvr != null)
			{
				LuaStateManager._luaSvr.reset(null, new Action(LuaStateManager.OnComplete), LuaSvrFlag.LSF_EXTLIB);
			}
		}

		public static object DoFile(string fileName)
		{
			byte[] luaBytes = AssetManager.GetLuaBytes(fileName);
			return LuaStateManager.DoBuffer(luaBytes, fileName);
		}

		public static object DoBuffer(byte[] bytes, string fileName)
		{
			if (bytes == null || bytes.Length == 0)
			{
				Logger.LogError("没有找到Lua文件： " + fileName);
				return null;
			}
			object result;
			if (LuaStateManager._luaSvr.luaState[0].doBuffer(bytes, fileName, out result))
			{
				return result;
			}
			return null;
		}

		public static bool IsGroupLuaExecuting(string group)
		{
			return LuaStateManager._executingLuaGroupSet.Contains(group);
		}

		public static void DoLuaFileInFileInfoList(string group, List<RemoteConfig.AssetInfo> fileInfoList)
		{
			if (LuaStateManager._executingLuaGroupSet.Contains(group))
			{
				string text = "资源组 " + group + " 中的Lua文件正在运行中~";
				Logger.LogError(text);
				Pandora.Instance.ReportError(text, 0);
				return;
			}
			LuaStateManager._executingLuaGroupSet.Add(group);
			for (int i = 0; i < fileInfoList.Count; i++)
			{
				string name = fileInfoList[i].name;
				if (name.ToLower().Contains("_lua.assetbundle"))
				{
					string luaName = LuaStateManager.GetLuaName(name);
					string message = "资源组加载完成，开始执行入口Lua文件： " + luaName;
					Logger.Log(message);
					try
					{
						LuaStateManager.DoFile(luaName);
					}
					catch (Exception var_5_90)
					{
						string text2 = "Lua DoFile 失败， FileName: " + luaName;
						Pandora.Instance.ReportError(text2, 10217594);
						Pandora.Instance.Report(text2, 10217603, 2);
					}
				}
			}
			if (LuaStateManager._executingLuaGroupSet.Count == 1)
			{
				string error = "执行Lua了";
				Pandora.Instance.ReportError(error, 10217595);
			}
		}

		private static string GetLuaName(string name)
		{
			return name.Split(new char[]
			{
				'_'
			})[1];
		}

		public static object CallLuaFunction(string functionName, params object[] args)
		{
			LuaFunction luaFunction = (LuaFunction)LuaStateManager._luaSvr.luaState[0][functionName];
			if (luaFunction != null)
			{
				return luaFunction.call(args);
			}
			return null;
		}

		public static void ReloadLua()
		{
		}
	}
}
