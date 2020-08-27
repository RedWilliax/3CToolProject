using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unitility.Engine;
using Unitility;

public class TCT_CharacterManager : Singleton<TCT_CharacterManager>, IHandler<TCT_Character>
{
    Dictionary<int, TCT_Character> allHandle = new Dictionary<int, TCT_Character>();

    public Dictionary<int, TCT_Character> AllHandle { get => allHandle; set => allHandle = value; }

    public void AddHandle(TCT_Character _handle)
    {
        ManageHandle(true, _handle);
    }

    public bool ExistHandle(TCT_Character _handle)
    {
        return allHandle.Any(n => n.Value.ID == _handle.ID);
    }

    public void ManageHandle(bool _add, TCT_Character _handle)
    {
        bool _exist = ExistHandle(_handle);

        if (_add ? _exist : !_exist) return;

        if (_add) allHandle.Add(_handle.ID, _handle);
        else allHandle.Remove(_handle.ID);
    }

    public void RemoveHandle(TCT_Character _handle)
    {
        ManageHandle(false, _handle);
    }
}
