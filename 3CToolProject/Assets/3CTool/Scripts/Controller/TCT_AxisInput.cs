using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public enum AxisCode
{
    MouseX,
    MouseY,
    JoytickLeft,
    JoystickRight

}

[Serializable]
public class TCT_AxisInput : ISmartNaming
{
    public Action<float> AxisInput = null;

    public string name = "Default_AxisName";

    [SerializeField] List<AxisCode> allAxisCode = new List<AxisCode>();

    public string Name { get => name; set => name = value; }

    public List<AxisCode> AllAxisCode { get => allAxisCode; set => allAxisCode = value; }

}
