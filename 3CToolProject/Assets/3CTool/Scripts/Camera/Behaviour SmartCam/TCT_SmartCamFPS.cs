using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCT_SmartCamFPS : TCT_SmartCamBehaviour
{
    public override void FollowTarget()
    {
        float _x = (1 - ownOption.Lerp) * ownOption.Target.transform.position.x + ownOption.Lerp * transform.position.x;
        float _y = (1 - ownOption.Lerp) * ownOption.Target.transform.position.y + ownOption.Lerp * transform.position.y;
        float _z = (1 - ownOption.Lerp) * ownOption.Target.transform.position.z + ownOption.Lerp * transform.position.z;

        transform.position = new Vector3(_x, _y, _z) + ownOption.OffsetSmartCam;
    }

    public override void RotateSmartCam()
    {
        throw new System.NotImplementedException();
    }


}
