using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroController : MonoBehaviour {

    public NavMeshAgent Agent;

	// Use this for initialization
	void Start () {
        Agent = GetComponent<NavMeshAgent>();
        Agent.enabled = false;
        Agent.enabled = true;
        //Agent.SetDestination(new Vector3(5, 5, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
        

	}
}
