using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Bindings;
using System.Linq;
using System;
using Unitility;

public class TCT_ControllerManager : Singleton<TCT_ControllerManager>
{
    public static List<TCT_ActionInput> allActionInput = new List<TCT_ActionInput>();

    public static List<TCT_AxisInput> allAxisInput = new List<TCT_AxisInput>();

    #region ManageInput
    public int CountActionInput => allActionInput.Count;

    public int CountAxisInput => allAxisInput.Count;

    public TCT_ActionInput GetActionInput(int _index) => allActionInput[_index];
    public TCT_AxisInput GetAxisInput(int _index) => allAxisInput[_index];

    public void RemoveActionInput(TCT_ActionInput _action) => allActionInput.Remove(_action);
    public void RemoveAxisInput(TCT_AxisInput _action) => allAxisInput.Remove(_action);

    public void AddActionInput(TCT_ActionInput _action) => allActionInput.Add(_action);
    public void AddAxisInput(TCT_AxisInput _action) => allAxisInput.Add(_action);
    #endregion

    private void Update()
    {
        allActionInput.ForEach(n => 
        {
            for (int i = 0; i < n.AllKeyCodes.Count; i++)
            {
                n.ActionInput.Invoke(Input.GetKey(n.AllKeyCodes[i]));
            }
        }
        );


        allAxisInput.ForEach(n =>
        {

            for (int i = 0; i < n.AllAxisCode.Count; i++)
            {

                n.AxisInput.Invoke(TCT_AxisRecuperator.GetAxis(n.AllAxisCode[i]));

            }

        });

    }

    public Action<bool> GetActionInput(string _nameAction)
    {
        return allActionInput.FirstOrDefault(n => n.Name == _nameAction).ActionInput;
    }

    public Action<float> GetAxisInput(string _nameAxis)
    {
        return allAxisInput.FirstOrDefault(n => n.Name == _nameAxis).AxisInput;
    }




}
