using UnityEngine;
using System.Collections;

public class AnimateOnHover : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAttack()
    {
        anim.SetBool("isAttacking", true);
        anim.SetBool("isIdle", false);
    }

    public void PlayIdle()
    {
        anim.SetBool("isAttacking", false);
        anim.SetBool("isIdle", true);
    }

}