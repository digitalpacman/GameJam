using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroController : MonoBehaviour {
    
    public Movement Movement { get; private set; }
    public SpriteRenderer SpriteRenderer { get; private set; }
    public BoxCollider2D Hitbox { get; private set; }

    public Animator Animator { get; private set; }
    public bool MovingAnimFlag { get; private set; }

    public int CurrentDirection { get; private set; }
    public Vector3 CurrentSteeringTarget { get; private set; }

    public EnemyController enemyTarget { get; set; }

    // Use this for initialization
    void Awake () {
        Movement = GetComponent<Movement>();
        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Hitbox = GetComponentInChildren<BoxCollider2D>();
        Animator = GetComponentInChildren<Animator>();
	}

    //
    void Update() {

        MoveUpdate();
    }

    //
    void MoveUpdate() {

        if (Movement.Moving) {
            if (!Movement.Agent.pathPending) {

                // start animating here since now we know path is found and we know direction hero should be facing
                if (!MovingAnimFlag) {
                    MovingAnimFlag = !MovingAnimFlag;
                    Animator.SetBool("isMoving", Movement.Moving);
                }

                // we only need to determine direction and change animation if there is a new steeringtarget (change in direction hero would be moving)
                if (CurrentSteeringTarget != Movement.Agent.steeringTarget) {

                    CurrentSteeringTarget = Movement.Agent.steeringTarget;

                    if (CurrentDirection == 3) {
                        SpriteRenderer.flipX = false;
                    }

                    // determine direction
                    int direction = -1;         // 0 - up, 1 - right, 2 - down, 3 - left
                    Vector3 directionVector = Movement.Agent.steeringTarget - transform.position;
                    float x = directionVector.x;
                    float y = directionVector.y;
                    if (Mathf.Abs(x) >= Mathf.Abs(y)) {
                        if (x >= 0) {
                            direction = 1;
                        }
                        else {
                            direction = 3;
                            SpriteRenderer.flipX = true;
                        }
                    }
                    else {
                        if (y >= 0) {
                            direction = 0;
                        }
                        else {
                            direction = 2;
                        }
                    }

                    if (direction == -1) {
                        Debug.Log("you have a logic error");
                    }

                    CurrentDirection = direction;

                    // animate
                    Animator.SetBool("change", true);
                    Animator.SetInteger("direction", CurrentDirection);

                }

            }
        }
        else {
            if (MovingAnimFlag) {
                MovingAnimFlag = !MovingAnimFlag;
                Animator.SetBool("isMoving", Movement.Moving);
            }
        }

    }

    //
    public void MoveTo(Vector3 position) {

        Movement.MoveTo(position);

        // set the steeringtarget to current position so that when new path is found, there will be a chance in direction
        CurrentSteeringTarget = transform.position;
    }

    //
    public void MoveAndAttack(EnemyController enemy) {

        enemyTarget = enemy;

        // check to see if hero is already colliding with the enemy. if it is, attack enemy and retirn out of function
        Collider2D[] overlappingColliders = new Collider2D[16];
        ContactFilter2D filter = new ContactFilter2D();
        filter.useTriggers = true;
        
        int colliderCount = Hitbox.OverlapCollider(filter, overlappingColliders);
        for (int i = 0; i < colliderCount; i++) {
            Collider2D col = overlappingColliders[i];
            if (col == enemy.Hitbox) {
                Attack(enemy);
                return;
            }
        }
        
        // if the hero is not colliding with attack target, then move towards it to attack it
        MoveTo(enemyTarget.transform.position);
    }

    //
    public void Attack(EnemyController enemy) {
        enemy.Die();
    }
}
