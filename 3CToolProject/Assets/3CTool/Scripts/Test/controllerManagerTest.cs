using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerManagerTest : MonoBehaviour
{


    private void Start()
    {
        TCT_ControllerManager.Instance.SubAtActionInput("OK", TestActionInput);

        //TCT_ControllerManager.Instance.SubAtAxisInput("NO", TestAxisInput);
    }


    void TestActionInput(bool _input)
    {

        Debug.Log($"I'm...I'm ALIVE !!,  {_input}");
    }

    void TestAxisInput(float _axis)
    {
        Debug.Log($"I'm...I'm DEAD !!,  {_axis}");
    }

}
