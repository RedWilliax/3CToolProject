using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;

[Serializable]
public class TCT_AxisInput : ISmartNaming
{
    public Action<float> AxisInput = null;

    public string name = "Default_AxisName";

    public float sensibilty = 1;

    public float deadZone = 0;

    [SerializeField] List<AxisCode> allAxisCode = new List<AxisCode>();

    public EditorUtility editorUtility = new EditorUtility();

    public string Name { get => name; set => name = value; }

    public List<AxisCode> AllAxisCode { get => allAxisCode; set => allAxisCode = value; }

    public void AddKey(AxisCode _key)
    {
        ManageKey(true, _key);
    }

    public void RemoveKey(AxisCode _key)
    {
        ManageKey(false, _key);
    }

    void ManageKey(bool _add, AxisCode _key)
    {
        if (_add ? ExistKeyCode(_key) : !ExistKeyCode(_key)) return;

        if (_add) AllAxisCode.Add(_key);

        else AllAxisCode.Remove(_key);
    }

    public bool ExistKeyCode(AxisCode _key)
    {
        return AllAxisCode.Any(n => n == _key);
    }

    public void Rename(string _name) => name = _name;


}
