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
        UtilityEditor.VersioningTool("TCT", 0, 1, 0, 0);
        
        EditorGUILayout.Space();

        EditorReflectionLayout.Toggle(smartCamOption, "fixeCam", "FixeCam");

        EditorGUILayout.Space();

        EditorReflectionLayout.Slider(smartCamOption, "x", "X", -100f, 100f);
        EditorReflectionLayout.Slider(smartCamOption, "y", "Y", -100f, 100f);
        EditorReflectionLayout.Slider(smartCamOption, "z", "Z", -100f, 100f);

        EditorGUILayout.Space();

        EditorReflectionLayout.EnumPopup<TypeSmartCam>(eTarget, "typeSmartCam", "TYPE SMART CAM");

        UpdateReflection(ref smartCamOption);

    }



}
