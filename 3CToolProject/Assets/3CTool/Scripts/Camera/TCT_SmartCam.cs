using System.Collections;
using System.Collections.Generic;
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

    SmartCamOption smartCamOption = new SmartCamOption();

    public int ID { get => id; set => id = value; }

    public string Name { get => name; set => name = value; }

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


}


public class SmartCamOption
{
    float x = 0;

    float y = 0;

    float z = 0;

    float lerp = 0;

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






}
