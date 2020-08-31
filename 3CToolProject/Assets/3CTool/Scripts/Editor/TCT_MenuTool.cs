using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEditor;

public static class TCT_MenuTool
{
    const string logicName = "Logic [3CTool]";

    [MenuItem("3CTool/SmartCamera/Add SmartCam")]
    static void AddSmartCam()
    {
        VerifyAndAddOnLogic<TCT_SmartCamManager>();

        GameObject _go = new GameObject($"SmartCam", new Type[]{ typeof(Camera), typeof(TCT_SmartCam) });

        Selection.activeObject = _go;
    }

    [MenuItem("3CTool/Player/Add Player")]
    static void AddPlayer()
    {
        VerifyAndAddOnLogic<TCT_CharacterManager>();

        GameObject _go = new GameObject($"Character [{GetAllCharacters().Count}]", typeof(TCT_Character));

        _go.GetComponent<TCT_Character>().Name = _go.name;

        Selection.activeObject = _go;
    }

    [MenuItem("3CTool/Input/InputManager")]
    static void InputManager()
    {
        VerifyAndAddOnLogic<TCT_ControllerManager>();

        EditorWindow.GetWindow<TCT_ControllerManagerWindow>(false, "Controller Manager 0.1.0.0", true);
    }

    static bool Exist(string _objectToCheck)
    {
        GameObject _ob = GameObject.Find(_objectToCheck);

        return _ob != null;
    }

    static void VerifyAndAddOnLogic<T>() where T : MonoBehaviour
    {
        VerifyLogic();

        if (!GetLogic().GetComponent<T>())
            AddComponentOnLogic<T>();
    }

    #region ManagerLogic
    static void VerifyLogic()
    {
        if (Exist(logicName)) return;

        Debug.Log("Add Logic because it's not exist");

        AddLogic();
    }

    static void AddComponentOnLogic<T>() where T : MonoBehaviour
    {
        GetLogic().AddComponent<T>();
    }

    static GameObject GetLogic()
    {
        return GameObject.Find(logicName);
    }

    static void AddLogic()
    {
        new GameObject(logicName);

    }

    #endregion

    public static List<ITargetSC> GetAllCharacters() => GameObject.FindObjectsOfType<MonoBehaviour>().OfType<ITargetSC>().ToList();



}
