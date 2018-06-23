using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Lang;
using Array = System.Array;

public class HeroAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0));
    }
}
