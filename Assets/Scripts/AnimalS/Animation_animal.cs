using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_animal : MonoBehaviour
{
    public Animator _animator;
    private bool isRuning = false;
    private bool isWalking = false;
    private bool isIdle = false;
    private bool isEating = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Run_Animation()
    {
        _animator.SetBool("Run", true);
        _animator.SetBool("Walk", false);
        _animator.SetBool("Eating", false);
        /*if (!isRuning)
        {
            _animator.SetBool("Run", true);
            _animator.SetBool("Walk", false);
            _animator.SetBool("Eating", false);
            isRuning = true;
            isWalking = false;
            isIdle = false;
            isEating = false;
        }*/
    }
    public void Walk_Animation()
    {
        _animator.SetBool("Run", false);
        _animator.SetBool("Walk", true);
        _animator.SetBool("Eating", false);
       /* if (!isWalking)
        {
            _animator.SetBool("Run", false);
            _animator.SetBool("Walk", true);
            _animator.SetBool("Eating", false);
            isRuning = false;
            isWalking = true;
            isIdle = false;
            isEating = false;
        }*/
    }

    public void Idle_Animation()
    {
        _animator.SetBool("Run", false);
        _animator.SetBool("Walk", false);
        _animator.SetBool("Eating", false);
      /*  if (!isIdle)
        {
            _animator.SetBool("Run", false);
            _animator.SetBool("Walk", false);
            _animator.SetBool("Eating", false);
            isRuning = false;
            isWalking = false;
            isIdle = true;
            isEating = false;
        }*/
    }
    public void Eat_Animation()
    {
        _animator.SetBool("Run", false);
        _animator.SetBool("Walk", false);
        _animator.SetBool("Eating", true);
      /*  if (!isEating)
        {
            _animator.SetBool("Run", false);
            _animator.SetBool("Walk", false);
            _animator.SetBool("Eating", true);
            isRuning = false;
            isWalking = false;
            isIdle = false;
            isEating = true;
        }*/
    }


}
