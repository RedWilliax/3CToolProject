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

    protected virtual void FollowTarget()
    {
        float _x = (1 - ownOption.Lerp) * ownOption.Target.transform.position.x + ownOption.Lerp * transform.position.x;
        float _y = (1 - ownOption.Lerp) * ownOption.Target.transform.position.y + ownOption.Lerp * transform.position.y;
        float _z = (1 - ownOption.Lerp) * ownOption.Target.transform.position.z + ownOption.Lerp * transform.position.z;

        transform.position = new Vector3(_x, _y, _z) + ownOption.OffsetSmartCam;
    }

    protected virtual void RotateSmartCam() {}
}

