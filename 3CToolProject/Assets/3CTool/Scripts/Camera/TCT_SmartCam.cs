using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unitility.Engine;

public enum TypeSmartCam
{
    FPS,
    TPS,
    NONE

}

public class TCT_SmartCam : MonoBehaviour, IHandle
{
    int id = 0;

    [SerializeField] new string name = "Default_SmartCam";

    [SerializeField] SmartCamOption smartCamOption = new SmartCamOption();

    [SerializeField] TCT_SmartCamBehaviour behaviour = null;

    [SerializeField] TypeSmartCam typeSmartCam = TypeSmartCam.NONE;

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

        InitBehaviour();
    }

    void InitBehaviour()
    {
        switch (typeSmartCam)
        {
            case TypeSmartCam.FPS:
                behaviour = gameObject.AddComponent<TCT_SmartCamFPS>();
                behaviour.Init(this);
                break;

            case TypeSmartCam.TPS:
                behaviour = gameObject.AddComponent<TCT_SmartCamTPS>();
                behaviour.Init(this);
                break;

            case TypeSmartCam.NONE:
                break;
            default:
                break;
        }
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.green;

        if (smartCamOption.Target != null)
            Gizmos.DrawSphere(smartCamOption.Target.Transform.position + Vector3.up * 2, 1);

        Gizmos.color = Color.red;

        Gizmos.DrawSphere(transform.position, 1);
    }


}

[Serializable]
public class SmartCamOption
{
    [SerializeField] float x = 0;

    [SerializeField] float y = 0;

    [SerializeField] float z = 0;

    [SerializeField] bool fixeCam = false;

    [SerializeField] float lerp = 0;

    [SerializeField] ITargetSC target;

    [SerializeField] float sensibility = 1;

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
    public ITargetSC Target
    {
        get => target;

        set
        {
            target = value;
        }
    }
    public float Lerp
    {
        get => lerp;

        set
        {
            lerp = value > 1 ? lerp : value;
        }
    }
    public Vector3 OffsetSmartCam => new Vector3(x, y, z);
    public float Sensibility { get => sensibility; set => sensibility = value; }
    public void SetTarget(ITargetSC _target) => Target = target;



}
