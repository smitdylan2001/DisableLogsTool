using UnityEngine;

namespace DevDunk.LogTools
{
	///<summary>
	///Contains all different logs that are supported by the Unity Editor. The selected value will be the max log type which is output
	///</summary>
	public enum WhatToLog
	{
		AllLogs,
		Assert,
		Warnings,
		Errors,
		Exception,
		None
	}

	///<summary>
	///DisableLogsTool is a tool made by Dev Dunk Studio to easily turn on, turn off and manage logs in your projects
	///</summary>
	public class DisableLogsTool : MonoBehaviour
	{
		[Header("Editor Settings")]
		[Tooltip("Disables all logs in the Unity Editor, no matter what is selected in the Max Log Level below")]
		public bool DisableAllLogsInEditor = false;
		[Tooltip("Max allowed log type being used in the Unity Editor. Unity will only log the type selected and those below it!")]
		public WhatToLog MaxLogLevelInEditor;

		[Header("Build Settings")]
		[Tooltip("Disables all logs in builds, no matter what is selected in the Max Log Level below")]
		public bool DisableAllLogsInBuilds = false;
		[Tooltip("Max allowed log type being used in builds. Unity will only log the type selected and those below it!")]
		public WhatToLog MaxLogLevelInBuild;

		private void Awake()
		{
#if UNITY_EDITOR
			Debug.unityLogger.logEnabled = !DisableAllLogsInEditor;
			if (!DisableAllLogsInEditor)
			{
				switch (MaxLogLevelInEditor)
				{
					case WhatToLog.AllLogs:
						Debug.unityLogger.filterLogType = LogType.Log;
						break;
					case WhatToLog.Assert:
						Debug.unityLogger.filterLogType = LogType.Assert;
						break;
					case WhatToLog.Warnings:
						Debug.unityLogger.filterLogType = LogType.Warning;
						break;
					case WhatToLog.Errors:
						Debug.unityLogger.filterLogType = LogType.Error;
						break;
					case WhatToLog.Exception:
						Debug.unityLogger.filterLogType = LogType.Exception;
						break;
					case WhatToLog.None:
						Debug.unityLogger.logEnabled = false;
						break;
				}
			}
#else
        Debug.unityLogger.logEnabled = !DisableAllLogsInBuilds;

		if (!DisableAllLogsInBuilds)
		{
			switch (MaxLogLevelInBuild)
			{
				case WhatToLog.AllLogs:
					Debug.unityLogger.filterLogType = LogType.Log;
					break;
				case WhatToLog.Assert:
					Debug.unityLogger.filterLogType = LogType.Assert;
					break;
				case WhatToLog.Warnings:
					Debug.unityLogger.filterLogType = LogType.Warning;
					break;
				case WhatToLog.Errors:
					Debug.unityLogger.filterLogType = LogType.Error;
					break;
				case WhatToLog.Exception:
					Debug.unityLogger.filterLogType = LogType.Exception;
					break;
			}
		}
#endif
		}

		///<summary>
		///enable all logs
		///</summary>
		/// <param name="onlyInBuild">(optional) If set to true, logs will only be enabled in builds, not in the Unity Editor</param>
		public static void EnableAllLogs(bool onlyInBuild = false)
		{
			if (!onlyInBuild)
			{
				Debug.unityLogger.logEnabled = true;
				Debug.unityLogger.filterLogType = LogType.Log;
			}
#if !UNITY_EDITOR
			Debug.unityLogger.logEnabled = true;
			Debug.unityLogger.filterLogType = LogType.Log;
#endif
		}

		///<summary>
		///Change maximum allowed log type
		///</summary>
		/// <param name="logType">Select what the highest allowed logtype is</param>
		public static void EnableAllLogs(WhatToLog logType)
		{
			Debug.unityLogger.logEnabled = true;

			switch (logType)
			{
				case WhatToLog.AllLogs:
					Debug.unityLogger.filterLogType = LogType.Log;
					break;
				case WhatToLog.Assert:
					Debug.unityLogger.filterLogType = LogType.Assert;
					break;
				case WhatToLog.Warnings:
					Debug.unityLogger.filterLogType = LogType.Warning;
					break;
				case WhatToLog.Errors:
					Debug.unityLogger.filterLogType = LogType.Error;
					break;
				case WhatToLog.Exception:
					Debug.unityLogger.filterLogType = LogType.Exception;
					break;
				case WhatToLog.None:
					Debug.unityLogger.logEnabled = false;
					break;
			}
		}

		///<summary>
		///Disable all logs
		///</summary>
		/// <param name="onlyInBuild">(optional) If set to true, logs will only be disabled in builds, not in the Unity Editor</param>
		public static void DisableAllLogs(bool onlyInBuild = false)
		{
			if (!onlyInBuild) Debug.unityLogger.logEnabled = false;
#if !UNITY_EDITOR
			Debug.unityLogger.logEnabled = false;
#endif
		}

		///<summary>
		///Change maximum allowed log type
		///</summary>
		/// <param name="logType">Select what the highest allowed logtype is</param>
		public static void ChangeMaxLogType(WhatToLog logType)
		{
			Debug.unityLogger.logEnabled = true;
			switch (logType)
			{
				case WhatToLog.AllLogs:
					Debug.unityLogger.filterLogType = LogType.Log;
					break;
				case WhatToLog.Assert:
					Debug.unityLogger.filterLogType = LogType.Assert;
					break;
				case WhatToLog.Warnings:
					Debug.unityLogger.filterLogType = LogType.Warning;
					break;
				case WhatToLog.Errors:
					Debug.unityLogger.filterLogType = LogType.Error;
					break;
				case WhatToLog.Exception:
					Debug.unityLogger.filterLogType = LogType.Exception;
					break;
				case WhatToLog.None:
					Debug.unityLogger.logEnabled = false;
					break;
			}
		}

		///<summary>
		///Turn logs on or off depending on the value given. Use ChangeMaxLogType or EnableAllLogs to change the logtype
		///</summary>
		/// <param name="value">Should the logs be turned off</param>
		public static void ToggleLogs(bool value)
		{
			Debug.unityLogger.logEnabled = value;
		}
	}
}