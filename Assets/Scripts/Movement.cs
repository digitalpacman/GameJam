using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour {

    public NavMeshAgent Agent { get; private set; }

	//
	void Start () {
        Agent = GetComponent<NavMeshAgent>();
        Agent.updateRotation = false;
    }
	
    //
	public void MoveTo(Vector3 position) {
        Agent.SetDestination(position);
    }
}
