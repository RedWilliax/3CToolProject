using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unitility;

public class TCT_SmartCamManager : MonoBehaviour, IHandler<TCT_SmartCam>
{
    Dictionary<int, TCT_SmartCam> allHandle = new Dictionary<int, TCT_SmartCam>();

    public Dictionary<int, TCT_SmartCam> AllHandle { get => allHandle; set => allHandle = value; }

    public void AddHandle(TCT_SmartCam _handle)
    {
        ManageHandle(true, _handle);
    }

    public bool ExistHandle(TCT_SmartCam _handle)
    {
        throw new System.NotImplementedException();
    }

    public void ManageHandle(bool _add, TCT_SmartCam _handle)
    {
        bool _exist = ExistHandle(_handle);

        if (_add ? !_exist : _exist) return;




    }

    public void RemoveHandle(TCT_SmartCam _handle)
    {
        ManageHandle(false, _handle);
    }
}
