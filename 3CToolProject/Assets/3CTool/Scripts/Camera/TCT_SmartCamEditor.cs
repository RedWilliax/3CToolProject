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

    void SetRelflection(out bool _fixeCam, out float _x, out float _y, out float _z)
    {

        _fixeCam = Reflection.Field<bool>(smartCamOption, "fixeCam");

        _x = Reflection.Property<float>(smartCamOption, "X");

        _y = Reflection.Property<float>(smartCamOption, "Y");

        _z = Reflection.Property<float>(smartCamOption, "Z");
        

    }

    void UpdateReflection(ref bool _fixeCam, ref float _x, ref float _y, ref float _z)
    {
        Reflection.SetField(smartCamOption, "fixeCam", _fixeCam);

        Reflection.SetProperty(smartCamOption, "X", _x);
        Reflection.SetProperty(smartCamOption, "Y", _y);
        Reflection.SetProperty(smartCamOption, "Z", _z);

    }

    public override void OnInspectorGUI()
    {
        SetRelflection(out bool _fixeCam, out float _x, out float _y, out float _z);

        _fixeCam = EditorGUILayout.Toggle("FixeCam", _fixeCam);

        _x = EditorGUILayout.Slider("X", _x, -100, 100);
        _y = EditorGUILayout.Slider("Y", _y, -100, 100);
        _z = EditorGUILayout.Slider("Z", _z, -100, 100);

        UpdateReflection(ref _fixeCam, ref _x, ref _y, ref _z);

    }



}
