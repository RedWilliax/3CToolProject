using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCT_SmartCamFPS : TCT_SmartCamBehaviour
{
    protected override void Update()
    {
        base.Update();

        FollowTarget();

        RotateSmartCam();
    }

    protected override void RotateSmartCam()
    {
        base.RotateSmartCam();

        Quaternion _targetRotate = ownOption.Target.Transform.rotation;

        transform.rotation = new Quaternion(_targetRotate.x * ownOption.Sensibility, _targetRotate.y * ownOption.Sensibility, _targetRotate.z * ownOption.Sensibility, _targetRotate.w * ownOption.Sensibility);
    }


}
