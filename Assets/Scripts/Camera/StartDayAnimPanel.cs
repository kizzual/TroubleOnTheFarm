using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDayAnimPanel : MonoBehaviour
{
    [SerializeField] private CameraAnimation cameraAnim;
    [SerializeField] Animator animation;

  
    public void StartDayAnimation()
    {
        animation.SetTrigger("StartAnimation");
        StartCoroutine(CameraMoveActivation());
    }
    IEnumerator CameraMoveActivation()
    {
        yield return new WaitForSeconds(1f);
        cameraAnim.SwitchCameraPosition();

    }

}
