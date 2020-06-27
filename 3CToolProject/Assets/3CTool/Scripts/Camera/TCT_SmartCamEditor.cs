using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unitility;
using ReflectionLib;

[CustomEditor(typeof(TCT_SmartCam))]
public class TCT_SmartCamEditor : EditorCustom<TCT_SmartCam>
{
    SmartCamOption smartCamOption;

    protected override void OnEnable()
    {
        base.OnEnable();

        smartCamOption = Reflection.Field<SmartCamOption>(eTarget, "smartCamOption");
    }

    void SetRelflection(out bool _fixeCam)
    {

        _fixeCam = Reflection.Field<bool>(smartCamOption, "fixeCam");


    }

    void UpdateReflection(ref bool _fixeCam)
    {
        Reflection.SetField(smartCamOption, "fixeCam", _fixeCam);

    }

    public override void OnInspectorGUI()
    {

        SetRelflection(out bool _fixeCam);

        _fixeCam = EditorGUILayout.Toggle("FixeCam", _fixeCam);

        UpdateReflection(ref _fixeCam);

    }



}
