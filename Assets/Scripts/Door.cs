using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
/*    public enum Side
    {
        Left,
        Right
    }
    public Side side;*/
    [SerializeField] private GameObject MainDoor;
    private Animator anim;
    private bool isOpen = false;
    void Start()
    {
        anim = GetComponent<Animator>();
/*        if (side == Side.Left)
        {
            MainDoor.transform.position = new Vector3(0.3f, 0.0001f, 0);
        }
        else if (side == Side.Right)
        {
            MainDoor.transform.position = new Vector3(-0.3f, 0.0001f, 0);
        }*/
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
    private void OnMouseDown()
    {
        if (open_CloseDoor())
        {
            anim.SetBool("IsOpen", true);
        }
        else
        {
            anim.SetBool("IsOpen", false);

        }
    }



}
