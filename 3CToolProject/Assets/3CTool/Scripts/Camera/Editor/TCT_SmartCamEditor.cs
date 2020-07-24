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
        _smartCamOption = Reflection.Field<SmartCamOption>(eTarget, "smartCamOption");
    }

    void UpdateReflection(ref SmartCamOption _smartCamOption)
    {
        eTarget.SmartCamOption = _smartCamOption;
    }

    public override void OnInspectorGUI()
    {
        UtilityEditor.VersioningTool("TCT", 0, 1, 0, 0);
        
        EditorLayout.Space(2);

        EditorReflectionLayout.Toggle(smartCamOption, "fixeCam", "FixeCam");

        EditorLayout.Space();

        EditorReflectionLayout.Slider(smartCamOption, "x", "X", -100f, 100f);
        EditorReflectionLayout.Slider(smartCamOption, "y", "Y", -100f, 100f);
        EditorReflectionLayout.Slider(smartCamOption, "z", "Z", -100f, 100f);

        EditorLayout.Space(2);

        EditorReflectionLayout.EnumPopup<TypeSmartCam>(eTarget, "typeSmartCam", "TYPE SMART CAM");

        EditorLayout.Space();

        switch (Reflection.Field<TypeSmartCam>(eTarget, "typeSmartCam"))
        {
            case TypeSmartCam.FPS:
            case TypeSmartCam.TPS:
                EditorReflectionLayout.Slider(smartCamOption, "lerp", "Lerp", 0f, 1f);
                break;

            case TypeSmartCam.FIXE:
            case TypeSmartCam.NONE:

                break;
        }




        UpdateReflection(ref smartCamOption);

    }



}
