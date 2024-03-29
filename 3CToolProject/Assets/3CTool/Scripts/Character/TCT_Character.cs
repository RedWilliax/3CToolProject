﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unitility.Engine;

public class TCT_Character : MonoBehaviour, IHandle, ISmartNaming, ITargetSC
{
    [SerializeField] new string name = "DefaultName";

    [SerializeField] List<TCT_CharacterComponent> allComponents = new List<TCT_CharacterComponent>();

    int id = 0;

    public string Name { get => name; set => name = value; }

    public int ID { get => id; set => id = value; }

    public Transform Transform => transform;

    void Start()
    {
        StartCoroutine(AddToHandler());
    }

    private void OnDestroy()
    {
        RemoveToHandler();
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.blue;

        Gizmos.DrawSphere(transform.position, 1);
    }

    public IEnumerator AddToHandler()
    {
        while (!TCT_CharacterManager.Instance)
            yield return null;

        ID = TCT_CharacterManager.Instance.AllHandle.Count;

        TCT_CharacterManager.Instance.AddHandle(this);
    }

    public void RemoveToHandler()
    {
        if (!TCT_CharacterManager.Instance) return;

        TCT_CharacterManager.Instance.RemoveHandle(this);
    }

    public void AddComponent(TCT_CharacterComponent _component)
    {
        Debug.Log("This feature coming out soon ! Stay aware");

        //if (allComponents.Any(n => n.GetType() == _component.GetType()))
        //    Debug.Log($"sameType {_component.GetType()}");


    }

}
