using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.tencent.pandora
{
	internal class LogConsole : MonoBehaviour, ILogRecorder
	{
		private const int LOG_MAX_COUNT = 100;

		private const int OFFSET = 10;

		private static readonly Dictionary<Logger.Level, Color> LOG_TYPE_COLOR_DICT = new Dictionary<Logger.Level, Color>
		{
			{
				Logger.Level.Debug,
				Color.white
			},
			{
				Logger.Level.Info,
				Color.white
			},
			{
				Logger.Level.Warning,
				Color.yellow
			},
			{
				Logger.Level.Error,
				Color.red
			}
		};

		private bool _visible;

		private Vector2 _logListScrollPosition;

		private Vector2 _selectedScrollPosition;

		private Rect _windowRect;

		private bool _showDebug = true;

		private bool _showInfo = true;

		private bool _showWarning = true;

		private bool _showError = true;

		private List<Log> _logList;

		private Log _selectedLog;

		protected void Awake()
		{
			this._windowRect = new Rect(10f, 10f, (float)(Screen.width - 20), (float)(Screen.height - 20));
			this._logList = new List<Log>(100);
		}

		protected void OnGUI()
		{
			if (!this._visible)
			{
				if (GUILayout.Button("显示Pandora LogGUI", new GUILayoutOption[0]))
				{
					this._visible = true;
				}
				return;
			}
			GUI.skin.button.alignment = TextAnchor.MiddleLeft;
			this._windowRect = GUILayout.Window(2147483647, this._windowRect, new GUI.WindowFunction(this.DrawWindowContent), "Console(点击键盘左上角`键关闭或显示，发生错误时强制显示)", new GUILayoutOption[0]);
			GUI.skin.button.alignment = TextAnchor.MiddleCenter;
		}

		private void DrawWindowContent(int windowId)
		{
			GUI.skin.button.alignment = TextAnchor.MiddleLeft;
			this.DrawLogList();
			this.DrawSelectedLog();
			GUI.skin.button.alignment = TextAnchor.MiddleCenter;
			this.DrawLogSetting();
		}

		private void DrawLogList()
		{
			this._logListScrollPosition = GUILayout.BeginScrollView(this._logListScrollPosition, new GUILayoutOption[]
			{
				GUILayout.Height((float)Screen.height * 0.6f)
			});
			for (int i = 0; i < this._logList.Count; i++)
			{
				Log selectedLog = this._logList[i];
				if (this._showDebug || selectedLog.level != Logger.Level.Debug)
				{
					if (this._showInfo || selectedLog.level != Logger.Level.Info)
					{
						if (this._showWarning || selectedLog.level != Logger.Level.Warning)
						{
							if (this._showError || selectedLog.level != Logger.Level.Error)
							{
								GUI.contentColor = LogConsole.LOG_TYPE_COLOR_DICT[selectedLog.level];
								int length = selectedLog.message.Length;
								string text = selectedLog.message.Substring(0, Mathf.Min(200, length));
								if (GUILayout.Button(text, new GUILayoutOption[0]))
								{
									this._selectedLog = selectedLog;
								}
							}
						}
					}
				}
			}
			GUILayout.EndScrollView();
			GUI.contentColor = Color.white;
		}

		private void DrawSelectedLog()
		{
			this._selectedScrollPosition = GUILayout.BeginScrollView(this._selectedScrollPosition, new GUILayoutOption[0]);
			GUI.contentColor = LogConsole.LOG_TYPE_COLOR_DICT[this._selectedLog.level];
			GUILayout.Label(this._selectedLog.message + "\n" + this._selectedLog.stackTrace, new GUILayoutOption[0]);
			GUI.contentColor = Color.white;
			GUILayout.EndScrollView();
		}

		private void DrawLogSetting()
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("Log选项：", new GUILayoutOption[0]);
			this._showDebug = GUILayout.Toggle(this._showInfo, "显示Debug", new GUILayoutOption[0]);
			this._showInfo = GUILayout.Toggle(this._showInfo, "显示Info", new GUILayoutOption[0]);
			this._showWarning = GUILayout.Toggle(this._showWarning, "显示警告", new GUILayoutOption[0]);
			this._showError = GUILayout.Toggle(this._showError, "显示错误", new GUILayoutOption[0]);
			if (GUILayout.Button("清空缓存", new GUILayoutOption[0]))
			{
				LocalDirectoryHelper.Clean();
			}
			if (GUILayout.Button("清空所有Log", new GUILayoutOption[0]))
			{
				this._logList.Clear();
				this._selectedLog = default(Log);
			}
			if (GUILayout.Button("关闭LogGUI", new GUILayoutOption[0]))
			{
				this._visible = false;
			}
			GUILayout.EndHorizontal();
		}

		public void Add(Log log)
		{
			if (this._logList.Count >= 100)
			{
				this._logList.RemoveAt(0);
			}
			this._logList.Add(log);
		}

		public void Dispose()
		{
			this._logList.Clear();
		}
	}
}
