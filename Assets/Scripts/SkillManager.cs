using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {

    public int skillNum = 5;
    public GameObject[] Skills ;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    Skills[0].GetComponent<BaseSkill>().CastSkill();
                    Skills[0].GetComponent<BaseSkill>().MousePosition = hit.point;
                    Skills[0].GetComponent<BaseSkill>().origin = this.gameObject;
                    Skills[0].GetComponent<BaseSkill>().target = hit.collider.gameObject;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Skills[1].GetComponent<BaseSkill>().CastSkill();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Skills[2].GetComponent<BaseSkill>().CastSkill();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Skills[3].GetComponent<BaseSkill>().CastSkill();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Skills[3].GetComponent<BaseSkill>().CastSkill();
        }

    }
}
