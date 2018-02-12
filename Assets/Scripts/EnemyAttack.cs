using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    Animator anim;
    GameObject player;
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
   public void Attack()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.idle") && !anim.IsInTransition(0))
        {
            anim.SetInteger("AttackAnim", Random.Range(1, 4));
            anim.SetTrigger("Attack");
        }
    }
    public void PlayerDamagedCallBack()
    {
        player.GetComponent<CharacterStats>().Damage(GetComponent<CharacterStats>().findStatByName("Attack").amount, "Health");
        player.GetComponent<CharacterStats>().findStatByName("Health").print();


        player.GetComponent<Animator>().SetBool("isDamaged",true);
    }
    public void StopAttack()
    {

        anim.SetTrigger("StopAttack");
        anim.ResetTrigger("Attack");
    }
}
