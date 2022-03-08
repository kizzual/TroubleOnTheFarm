using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_animal : MonoBehaviour
{
    public Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Run_Animation()
    {
        _animator.SetBool("Run", true);
        _animator.SetBool("Walk", false);
    }
    public void Walk_Animation()
    {
        _animator.SetBool("Run", false);
        _animator.SetBool("Walk", true);

    }
    public void Idle_Animation()
    {
        _animator.SetBool("Run", false);
        _animator.SetBool("Walk", false);

    }


}
