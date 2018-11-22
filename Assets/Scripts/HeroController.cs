using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroController : MonoBehaviour {
    
    public Movement Movement { get; private set; }

    public EnemyController enemyTarget { get; set; }

    // Use this for initialization
    void Start () {
        Movement = GetComponent<Movement>();
	}

    //
    public void MoveTo(Vector3 position) {
        Movement.MoveTo(position);
    }

    //
    public void MoveAndAttack(EnemyController enemy) {
        enemyTarget = enemy;
        MoveTo(enemyTarget.transform.position);
    }

    //
    public void Attack(EnemyController enemy) {
        enemy.Die();
    }
}
