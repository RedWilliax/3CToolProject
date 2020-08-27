using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.IO;
using Unitility;
using JsonCom;

public struct SaveControllerManager
{
    public List<TCT_ActionInput> allActionInput;
    public List<TCT_AxisInput> allAxisInput;

    public SaveControllerManager(List<TCT_ActionInput> allActionInput, List<TCT_AxisInput> allAxisInput)
    {
        this.allActionInput = allActionInput;
        this.allAxisInput = allAxisInput;
    }
}
public class TCT_ControllerManager : Singleton<TCT_ControllerManager>
{
    [SerializeField] List<TCT_ActionInput> allActionInput = new List<TCT_ActionInput>();

    [SerializeField] List<TCT_AxisInput> allAxisInput = new List<TCT_AxisInput>();

    public override void Awake()
    {
        base.Awake();

        Init();
    }

    private void Update()
    {
        allActionInput.ForEach(n => 
        {
            for (int i = 0; i < n.AllKeyCodes.Count; i++)
            {
                n.ActionInput?.Invoke(Input.GetKey(n.AllKeyCodes[i]));
            }
        }
        );

        allAxisInput.ForEach(n =>
        {
            for (int i = 0; i < n.AllAxisCode.Count; i++)
            {
                n.AxisInput?.Invoke(TCT_AxisRecuperator.GetAxis(n.AllAxisCode[i]));
            }
        });

    }

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

    public TCT_ActionInput GetActionInput(string _nameAction)
    {
        return allActionInput.Find(n => n.Name == _nameAction);
    }

    public TCT_AxisInput GetAxisInput(string _nameAxis)
    {
        return allAxisInput.Find(n => n.Name == _nameAxis);
    }

    public void SetListActionInput(List<TCT_ActionInput> _action)
    {
        allActionInput = _action;
    }

    public void SetListAxisInput(List<TCT_AxisInput> _axis)
    {
        allAxisInput = _axis;
    }

    void Init()
    {
        SaveControllerManager _getSave = new SaveControllerManager();

        JsonUnitility.ReadJson(ref _getSave, TCT_PathForSave.filePath, TCT_PathForSave.directoyPath);

        allActionInput = _getSave.allActionInput;

        allAxisInput = _getSave.allAxisInput;
    }

    public void SubAtActionInput(string _nameActionInput, Action<bool> _methodeToSub)
    {
        TCT_ActionInput _currentAction = GetActionInput(_nameActionInput);

        _currentAction.ActionInput += _methodeToSub;
    }

    public void SubAtAxisInput(string _nameAxis, Action<float> _methodeToSub)
    {
        TCT_AxisInput _currentAxis = GetAxisInput(_nameAxis);

        _currentAxis.AxisInput += _methodeToSub;
    }

}

public static class TCT_PathForSave
{
    public static string directoyPath = Path.Combine(Application.dataPath, "Resources/SaveControllerManager");

    public static string filePath = Path.Combine(directoyPath, "SaveControlleManage.txt");
}