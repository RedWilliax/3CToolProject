using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCT_SmartCamTPS : TCT_SmartCamBehaviour
{
    Vector3 GetVectorDirector => ownOption.Target.Transform.position - transform.position;

    float angle = 0;

    protected override void Update()
    {

        if (ownOption == null) return;

        FollowTarget();

        RotateAround(ownOption.Sensibility);

    }

    void RotateAround(float _sensibility)
    {
        //trigo 
        //transform.Rotate(Vector3.up + GetVectorDirector, TCT_AxisRecuperator.GetAxis(AxisCode.MouseX) * _sensibility);
        //transform.Rotate(Vector3.right + GetVectorDirector, -TCT_AxisRecuperator.GetAxis(AxisCode.MouseY) * _sensibility);

        angle += TCT_AxisRecuperator.GetAxis(AxisCode.MouseX);

        transform.position = new Vector3(Mathf.Cos(angle), 0 , Mathf.Sin(angle)) + ownOption.OffsetSmartCam + ownOption.Target.Transform.position;

    }

    void LookAt()
    {



    }


    private void OnGUI()
    {
        GUI.TextField(new Rect(Vector2.zero, new Vector2(100, 200)), $" X : {TCT_AxisRecuperator.GetAxis(AxisCode.MouseX)} Y : {TCT_AxisRecuperator.GetAxis(AxisCode.MouseY)}" );

    }


}
