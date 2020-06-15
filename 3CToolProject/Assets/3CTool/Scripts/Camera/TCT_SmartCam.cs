using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unitility;

public class TCT_SmartCam : MonoBehaviour, IHandle
{
    int id = 0;

    new string name = "Default_SmartCam";

    public int ID { get => id; set => id = value; }

    public string Name { get => name; set => name = value; }

    private void Awake()
    {
        StartCoroutine(AddToHandler());
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
}
