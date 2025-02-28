using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Door : MonoBehaviour
{

    [SerializeField] private GameObject MainDoor;
    [SerializeField] private List<Animator> anim;
    private bool isOpen = false;
    void Start()
    {

    }

    void Update()
    {

    }
   
    public bool open_CloseDoor()
    {
        if(isOpen)
        {
            isOpen = false;
            return false;
        }
        else
        {
            isOpen = true;
            return true;
        }
    }
    public void EnableColision(bool on)
    {
        if (on)
        {
            foreach (var item in anim)
            {
                item.gameObject.GetComponent<NavMeshObstacle>().enabled = true;
            }
        }
        else
        {
            foreach (var item in anim)
            {
                item.gameObject.GetComponent<NavMeshObstacle>().enabled = false;
            }
        }
    }

    public void CloseOpenDoore()
    {
        if (open_CloseDoor())
        {
            foreach (var item in anim)
            {
                item.SetBool("isOpen", true);
            }
        }
        else
        {
            foreach (var item in anim)
            {
                item.SetBool("isOpen", false);
            }
        }
    }

    public void Close_door()
    {
        foreach (var item in anim)
        {
            item.SetBool("isOpen", false);
        }
        isOpen = false;
    }
    public void Open_door()
    {
        foreach (var item in anim)
        {
            item.SetBool("isOpen", true);
        }
        isOpen = true;
    }

}
