using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEditor;

using Unitility;

public class TCT_ControllerManagerWindow : EditorWindow
{

    bool showActionInput = false;

    bool showAxisInput = false;

    Vector2 scroll = new Vector2();

    private void OnGUI()
    {
        //GUILayout.BeginArea(new Rect(10, 10, position.width * 0.15f, position.height));

        scroll = GUILayout.BeginScrollView(scroll);

        GUILayout.BeginHorizontal();

        EditorLayout.Button("Add ActionInput", CreateActionInput);

        EditorLayout.Button("Add AxisInput", CreateAxisInput);

        GUILayout.EndHorizontal();

        EditorLayout.Space();

        showActionInput = EditorGUILayout.Foldout(showActionInput, "Actions Input");
        DrawAllActionInput(showActionInput);

        EditorLayout.Space();

        showAxisInput = EditorGUILayout.Foldout(showAxisInput, "Axis Input");
        DrawAllAxisInput(showAxisInput);

        GUILayout.EndScrollView();

    }

    #region ActionInput

    void DrawAllActionInput(bool _show)
    {
        if (!_show || TCT_ControllerManager.allActionInput.Count < 1) return;

        for (int i = 0; i < TCT_ControllerManager.allActionInput.Count; i++)
        {
            bool _showInputs = TCT_ControllerManager.allActionInput[i].editorUtility.show;

            GUILayout.BeginHorizontal();

            EditorGUILayout.Separator();

            TCT_ControllerManager.allActionInput[i].editorUtility.show = EditorGUILayout.Foldout(_showInputs, TCT_ControllerManager.allActionInput[i].name);

            EditorLayout.Button("...", RenameActionInput, TCT_ControllerManager.allActionInput[i]);

            EditorLayout.Button("+", AddKeyInAction, TCT_ControllerManager.allActionInput[i], KeyCode.None);

            EditorLayout.Button("x", RemoveActionInput, TCT_ControllerManager.allActionInput[i]);

            GUILayout.EndHorizontal();

            EditorLayout.Space();

            if (TCT_ControllerManager.allActionInput.Count < 1) return;

            DrawKeysActionInput(_showInputs, TCT_ControllerManager.allActionInput[i]);

            EditorLayout.Space();
        }
    }

    void AddKeyInAction(TCT_ActionInput _action, KeyCode _key)
    {
        if (_action.AllKeyCodes.Any(n => n == KeyCode.None))
        {
            Debug.LogWarning("A key is not assign. Please assign it to get an other key");
            return;
        }

        _action.AddKey(_key);
    }
    public void RemoveActionInput(TCT_ActionInput _action)
    {
        TCT_ControllerManager.allActionInput.Remove(_action);
    }

    void RenameActionInput(TCT_ActionInput _action)
    {

        GetWindow<TCT_RenameWindow>(true, "Rename AcitonInput", true).Init(_action);
        //  _action.Rename(_newName);
    }

    void DrawKeysActionInput(bool _show, TCT_ActionInput _action)
    {
        if (!_show) return;

        if (_action == null || _action.AllKeyCodes.Count < 1) return;

        for (int i = 0; i < _action.AllKeyCodes.Count; i++)
        {
            Enum _currentKeyCode = _action.AllKeyCodes[i];

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.Separator();

            EditorLayout.EnumPopup(ref _currentKeyCode, "");

            if (_action.ExistKeyCode((KeyCode)_currentKeyCode) && (KeyCode)_currentKeyCode != _action.AllKeyCodes[i])
                Debug.LogWarning("this Key is already assign in this Action. Please select an other");
            else
                _action.AllKeyCodes[i] = (KeyCode)_currentKeyCode;

            EditorLayout.Button("x", _action.RemoveKey, (KeyCode)_currentKeyCode);

            EditorGUILayout.EndHorizontal();

            EditorLayout.Space();
        }

    }
    void CreateActionInput()
    {
        TCT_ControllerManager.allActionInput.Add(new TCT_ActionInput());
    }

    #endregion

    void DrawAllAxisInput(bool _show)
    {
        if (!_show) return;

        for (int i = 0; i < TCT_ControllerManager.allAxisInput.Count; i++)
        {

        }
    }

    void CreateAxisInput()
    {
        TCT_ControllerManager.allAxisInput.Add(new TCT_AxisInput());
    }


}


public class TCT_RenameWindow : EditorWindow
{
    ISmartNaming currentSmartName;

    string currentName;

    private void OnEnable()
    {
        maxSize = new Vector2(300, 100);
        minSize = new Vector2(300, 100);

    }

    private void OnGUI()
    {
        currentName = EditorGUILayout.TextField(currentName);

        EditorLayout.Space(2);

        EditorGUILayout.BeginHorizontal();

        EditorLayout.Button("OK", ValidateChangeName, currentName);

        EditorLayout.Button("Cancel", Close);

        EditorGUILayout.EndHorizontal();
    }

    public void Init(ISmartNaming _name)
    {
        SetSmartNaming(_name);

        currentName = _name.Name;

    }

    void ValidateChangeName(string _name)
    {
        ChangeName(_name);
        Close();
    }

    void ChangeName(string _name) => currentSmartName.Name = _name;
    public void SetSmartNaming(ISmartNaming _name) => currentSmartName = _name;



}