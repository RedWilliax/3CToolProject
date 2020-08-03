using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCT_SmartCamFPS : TCT_SmartCamBehaviour
{
    private void Update()
    {

        FollowTarget();

        RotateSmartCam();

    }

    protected override void RotateSmartCam()
    {
        base.RotateSmartCam();

        transform.rotation = ownOption.Target.Transform.rotation;
    }


}
