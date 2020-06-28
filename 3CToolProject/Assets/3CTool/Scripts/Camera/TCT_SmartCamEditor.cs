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

    void SetRelflection(out bool _fixeCam, out float _x)
    {

        _fixeCam = Reflection.Field<bool>(smartCamOption, "fixeCam");

        _x = Reflection.Property<float>(smartCamOption, "X");


    }

    void UpdateReflection(ref bool _fixeCam, ref float _x)
    {
        Reflection.SetField(smartCamOption, "fixeCam", _fixeCam);

        Reflection.SetProperty(smartCamOption, "X", _x);

    }

    public override void OnInspectorGUI()
    {

        SetRelflection(out bool _fixeCam, out float _x);

        _fixeCam = EditorGUILayout.Toggle("FixeCam", _fixeCam);

        _x = EditorGUILayout.Slider("X", _x, -100, 100);

        UpdateReflection(ref _fixeCam, ref _x);

    }



}
