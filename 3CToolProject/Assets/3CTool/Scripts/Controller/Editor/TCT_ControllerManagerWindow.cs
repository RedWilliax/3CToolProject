using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEditor;

using Unitility;

public class TCT_ControllerManagerWindow : EditorWindow
{

    List<TCT_ActionInput> AllActionInput = new List<TCT_ActionInput>();

    List<TCT_AxisInput> AllAxisInput = new List<TCT_AxisInput>();

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

        // GUILayout.BeginArea(new Rect(10, 50, position.width * 0.4f, position.height));

        DrawAllActionInput(showActionInput);

        // GUILayout.EndArea();

        EditorLayout.Space();

        showAxisInput = EditorGUILayout.Foldout(showAxisInput, "Axis Input");

        //GUILayout.BeginArea(new Rect(10, 50, position.width * 0.4f, position.height));

        DrawAllAxisInput(showAxisInput);

        //GUILayout.EndArea();
        GUILayout.EndScrollView();

    }

    void DrawAllActionInput(bool _show)
    {
        if (!_show || AllActionInput.Count < 1) return;

        for (int i = 0; i < AllActionInput.Count; i++)
        {
            bool _showInputs = AllActionInput[i].Show;

            GUILayout.BeginHorizontal();

            _showInputs = EditorGUILayout.Foldout(_showInputs, AllActionInput[i].name);

            EditorLayout.Button("+", AddKeyInAction, AllActionInput[i], KeyCode.None);

            EditorLayout.Button("x", RemoveActionInput, AllActionInput[i]);

            GUILayout.EndHorizontal();

            EditorLayout.Space();

            if (AllActionInput.Count < 1) return;

            DrawKeysActionInput(_showInputs, AllActionInput[i]);

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

    void DrawKeysActionInput(bool _show, TCT_ActionInput _action)
    {
        if (_action == null || _action.AllKeyCodes.Count < 1) return;

        for (int i = 0; i < _action.AllKeyCodes.Count; i++)
        {
            Enum _currentKeyCode = _action.AllKeyCodes[i];

            EditorGUILayout.BeginHorizontal();

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

    void DrawAllAxisInput(bool _show)
    {
        if (!_show) return;

        for (int i = 0; i < AllAxisInput.Count; i++)
        {

        }
    }

    void CreateActionInput()
    {
        AllActionInput.Add(new TCT_ActionInput());
    }

    void CreateAxisInput()
    {
        AllAxisInput.Add(new TCT_AxisInput());
    }

    public void RemoveActionInput(TCT_ActionInput _action)
    {
        AllActionInput.Remove(_action);
    }

}
