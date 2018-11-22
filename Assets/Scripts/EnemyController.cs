using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour {

    public HeroController Hero { get; private set; }
    public Movement Movement { get; private set; }

    //
    void Awake() {
        Hero = FindObjectOfType<HeroController>();
        Movement = GetComponent<Movement>();
    }

    //
    public void Update() {
       Movement.MoveTo(Hero.transform.position);
    }
    
    //
	void OnMouseDown() {
        Hero.MoveAndAttack(this);
    }

    //
    public void Die() {
        gameObject.SetActive(false);
    }
}
