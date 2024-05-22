using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoors : MonoBehaviour
{
    Animator _animator;
    static readonly int OpenDoors = Animator.StringToHash("OpenDoors");


    void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.enabled = true;

    }

    void OpenDoorAnimation()
    {
        _animator.SetTrigger(OpenDoors);
        return;
    }

}
