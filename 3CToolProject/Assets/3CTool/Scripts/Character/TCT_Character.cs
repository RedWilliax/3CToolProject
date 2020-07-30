using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unitility;

public class TCT_Character : MonoBehaviour, IHandle
{
    [SerializeField] new string name = "DefaultName";

    public string Name { get => name; set => name = value; }

    int id = 0;

    public int ID { get => id; set => id = value; }

    // Start is called before the first frame update
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
}
