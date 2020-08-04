using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[Serializable]
public class TCT_ActionInput
{
    public static Action<bool> ActionInput = null;

    public string name = "Default_ActionName";

    List<KeyCode> allKeyCodes = new List<KeyCode>();

    EditorUtility editorUtility = new EditorUtility();

    public string Name { get; set; }

    public List<KeyCode> AllKeyCodes { get => allKeyCodes; set => allKeyCodes = value; }

    public bool Show => editorUtility.show;

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


}

[Serializable]
public class EditorUtility
{
   public bool show = false;

}