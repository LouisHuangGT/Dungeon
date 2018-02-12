using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour {

    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void isAttackingCallback()
    {
        anim.SetBool("isAttacking", false);
    }

    public void isCastingCallback()
    {
        anim.SetBool("isCasting", false);
    }
    public void isDeadCallback()
    {

    }
    public void isDamagedCallback()
    {
        anim.SetBool("isDamaged", false);
    }
}
