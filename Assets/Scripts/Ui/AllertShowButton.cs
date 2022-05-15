using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllertShowButton : MonoBehaviour
{
    public GameObject alertImage;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ShowAlertImage(bool IsActive)
    {
        if (IsActive)
            alertImage.SetActive(true);
        else
            alertImage.SetActive(false);
    }

}
