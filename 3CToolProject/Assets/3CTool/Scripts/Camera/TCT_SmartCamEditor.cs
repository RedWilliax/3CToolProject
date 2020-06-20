using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unitility;

[CustomEditor(typeof(TCT_SmartCam))]
public class TCT_SmartCamEditor : EditorCustom<TCT_SmartCam>
{
    bool _fixeCame = false;

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnInspectorGUI()
    {

        _fixeCame = GUILayout.Toggle(_fixeCame, "Fixe Came");




    }



}
