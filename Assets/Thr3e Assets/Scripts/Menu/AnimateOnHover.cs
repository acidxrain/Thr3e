using UnityEngine;
using System.Collections;

public class AnimateOnHover : MonoBehaviour
{
    public Animator anim;

    public void PlayAttack()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("IsAttacking", true);
    }

    public void PlayIdle()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("IsAttacking", false);
        anim.SetBool("IsWalking", false);
    }

}