using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingProjectile : MonoBehaviour {

    public float speed;
    public GameObject Player;
    public float Timer;
    NavMeshAgent agent;

    public GameObject origin;
    public GameObject target;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = Vector3.MoveTowards(transform.position,target.transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(this.gameObject);
            target.GetComponent<Animator>().SetTrigger("GetHit");
            target.GetComponent<CharacterStats>().Damage(10, "Health");
            Debug.Log(target.GetComponent<CharacterStats>().stats[0].amount);

        }
    }
}
