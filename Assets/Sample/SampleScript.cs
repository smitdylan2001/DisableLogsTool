using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScript : MonoBehaviour
{
    public void MakeLog()
    {
        Debug.Log("This is a log");
    }

    public void MakeWarning()
    {
        Debug.LogWarning("This is a warning");
    }

    public void MakeError()
    {
        Debug.LogError("This is an error");
    }

    public void ToggleLogs(bool value)
	{
        Debug.unityLogger.logEnabled = value;
    }

    public void ChangeLogType(int value)
	{
        DisableLogsTool.ChangeMaxLogType((WhatToLog)value);
    }
}
