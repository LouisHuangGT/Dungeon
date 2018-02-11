using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterStatsManager : MonoBehaviour {
    
    CharacterStats characterStats;
    
    public int statsNum = 4;
    public Stat[] stats = new Stat[4];


    private void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        
        stats[0] = new Stat("Health", 50, 0, 100);
        stats[1] = new Stat("Mana", 10, 0, 100);
        stats[2] = new Stat("Attack", 10, 0, 200);
        stats[3] = new Stat("Defense", 10, 0, 200);

        characterStats.stats = new List<Stat>(stats);
        
    }

    private void Update()
    {
        if (stats[0].amount <= stats[0].minAmount)
        {
            GetComponent<Animator>().SetBool("isDead",true);
            GetComponent<NavMeshAgent>().speed = 0;
            //GetComponent<NavMeshAgent>().enabled = false;
        }
    }

    void deathCallBack()
    {
        GameManager.GameOver();
    }
}
