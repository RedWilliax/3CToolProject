using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ReflectionLib;
using Unitility.Editor;

[CustomEditor(typeof(TCT_Character))]
public class TCT_CharacterEditor : EditorCustom<TCT_Character>
{

    TCT_CharacterComponent currentComponent;

    protected override void OnEnable()
    {
        eTarget = (TCT_Character)target;
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        UtilityEditor.VersioningTool("TCT", 0, 1, 0, 0);

        EditorLayout.Space(2);

        EditorReflectionLayout.TextField(eTarget, "name", "Character Name");

        EditorLayout.Space();

        currentComponent = (TCT_CharacterComponent)EditorGUILayout.ObjectField("Component to Add", currentComponent, typeof(TCT_CharacterComponent), false);

        EditorLayout.Button("Add", eTarget.AddComponent, currentComponent);
            
        

    }

}
