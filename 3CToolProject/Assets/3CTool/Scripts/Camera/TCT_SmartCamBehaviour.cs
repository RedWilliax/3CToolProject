using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class TCT_SmartCamBehaviour : MonoBehaviour
{
    protected TCT_SmartCam ownSmartCam = null;

    protected SmartCamOption ownOption = null;

    public void Init(TCT_SmartCam _ownSmartCam)
    {
        ownSmartCam = _ownSmartCam;

        ownOption = _ownSmartCam.SmartCamOption;

    }

    public abstract void FollowTarget();

    public abstract void RotateSmartCam();
}

