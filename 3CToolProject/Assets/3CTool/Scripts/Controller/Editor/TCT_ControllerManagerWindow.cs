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
        if (!_show || TCT_ControllerManager.AllActionInput.Count < 1) return;

        for (int i = 0; i < TCT_ControllerManager.AllActionInput.Count; i++)
        {
            bool _showInputs = TCT_ControllerManager.AllActionInput[i].editorUtility.show;

            GUILayout.BeginHorizontal();

            EditorGUILayout.Separator();

            TCT_ControllerManager.AllActionInput[i].editorUtility.show = EditorGUILayout.Foldout(_showInputs, TCT_ControllerManager.AllActionInput[i].name);

            EditorLayout.Button("...", RenameActionInput, TCT_ControllerManager.AllActionInput[i]);

            EditorLayout.Button("+", AddKeyInAction, TCT_ControllerManager.AllActionInput[i], KeyCode.None);

            EditorLayout.Button("x", RemoveActionInput, TCT_ControllerManager.AllActionInput[i]);

            GUILayout.EndHorizontal();

            EditorLayout.Space();

            if (TCT_ControllerManager.AllActionInput.Count < 1) return;

            DrawKeysActionInput(_showInputs, TCT_ControllerManager.AllActionInput[i]);

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
        TCT_ControllerManager.AllActionInput.Remove(_action);
    }

    void RenameActionInput(TCT_ActionInput _action)
    {

        
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
        TCT_ControllerManager.AllActionInput.Add(new TCT_ActionInput());
    }

    #endregion

    void DrawAllAxisInput(bool _show)
    {
        if (!_show) return;

        for (int i = 0; i < TCT_ControllerManager.AllAxisInput.Count; i++)
        {

        }
    }

    void CreateAxisInput()
    {
        TCT_ControllerManager.AllAxisInput.Add(new TCT_AxisInput());
    }


}
