using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TCT_MenuTool : MonoBehaviour
{
    [MenuItem("3CTool/SmartCamera/Add SmartCam")]
    static void AddSmartCam()
    {
        GameObject _go = new GameObject($"SmartCam", (typeof(TCT_SmartCam)));

        Selection.activeObject = _go;
    }

    [MenuItem("3CTool/Player/Add Player")]
    static void AddPlayer()
    {


    }

    [MenuItem("3CTool/Input/Add InputManager")]
    static void AddInputManager()
    {


    }

}
