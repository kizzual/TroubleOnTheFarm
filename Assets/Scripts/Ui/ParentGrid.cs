using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentGrid : MonoBehaviour
{
    public BoxCollider box;
    public bool IsActive = true;
    void Start()
    {
        box = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (IsActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CheckChild();
            }
            if (Input.GetMouseButtonUp(0))
            {
                BoxOn();
            }
        }

    }

    private void CheckChild()
    {
        if(transform.childCount > 0)
        {
            box.enabled = false;
        }
        else
        {
            box.enabled = true;
        }
    }
    public void BoxOn()
    {
        box.enabled = true;
    }
    public void BoxOff()
    {
        box.enabled = false;
    }
}
