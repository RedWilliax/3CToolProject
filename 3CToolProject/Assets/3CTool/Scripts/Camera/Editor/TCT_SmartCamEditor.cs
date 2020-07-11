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

        SetReflection(out smartCamOption);
    }

    void SetReflection(out SmartCamOption _smartCamOption)
    {
        SmartCamOption _smartCamOptionTamp = Reflection.Field<SmartCamOption>(eTarget, "smartCamOption");

        _smartCamOption = _smartCamOptionTamp == null ? new SmartCamOption() : _smartCamOptionTamp;
    }

    void UpdateReflection(ref SmartCamOption _smartCamOption)
    {
        //Reflection.SetField(eTarget, "smartCamOption", _smartCamOption);

        eTarget.SmartCamOption = _smartCamOption;
    }

    public override void OnInspectorGUI()
    {
        bool _fixeCam = Reflection.Field<bool>(smartCamOption, "fixeCam");

        _fixeCam = EditorGUILayout.Toggle("FixeCam", _fixeCam);

        Reflection.SetField(smartCamOption, "fixeCam", _fixeCam);

        //_x = EditorGUILayout.Slider("X", _x, -100, 100);
        //_y = EditorGUILayout.Slider("Y", _y, -100, 100);
        //_z = EditorGUILayout.Slider("Z", _z, -100, 100);

        UpdateReflection(ref smartCamOption);

    }



}
