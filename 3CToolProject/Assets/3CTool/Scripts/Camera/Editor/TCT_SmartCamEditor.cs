using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using ReflectionLib;
using Unitility;

[CustomEditor(typeof(TCT_SmartCam))]
public class TCT_SmartCamEditor : EditorCustom<TCT_SmartCam>
{
    SmartCamOption smartCamOption;

    List<TCT_Character> allCharacter;

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
        TCT_Character _currentTarget = Reflection.Field<TCT_Character>(smartCamOption, "target");

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
        if (allCharacter.Count < 1) return;

        currentIDTarget = EditorGUILayout.Popup("Target", currentIDTarget, allCharacter.Select(n => n.Name).ToArray());

        Reflection.SetField(smartCamOption, "target", allCharacter[currentIDTarget]);
    }

}
