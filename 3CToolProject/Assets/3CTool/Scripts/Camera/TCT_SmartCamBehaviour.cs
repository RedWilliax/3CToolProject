using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class TCT_SmartCamBehaviour : MonoBehaviour
{

    public abstract void FollowTarget();

    public abstract void RotateSmartCam();
}

public class TCT_SmartCamBehaviourOption
{
    Transform target = null;

    float lerp = 0;

    public Transform Target { get; set; }


}
