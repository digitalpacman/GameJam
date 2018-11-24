using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour {

    public HeroController Hero { get; private set; }
    public Movement Movement { get; private set; }
    public BoxCollider2D Hitbox { get; private set; }

    bool Kill = false;

    //
    void Awake() {
        Hero = FindObjectOfType<HeroController>();
        Movement = GetComponent<Movement>();
        Hitbox = GetComponentInChildren<BoxCollider2D>();
    }

    //
    public void Update() {
        if (Kill) {
            Destroy(gameObject);
            return;
        }

       //Movement.MoveTo(Hero.transform.position);
    }
    
    //
	void OnMouseDown() {
        Hero.MoveAndAttack(this);
    }

    //
    public void Die() {
        //gameObject.SetActive(false);
        //gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        Kill = true;
    }
}
