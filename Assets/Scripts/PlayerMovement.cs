using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {


	public float speed = 3f;
	float Speed = 1f;
    public float maxSpeed = 32f;

    Vector3 direction = Vector3.zero; //WSAD dir
    NavMeshAgent agent;
	Animator anim;
    Vector3 Point;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        RaycastHit hit;
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer == 10)
                {
                    Point = hit.point;
                    agent.SetDestination(Point);
                    anim.SetFloat("Speed", Vector3.Magnitude(agent.velocity) / maxSpeed);
                    anim.SetBool("isMoving", true);
                }
                }
        }
        
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            anim.SetBool("isMoving", false);
        }
    }

}
