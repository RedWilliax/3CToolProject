using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public static class TCT_MenuEditor 
{
    [MenuItem("3CTool/Input/InputManager")]
    public static void CreateWindow()
    {
        TCT_MenuTool.VerifyAndAddOnLogic<TCT_ControllerManager>();

        EditorWindow.GetWindow<TCT_ControllerManagerWindow>(false, "Controller Manager 0.1.0.0", true);
    }

}
