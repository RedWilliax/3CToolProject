using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unitility;

public class TCT_ControllerManager : Singleton<TCT_ControllerManager>
{
    [SerializeField] public static List<TCT_ActionInput> AllActionInput = new List<TCT_ActionInput>();

    [SerializeField] public static List<TCT_AxisInput> AllAxisInput = new List<TCT_AxisInput>();




}
