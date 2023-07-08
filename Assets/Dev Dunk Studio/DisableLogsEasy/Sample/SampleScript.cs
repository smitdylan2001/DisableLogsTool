using UnityEngine;

//Needed to use the Dev Dunk Studio log tools
using DevDunk.LogTools;

namespace DevDunk.Samples
{
    //Sample Script used in the DisableLogsTool Demo Scene
    public class SampleScript : MonoBehaviour
    {
        //Throw a log
        public void MakeLog()
        {
            Debug.Log("This is a log");
        }

        //Throw a warning
        public void MakeWarning()
        {
            Debug.LogWarning("This is a warning");
        }

        //Throw an error
        public void MakeError()
        {
            Debug.LogError("This is an error");
        }

        //Turn logs on or off depending on the value given
        public void ToggleLogs(bool value)
        {
            DisableLogsTool.ToggleLogs(!value);
        }

        //Change log type
        public void ChangeLogType(int value)
        {
            DisableLogsTool.ChangeMaxLogType((WhatToLog)value); //Cast to WhatToLog to convert int to the WhatToLog enum
        }
    }
}