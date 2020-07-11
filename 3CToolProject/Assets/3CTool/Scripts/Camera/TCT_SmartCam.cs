using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unitility;

enum TypeSmartCam
{
    FPS,
    TPS,
    FIXE,
    NONE

}

public class TCT_SmartCam : MonoBehaviour, IHandle
{
    int id = 0;

    new string name = "Default_SmartCam";

    SmartCamOption smartCamOption = null;

    TCT_SmartCamBehaviour behaviour = null;

    TypeSmartCam typeSamrtCam = TypeSmartCam.NONE;

    public int ID { get => id; set => id = value; }

    public string Name { get => name; set => name = value; }

    public TCT_SmartCamBehaviour Behaviour { get => behaviour; set => behaviour = value; }

    public SmartCamOption SmartCamOption { get => smartCamOption; set => smartCamOption = value; }

    private void Awake()
    {
        StartCoroutine(AddToHandler());
    }

    private void Start()
    {
        StartCoroutine(InitSmartCam());

    }

    private void OnDestroy()
    {
        RemoveToHandler();
    }

    public IEnumerator AddToHandler()
    {
        while (!TCT_SmartCamManager.Instance)
            yield return null;

        ID = TCT_SmartCamManager.Instance.AllHandle.Count;

        TCT_SmartCamManager.Instance.AddHandle(this);
    }
    public void RemoveToHandler()
    {
        if (!TCT_SmartCamManager.Instance) return;

        TCT_SmartCamManager.Instance.RemoveHandle(this);
    }

    IEnumerator InitSmartCam()
    {
        while ((bool)!TCT_SmartCamManager.Instance?.ExistHandle(this))
            yield return null;
    }

    void InitBehaviour()
    {
        switch (typeSamrtCam)
        {
            case TypeSmartCam.FPS:
                break;
            case TypeSmartCam.TPS:
                break;
            case TypeSmartCam.FIXE:
                break;
            case TypeSmartCam.NONE:
                break;
            default:
                break;
        }
    }


}

[Serializable]
public class SmartCamOption
{
    float x = 0;

    float y = 0;

    float z = 0;

    bool fixeCam = false;

    public float X
    {
        get => x;

        set
        {
            x = fixeCam ? x : value;
        }
    }

    public float Y
    {
        get => y;

        set
        {
            y = fixeCam ? y : value;
        }
    }

    public float Z
    {
        get => z;

        set
        {
            z = fixeCam ? z : value;
        }
    }

    public bool FixeCam
    {
        get => fixeCam;

        set
        {
            if (value == fixeCam) return;
            fixeCam = value;
        }
    }





}
