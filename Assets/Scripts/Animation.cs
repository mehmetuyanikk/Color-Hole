using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] Animator _animator;

    private void Start()
    {
        AnimationPlay();
    }

    void AnimationPlay()
    {
        _animator.Play("Path");
    }

}
