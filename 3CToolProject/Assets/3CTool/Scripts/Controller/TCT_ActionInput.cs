using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[Serializable]
public class TCT_ActionInput : ISmartNaming
{
    public static Action<bool> ActionInput = null;

    public string name = "Default_ActionName";

    [SerializeField] List<KeyCode> allKeyCodes = new List<KeyCode>();

    public EditorUtility editorUtility = new EditorUtility();

    public string Name { get => name; set => name = value; }

    public List<KeyCode> AllKeyCodes { get => allKeyCodes; set => allKeyCodes = value; }

    public void AddKey(KeyCode _key)
    {
        ManageKey(true, _key);
    }

    public void RemoveKey(KeyCode _key)
    {
        ManageKey(false, _key);
    }

    void ManageKey(bool _add, KeyCode _key)
    {
        if (_add ? ExistKeyCode(_key) : !ExistKeyCode(_key)) return;

        if (_add) allKeyCodes.Add(_key);

        else allKeyCodes.Remove(_key);
    }

    public bool ExistKeyCode(KeyCode _key)
    {
        return allKeyCodes.Any(n => n == _key);
    }

    public void Rename(string _name) => name = _name;

}

[Serializable]
public class EditorUtility
{
    public bool show = false;

}