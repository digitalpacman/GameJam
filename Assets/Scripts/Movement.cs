using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour {

    public NavMeshAgent Agent { get; private set; }

    void Awake() {
        Agent = GetComponent<NavMeshAgent>();
        Agent.updateRotation = false;
    }

	//
	void Start () {
    }
	
    //
	public void MoveTo(Vector3 position) {
        Agent.SetDestination(position);
    }
}
