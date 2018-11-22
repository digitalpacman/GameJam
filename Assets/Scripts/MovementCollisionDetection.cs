using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCollisionDetection : MonoBehaviour {

    EnemyController Enemy;

    void Awake() {
        Enemy = GetComponentInParent<EnemyController>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (Enemy.Hero.enemyTarget == Enemy) {
            Enemy.Hero.MoveTo(Enemy.Hero.transform.position);
            Enemy.Hero.Attack(Enemy);
        }
    }
}
