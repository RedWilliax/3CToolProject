using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

public static class TCT_MenuTool
{
    const string logicName = "Logic [3CTool]";

    [MenuItem("3CTool/SmartCamera/Add SmartCam")]
    static void AddSmartCam()
    {
        VerifyLogic();

        if (!GetLogic().GetComponent<TCT_SmartCamManager>())
            AddComponentOnLogic<TCT_SmartCamManager>();

        GameObject _go = new GameObject($"SmartCam", (typeof(TCT_SmartCam)));

        Selection.activeObject = _go;
    }

    [MenuItem("3CTool/Player/Add Player")]
    static void AddPlayer()
    {
        VerifyLogic();

        if (!GetLogic().GetComponent<TCT_CharacterManager>())
            AddComponentOnLogic<TCT_CharacterManager>();

        GameObject _go = new GameObject($"Character [{GetAllCharacters().Count}]", typeof(TCT_Character));

        _go.GetComponent<TCT_Character>().Name = _go.name;

        Selection.activeObject = _go;
    }

    [MenuItem("3CTool/Input/InputManager")]
    static void InputManager()
    {
        EditorWindow.GetWindow<TCT_ControllerManagerWindow>(false, "Controller Manager");
    }

    static bool Exist(string _objectToCheck)
    {
        GameObject _ob = GameObject.Find(_objectToCheck);

        return _ob != null;
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
