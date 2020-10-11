using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCT_SmartCamTPS : TCT_SmartCamBehaviour
{
    Vector3 GetVectorDirector => ownOption.Target.Transform.position - transform.position;

    float angleHorizon = 0;
    float angleVerti = 0;

    protected override void Update()
    {

        if (ownOption == null) return;

        FollowTarget();

        RotateAround(ownOption.Sensibility);

        LookAt();
    }

    void RotateAround(float _sensibility)
    {

        float _distanceTemp = 5;

        angleHorizon += TCT_AxisRecuperator.GetAxis(AxisCode.MouseX) * _sensibility * 0.01f;

        angleVerti += TCT_AxisRecuperator.GetAxis(AxisCode.MouseY) * _sensibility * 0.01f;

        Vector3 _position = new Vector3(_distanceTemp + Mathf.Cos(angleHorizon), 0, Mathf.Sin(angleHorizon));


        transform.position = _position + ownOption.OffsetSmartCam + ownOption.Target.Transform.position;

    }

    void LookAt()
    {
        Vector3 _direction = ownOption.Target.Transform.position - ownSmartCam.transform.position;

        Quaternion _lookAt = Quaternion.LookRotation(_direction, Vector3.up);

        ownSmartCam.transform.rotation = Quaternion.RotateTowards(ownSmartCam.transform.rotation, _lookAt, 500);
    }


    private void OnGUI()
    {
        
    }


}
