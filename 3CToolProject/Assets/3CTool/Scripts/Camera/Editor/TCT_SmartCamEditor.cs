using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ReflectionLib;
using Unitility;

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
        eTarget.SmartCamOption = _smartCamOption;
    }

    public override void OnInspectorGUI()
    {
       EditorReflectionLayout.Toggle(smartCamOption, "fixeCam", "FixeCam");


        EditorReflectionLayout.Slider(smartCamOption, "x", "X", -100, 100);
        EditorReflectionLayout.Slider(smartCamOption, "y", "Y", -100, 100);
        EditorReflectionLayout.Slider(smartCamOption, "z", "Z", -100, 100);

        //_x = EditorGUILayout.Slider("X", _x, -100, 100);
        //_y = EditorGUILayout.Slider("Y", _y, -100, 100);
        //_z = EditorGUILayout.Slider("Z", _z, -100, 100);

        UpdateReflection(ref smartCamOption);

    }



}
