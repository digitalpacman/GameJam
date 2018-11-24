using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour {

    public NavMeshAgent Agent { get; private set; }

    public bool Moving { get; private set; }
    public Vector3 TargetPosition { get; private set; }

    void Awake() {
        Agent = GetComponent<NavMeshAgent>();
        Agent.updateRotation = false;

        TargetPosition = Vector3.forward;
    }

    void Update() {
        if (TargetPosition != Vector3.forward) {
            if (!Agent.pathPending && Moving) {
                if (Agent.remainingDistance <= Agent.stoppingDistance) {
                    Moving = false;
                    TargetPosition = Vector3.forward;
                }
                else {

                    // this can be used to keep pathfinding at certain intervals
                    /*
                    PathfindingTimer += Time.deltaTime;
                    if (PathfindingTimer >= PathfindingCooldown) {
                        NavMeshPath path = new NavMeshPath();
                        bool validPath = Agent.CalculatePath(destination.ToVector3(), path);
                        Agent.path = path;
                    }
                    */

                }
            }
            else if (Agent.pathPending) {

                // still looking for path so do nothing

            }
            else {
                Debug.Log(name + " has stopped moving by default condition. This probably is a bug.");
            }
        }
    }
	
    //
	public void MoveTo(Vector3 position) {
        Moving = true;
        TargetPosition = position;
        Agent.SetDestination(position);
    }
}
