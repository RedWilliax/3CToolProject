using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEditor;
using Unitility.Editor;
using JsonCom;

public class TCT_ControllerManagerWindow : EditorWindow
{
    List<TCT_ActionInput> allActionInput = new List<TCT_ActionInput>();

    List<TCT_AxisInput> allAxisInput = new List<TCT_AxisInput>();

    bool showActionInput = false;

    bool showAxisInput = false;

    Vector2 scroll = new Vector2();
    private void OnEnable()
    {
        SaveControllerManager _getSave = new SaveControllerManager();

        JsonUnitility.ReadJson(ref _getSave, TCT_PathForSave.filePath, TCT_PathForSave.directoyPath);

        allActionInput = _getSave.allActionInput;

        allAxisInput = _getSave.allAxisInput;
    }

    private void OnGUI()
    {
        //GUILayout.BeginArea(new Rect(10, 10, position.width * 0.15f, position.height));

        scroll = GUILayout.BeginScrollView(scroll);

        GUILayout.BeginHorizontal();

        EditorLayout.Button("Add ActionInput", CreateActionInput);

        EditorLayout.Button("Add AxisInput", CreateAxisInput);

        EditorLayout.Button("Save Change", SaveChange);

        GUILayout.EndHorizontal();

        EditorLayout.Space();

        showActionInput = EditorGUILayout.Foldout(showActionInput, "Actions Input");
        DrawAllActionInput(showActionInput);

        EditorLayout.Space();

        showAxisInput = EditorGUILayout.Foldout(showAxisInput, "Axis Input");
        DrawAllAxisInput(showAxisInput);

        GUILayout.EndScrollView();

        EditorLayout.Space();
    }

    #region ActionInput
    void CreateActionInput()
    {
        allActionInput.Add(new TCT_ActionInput());
    }

    void DrawAllActionInput(bool _show)
    {
        if (!_show || allActionInput.Count < 1) return;

        for (int i = 0; i < allActionInput.Count; i++)
        {
            bool _showInputs = allActionInput[i].editorUtility.show;

            GUILayout.BeginHorizontal();

            EditorGUILayout.Separator();

            allActionInput[i].editorUtility.show = EditorGUILayout.Foldout(_showInputs, allActionInput[i].name);

            EditorLayout.Button("...", RenameInput, allActionInput[i]);

            EditorLayout.Button("+", AddKeyInAction, allActionInput[i], KeyCode.None);

            EditorLayout.Button("x", RemoveActionInput, allActionInput[i]);

            GUILayout.EndHorizontal();

            EditorLayout.Space();

            if (allActionInput.Count <= i) return;

            DrawKeysActionInput(_showInputs, allActionInput[i]);

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
        allActionInput.Remove(_action);
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

            EditorLayout.Button("x", RemoveKeyCode, _action, (KeyCode)_currentKeyCode);

            EditorGUILayout.EndHorizontal();

            EditorLayout.Space();
        }

    }

    void RemoveKeyCode(TCT_ActionInput _action, KeyCode _key)
    {
        _action.RemoveKey(_key);
    }

    #endregion

    #region AxisInput
    void CreateAxisInput()
    {
        allAxisInput.Add(new TCT_AxisInput());
    }

    void DrawAllAxisInput(bool _show)
    {
        if (!_show || allAxisInput.Count < 1) return;

        for (int i = 0; i < allAxisInput.Count; i++)
        {
            bool _showInputs = allAxisInput[i].editorUtility.show;

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.Separator();

            allAxisInput[i].editorUtility.show = EditorGUILayout.Foldout(_showInputs, allAxisInput[i].Name);

            EditorLayout.Button("...", RenameInput, allAxisInput[i]);

            EditorLayout.Button("+", AddAxisInAxisInput, allAxisInput[i], AxisCode.None);

            EditorLayout.Button("x", RemoveAxisInput, allAxisInput[i]);

            EditorGUILayout.EndHorizontal();

            EditorLayout.Space();

            if (allAxisInput.Count <= i) return;

            DrawAxisInput(_showInputs, allAxisInput[i]);

            EditorLayout.Space();

        }
    }

    void AddAxisInAxisInput(TCT_AxisInput _action, AxisCode _key)
    {
        if (_action.AllAxisCode.Any(n => n == AxisCode.None))
        {
            Debug.LogWarning("A axis is not assign. Please assign it to get an other key");
            return;
        }

        _action.AddKey(_key);
    }
    public void RemoveAxisInput(TCT_AxisInput _axis)
    {
        allAxisInput.Remove(_axis);
    }

    void DrawAxisInput(bool _show, TCT_AxisInput _axis)
    {
        if (!_show) return;

        if (_axis == null || _axis.AllAxisCode.Count < 1) return;

        for (int i = 0; i < _axis.AllAxisCode.Count; i++)
        {
            Enum _currentKeyCode = _axis.AllAxisCode[i];

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.Separator();

            _currentKeyCode = EditorGUILayout.EnumPopup(_currentKeyCode, GUILayout.MaxWidth(100));

            if (_axis.ExistKeyCode((AxisCode)_currentKeyCode) && (AxisCode)_currentKeyCode != _axis.AllAxisCode[i])
                Debug.LogWarning("this Axis is already assign in this Action. Please select an other");
            else
                _axis.AllAxisCode[i] = (AxisCode)_currentKeyCode;

            GUILayout.Box("Sensibility", GUILayout.MaxWidth(80));

            _axis.sensibilty = EditorGUILayout.FloatField(_axis.sensibilty, GUILayout.MaxWidth(50));

            GUILayout.Box("DeadZone", GUILayout.MaxWidth(80));

            _axis.deadZone = EditorGUILayout.FloatField(_axis.deadZone, GUILayout.MaxWidth(50));


            EditorLayout.Button("x", RemoveAxisCode, _axis, (AxisCode)_currentKeyCode);

            EditorGUILayout.EndHorizontal();

            EditorLayout.Space();
        }
    }

    void RemoveAxisCode(TCT_AxisInput _axis, AxisCode _code)
    {
        _axis.RemoveKey(_code);
    }

    #endregion

    void RenameInput(ISmartNaming _name)
    {
        GetWindow<TCT_RenameWindow>(true, "Rename AxisInput", true).Init(_name);
    }

    void RefreshData()
    {
        SaveControllerManager _current = new SaveControllerManager(allActionInput, allAxisInput);

        JsonUnitility.WriteOnJson(TCT_PathForSave.filePath, TCT_PathForSave.directoyPath, _current);
    }

    void SaveChange()
    {
        RefreshData();
        AssetDatabase.Refresh();
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