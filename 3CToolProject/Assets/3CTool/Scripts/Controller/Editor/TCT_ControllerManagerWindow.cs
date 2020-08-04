using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using Unitility;

public class TCT_ControllerManagerWindow : EditorWindow
{

    [SerializeField] List<TCT_ActionInput> AllActionInput = new List<TCT_ActionInput>();

    [SerializeField] List<TCT_AxisInput> AllAxisInput = new List<TCT_AxisInput>();

    bool showActionInput = false;


    private void OnGUI()
    {

        //GUILayout.BeginArea(new Rect(10, 10, position.width * 0.15f, position.height));

        GUILayout.BeginHorizontal();

        EditorLayout.Button("Add ActionInput", CreateNewActionInput);

        EditorLayout.Button("Add AxisInput", CreateNewAxisInput);

        GUILayout.EndHorizontal();

        EditorLayout.Space();

        showActionInput = EditorGUILayout.Foldout(showActionInput, "Actions Input");

        DrawAllActionInput(showActionInput);




        //GUILayout.EndArea();

    }

    void DrawAllActionInput(bool _show)
    {
        if (!_show) return;

        for (int i = 0; i < AllActionInput.Count; i++)
        {
            bool _showInputs = true;

            GUILayout.BeginHorizontal();

            _showInputs = EditorGUILayout.Foldout(_showInputs, "");

            EditorGUILayout.TextField(AllActionInput[i].name, GUILayout.MaxWidth(200));

            EditorLayout.Button("+", AllActionInput[i].AddKey, KeyCode.A);

            //DrawKeysActionInput(_showInputs, AllActionInput[i]);

            GUILayout.EndHorizontal();

            EditorLayout.Space();
        }
    }

    void DrawKeysActionInput(bool _show, TCT_ActionInput _action)
    {

        if (_action == null || _action.AllKeyCodes.Count < 1) return;

        for (int i = 0; i < _action.AllKeyCodes.Count; i++)
        {
            EditorGUILayout.TextField(_action.AllKeyCodes[i].ToString());

            EditorLayout.Space();
        }

    }

    void CreateNewActionInput()
    {
        AllActionInput.Add(new TCT_ActionInput());
    }

    void CreateNewAxisInput()
    {


    }

}
