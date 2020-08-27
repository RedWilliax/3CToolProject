using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unitility.Engine;
using Unitility;
using System.Linq;

public class TCT_SmartCamManager : Singleton<TCT_SmartCamManager>, IHandler<TCT_SmartCam>
{
    Dictionary<int, TCT_SmartCam> allHandle = new Dictionary<int, TCT_SmartCam>();

    public Dictionary<int, TCT_SmartCam> AllHandle { get => allHandle; set => allHandle = value; }

    public void AddHandle(TCT_SmartCam _handle)
    {
        ManageHandle(true, _handle);
    }

    public void RemoveHandle(TCT_SmartCam _handle)
    {
        ManageHandle(false, _handle);
    }

    public bool ExistHandle(TCT_SmartCam _handle)
    {
        return allHandle.Any(n => n.Value.ID == _handle.ID);
    }

    public void ManageHandle(bool _add, TCT_SmartCam _handle)
    {
        bool _exist = ExistHandle(_handle);

        if (_add ? _exist : !_exist) return;

        if (_add) allHandle.Add(_handle.ID, _handle);
        else allHandle.Remove(_handle.ID);
    }

}
