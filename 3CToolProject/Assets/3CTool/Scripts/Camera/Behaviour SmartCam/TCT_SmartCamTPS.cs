using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCT_SmartCamTPS : TCT_SmartCamBehaviour
{
    Vector3 GetVectorDirector => (ownOption.TargetPosition + ownOption.OffsetSmartCam)- transform.position;

    float _angleHorizon = 0;
    float _angleVerti = 0;

    protected override void Update()
    {
        base.Update();

        FollowTarget();
        
        RotateAround(ownOption.Sensibility);

        LookAt();
    }

    void RotateAround(float _sensibility)
    {
        float _distanceTemp = 10;

        _angleHorizon += -TCT_AxisRecuperator.GetAxis(AxisCode.MouseX) * _sensibility * 0.01f;

        _angleVerti += TCT_AxisRecuperator.GetAxis(AxisCode.MouseY) * _sensibility * 0.01f;

        Vector3 _finalPos = SphericTrigo(_angleHorizon, _angleVerti, _distanceTemp) + ownOption.OffsetSmartCam;

        transform.position += _finalPos;
    }

    Vector3 SphericTrigo(float _angleZX, float _angleYZ, float _radius = 1)
    {
        Vector3 _position = Vector3.zero;

        _position.x = Mathf.Cos(_angleZX);
        _position.y = Mathf.Sin(_angleYZ);
        _position.z = Mathf.Sin(_angleZX) * Mathf.Cos(_angleYZ);

        _position *= _radius;

        return _position;
    }

    void LookAt()
    {
        Vector3 _direction = GetVectorDirector - ownSmartCam.transform.position;

        Quaternion _lookAt = Quaternion.LookRotation(_direction, Vector3.up);

        ownSmartCam.transform.rotation = Quaternion.RotateTowards(ownSmartCam.transform.rotation, _lookAt, 500);
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.black;

        Gizmos.DrawSphere(GetVectorDirector - ownSmartCam.transform.position, 1);

    }

}
