using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCT_SmartCamFPS : TCT_SmartCamBehaviour
{
    protected override void Update()
    {
        base.Update();

        if (ownOption.Target == null) return;

        FollowTarget();

        RotateSmartCam();
    }

    protected override void RotateSmartCam()
    {
        base.RotateSmartCam();

        transform.rotation = ownOption.Target.Transform.rotation;
    }


}
