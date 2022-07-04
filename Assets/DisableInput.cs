using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInput : MonoBehaviour
{
    public Container contrainer;
  
    private void OnDisable()
    {

        contrainer.inputMouse.TutorialIsActive = false;
        contrainer.cam.IsStoped = false;
    }
    private void OnEnable()
    {
        Debug.Log("ASD");
        contrainer.inputMouse.TutorialIsActive = true;
        contrainer.cam.IsStoped = true;
    }

}
