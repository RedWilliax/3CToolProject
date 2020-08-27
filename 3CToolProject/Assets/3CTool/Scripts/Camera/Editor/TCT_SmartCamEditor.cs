using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using ReflectionLib;
using Unitility.Editor;

[CustomEditor(typeof(TCT_SmartCam))]
public class TCT_SmartCamEditor : EditorCustom<TCT_SmartCam>
{
    SmartCamOption smartCamOption;

    List<ITargetSC> allCharacter;

    int currentIDTarget = 0;

    protected override void OnEnable()
    {
        base.OnEnable();

        SetReflection(out smartCamOption);

        allCharacter = TCT_MenuTool.GetAllCharacters();

        SetIDTarget();
    }

    void SetReflection(out SmartCamOption _smartCamOption)
    {
        _smartCamOption = Reflection.Field<SmartCamOption>(eTarget, "smartCamOption");
    }

    void SetIDTarget()
    {
        ITargetSC _currentTarget = Reflection.Field<ITargetSC>(smartCamOption, "target");

        if (_currentTarget == null || allCharacter.Count < 1)
            return;

        for (int i = 0; i < allCharacter.Count; i++)
            if (allCharacter[i].Name == _currentTarget.Name)
                currentIDTarget = i;
    }

    void UpdateReflection(ref SmartCamOption _smartCamOption)
    {
        eTarget.SmartCamOption = _smartCamOption;
    }

    public override void OnInspectorGUI()
    {
        UtilityEditor.VersioningTool("TCT", 0, 1, 0, 0);
        
        EditorLayout.Space(2);

        EditorReflectionLayout.TextField(eTarget, "name", "SmartCam's Name");

        EditorLayout.Space();

        EditorReflectionLayout.EnumPopup<TypeSmartCam>(eTarget, "typeSmartCam", "TYPE SMART CAM");

        if (Reflection.Field<TypeSmartCam>(eTarget, "typeSmartCam") == TypeSmartCam.NONE) return;

        EditorLayout.Space();

        SetTargetSmartCam();

        EditorLayout.Space();

        EditorReflectionLayout.Toggle(smartCamOption, "fixeCam", "FixeCam");

        EditorLayout.Space();

        SetOffSetSmartCam();

        EditorLayout.Space();

        EditorReflectionLayout.Slider(smartCamOption, "lerp", "Lerp", 0f, 1f);

        EditorLayout.Space(2);

        UpdateReflection(ref smartCamOption);

        SceneView.RepaintAll();

    }

    void SetOffSetSmartCam()
    {
        EditorReflectionLayout.Slider(smartCamOption, "x", "X", -100f, 100f);
        EditorReflectionLayout.Slider(smartCamOption, "y", "Y", -100f, 100f);
        EditorReflectionLayout.Slider(smartCamOption, "z", "Z", -100f, 100f);
    }

    void SetTargetSmartCam()
    {
        if (allCharacter.Count < 1) 
        {
            EditorGUILayout.LabelField("No target found");
            return;
        }

        currentIDTarget = EditorGUILayout.Popup("Target", currentIDTarget, allCharacter.Select(n => n.Transform.gameObject.name).ToArray());

        Reflection.SetField(smartCamOption, "target", allCharacter[currentIDTarget]);
    }

}
