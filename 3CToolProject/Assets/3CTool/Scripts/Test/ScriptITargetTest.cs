using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptITargetTest : MonoBehaviour, ITargetSC
{
    public Transform Transform => transform;

    public string Name => gameObject.name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
