using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {


    
    public float speed = 3f;
    float Speed = 1f;

    public float attackDistance = 8f;

    EnemyAttack ea;
    NavMeshAgent agent;
    Animator anim;
    GameObject player;

    Vector3 Point;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        ea = GetComponent<EnemyAttack>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        anim.SetBool("isWalking", true);
        anim.SetFloat("WalkingSpeed", speed);
        agent.isStopped = false;
        agent.SetDestination(player.transform.position);

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            anim.SetBool("isWalking", false);
            anim.SetFloat("WalkingSpeed", 0);
            agent.isStopped = true;
        }
        if (Vector3.Distance(transform.position, player.transform.position) < attackDistance)
            ea.Attack();
    }
    
}
